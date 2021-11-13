using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Melodi.Networking;

namespace File_Transfer_2
{
    public static class FileTransferService
    {
        public static int Port = 5001;
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
        public static void Discover()
        {
            // TODO: Implement this method/function
        }
        public static void Send(string destination, string file)
        {

        }
        public static void Init()
        {
            DownloadPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
            Server = new TCPConnectionServer(Port);

            Server.onConnect = client =>
            /* This is a delegate, it is an anonamous function, so it doesn't have a name
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
                /* Delete connection record to free up space */
            };
            Server.onMessage = (client, message) =>
            {
                long clientID = client.SocketId();
                if (ConnectionRequestAccept.ContainsKey(clientID))
                {
                    if (ConnectionRequestAccept[clientID])
                    /* Makes sure we accepted the connection before allowing download */
                    {
                        if (ConnectionFileName.ContainsKey(clientID))
                        /* Work out if this is the first message, and if so, it will
                         * Set the filename to this message. If not, it will*/
                        {
                            File.AppendAllText(Path.Combine(DownloadPath, ConnectionFileName[clientID]), message);
                        }
                        else
                        {
                            ConnectionFileName[clientID] = message;
                            File.WriteAllText(Path.Combine(DownloadPath, ConnectionFileName[clientID]), "");
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
