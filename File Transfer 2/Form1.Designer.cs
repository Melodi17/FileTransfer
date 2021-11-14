
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
            this.Main_TabControl = new System.Windows.Forms.TabControl();
            this.Main_TabPage = new System.Windows.Forms.TabPage();
            this.Eta_TextBox = new System.Windows.Forms.TextBox();
            this.Speed_TextBox = new System.Windows.Forms.TextBox();
            this.DeviceSelection_ListBox = new System.Windows.Forms.CheckedListBox();
            this.Send_Button = new System.Windows.Forms.Button();
            this.Main_Progressbar = new System.Windows.Forms.ProgressBar();
            this.Settings_TabPage = new System.Windows.Forms.TabPage();
            this.DownloadPath_TextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.TextBox();
            this.SignUp_Button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.TextBox();
            this.Username_TextBox = new System.Windows.Forms.TextBox();
            this.Upload_Timer = new System.Windows.Forms.Timer(this.components);
            this.openFileDlg = new System.Windows.Forms.OpenFileDialog();
            this.folderDlg = new System.Windows.Forms.FolderBrowserDialog();
            this.Main_BackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.Main_TabControl.SuspendLayout();
            this.Main_TabPage.SuspendLayout();
            this.Settings_TabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // Main_TabControl
            // 
            this.Main_TabControl.Controls.Add(this.Main_TabPage);
            this.Main_TabControl.Controls.Add(this.Settings_TabPage);
            this.Main_TabControl.Location = new System.Drawing.Point(0, 1);
            this.Main_TabControl.Name = "Main_TabControl";
            this.Main_TabControl.SelectedIndex = 0;
            this.Main_TabControl.Size = new System.Drawing.Size(584, 310);
            this.Main_TabControl.TabIndex = 3;
            // 
            // Main_TabPage
            // 
            this.Main_TabPage.Controls.Add(this.Eta_TextBox);
            this.Main_TabPage.Controls.Add(this.Speed_TextBox);
            this.Main_TabPage.Controls.Add(this.DeviceSelection_ListBox);
            this.Main_TabPage.Controls.Add(this.Send_Button);
            this.Main_TabPage.Controls.Add(this.Main_Progressbar);
            this.Main_TabPage.Location = new System.Drawing.Point(4, 29);
            this.Main_TabPage.Name = "Main_TabPage";
            this.Main_TabPage.Padding = new System.Windows.Forms.Padding(3);
            this.Main_TabPage.Size = new System.Drawing.Size(576, 277);
            this.Main_TabPage.TabIndex = 0;
            this.Main_TabPage.Text = "Main";
            this.Main_TabPage.UseVisualStyleBackColor = true;
            // 
            // Eta_TextBox
            // 
            this.Eta_TextBox.Location = new System.Drawing.Point(106, 194);
            this.Eta_TextBox.Name = "Eta_TextBox";
            this.Eta_TextBox.Size = new System.Drawing.Size(196, 26);
            this.Eta_TextBox.TabIndex = 9;
            this.Eta_TextBox.Visible = false;
            // 
            // Speed_TextBox
            // 
            this.Speed_TextBox.Location = new System.Drawing.Point(106, 171);
            this.Speed_TextBox.Name = "Speed_TextBox";
            this.Speed_TextBox.Size = new System.Drawing.Size(196, 26);
            this.Speed_TextBox.TabIndex = 4;
            this.Speed_TextBox.Visible = false;
            // 
            // DeviceSelection_ListBox
            // 
            this.DeviceSelection_ListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DeviceSelection_ListBox.CheckOnClick = true;
            this.DeviceSelection_ListBox.FormattingEnabled = true;
            this.DeviceSelection_ListBox.Location = new System.Drawing.Point(395, 6);
            this.DeviceSelection_ListBox.Name = "DeviceSelection_ListBox";
            this.DeviceSelection_ListBox.Size = new System.Drawing.Size(178, 252);
            this.DeviceSelection_ListBox.TabIndex = 7;
            // 
            // Send_Button
            // 
            this.Send_Button.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Send_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.Send_Button.Location = new System.Drawing.Point(106, 129);
            this.Send_Button.Name = "Send_Button";
            this.Send_Button.Size = new System.Drawing.Size(196, 37);
            this.Send_Button.TabIndex = 0;
            this.Send_Button.Text = "send";
            this.Send_Button.UseVisualStyleBackColor = true;
            this.Send_Button.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // Main_Progressbar
            // 
            this.Main_Progressbar.Location = new System.Drawing.Point(40, 133);
            this.Main_Progressbar.Name = "Main_Progressbar";
            this.Main_Progressbar.Size = new System.Drawing.Size(321, 37);
            this.Main_Progressbar.TabIndex = 4;
            this.Main_Progressbar.Visible = false;
            // 
            // Settings_TabPage
            // 
            this.Settings_TabPage.Controls.Add(this.DownloadPath_TextBox);
            this.Settings_TabPage.Controls.Add(this.label2);
            this.Settings_TabPage.Controls.Add(this.SignUp_Button);
            this.Settings_TabPage.Controls.Add(this.label1);
            this.Settings_TabPage.Controls.Add(this.Username_TextBox);
            this.Settings_TabPage.Location = new System.Drawing.Point(4, 29);
            this.Settings_TabPage.Name = "Settings_TabPage";
            this.Settings_TabPage.Padding = new System.Windows.Forms.Padding(3);
            this.Settings_TabPage.Size = new System.Drawing.Size(576, 277);
            this.Settings_TabPage.TabIndex = 1;
            this.Settings_TabPage.Text = "Settings";
            this.Settings_TabPage.UseVisualStyleBackColor = true;
            // 
            // DownloadPath_TextBox
            // 
            this.DownloadPath_TextBox.Location = new System.Drawing.Point(107, 132);
            this.DownloadPath_TextBox.Name = "DownloadPath_TextBox";
            this.DownloadPath_TextBox.Size = new System.Drawing.Size(419, 26);
            this.DownloadPath_TextBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(107, 108);
            this.label2.Name = "label2";
            this.label2.ReadOnly = true;
            this.label2.Size = new System.Drawing.Size(182, 26);
            this.label2.TabIndex = 3;
            this.label2.Text = "Download location:";
            // 
            // SignUp_Button
            // 
            this.SignUp_Button.Location = new System.Drawing.Point(107, 228);
            this.SignUp_Button.Name = "SignUp_Button";
            this.SignUp_Button.Size = new System.Drawing.Size(182, 43);
            this.SignUp_Button.TabIndex = 2;
            this.SignUp_Button.TabStop = false;
            this.SignUp_Button.Text = "Save";
            this.SignUp_Button.UseVisualStyleBackColor = true;
            this.SignUp_Button.Click += new System.EventHandler(this.SignUp_Button_Click);
            // 
            // label1
            // 
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(107, 25);
            this.label1.Name = "label1";
            this.label1.ReadOnly = true;
            this.label1.Size = new System.Drawing.Size(182, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Username:";
            // 
            // Username_TextBox
            // 
            this.Username_TextBox.Location = new System.Drawing.Point(107, 48);
            this.Username_TextBox.Name = "Username_TextBox";
            this.Username_TextBox.Size = new System.Drawing.Size(182, 26);
            this.Username_TextBox.TabIndex = 0;
            // 
            // Upload_Timer
            // 
            this.Upload_Timer.Interval = 3000;
            // 
            // openFileDlg
            // 
            this.openFileDlg.FileName = "openFileDialog1";
            this.openFileDlg.RestoreDirectory = true;
            // 
            // Main_BackgroundWorker
            // 
            this.Main_BackgroundWorker.WorkerReportsProgress = true;
            this.Main_BackgroundWorker.WorkerSupportsCancellation = true;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(594, 324);
            this.Controls.Add(this.Main_TabControl);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Main_TabControl.ResumeLayout(false);
            this.Main_TabPage.ResumeLayout(false);
            this.Main_TabPage.PerformLayout();
            this.Settings_TabPage.ResumeLayout(false);
            this.Settings_TabPage.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl Main_TabControl;
        private System.Windows.Forms.TabPage Settings_TabPage;
        private System.Windows.Forms.TextBox DownloadPath_TextBox;
        private System.Windows.Forms.TextBox label2;
        private System.Windows.Forms.Button SignUp_Button;
        private System.Windows.Forms.TextBox label1;
        private System.Windows.Forms.TextBox Username_TextBox;
        private System.Windows.Forms.Timer Upload_Timer;
        private System.Windows.Forms.OpenFileDialog openFileDlg;
        private System.Windows.Forms.FolderBrowserDialog folderDlg;
        private System.Windows.Forms.TabPage Main_TabPage;
        private System.Windows.Forms.TextBox Eta_TextBox;
        private System.Windows.Forms.TextBox Speed_TextBox;
        public System.Windows.Forms.CheckedListBox DeviceSelection_ListBox;
        private System.Windows.Forms.Button Send_Button;
        public System.Windows.Forms.ProgressBar Main_Progressbar;
        private System.ComponentModel.BackgroundWorker Main_BackgroundWorker;
    }
}

