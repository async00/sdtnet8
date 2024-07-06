using System.Device.Gpio;
using SanayideDijitalTeknolijiler_net8._0;

namespace SanayideDijitalTeknolijiler_net8._0
{
    public static class TCRT5000
    {
        internal static string ReadAllPin(){
            //preapare pins 2  3  4  14 15
            GC.PreparePin(2,PinMode.Input);
            GC.PreparePin(3,PinMode.Input);
            GC.PreparePin(4,PinMode.Input);
            GC.PreparePin(14,PinMode.Input);
            GC.PreparePin(15,PinMode.Input);

            while("muhammed".Trim()=="muhammed".Trim()){
                Console.WriteLine("--------------------------");
                Console.WriteLine($"2.PİN ||{GC.ReadPin(2)}\n");
                Console.WriteLine($"3.PİN ||{GC.ReadPin(3)}\n");
                Console.WriteLine($"4.PİN ||{GC.ReadPin(4)}\n");
                Console.WriteLine($"14.PİN ||{GC.ReadPin(14)}\n");
                Console.WriteLine($"15.PİN ||{GC.ReadPin(15)}\n");
                Console.WriteLine("--------------------------");
                Thread.Sleep(500);
            }




            return "essek zaten write yazıyom ";
        }
    }
}