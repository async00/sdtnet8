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

        internal static void LR_ATTACH(){
            if(Program.tcrt5_t.IsAlive){
                LogSys.InfoLog("Thread is running.Lrpins attached to engine");
             
            }
            else{
                LogSys.ErrorLog("Tcrt5_t thread not working");
            }
        }

        internal static void ListenPins(){
            //pinleri dinle ve eşitle
            int TEMP1,TEMP2,TEMP3,TEMP4,TEMP5;      
            GC.PreparePin(2,PinMode.Input);
            GC.PreparePin(3,PinMode.Input);
            GC.PreparePin(4,PinMode.Input);
            GC.PreparePin(14,PinMode.Input);
            GC.PreparePin(15,PinMode.Input);


            int[] pins=[2,3,4,14,15];


            while(1==1){
            TEMP1=GC.ReadPin(2);
            TEMP2=GC.ReadPin(3);
            TEMP3=GC.ReadPin(4);
            TEMP4=GC.ReadPin(14);
            TEMP5=GC.ReadPin(15);
            Thread.Sleep(30);
            if(TEMP1==GC.ReadPin(2)&&TEMP2==GC.ReadPin(3)&&TEMP3==GC.ReadPin(4)&&TEMP4==GC.ReadPin(14)&&TEMP5==GC.ReadPin(15))
            {
                Program.lrpin1=GC.ReadPin(2);
                Program.lrpin2=GC.ReadPin(3);
                Program.lrpin3=GC.ReadPin(4);
                Program.lrpin4=GC.ReadPin(14);
                Program.lrpin5=GC.ReadPin(15);
            }
            Thread.Sleep(30);


         
            }
            
        }



        //herhangibi bir döngü yok sadece ekrana yazdır 
        internal static string WriteAllPins(){
            //preapare pins 2  3  4  14 15
            //debug için string döndür 
            string wreturn=string.Empty;
            GC.PreparePin(2,PinMode.Input);
            GC.PreparePin(3,PinMode.Input);
            GC.PreparePin(4,PinMode.Input);
            GC.PreparePin(14,PinMode.Input);
            GC.PreparePin(15,PinMode.Input);
            int[] pins = { 2,3,4,14,15 };
            Console.Clear();
            wreturn+="TCRT5000 Sensör Okumaları:";
            wreturn+="--------------------------";      
            wreturn+="| Pin | Durum           |";  
            wreturn+="--------------------------";

            Console.WriteLine("TCRT5000 Sensör Okumaları:");
            Console.WriteLine("--------------------------");
            Console.WriteLine("| Pin | Durum           |");
            Console.WriteLine("--------------------------");

            foreach (var pin in pins)
            {
                var value = GC.ReadPin(pin);
                Console.WriteLine($"| {pin,3} | {(value == 1 ? "Cizgi Yok" : "Cizgi Var"),-15} |");
                wreturn+=$"| {pin,3} | {(value == 1 ? "Cizgi Yok" : "Cizgi Var"),-15} |";
            }
            wreturn+="--------------------------";
            Console.WriteLine("--------------------------");
            return wreturn;
        
    }
    }
}
