using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Melodi.Networking
{
    public class TCPConnectionServer
    {
        private int Port;
        private TcpListener TcpListener;
        private bool Running = false;
        private Thread _t = null;
        public List<TcpClient> Clients = new();
        public Action<TcpClient, string> onMessage = null;
        public Action<TcpClient> onConnect = null;
        public Action<TcpClient> onDisconnect = null;
        public TCPConnectionServer(int port)
        {
            this.Port = port;
            this.TcpListener = new(IPAddress.Any, port);
        }
        public void Start()
        {
            if (_t != null)
            {
                throw new Exception("Already started, stop first");
            }

            TcpListener.Start();
            Running = true;

            _t = new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;

                while (Running)
                {
                    try
                    {
                        TcpClient client = TcpListener.AcceptTcpClient();
                        if (Running)
                        {
                            HandleConnect(client);
                        }
                    }
                    catch (Exception e) { /* Don't Care */Console.WriteLine(e); }
                }
            });
            _t.Start();
        }
        public void KillConnections()
        {
            foreach (TcpClient item in Clients)
            {
                item.Close();
            }
        }
        public void Stop()
        {
            TcpListener.Stop();
            Running = false;
            KillConnections();
        }
        public void Send(TcpClient client, string buffer)
        {
            StreamWriter writer = new(Clients.First(x => x.SocketId() == client.SocketId()).GetStream());
            writer.AutoFlush = true;
            writer.WriteLine(buffer);
        }
        private void HandleConnect(TcpClient client)
        {
            Clients.Add(client);
            StreamReader reader = new(client.GetStream());

            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;

                while (Running)
                {
                    try
                    {
                        string response = reader.ReadLine();
                        if (!Running) { break; }
                        if (!client.Client.IsConnected() || response == null) { break; }
                        HandleMessage(client, response);
                    }
                    catch (Exception) { break; }
                }
                if (Running)
                {
                    HandleDisconnect(client);
                }
            }).Start();

            onConnect?.Invoke(client);
        }
        private void HandleMessage(TcpClient client, string buffer)
        {
            onMessage?.Invoke(client, buffer);
        }
        private void HandleDisconnect(TcpClient client)
        {
            Clients.RemoveAll(x => x.SocketId() == client.SocketId());

            onDisconnect?.Invoke(client);
        }
    }
}
