
namespace File_Transfer_2
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Main = new System.Windows.Forms.TabPage();
            this.eta = new System.Windows.Forms.TextBox();
            this.speed = new System.Windows.Forms.TextBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.sendbutton = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.Settings = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.DownloadPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.TextBox();
            this.signup = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.TextBox();
            this.input1 = new System.Windows.Forms.TextBox();
            this.upload_timer = new System.Windows.Forms.Timer(this.components);
            this.openFileDlg = new System.Windows.Forms.OpenFileDialog();
            this.folderDlg = new System.Windows.Forms.FolderBrowserDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tabControl1.SuspendLayout();
            this.Main.SuspendLayout();
            this.Settings.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Main);
            this.tabControl1.Controls.Add(this.Settings);
            this.tabControl1.Location = new System.Drawing.Point(0, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(584, 310);
            this.tabControl1.TabIndex = 3;
            // 
            // Main
            // 
            this.Main.Controls.Add(this.eta);
            this.Main.Controls.Add(this.speed);
            this.Main.Controls.Add(this.checkedListBox1);
            this.Main.Controls.Add(this.sendbutton);
            this.Main.Controls.Add(this.progressBar1);
            this.Main.Location = new System.Drawing.Point(4, 25);
            this.Main.Name = "Main";
            this.Main.Padding = new System.Windows.Forms.Padding(3);
            this.Main.Size = new System.Drawing.Size(576, 281);
            this.Main.TabIndex = 0;
            this.Main.Text = "Main";
            this.Main.UseVisualStyleBackColor = true;
            // 
            // eta
            // 
            this.eta.Location = new System.Drawing.Point(106, 194);
            this.eta.Name = "eta";
            this.eta.Size = new System.Drawing.Size(196, 22);
            this.eta.TabIndex = 9;
            this.eta.Visible = false;
            // 
            // speed
            // 
            this.speed.Location = new System.Drawing.Point(106, 171);
            this.speed.Name = "speed";
            this.speed.Size = new System.Drawing.Size(196, 22);
            this.speed.TabIndex = 4;
            this.speed.Visible = false;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(395, 6);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(178, 255);
            this.checkedListBox1.TabIndex = 7;
            // 
            // sendbutton
            // 
            this.sendbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.sendbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendbutton.Location = new System.Drawing.Point(106, 131);
            this.sendbutton.Name = "sendbutton";
            this.sendbutton.Size = new System.Drawing.Size(196, 37);
            this.sendbutton.TabIndex = 0;
            this.sendbutton.Text = "send";
            this.sendbutton.UseVisualStyleBackColor = true;
            this.sendbutton.Click += new System.EventHandler(this.sendbutton_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(40, 133);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(321, 37);
            this.progressBar1.TabIndex = 4;
            // 
            // Settings
            // 
            this.Settings.Controls.Add(this.button1);
            this.Settings.Controls.Add(this.DownloadPath);
            this.Settings.Controls.Add(this.label2);
            this.Settings.Controls.Add(this.signup);
            this.Settings.Controls.Add(this.label1);
            this.Settings.Controls.Add(this.input1);
            this.Settings.Location = new System.Drawing.Point(4, 25);
            this.Settings.Name = "Settings";
            this.Settings.Padding = new System.Windows.Forms.Padding(3);
            this.Settings.Size = new System.Drawing.Size(576, 281);
            this.Settings.TabIndex = 1;
            this.Settings.Text = "Settings";
            this.Settings.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(107, 155);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(182, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "edit";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // DownloadPath
            // 
            this.DownloadPath.Location = new System.Drawing.Point(107, 132);
            this.DownloadPath.Name = "DownloadPath";
            this.DownloadPath.ReadOnly = true;
            this.DownloadPath.Size = new System.Drawing.Size(419, 22);
            this.DownloadPath.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(107, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(182, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "download location:";
            // 
            // signup
            // 
            this.signup.Location = new System.Drawing.Point(107, 230);
            this.signup.Name = "signup";
            this.signup.Size = new System.Drawing.Size(182, 43);
            this.signup.TabIndex = 2;
            this.signup.TabStop = false;
            this.signup.Text = "confirm";
            this.signup.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(107, 25);
            this.label1.Name = "label1";
            this.label1.ReadOnly = true;
            this.label1.Size = new System.Drawing.Size(182, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Username:";
            // 
            // input1
            // 
            this.input1.Location = new System.Drawing.Point(107, 48);
            this.input1.Name = "input1";
            this.input1.Size = new System.Drawing.Size(182, 22);
            this.input1.TabIndex = 0;
            // 
            // upload_timer
            // 
            this.upload_timer.Interval = 3000;
            // 
            // openFileDlg
            // 
            this.openFileDlg.FileName = "openFileDialog1";
            this.openFileDlg.RestoreDirectory = true;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(594, 324);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.Main.ResumeLayout(false);
            this.Main.PerformLayout();
            this.Settings.ResumeLayout(false);
            this.Settings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Settings;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox DownloadPath;
        private System.Windows.Forms.TextBox label2;
        private System.Windows.Forms.Button signup;
        private System.Windows.Forms.TextBox label1;
        private System.Windows.Forms.TextBox input1;
        private System.Windows.Forms.Timer upload_timer;
        private System.Windows.Forms.OpenFileDialog openFileDlg;
        private System.Windows.Forms.FolderBrowserDialog folderDlg;
        private System.Windows.Forms.TabPage Main;
        private System.Windows.Forms.TextBox eta;
        private System.Windows.Forms.TextBox speed;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button sendbutton;
        public System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

