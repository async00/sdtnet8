using System;
using System.Device.Gpio;
using System.Security.Cryptography.X509Certificates;

namespace GpioLedExample
{
    class Program
    {
        public static string lastreceviedstring=string.Empty;
        static void Main(string[] args)
        {
            
            Console.WriteLine("Program begin");
            TcpServer server = new TcpServer(2804);
            server.Listen();
        }
    }
}
