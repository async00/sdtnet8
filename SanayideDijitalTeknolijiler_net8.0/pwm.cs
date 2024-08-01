using System;
using System.Device.Pwm;

namespace TestTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello PWM!");
            var pwm = PwmChannel.Create(0, 0, 400, 0.5);
            pwm.Start();
            Console.ReadKey();
        }
    }
}
