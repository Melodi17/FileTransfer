using System.Net.Sockets;
using System.Runtime.Serialization;

namespace Melodi.Networking
{
    public static class SocketExtensions
    {
        private static ObjectIDGenerator generator = new ObjectIDGenerator();
        public static bool IsConnected(this Socket socket)
        {
            try
            {
                return !(socket.Poll(1, SelectMode.SelectRead) && socket.Available == 0);
            }
            catch (SocketException) { return false; }
        }
        public static long SocketId(this TcpClient client)
        {
            return generator.GetId(client, out _);
        }
    }
}
