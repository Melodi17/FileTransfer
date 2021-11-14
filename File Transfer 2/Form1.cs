using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace File_Transfer_2
{
    public partial class Form1 : Form
    {
        public string DataPath;
        public string Username;
        public string DownloadPath;
        public string AllowedCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789-";

        public Form1()
        {
            InitializeComponent();
            LoadSettings();
            Main_Progressbar.Hide();
            
            string exeLocation = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            /* This will get the exe location and find the path of the folder it is in. */
            
            DataPath = Path.Combine(exeLocation, "Data");
            /* This allows us to create a path in a neater way. */

            Username = $"DefaultUser{new Random().Next(111, 999)}";
            DownloadPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
            
            Directory.CreateDirectory(DataPath);
            /* If it already exists, the code will automatically
             * ignore it. */
        }

        private Dictionary<string, string> ReadConfig(string file)
        {
            string[] content = File.ReadAllLines(file);
            return content.ToDictionary(x => x.Split('=')[0].Trim(), x => x.Split('=').Length > 1 ? x.Split('=')[1].Trim() : "");
            /* Converts a=b to a dictionary. Don't worry its complicated for me as well. */
        }

        private void SaveSettings()
        {
            string settingsFile = Path.Combine(DataPath, "settings.config");
            if (Username_TextBox.Text.All(x => AllowedCharacters.Contains(x)) && Directory.Exists(DownloadPath_TextBox.Text))
                /* Makes sure all letters in username are allowed characters and that the download
                 * folder does actually exist. */
            {
                Username = Username_TextBox.Text;
                DownloadPath = DownloadPath_TextBox.Text;
                File.WriteAllText(settingsFile, $"Username = {Username}\nDownload Folder = {DownloadPath}");
            }
            else
            {
                DialogResult result = MessageBox.Show(
                    "Your config files have some issues that need to be\nfixed, would you like to reset them?", "Config File Errors", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    File.WriteAllText(settingsFile, $"Username = {Username}\nDownload Folder = {DownloadPath}");
                    Username_TextBox.Text = Username;
                    DownloadPath_TextBox.Text = DownloadPath;
                }
                else
                {
                    Main_TabPage.Visible = false;
                    Main_TabControl.SelectedTab = Settings_TabPage;
                }
            }
        }
        private void LoadSettings()
        {
            string settingsFile = Path.Combine(DataPath, "settings.config");
            if (File.Exists(settingsFile))
            {
                Dictionary<string, string> config = ReadConfig(settingsFile);
                if (config.ContainsKey("Username") && config.ContainsKey("Download Folder"))
                {
                    if (config["Username"].All(x => AllowedCharacters.Contains(x)) && Directory.Exists(config["Download Folder"]))
                        /* Makes sure all letters in username are allowed characters and that the download
                         * folder does actually exist. */
                    {
                        Username = config["Username"];
                        DownloadPath = config["Download Folder"];
                        
                        Username_TextBox.Text = Username;
                        DownloadPath_TextBox.Text = DownloadPath;
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show(
                            "Your config files have some issues that need to be\nfixed, would you like to reset them?", "Config File Errors", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (result == DialogResult.Yes)
                        {
                            File.WriteAllText(settingsFile, $"Username = {Username}\nDownload Folder = {DownloadPath}");
                            
                            Username_TextBox.Text = Username;
                            DownloadPath_TextBox.Text = DownloadPath;
                        }
                        else
                        {
                            Main_TabPage.Visible = false;
                            Main_TabControl.SelectedTab = Settings_TabPage;
                        }
                    }
                }
            }
            else
            {
                File.WriteAllText(settingsFile, $"Username = {Username}\nDownload Folder = {DownloadPath}");
            }
        }


        // Code to fix below
        #region Old Code
        //private void Authenticate()
        //{
        //    string path = ExeFilePath.Replace(ExeName, "");
        //    if (File.Exists(path + "\\Data\\settings.config") && Directory.Exists(path + "\\Data"))
        //    {
        //        if (File.ReadAllText(path + "\\Data\\settings.config") == "")
        //        {
        //            File.WriteAllText(path + "\\Data\\settings.config", "Username = \nDownload Folder = ");
        //        }
        //        string[] contents = File.ReadAllLines(path + "\\Data\\settings.config");
        //        username = contents[0].Replace("Username = ", "");
        //        downloadfolder = contents[1].Replace("Download Folder = ", "");
        //        if (downloadfolder == "" || !Directory.Exists(downloadfolder))
        //        {
        //            downloadfolder = System.Environment.ExpandEnvironmentVariables("%userprofile%\\downloads\\");
        //        }
        //        DownloadPath.Text = downloadfolder;
        //        if (username == "" || username.Contains(":") || username.Contains(" "))
        //        {
        //            tabControl1.TabPages.Remove(Main);
        //        }
        //        else
        //        {
        //            if (tabControl1.TabCount == 1)
        //            {
        //                tabControl1.TabPages.Insert(0, Main);
        //            }
        //            tabControl1.SelectedIndex = 0;
        //            input1.Text = username;
        //            StartListening();
        //            Sendtext("~ping");
        //        }

        //    }
        //    else
        //    {
        //        if (Directory.Exists(path + "\\Data"))
        //        {
        //            Directory.Delete(path + "\\Data");
        //        }
        //        Directory.CreateDirectory(path + "\\Data");
        //        File.Create(path + "\\Data\\settings.config").Dispose();

        //        Authenticate();
        //    }

        //}
        //private void StartListening()
        //{

        //    ar_2 = udp2.BeginReceive(Receivetext, new object());

        //}
        //private void DataReceived(object sender, SimpleTCP.Message bytes)
        //{
        //    if (receivedbytes.Length == 0)
        //    {
        //        stopwatch.Restart();
        //    }
        //    receivedbytes = CombineBytes(receivedbytes, bytes.Data);
        //    try
        //    {
        //        if (stopwatch.ElapsedMilliseconds >= laststamped + 1000)
        //        {
        //            int speedkb = byteslastsec / ((int)stopwatch.ElapsedMilliseconds - laststamped);
        //            int Est_Sec_Left = (filesize - receivedbytes.Length) / (receivedbytes.Length / stopwatch.Elapsed.Seconds);
        //            TimeSpan time = TimeSpan.FromSeconds(Est_Sec_Left);
        //            string str = time.ToString(@"hh\:mm\:ss");
        //            if (InvokeRequired)
        //            {
        //                this.Invoke(new MethodInvoker(delegate
        //                {
        //                    try
        //                    {
        //                        speed.Text = "Speed: " + speedkb.ToString() + " Kbps";
        //                        eta.Text = "Estimated Remaining time = " + str;
        //                    }
        //                    catch { /* i dont care */ }
        //                }));
        //            }
        //            else
        //            {
        //                speed.Text = "Speed: " + speedkb.ToString() + " Kbps";
        //                eta.Text = "Estimated Remaining time = " + str;
        //            }
        //            byteslastsec = 0;
        //            laststamped = (int)stopwatch.ElapsedMilliseconds;
        //        }
        //        else
        //        {
        //            byteslastsec = byteslastsec + bytes.Data.Length;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //    };
        //    if (InvokeRequired)
        //    {
        //        this.Invoke(new MethodInvoker(delegate
        //        {
        //            try
        //            {
        //                progressBar1.Value = receivedbytes.Length;
        //            }
        //            catch { /* i don't care*/ }

        //        }));
        //    }
        //    else
        //    {
        //        progressBar1.Value = receivedbytes.Length;
        //    }
        //    if (receivedbytes.Length == filesize)
        //    {
        //        stopwatch.Stop();
        //        File.Create(downloadfolder + downloadingfilename).Dispose();
        //        File.WriteAllBytes(downloadfolder + downloadingfilename, receivedbytes);
        //        receivedbytes = new byte[0];
        //        TimeSpan tspan = stopwatch.Elapsed;
        //        string time = String.Format(" Time elapsed: {0:00}:{1:00}:{2:00}.{3:00} ", tspan.Hours, tspan.Minutes, tspan.Seconds, tspan.Milliseconds / 10);
        //        string message = "received " + downloadingfilename + " from " + sendername;
        //        if (InvokeRequired)
        //        {
        //            this.Invoke(new MethodInvoker(delegate
        //            {
        //                progressBar1.Hide();
        //                progressBar1.Value = 0;
        //                sendbutton.Show();
        //                speed.Hide();
        //                eta.Hide();
        //            }));
        //        }
        //        else
        //        {
        //            progressBar1.Hide();
        //            progressBar1.Value = 0;
        //            sendbutton.Show();
        //            speed.Hide();
        //            eta.Hide();
        //        }
        //        MessageBox.Show(message + time);
        //    }

        //}
        //private void Receivetext(IAsyncResult ar_2)

        //{
        //    IPEndPoint ip = new IPEndPoint(IPAddress.Any, infoport);
        //    string message = Encoding.ASCII.GetString(udp2.EndReceive(ar_2, ref ip));
        //    if (message.Contains("~"))
        //    {
        //        string myip = Dns.GetHostEntry(Dns.GetHostName()).AddressList[1].ToString();
        //        string sender = ip.Address.ToString();
        //        if (message == "~ping")
        //        {
        //            string selecteditems = "";
        //            if (InvokeRequired)
        //            {
        //                this.Invoke(new MethodInvoker(delegate
        //                {
        //                    checkedListBox1.Items.Clear();
        //                }));
        //            }
        //            else
        //            {
        //                checkedListBox1.Items.Clear();
        //            }
        //            Sendtext("~resping " + username + " " + myip);
        //        }
        //        else
        //        {
        //            string[] args = message.Split(' ');
        //            if (args[0] == "~resping")
        //            {
        //                if (InvokeRequired)
        //                {
        //                    this.Invoke(new MethodInvoker(delegate { checkedListBox1.Items.Add(args[1] + ":" + args[2]); }));
        //                }
        //                else
        //                {
        //                    checkedListBox1.Items.Add(args[1] + ":" + args[2]);
        //                }
        //            }
        //            if (args[0] == "~uploading")
        //            {

        //                string[] ips = args[1].Split(',');
        //                bool access = false;
        //                for (int i = 0; i < ips.Length; i++)
        //                {
        //                    if (ips[i] == myip)
        //                    {
        //                        access = true;
        //                    }
        //                }
        //                if (access)
        //                {
        //                    senderip = sender;
        //                    downloadingfilename = args[2];
        //                    sendername = args[3];
        //                    filesize = Int32.Parse(args[4]);

        //                    try
        //                    {
        //                        client = new SimpleTcpClient();
        //                        client.StringEncoder = Encoding.ASCII;
        //                        client.DataReceived += DataReceived;
        //                        client.Connect(senderip, byteport);
        //                    }
        //                    catch
        //                    {
        //                    }


        //                    if (InvokeRequired)
        //                    {
        //                        this.Invoke(new MethodInvoker(delegate
        //                        {
        //                            progressBar1.Show();
        //                            progressBar1.Maximum = filesize;
        //                            progressBar1.Value = 0;
        //                            sendbutton.Hide();
        //                            speed.Show();
        //                            eta.Show();
        //                        }));
        //                    }
        //                    else
        //                    {
        //                        progressBar1.Show();
        //                        progressBar1.Maximum = filesize;
        //                        progressBar1.Value = 0;
        //                        speed.Show();
        //                        eta.Show();
        //                    }
        //                }
        //            }
        //        }

        //    }
        //    StartListening();
        //}
        //private void Sendbutton_Click(object sender, EventArgs e)
        //{
        //    string recipients = "";
        //    foreach (string item in checkedListBox1.SelectedItems)
        //    {
        //        if (recipients != "")
        //        {
        //            recipients += ",";
        //        }
        //        recipients += item.Split(':')[1];
        //    }
        //    if (recipients != "")
        //    {
        //        if (openFileDlg.ShowDialog() == DialogResult.OK)
        //        {
        //            path = openFileDlg.FileName;
        //            FileInfo myfile = new FileInfo(path);
        //            try
        //            {
        //                string myip = Dns.GetHostEntry(Dns.GetHostName()).AddressList[1].ToString();
        //                string filename = Path.GetFileName(path);
        //                //upload();
        //                Thread t = new Thread(new ThreadStart(Upload));
        //                t.Start();
        //                Sendtext("~uploading " + recipients + " " + filename.Replace(" ", "_") + " " + username + " " + myfile.Length.ToString());
        //            }
        //            catch (Exception)
        //            {
        //                MessageBox.Show("This application has experienced an unrecoverable error, restarting application.");
        //                Application.Restart();
        //            }
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Choose a recipient first!");
        //    }
        //}
        //private byte[][] SplitForSending(byte[] buffer, int blockSize)
        //{
        //    byte[][] blocks = new byte[(buffer.Length + blockSize - 1) / blockSize][];

        //    for (int i = 0, j = 0; i < blocks.Length; i++, j += blockSize)
        //    {
        //        blocks[i] = new byte[Math.Min(blockSize, buffer.Length - j)];
        //        Array.Copy(buffer, j, blocks[i], 0, blocks[i].Length);
        //    }

        //    return blocks;
        //}
        //private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    Upload();
        //}
        //private void Upload()
        //{
        //    ThreadPool.QueueUserWorkItem(o =>
        //    {
        //        TcpListener server = new TcpListener(IPAddress.Any, byteport);
        //        server.Start();
        //        while (true)
        //        {
        //            TcpClient client = server.AcceptTcpClient();
        //            NetworkStream ns = client.GetStream();
        //            while (client.Connected)
        //            {
        //                FileInfo MyFile = new FileInfo(path);
        //                string filename = Path.GetFileName(path);
        //                int i = 0;
        //                int timeout = 1;
        //                int chunksize = 10000;
        //                byte[][] bte = SplitForSending(File.ReadAllBytes(path), chunksize);
        //                foreach (byte[] item in bte)
        //                {
        //                    ns.Write(item, 0, item.Length);
        //                    i = i + item.Length;
        //                    System.Threading.Thread.Sleep(timeout);
        //                }

        //                break;
        //            }
        //            break;
        //        }
        //        server.Stop();
        //    });
        //}
        //private void Sendtext(string msg)
        //{
        //    byte[] bytes = Encoding.ASCII.GetBytes(msg);
        //    UdpClient client = new UdpClient();
        //    IPEndPoint ip = new IPEndPoint(IPAddress.Parse("255.255.255.255"), infoport);
        //    client.Send(bytes, bytes.Length, ip);
        //    client.Close();
        //}
        //public static byte[] ReadBytes(string path, int offset, int count)
        //{
        //    using (var file = File.OpenRead(path))
        //    {
        //        file.Position = offset;
        //        offset = 0;
        //        byte[] buffer = new byte[count];
        //        int read;
        //        while (count > 0 && (read = file.Read(buffer, offset, count)) > 0)
        //        {
        //            offset += read;
        //            count -= read;
        //        }
        //        if (count < 0) throw new EndOfStreamException();
        //        return buffer;
        //    }

        //}
        //private byte[] CombineBytes(params byte[][] arrays)
        //{
        //    byte[] rv = new byte[arrays.Sum(a => a.Length)];
        //    int offset = 0;
        //    foreach (byte[] array in arrays)
        //    {
        //        System.Buffer.BlockCopy(array, 0, rv, offset, array.Length);
        //        offset += array.Length;
        //    }
        //    return rv;
        //}
        //private void Signup_Click(object sender, EventArgs e)
        //{
        //    if (input1.Text != "" && input1.Text != null)
        //    {
        //        string path = ExeFilePath.Replace(ExeName, "");
        //        string[] contents = File.ReadAllLines(path + "\\Data\\settings.config");
        //        contents[0] = "Username = " + input1.Text;
        //        contents[1] = "Download Folder = " + DownloadPath.Text;
        //        File.WriteAllLines(path + "\\Data\\settings.config", contents);
        //        Authenticate();
        //    }
        //    else
        //    {
        //        input1.Text = username;
        //    }
        //}
        //private void Button1_Click(object sender, EventArgs e)
        //{
        //    if (folderDlg.ShowDialog() == DialogResult.OK)
        //    {
        //        DownloadPath.Text = folderDlg.SelectedPath;
        //    }
        //}
        //private void Button2_Click(object sender, EventArgs e)
        //{
        //}
        //private void Ping_Click(object sender, EventArgs e)
        //{
        //    Sendtext("~ping");
        //}
        #endregion

        private void sendbutton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.ShowDialog();
            if (dialog.FileName != null)
            {
                new Thread(() =>
                {
                    Thread.CurrentThread.IsBackground = true;

                    FileTransferService.Send("user", dialog.FileName);
                }).Start();
            }
            else
            {
                MessageBox.Show("No file was selected", "File missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FileTransferService.Init(this);
            LoadSettings();
        }

        private void SignUp_Button_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }
    }
}