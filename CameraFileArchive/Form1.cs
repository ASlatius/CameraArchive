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
        private RegistryKey regKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\CameraPhotoArchive");
        private FileInfo[] jpgFiles;
        private DateTime lastProgressUpdate;

        public MainForm()
        {
            InitializeComponent();
            textBoxSrc.Text = (string)regKey.GetValue("LastSrc", "");
            textBoxDst.Text = (string)regKey.GetValue("LastDst", "");
        }

        private void BrowseSrcButton_Click(object sender, EventArgs e)
        {
            if (textBoxSrc.Text != "")
                folderBrowserDialog.SelectedPath = textBoxSrc.Text;

            folderBrowserDialog.ShowNewFolderButton = false;
            folderBrowserDialog.ShowDialog();
            textBoxSrc.Text = folderBrowserDialog.SelectedPath;
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
            DialogResult result = DialogResult.Yes;

            if ("Go" == GoButton.Text)
            {
                if (Directory.Exists(textBoxSrc.Text) == false)
                {
                    MessageBox.Show("The source path does not exsist!",
                                "Check path", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (Directory.Exists(textBoxDst.Text) == false)
                {
                    MessageBox.Show("The destination path does not exsist!",
                                "Check path", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (textBoxSrc.Text.Contains("DCIM") != true)
                {
                    result = MessageBox.Show("The path does not contain 'DCIM' " +
                                "which is normal for a camera memory card.\n\n" +
                                "Are you sure you want to continue?",
                                "Check path", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                        return;
                }
                if (textBoxDst.Text.Substring(textBoxDst.Text.Length - 1) != "\\")
                {
                    textBoxDst.Text = textBoxDst.Text + "\\";
                }
                DirectoryInfo di = new DirectoryInfo(textBoxSrc.Text);
                jpgFiles = di.GetFiles("*.jpg");

                //Store last used paths...
                regKey.SetValue("LastSrc", textBoxSrc.Text, RegistryValueKind.String);
                regKey.SetValue("LastDst", textBoxDst.Text, RegistryValueKind.String);

                //Prepare userinterface for copy action...
                listBox.ResetText();
                listBox.Items.Add("Found " + jpgFiles.Count() + " files to copy\n");
                progressBar.Maximum = jpgFiles.Count();
                progressBar.Value = 0;
                progressBar.Visible = true;
                progress.Visible = true;
                GoButton.Text = "Cancel";

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
            string destPath = "";
            int i = 0;

            foreach (FileInfo file in jpgFiles)
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
                }
                worker.ReportProgress(i++, DateTime.Now);
            }
            e.Result = "Copied " + i + " files.";
        }

        //This event is raised on the main thread.  
        //It is safe to access UI controls here.  
        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            DateTime time = Convert.ToDateTime(e.UserState); //get additional information about progress  

            progressBar.Value = e.ProgressPercentage; //update progress bar  
            TimeSpan diff = time - lastProgressUpdate;

            float speed = (float)((jpgFiles[e.ProgressPercentage].Length / (1024 * 1024)) / diff.TotalSeconds);
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
            else
            {
                GoButton.Text = "Go";
                listBox.Items.Add(e.Result.ToString());
            }
        }
    }
}
