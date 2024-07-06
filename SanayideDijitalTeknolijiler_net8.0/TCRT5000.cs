using System.Device.Gpio;
using SanayideDijitalTeknolijiler_net8._0;

namespace SanayideDijitalTeknolijiler_net8._0
{
    public static class TCRT5000
    {
        internal static string ReadAllPin(){
            //preapare pins 3  5  7  8 10
            GC.PreparePin(3,PinMode.Input);
            GC.PreparePin(5,PinMode.Input);
            GC.PreparePin(7,PinMode.Input);
            GC.PreparePin(8,PinMode.Input);
            GC.PreparePin(10,PinMode.Input);

            while("muhammed".Trim()=="muhammed".Trim()){
                Console.WriteLine("--------------------------");
                Console.WriteLine($"3.PİN ||{GC.ReadPin(3)}\n");
                Console.WriteLine($"5.PİN ||{GC.ReadPin(5)}\n");
                Console.WriteLine($"7.PİN ||{GC.ReadPin(7)}\n");
                Console.WriteLine($"8.PİN ||{GC.ReadPin(8)}\n");
                Console.WriteLine($"10.PİN ||{GC.ReadPin(10)}\n");
                Console.WriteLine("--------------------------");
                Thread.Sleep(500);
            }




            return "essek zaten write yazıyom ";
        }
    }
}