using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Melodi.Networking
{
    public class UDPConnection
    {
        private int Port;
        private UdpClient UdpClient;
        private IAsyncResult _asyncResult = null;
        private Thread t = null;
        public Action<IPEndPoint, byte[], string> onMessage = null;
        public UDPConnection(int port)
        {
            this.Port = port;
            this.UdpClient = new UdpClient(port);
        }
        public void Start()
        {
            if (t != null)
            {
                throw new Exception("Already started, stop first");
            }

            StartListening();
        }
        public void Stop()
        {
            try
            {
                t = null;
                UdpClient.Close();
            }
            catch { /* Don't care */ }
        }
        private void StartListening()
        {
            _asyncResult = UdpClient.BeginReceive(Receive, new object());
        }
        private void Receive(IAsyncResult ar)
        {
            IPEndPoint ip = new IPEndPoint(IPAddress.Any, this.Port);
            byte[] bytes = UdpClient.EndReceive(ar, ref ip);
            string message = Encoding.ASCII.GetString(bytes);

            if (this.onMessage != null)
            {
                this.onMessage.Invoke(ip, bytes, message);
            }

            StartListening();
        }
        /// <summary>
        /// Sends UDP data
        /// </summary>
        /// <param name="message">Data to send</param>
        /// <param name="port">Port to send to</param>
        /// <param name="dest">IPAdress to send to</param>
        public void Send(string message)
        {
            UdpClient client = new UdpClient();
            IPEndPoint ip = new IPEndPoint(IPAddress.Parse("255.255.255.255"), this.Port);
            byte[] bytes = Encoding.ASCII.GetBytes(message);
            client.Send(bytes, bytes.Length, ip);
            client.Close();
            //Console.WriteLine("Sent: {0} ", message);
        }
    }
}
