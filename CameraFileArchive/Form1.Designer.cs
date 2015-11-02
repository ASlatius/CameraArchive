namespace CameraFileArchive
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SourceDriveLabel = new System.Windows.Forms.Label();
            this.SourceDirLabel = new System.Windows.Forms.Label();
            this.textBoxDst = new System.Windows.Forms.TextBox();
            this.BrowseDstButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.GoButton = new System.Windows.Forms.Button();
            this.listBox = new System.Windows.Forms.ListBox();
            this.progress = new System.Windows.Forms.Label();
            this.bw = new System.ComponentModel.BackgroundWorker();
            this.srcDrive = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // SourceDriveLabel
            // 
            this.SourceDriveLabel.AutoSize = true;
            this.SourceDriveLabel.Location = new System.Drawing.Point(7, 12);
            this.SourceDriveLabel.Name = "SourceDriveLabel";
            this.SourceDriveLabel.Size = new System.Drawing.Size(67, 13);
            this.SourceDriveLabel.TabIndex = 0;
            this.SourceDriveLabel.Text = "Source drive";
            // 
            // SourceDirLabel
            // 
            this.SourceDirLabel.AutoSize = true;
            this.SourceDirLabel.Location = new System.Drawing.Point(7, 38);
            this.SourceDirLabel.Name = "SourceDirLabel";
            this.SourceDirLabel.Size = new System.Drawing.Size(103, 13);
            this.SourceDirLabel.TabIndex = 2;
            this.SourceDirLabel.Text = "Destination directory";
            // 
            // textBoxDst
            // 
            this.textBoxDst.Location = new System.Drawing.Point(116, 35);
            this.textBoxDst.Name = "textBoxDst";
            this.textBoxDst.Size = new System.Drawing.Size(211, 20);
            this.textBoxDst.TabIndex = 4;
            // 
            // BrowseDstButton
            // 
            this.BrowseDstButton.Location = new System.Drawing.Point(333, 35);
            this.BrowseDstButton.Name = "BrowseDstButton";
            this.BrowseDstButton.Size = new System.Drawing.Size(59, 23);
            this.BrowseDstButton.TabIndex = 5;
            this.BrowseDstButton.Text = "Browse...";
            this.BrowseDstButton.UseVisualStyleBackColor = true;
            this.BrowseDstButton.Click += new System.EventHandler(this.BrowseDstButton_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(116, 63);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(211, 23);
            this.progressBar.TabIndex = 6;
            this.progressBar.Visible = false;
            // 
            // GoButton
            // 
            this.GoButton.Location = new System.Drawing.Point(333, 63);
            this.GoButton.Name = "GoButton";
            this.GoButton.Size = new System.Drawing.Size(59, 23);
            this.GoButton.TabIndex = 1;
            this.GoButton.Text = "Go";
            this.GoButton.UseVisualStyleBackColor = true;
            this.GoButton.Click += new System.EventHandler(this.GoButton_Click);
            // 
            // listBox
            // 
            this.listBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.listBox.FormattingEnabled = true;
            this.listBox.HorizontalScrollbar = true;
            this.listBox.Location = new System.Drawing.Point(10, 94);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(382, 82);
            this.listBox.TabIndex = 6;
            // 
            // progress
            // 
            this.progress.AutoSize = true;
            this.progress.Location = new System.Drawing.Point(7, 69);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(104, 13);
            this.progress.TabIndex = 9;
            this.progress.Text = "progess....................";
            this.progress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.progress.Visible = false;
            // 
            // bw
            // 
            this.bw.WorkerReportsProgress = true;
            this.bw.WorkerSupportsCancellation = true;
            this.bw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_DoWork);
            this.bw.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bw_ProgressChanged);
            this.bw.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_RunWorkerCompleted);
            // 
            // srcDrive
            // 
            this.srcDrive.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.srcDrive.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.srcDrive.FormattingEnabled = true;
            this.srcDrive.Location = new System.Drawing.Point(116, 9);
            this.srcDrive.Name = "srcDrive";
            this.srcDrive.Size = new System.Drawing.Size(211, 21);
            this.srcDrive.TabIndex = 10;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 187);
            this.Controls.Add(this.srcDrive);
            this.Controls.Add(this.progress);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.GoButton);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.BrowseDstButton);
            this.Controls.Add(this.textBoxDst);
            this.Controls.Add(this.SourceDirLabel);
            this.Controls.Add(this.SourceDriveLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Camera Photo Backup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Label SourceDriveLabel;
        private System.Windows.Forms.Label SourceDirLabel;
        private System.Windows.Forms.TextBox textBoxDst;
        private System.Windows.Forms.Button BrowseDstButton;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button GoButton;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Label progress;
        private System.ComponentModel.BackgroundWorker bw;
        private System.Windows.Forms.ComboBox srcDrive;
    }
}

