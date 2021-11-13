using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Melodi.Networking;

namespace File_Transfer_2
{
    public static class FileTransferService
    {
        public static int Port;
        public static TCPConnectionServer Server;
        /* Only 'local' variables start with a lower-case letter, these are global because
         * they can be accessed anywhere in the code. Local variables are like the stuff
         * in function and are only temporary. */
        public static Dictionary<ulong, string> DeviceFriendlyNames; 
        /* A dictionary is like a list but instead of an index like this mylist[0] we do this
         * mydictionary["key"] so the 'index' is like the key to get the value
         * the ulong is basically just a number that can have a really high value
         * higher than an int, but it can only have positive numbers and 0. */
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
            Server = new TCPConnectionServer(Port);

            Server.onConnect = client =>
            /* This is a delegate, it is an anonamous function, so it doesn't have a name
             * it is similar to an action. The code inside these run on a different thread
             * to the UI so the UI will not be affected unless we invoke it. The 'client'
             * part is what we choose to name the argument passed to us. */
            {

            };
            Server.onDisconnect = client =>
            {
                /* Don't Care (For now) */
            };
            Server.onMessage = (client, message) =>
            {

            };

            Server.Start();
            /* This will start listening for connections and run the delegates when they 
             * are triggered. The code will keep running one the server is started, saving
             * the UI thread for UI work only. */
        }
    }
}
