
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Main_TabControl = new System.Windows.Forms.TabControl();
            this.Main_TabPage = new System.Windows.Forms.TabPage();
            this.EstimatedTimeLeft = new System.Windows.Forms.Label();
            this.speed = new System.Windows.Forms.Label();
            this.Close_Button = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.NoDevices_Label = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DeviceSelection_ListBox = new System.Windows.Forms.CheckedListBox();
            this.Send_Button = new System.Windows.Forms.Button();
            this.Main_Progressbar = new System.Windows.Forms.ProgressBar();
            this.Settings_TabPage = new System.Windows.Forms.TabPage();
            this.Discoverable_CheckBox = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.Main_TabPage.BackColor = System.Drawing.Color.White;
            this.Main_TabPage.Controls.Add(this.EstimatedTimeLeft);
            this.Main_TabPage.Controls.Add(this.speed);
            this.Main_TabPage.Controls.Add(this.Close_Button);
            this.Main_TabPage.Controls.Add(this.pictureBox1);
            this.Main_TabPage.Controls.Add(this.NoDevices_Label);
            this.Main_TabPage.Controls.Add(this.label3);
            this.Main_TabPage.Controls.Add(this.DeviceSelection_ListBox);
            this.Main_TabPage.Controls.Add(this.Send_Button);
            this.Main_TabPage.Controls.Add(this.Main_Progressbar);
            this.Main_TabPage.Location = new System.Drawing.Point(4, 22);
            this.Main_TabPage.Name = "Main_TabPage";
            this.Main_TabPage.Padding = new System.Windows.Forms.Padding(3);
            this.Main_TabPage.Size = new System.Drawing.Size(576, 284);
            this.Main_TabPage.TabIndex = 0;
            this.Main_TabPage.Text = "Main";
            // 
            // EstimatedTimeLeft
            // 
            this.EstimatedTimeLeft.AutoSize = true;
            this.EstimatedTimeLeft.Location = new System.Drawing.Point(199, 196);
            this.EstimatedTimeLeft.Name = "EstimatedTimeLeft";
            this.EstimatedTimeLeft.Size = new System.Drawing.Size(35, 13);
            this.EstimatedTimeLeft.TabIndex = 15;
            this.EstimatedTimeLeft.Text = "label4";
            // 
            // speed
            // 
            this.speed.AutoSize = true;
            this.speed.Location = new System.Drawing.Point(192, 196);
            this.speed.Name = "speed";
            this.speed.Size = new System.Drawing.Size(0, 13);
            this.speed.TabIndex = 14;
            // 
            // Close_Button
            // 
            this.Close_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Close_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Close_Button.Location = new System.Drawing.Point(142, 224);
            this.Close_Button.Name = "Close_Button";
            this.Close_Button.Size = new System.Drawing.Size(130, 25);
            this.Close_Button.TabIndex = 13;
            this.Close_Button.Text = "Quit";
            this.Close_Button.UseVisualStyleBackColor = true;
            this.Close_Button.Click += new System.EventHandler(this.Close_Button_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(110, 61);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(196, 115);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // NoDevices_Label
            // 
            this.NoDevices_Label.AutoSize = true;
            this.NoDevices_Label.BackColor = System.Drawing.Color.White;
            this.NoDevices_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoDevices_Label.Location = new System.Drawing.Point(419, 130);
            this.NoDevices_Label.Name = "NoDevices_Label";
            this.NoDevices_Label.Size = new System.Drawing.Size(107, 30);
            this.NoDevices_Label.TabIndex = 11;
            this.NoDevices_Label.Text = "No Devices Found\r\n:(";
            this.NoDevices_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.NoDevices_Label.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(408, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Available Devices";
            // 
            // DeviceSelection_ListBox
            // 
            this.DeviceSelection_ListBox.BackColor = System.Drawing.Color.White;
            this.DeviceSelection_ListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DeviceSelection_ListBox.CheckOnClick = true;
            this.DeviceSelection_ListBox.FormattingEnabled = true;
            this.DeviceSelection_ListBox.Location = new System.Drawing.Point(389, 40);
            this.DeviceSelection_ListBox.Name = "DeviceSelection_ListBox";
            this.DeviceSelection_ListBox.Size = new System.Drawing.Size(181, 225);
            this.DeviceSelection_ListBox.TabIndex = 7;
            // 
            // Send_Button
            // 
            this.Send_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Send_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Send_Button.Location = new System.Drawing.Point(110, 184);
            this.Send_Button.Name = "Send_Button";
            this.Send_Button.Size = new System.Drawing.Size(196, 37);
            this.Send_Button.TabIndex = 0;
            this.Send_Button.Text = "Send";
            this.Send_Button.UseVisualStyleBackColor = true;
            this.Send_Button.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // Main_Progressbar
            // 
            this.Main_Progressbar.Location = new System.Drawing.Point(40, 184);
            this.Main_Progressbar.Name = "Main_Progressbar";
            this.Main_Progressbar.Size = new System.Drawing.Size(321, 37);
            this.Main_Progressbar.TabIndex = 4;
            this.Main_Progressbar.Visible = false;
            // 
            // Settings_TabPage
            // 
            this.Settings_TabPage.BackColor = System.Drawing.Color.White;
            this.Settings_TabPage.Controls.Add(this.Discoverable_CheckBox);
            this.Settings_TabPage.Controls.Add(this.textBox1);
            this.Settings_TabPage.Controls.Add(this.DownloadPath_TextBox);
            this.Settings_TabPage.Controls.Add(this.label2);
            this.Settings_TabPage.Controls.Add(this.SignUp_Button);
            this.Settings_TabPage.Controls.Add(this.label1);
            this.Settings_TabPage.Controls.Add(this.Username_TextBox);
            this.Settings_TabPage.Location = new System.Drawing.Point(4, 22);
            this.Settings_TabPage.Name = "Settings_TabPage";
            this.Settings_TabPage.Padding = new System.Windows.Forms.Padding(3);
            this.Settings_TabPage.Size = new System.Drawing.Size(576, 284);
            this.Settings_TabPage.TabIndex = 1;
            this.Settings_TabPage.Text = "Settings";
            // 
            // Discoverable_CheckBox
            // 
            this.Discoverable_CheckBox.Checked = true;
            this.Discoverable_CheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Discoverable_CheckBox.Location = new System.Drawing.Point(107, 186);
            this.Discoverable_CheckBox.Name = "Discoverable_CheckBox";
            this.Discoverable_CheckBox.Size = new System.Drawing.Size(104, 24);
            this.Discoverable_CheckBox.TabIndex = 6;
            this.Discoverable_CheckBox.Text = "Enable";
            this.Discoverable_CheckBox.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(107, 158);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(182, 13);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "Discoverable:";
            // 
            // DownloadPath_TextBox
            // 
            this.DownloadPath_TextBox.Location = new System.Drawing.Point(107, 116);
            this.DownloadPath_TextBox.Name = "DownloadPath_TextBox";
            this.DownloadPath_TextBox.Size = new System.Drawing.Size(419, 20);
            this.DownloadPath_TextBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(107, 88);
            this.label2.Name = "label2";
            this.label2.ReadOnly = true;
            this.label2.Size = new System.Drawing.Size(182, 13);
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
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(107, 25);
            this.label1.Name = "label1";
            this.label1.ReadOnly = true;
            this.label1.Size = new System.Drawing.Size(182, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Username:";
            // 
            // Username_TextBox
            // 
            this.Username_TextBox.Location = new System.Drawing.Point(107, 48);
            this.Username_TextBox.Name = "Username_TextBox";
            this.Username_TextBox.Size = new System.Drawing.Size(182, 20);
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
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(594, 324);
            this.Controls.Add(this.Main_TabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "File Transfer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Main_TabControl.ResumeLayout(false);
            this.Main_TabPage.ResumeLayout(false);
            this.Main_TabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.Settings_TabPage.ResumeLayout(false);
            this.Settings_TabPage.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox Discoverable_CheckBox;

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
        public System.Windows.Forms.CheckedListBox DeviceSelection_ListBox;
        public System.Windows.Forms.Button Send_Button;
        public System.Windows.Forms.ProgressBar Main_Progressbar;
        private System.ComponentModel.BackgroundWorker Main_BackgroundWorker;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label NoDevices_Label;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Button Close_Button;
        private System.Windows.Forms.Label speed;
        public System.Windows.Forms.Label EstimatedTimeLeft;
    }
}

