using System.Device.Gpio;
using SanayideDijitalTeknolijiler_net8._0;

namespace SanayideDijitalTeknolijiler_net8._0
{
    public static class TCRT5000
    {
        internal static int SpesificLineRead(int pin){
            GC.PreparePin(2,PinMode.Input);
            GC.PreparePin(3,PinMode.Input);
            GC.PreparePin(4,PinMode.Input);
            GC.PreparePin(14,PinMode.Input);
            GC.PreparePin(15,PinMode.Input);
            if(pin==1){
                return GC.ReadPin(2);
            }
            if(pin==2){
                return GC.ReadPin(3);
            }
            if(pin==3){
                return GC.ReadPin(4);
            }
            if(pin==4){
                return GC.ReadPin(14);
            }
            if(pin==5){
                return GC.ReadPin(15);
            }
            LogSys.ErrorLog("Spesifc pin sadece 12345 değer alır adam gibi birşey yaz moruk");
            return -1;





        }



        internal static string WriteAllPin(){
            //preapare pins 2  3  4  14 15
            GC.PreparePin(2,PinMode.Input);
            GC.PreparePin(3,PinMode.Input);
            GC.PreparePin(4,PinMode.Input);
            GC.PreparePin(14,PinMode.Input);
            GC.PreparePin(15,PinMode.Input);
            int[] pins = { 2,3,4,14,15 };

        while (true)
        {
            Console.Clear();
            Console.WriteLine("TCRT5000 Sensör Okumaları:");
            Console.WriteLine("--------------------------");
            Console.WriteLine("| Pin | Durum           |");
            Console.WriteLine("--------------------------");

            foreach (var pin in pins)
            {
                var value = GC.ReadPin(pin);
                Console.WriteLine($"| {pin,3} | {(value == 1 ? "Cizgi Yok" : "Cizgi Var"),-15} |");
            }

            Console.WriteLine("--------------------------");
            Thread.Sleep(1000); // 1 saniye bekle
        }
    }
    }
}
