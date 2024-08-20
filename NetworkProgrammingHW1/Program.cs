using System.Net.Sockets;
using System.Net;
using System.Text;

namespace NetworkProgrammingHW1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StartServer();
        }

        public static void StartServer()

        {

            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");

            int port = 8888;

            TcpListener listener = new TcpListener(ipAddress, port);

            try

            {

                listener.Start();

                Console.WriteLine("Сервер запущен...");


               

                    TcpClient client = listener.AcceptTcpClient();

                    Console.WriteLine("Новый клиент подключен.");
                    Console.WriteLine(DateTime.Now);

                    NetworkStream stream = client.GetStream();
                while (client.Connected)
                {

                    byte[] data = new byte[8];

                    int size = stream.Read(data, 0, data.Length);
                    StringBuilder message = new StringBuilder();
                    message.Append(Encoding.UTF8.GetString(data));
                    string res = new string("");
                    if (message.ToString() == "USD EURO")
                    {
                        res = "Курс долара к евро-> 1:09";

                    }

                    else if (message.ToString() == "EURO USD")
                    {
                        res = "Курс евро к долару-> 1:1.11 ";

                    }
                    else
                    {
                        res = "Error";

                    }
                    byte[] response = Encoding.UTF8.GetBytes(res.ToString());
                    stream.Write(response, 0, response.Length);
                    client.Close();
                }
                

            }

            catch (Exception ex)

            {

                Console.WriteLine("Ошибка: " + ex.Message);

            }

            finally

            {

                listener.Stop();

            }

        }
    }
}