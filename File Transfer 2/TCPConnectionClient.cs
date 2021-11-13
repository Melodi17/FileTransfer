using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;

namespace Melodi.Networking
{
    public class TCPConnectionClient
    {
        private string Host;
        private int Port;
        private TcpClient TcpClient;
        private bool running = false;
        private Thread t = null;
        public Action<string> onMessage = null;
        public Action onConnect = null;
        public Action onDisconnect = null;
        public Action onConnectFailed = null;

        public TCPConnectionClient(string host, int port)
        {
            this.Host = host;
            this.Port = port;
        }
        public void Start()
        {
            this.TcpClient = new TcpClient();
            try
            {
                this.TcpClient.Connect(this.Host, this.Port);
            }
            catch (Exception)
            {
                Stop();
                if (this.onConnectFailed != null)
                {
                    this.onConnectFailed.Invoke();
                }
            }
            HandleConnect();
            running = true;
            StreamReader reader = new StreamReader(this.TcpClient.GetStream());

            t = new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;

                while (running)
                {
                    try
                    {
                        string message = reader.ReadLine();
                        if (!running || message == null || !TcpClient.Client.IsConnected())
                        {
                            break;
                        }
                        HandleMessage(message);
                    }
                    catch (Exception)
                    {
                        break;
                    }
                }
                if (running)
                {
                    HandleDisconnect();
                }
            });
            t.Start();
        }
        private void HandleMessage(string buffer)
        {
            if (this.onMessage != null)
            {
                this.onMessage.Invoke(buffer);
            }
        }
        private void HandleDisconnect()
        {
            if (this.onDisconnect != null)
            {
                this.onDisconnect.Invoke();
            }
        }
        private void HandleConnect()
        {
            if (this.onConnect != null)
            {
                this.onConnect.Invoke();
            }
        }
        public void Send(string buffer)
        {
            StreamWriter writer = new StreamWriter(this.TcpClient.GetStream());
            writer.AutoFlush = true;
            writer.WriteLine(buffer);
        }
        public void Stop()
        {
            this.TcpClient.Close();
            running = false;
        }
    }
}
