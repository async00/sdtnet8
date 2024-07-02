using System;
using System.Device.Gpio;

namespace GpioLedExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program begin");
            TcpServer server = new TcpServer(2804);
            server.Listen();
        }
    }
}
