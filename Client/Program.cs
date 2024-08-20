using System.Net.Sockets;
using System.Text;

namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConnectToServer();
            Console.ReadLine();
        }

        static void ConnectToServer()

        {

            try

            {
                TcpClient client = new TcpClient("127.0.0.1", 8888);
                int choice = 1;
                Console.WriteLine("Подключено к серверу...");
                while (choice==1)
                {
                    Console.WriteLine("Введите название двух валют->");
                    string message = Console.ReadLine();


                    NetworkStream stream = client.GetStream();


                    byte[] data = Encoding.UTF8.GetBytes(message);

                    stream.Write(data, 0, data.Length);


                    byte[] data2 = new byte[2048];
                    int size = stream.Read(data2, 0, data2.Length);
                    string message2 = Encoding.UTF8.GetString(data2, 0, data2.Length);
                    Console.WriteLine(message2);
                    Console.Write("Continue?(1-yes 0-no)");
                   choice=Convert.ToInt32(Console.ReadLine());

                }
                client.Close();

            }

            catch (Exception ex)

            {

                Console.WriteLine("Ошибка: " + ex.Message);

            }

        }
    }
}