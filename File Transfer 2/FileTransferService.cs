using Melodi.Networking;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Threading;
using System.Windows.Forms;

namespace File_Transfer_2
{
    public static class FileTransferService
    {
        public static Form1 MainForm;
        public static int FilePort = 5001;
        public static int DiscoveryPort = 5002;
        public static int TCPPacketSizeMax = 65535;
        public static int TCPPacketMarginSize = 535;
        public static int TCPPacketCalculatedSize => TCPPacketSizeMax - TCPPacketMarginSize;
        /* This is called a property, its a cross between a function and a variable.
         * It returns the result every time it is mentioned so it can change over time.
         * When the variables in it change. */
        public static string DownloadPath => MainForm.DownloadPath;
        public static TCPConnectionServer Server;
        /* Only 'local' variables start with a lower-case letter, these are global because
         * they can be accessed anywhere in the code. Local variables are like the stuff
         * in function and are only temporary. */
        public static Dictionary<long, bool> ConnectionRequestAccept;
        /* A dictionary is like a list but instead of an index like this mylist[0] we do this
         * mydictionary["key"] so the 'index' is like the key to get the value
         * the long is basically just a number that can have a really high value
         * higher than an int, but it can only have positive numbers and 0. */
        public static Dictionary<long, string> ConnectionFileName;
        public static Dictionary<string, (string, DateTime)> KnownDevices;
        /* The key is the device 'friendly name' the value is the IP. This is so
         * we can talk to it from the listbox. */
        public static byte[][] SplitForSending(byte[] buffer, int blockSize)
        {
            byte[][] blocks = new byte[(buffer.Length + blockSize - 1) / blockSize][];

            for (int i = 0, j = 0; i < blocks.Length; i++, j += blockSize)
            {
                blocks[i] = new byte[Math.Min(blockSize, buffer.Length - j)];
                Array.Copy(buffer, j, blocks[i], 0, blocks[i].Length);
            }

            return blocks;
        }
        public static void AppendAllBytes(string path, byte[] bytes)
        {
            using (var stream = new FileStream(path, FileMode.Append))
            {
                stream.Write(bytes, 0, bytes.Length);
            }
        }
        public static void Discover()
        {
            // TODO: Implement this method/function
            KnownDevices = new Dictionary<string, (string, DateTime)>();

            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;

                UDPConnection connection = new UDPConnection(DiscoveryPort);
                connection.onMessage = (device, buffer, message) =>
                {
                    lock (KnownDevices)
                    {
                        foreach (var item in KnownDevices.ToArray())
                        {
                            if (item.Value.Item2.AddSeconds(5) < DateTime.Now)
                            {
                                MainForm.Invoke(new Action(() => MainForm.DeviceSelection_ListBox.Items.Remove(item.Key)));
                                KnownDevices.Remove(item.Key);   
                            }
                        }
                        if (!KnownDevices.ContainsKey(message))
                        {
                            MainForm.Invoke(new Action(() => MainForm.DeviceSelection_ListBox.Items.Add(message)));
                        }
                        KnownDevices[message] = (device.Address.ToString(), DateTime.Now);
                    }
                };
                connection.Start();
                while (true)
                {
                    connection.Send(MainForm.Username);
                    Thread.Sleep(1000 * 3);
                }
            }).Start();
        }
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
        public static void Send(string destination, string file)
        {
            TCPConnectionClient client = new TCPConnectionClient(destination, FilePort);
            client.onConnect = () =>
            {
                /* Do nothing for now */
            };
            client.onConnectFailed = () =>
            {
                client.Stop();
                MessageBox.Show("Server was unreachable", "File sharing request failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            };
            client.onDisconnect = () =>
            {
                client.Stop();
                MessageBox.Show("Server aborted request", "File sharing request aborted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            };
            client.onMessage = message =>
            {
                if (message == "Denied")
                {
                    client.Stop();
                    MessageBox.Show("Server denied request", "File sharing request denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (message == "Accepted")
                {
                    string flName = Path.GetFileName(file);
                    /* This will only get the file name like this
                     * we give it C:\users\melod\Documents\test.txt
                     * and it returns test.txt this is so the other side
                     * will know what type of file it is. */
                    client.Send(flName);
                    /* This tells the server what the file is called */

                    Thread.Sleep(1000);
                    /* Give the server some time to prepare */

                    byte[] fileContent = File.ReadAllBytes(file);
                    // TODO: Implement stream for big files

                    byte[][] fileContentSplit = SplitForSending(fileContent, TCPPacketCalculatedSize);

                    MainForm.Invoke(new Action(() =>
                    {
                        MainForm.Main_Progressbar.Maximum = fileContentSplit.Length;
                        MainForm.Main_Progressbar.Value = 0;
                        MainForm.Main_Progressbar.Visible = true;
                        MainForm.Send_Button.Visible = false;
                    }));

                    foreach (string chunk in fileContentSplit.Select(Convert.ToBase64String))
                    /* The select allows us to foreach the array really quickly do
                     * something to each part of it. In this case I am converting
                     * it all to base 64 strings.
                     * Base 64 strings allow us to store bytes without loosing any data in
                     * the conversion. */
                    {
                        client.Send(chunk);
                        MainForm.Invoke(new Action(() => MainForm.Main_Progressbar.Value++));
                        Thread.Sleep(50);
                    }

                    client.Send("~~~done~~~" + MD5ChecksumFile(file));
                    /* Now we send this to make the server check if the file is corrupted. */

                    Thread.Sleep(50);
                    /* Give the server some time to recieve last message before disconnect. */

                    client.Stop();

                    MainForm.Invoke(new Action(() =>
                    {
                        MainForm.Main_Progressbar.Value = MainForm.Main_Progressbar.Maximum;
                        MainForm.Main_Progressbar.Visible = false;
                        MainForm.Send_Button.Visible = true;
                    }));

                    MessageBox.Show("File was successfully transmitted to your destination(s)", "File share success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    client.Stop();
                    MessageBox.Show("Server send invalid data back", "File sharing request failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            client.Start();
        }
        public static string MD5ChecksumFile(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "").ToLower();
                }
            }
        }
        public static void Init(Form1 form1)
        {
            ConnectionRequestAccept = new Dictionary<long, bool>();
            ConnectionFileName = new Dictionary<long, string>();

            MainForm = form1;
            //DownloadPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
            Server = new TCPConnectionServer(FilePort);

            Server.onConnect = client =>
            /* This is a delegate, it is an anonymous function, so it doesn't have a name
             * it is similar to an action. The code inside these run on a different thread
             * to the UI so the UI will not be affected unless we invoke it. The 'client'
             * part is what we choose to name the argument passed to us. */
            {
                Func<KeyValuePair<string, (string, DateTime)>, bool> func = x => x.Value.Item1 == client.Client.RemoteEndPoint.ToString().Split(':')[0];
                string deviceDisplay = KnownDevices.Any(func) ? KnownDevices.First(func).Key : client.Client.RemoteEndPoint.ToString();
                DialogResult result = MessageBox.Show($"{deviceDisplay} would like to send you a file", "File sharing request", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    Server.Send(client, "Accepted");
                    ConnectionRequestAccept[client.SocketId()] = true;
                    /* Get ready for download bytes */
                }
                else
                {
                    Server.Send(client, "Denied");
                    ConnectionRequestAccept[client.SocketId()] = false;
                }
            };
            Server.onDisconnect = client =>
            {
                long clientId = client.SocketId();

                /* Delete connection record to free up space */

                if (ConnectionRequestAccept.ContainsKey(clientId)) ConnectionRequestAccept.Remove(clientId);
                if (ConnectionFileName.ContainsKey(clientId)) ConnectionFileName.Remove(clientId);
            };
            Server.onMessage = (client, message) =>
            {
                long clientId = client.SocketId();
                if (ConnectionRequestAccept.ContainsKey(clientId))
                {
                    if (ConnectionRequestAccept[clientId])
                    /* Makes sure we accepted the connection before allowing download */
                    {
                        if (ConnectionFileName.ContainsKey(clientId))
                        /* Work out if this is the first message, and if so, it will
                         * set the filename to this message. If not, it will start building
                         * the file. */
                        {
                            string flPath = Path.Combine(DownloadPath, ConnectionFileName[clientId]);
                            if (message.StartsWith("~~~done~~~"))
                            {
                                string hash = message.Replace("~~~done~~~", "");
                                string selfHash = MD5ChecksumFile(flPath);

                                if (hash == selfHash)
                                {
                                    DialogResult res = MessageBox.Show("File was successfully recieved, would you like to open it?", "File share success", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                    if (res == DialogResult.Yes)
                                    {
                                        Process.Start("explorer.exe", flPath);
                                    }
                                }
                                else
                                {
                                    DialogResult res = MessageBox.Show("The recieved file was corrupted, would you like to delete it?", "File sharing corrupted", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                                    if (res == DialogResult.Yes)
                                    {
                                        File.Delete(flPath);
                                    }
                                }
                            }

                            AppendAllBytes(flPath, Convert.FromBase64String(message));
                            /* Base 64 strings allow us to store bytes without loosing any data in
                             * the conversion. */
                        }
                        else
                        {
                            ConnectionFileName[clientId] = message;
                            File.WriteAllText(Path.Combine(DownloadPath, ConnectionFileName[clientId]), "");
                            /* Generate empty file */
                        }
                    }
                }
            };

            Server.Start();
            /* This will start listening for connections and run the delegates when they 
             * are triggered. The code will keep running one the server is started, saving
             * the UI thread for UI work only. */
        }
    }
}
