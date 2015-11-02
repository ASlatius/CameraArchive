using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;

namespace CameraFileArchive
{
    public partial class MainForm : Form
    {
        private RegistryKey regKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\\CameraArchive");
        private DriveInfo[] allDrives = DriveInfo.GetDrives();
        private List<FileInfo> filesList = new List<FileInfo>();
        private DateTime lastProgressUpdate;

        public MainForm()
        {
            InitializeComponent();
            foreach( DriveInfo drive in this.allDrives )
            {
                if (drive.DriveType == DriveType.Fixed    ||
                    drive.DriveType == DriveType.Removable  )
                {
                    srcDrive.Items.Add(drive.Name);
                }
            }
            srcDrive.SelectedItem = (string)regKey.GetValue("LastSrc", "");
            textBoxDst.Text = (string)regKey.GetValue("LastDst", "");
        }

        private void BrowseSrcButton_Click(object sender, EventArgs e)
        {
            //if (textBoxSrc.Text != "")
            //    folderBrowserDialog.SelectedPath = textBoxSrc.Text;

            //folderBrowserDialog.ShowNewFolderButton = false;
            //folderBrowserDialog.ShowDialog();
            //textBoxSrc.Text = folderBrowserDialog.SelectedPath;
        }

        private void BrowseDstButton_Click(object sender, EventArgs e)
        {
            if (textBoxDst.Text != "")
                folderBrowserDialog.SelectedPath = textBoxDst.Text;

            folderBrowserDialog.ShowNewFolderButton = true;
            folderBrowserDialog.ShowDialog();
            textBoxDst.Text = folderBrowserDialog.SelectedPath;
        }

        private void GoButton_Click(object sender, EventArgs e)
        {
            if ("Go" == GoButton.Text)
            {
                //Safety checks
                if (Directory.Exists(srcDrive.SelectedItem.ToString()) == false)
                {
                    MessageBox.Show("The source drive is not accessible!",
                                "Check drive", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (Directory.Exists(textBoxDst.Text) == false)
                {
                    MessageBox.Show("The destination path does not exsist!",
                                "Check path", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                //Store last used paths...
                regKey.SetValue("LastSrc", srcDrive.SelectedItem.ToString(), RegistryValueKind.String);
                regKey.SetValue("LastDst", textBoxDst.Text, RegistryValueKind.String);

                //Locate all files to copy
                DirSearch(srcDrive.SelectedItem.ToString(), "*.jpg");
                DirSearch(srcDrive.SelectedItem.ToString(), "*.mts");

                //Prepare userinterface for copy action...
                listBox.ResetText();
                listBox.Items.Add("Found " + filesList.Count() + " files to copy\n");
                progressBar.Maximum = filesList.Count();
                progressBar.Value = 0;
                progressBar.Visible = true;
                progress.Visible = true;
                GoButton.Text = "Cancel";
                srcDrive.Enabled = false;
                textBoxDst.Enabled = false;

                //Start copy
                lastProgressUpdate = System.DateTime.Now;
                bw.RunWorkerAsync();
            }
            else
            {
                listBox.Items.Add("Copy process canceled!");
                GoButton.Text = "Go";
                bw.CancelAsync();
            }
        }

        //This method is executed in a separate thread created by the background worker.  
        //so don't try to access any UI controls here!! (unless you use a delegate to do it)  
        //this attribute will prevent the debugger to stop here if any exception is raised.  
        //[System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            string destPath = "", result = "";
            int copyCnt = 0, skipCnt = 0;

            foreach (FileInfo file in filesList.ToArray())
            {
                if ((worker.CancellationPending == true))
                {
                    e.Cancel = true;
                    break;
                }
                destPath = textBoxDst.Text +
                           file.LastWriteTime.Year.ToString("0000") + "_" +
                           file.LastWriteTime.Month.ToString("00") + "_" +
                           file.LastWriteTime.Day.ToString("00") + "\\";

                if (Directory.Exists(destPath) == false)
                {
                    Directory.CreateDirectory(destPath);
                }
                if (File.Exists(destPath + file.Name) == false)
                {
                    file.CopyTo(destPath + file.Name);
                    copyCnt++;
                }
                else
                {
                    listBox.Items.Add("Skipped " + file.Name);
                    skipCnt++;
                }
                worker.ReportProgress((copyCnt + skipCnt), DateTime.Now);
            }
            if (copyCnt > 0)
            {
                result = "copied " + copyCnt + " files";
            }
            if (skipCnt > 0)
            {
                if (result.Length > 0)
                {
                    result += ", ";
                }
                result += "skipped " + skipCnt + " files";
            }
            e.Result = result;
        }

        //This event is raised on the main thread.  
        //It is safe to access UI controls here.  
        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            DateTime time = Convert.ToDateTime(e.UserState); //get additional information about progress  

            progressBar.Value = e.ProgressPercentage; //update progress bar  
            TimeSpan diff = time - lastProgressUpdate;

            float speed = (float)((filesList.ToArray()[e.ProgressPercentage].Length / (1024 * 1024)) / diff.TotalSeconds);
            if (speed < 100)
            {
                progress.Text = progressBar.Value.ToString() + "/" +
                                progressBar.Maximum.ToString() + " " +
                                speed.ToString("0.00") + "Mb/s";
            }
            else
            {
                progress.Text = progressBar.Value.ToString() + "/" +
                                progressBar.Maximum.ToString();
            }
            lastProgressUpdate = time;
        }

        //This is executed after the task is complete whatever the task has completed: 
        //  a) sucessfully, 
        //  b) with error,
        //  c) has been cancelled  
        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("The task has been cancelled");
            }
            else if (e.Error != null)
            {
                MessageBox.Show("Error. Details: " + (e.Error as Exception).ToString());
            }

            GoButton.Text = "Go";
            srcDrive.Enabled = true;
            textBoxDst.Enabled = true;
            progressBar.Value = 0;
            listBox.Items.Add(e.Result.ToString());
        }

        //Create a list of files that match the search condition in all of the subdirectories
        // in and below the supplied sDir
        private void DirSearch(string sDir, string search)
        {
            try
            {
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    foreach (string f in Directory.GetFiles(d, search))
                    {
                        filesList.Add( new FileInfo(f) );
                    }
                    DirSearch(d, search);
                }
            }
            catch (System.Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }
        }
    }
}
