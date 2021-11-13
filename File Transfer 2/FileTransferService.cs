using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Melodi.Networking;

namespace File_Transfer_2
{
    public static class FileTransferService
    {
        public static int Port = 5001;
        public static int TCPPacketSizeMax = 65535;
        public static int TCPPacketMarginSize = 535;
        public static int TCPPacketCalculatedSize => TCPPacketSizeMax - TCPPacketMarginSize;
        /* This is called a property, its a cross between a function and a variable.
         * It returns the result every time it is mentioned so it can change over time.
         * When the variables in it change. */
        public static string DownloadPath;
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
        }
        public static void Send(string destination, string file)
        {
            TCPConnectionClient client = new TCPConnectionClient(destination, Port);
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
                    byte[][] fileContentSplit = SplitForSending(fileContent, TCPPacketCalculatedSize);
                    
                    
                    
                    foreach (string chunk in fileContentSplit.Select(Convert.ToBase64String))
                        /* The select allows us to foreach the array really quickly do
                         * something to each part of it. In this case I am converting
                         * it all to base 64 strings. */
                        /* Base 64 strings allow us to store bytes without loosing any data in
                         * the conversion. */
                    {
                        client.Send(chunk);
                        Thread.Sleep(50);
                    }
                }
                else
                {
                    client.Stop();
                    MessageBox.Show("Server send invalid data back", "File sharing request failed", MessageBoxButtons.OK, MessageBoxIcon.Error);   
                }
            };
            client.Start();
        }
        public static void Init()
        {
            DownloadPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
            Server = new TCPConnectionServer(Port);

            Server.onConnect = client =>
            /* This is a delegate, it is an anonymous function, so it doesn't have a name
             * it is similar to an action. The code inside these run on a different thread
             * to the UI so the UI will not be affected unless we invoke it. The 'client'
             * part is what we choose to name the argument passed to us. */
            {
                DialogResult result = MessageBox.Show($"{client.Client.RemoteEndPoint} would like to send you a file", "File sharing request", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
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
                            AppendAllBytes(Path.Combine(DownloadPath, ConnectionFileName[clientId]), Convert.FromBase64String(message));
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
