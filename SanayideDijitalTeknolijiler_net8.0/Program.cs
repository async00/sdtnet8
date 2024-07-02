using System;
using System.Device.Gpio;

namespace GpioLedExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // GPIO pinini tanımlayın (örneğin GPIO 17)
            const int ledPin = 17;

            // GPIO kontrol nesnesini oluşturun
            using var gpio = new GpioController();

            // Pin konfigürasyonunu yapın
            gpio.OpenPin(ledPin, PinMode.Output);

            // LED'i aç ve kapat
            Console.WriteLine("LED yanıyor...");
            gpio.Write(ledPin, PinValue.High);
            System.Threading.Thread.Sleep(1000); // 1 saniye bekle

            // Uygulamayı sonlandır
            Console.WriteLine("Program sonlandı.");
        }
    }
}
