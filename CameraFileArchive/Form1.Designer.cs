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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxSrc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxDst = new System.Windows.Forms.TextBox();
            this.BrowseSrcButton = new System.Windows.Forms.Button();
            this.BrowseDstButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.GoButton = new System.Windows.Forms.Button();
            this.listBox = new System.Windows.Forms.ListBox();
            this.progress = new System.Windows.Forms.Label();
            this.bw = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Source directory";
            // 
            // textBoxSrc
            // 
            this.textBoxSrc.Location = new System.Drawing.Point(116, 6);
            this.textBoxSrc.Name = "textBoxSrc";
            this.textBoxSrc.Size = new System.Drawing.Size(211, 20);
            this.textBoxSrc.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Destination directory";
            // 
            // textBoxDst
            // 
            this.textBoxDst.Location = new System.Drawing.Point(116, 35);
            this.textBoxDst.Name = "textBoxDst";
            this.textBoxDst.Size = new System.Drawing.Size(211, 20);
            this.textBoxDst.TabIndex = 4;
            // 
            // BrowseSrcButton
            // 
            this.BrowseSrcButton.Location = new System.Drawing.Point(333, 4);
            this.BrowseSrcButton.Name = "BrowseSrcButton";
            this.BrowseSrcButton.Size = new System.Drawing.Size(59, 23);
            this.BrowseSrcButton.TabIndex = 3;
            this.BrowseSrcButton.Text = "Browse...";
            this.BrowseSrcButton.UseVisualStyleBackColor = true;
            this.BrowseSrcButton.Click += new System.EventHandler(this.BrowseSrcButton_Click);
            // 
            // BrowseDstButton
            // 
            this.BrowseDstButton.Location = new System.Drawing.Point(333, 34);
            this.BrowseDstButton.Name = "BrowseDstButton";
            this.BrowseDstButton.Size = new System.Drawing.Size(59, 23);
            this.BrowseDstButton.TabIndex = 5;
            this.BrowseDstButton.Text = "Browse...";
            this.BrowseDstButton.UseVisualStyleBackColor = true;
            this.BrowseDstButton.Click += new System.EventHandler(this.BrowseDstButton_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(116, 64);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(211, 23);
            this.progressBar.TabIndex = 6;
            this.progressBar.Visible = false;
            // 
            // GoButton
            // 
            this.GoButton.Location = new System.Drawing.Point(333, 64);
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
            this.listBox.Size = new System.Drawing.Size(382, 56);
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
            this.bw.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_RunWorkerCompleted);
            this.bw.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bw_ProgressChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 160);
            this.Controls.Add(this.progress);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.GoButton);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.BrowseDstButton);
            this.Controls.Add(this.BrowseSrcButton);
            this.Controls.Add(this.textBoxDst);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxSrc);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxSrc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxDst;
        private System.Windows.Forms.Button BrowseSrcButton;
        private System.Windows.Forms.Button BrowseDstButton;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button GoButton;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Label progress;
        private System.ComponentModel.BackgroundWorker bw;
    }
}

