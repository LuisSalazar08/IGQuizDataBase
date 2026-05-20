using System.IO;
using System.Net.Sockets;

namespace BDGameQuiz
{
    public static class Conexion
    {
        public static TcpClient client;
        public static StreamReader reader;
        public static StreamWriter writer;
        public static void Cerrar()
        {
            try
            {
                writer?.Close();
                reader?.Close();
                client?.Close();
            }
            catch { }
        }
    }
}