using System.Device.Gpio;
using SanayideDijitalTeknolijiler_net8._0;

namespace SanayideDijitalTeknolijiler_net8._0
{
    public static class TCRT5000
    {
        internal static int SpesificLineRead(int pin){
            // 5 pin 
            GC.PreparePin(25,PinMode.Input);
            GC.PreparePin(8,PinMode.Input);
            GC.PreparePin(7,PinMode.Input);
            GC.PreparePin(1,PinMode.Input);
            GC.PreparePin(16,PinMode.Input);
            if(pin==1){
                return GC.ReadPin(25);
            }
            else if(pin==2){
                return GC.ReadPin(8);
            }
            else if(pin==3){
                return GC.ReadPin(7);
            }
            else if(pin==4){
                return GC.ReadPin(1);
            }
            else if(pin==5){
                return GC.ReadPin(16);
            }else{
                LogSys.ErrorLog("Spesifc pin sadece 1-2-3-4-5 değerlerinden birini  alır adam gibi birşey yaz moruk");
            return -1;
            }
        }

        internal static void LR_ATTACH(){
            if(Program.tcrt5_t.IsAlive){
                LogSys.InfoLog("Thread is running.Lrpins attached to engine");
             
            }
            else{
                LogSys.ErrorLog("Tcrt5_t thread not working");
            }
        }
        internal static void döndü_hanım(){
            //Console.WriteLine("Distance : "+DistanceSens.GetDistance());
            while(true){
               if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(intercept: true);
                if (key.Key == ConsoleKey.X)
                {
                    Console.WriteLine("x pressed exiting");
                    break;
                }
                if (key.Key == ConsoleKey.Spacebar)
                {
                    Console.WriteLine("breaaak ");
                    EngineDrivers.Engine_RESET();
                }

            }
               
                //siyasi ağaç ferhat
                if(Program.lrpin1==1 && Program.lrpin2==1){
                    Console.WriteLine("sağcı ferhat");
                    EngineDrivers.Engine_RIGHT();
                   
                }
                if(Program.lrpin4==1 && Program.lrpin5==1){
                     Console.WriteLine("solcu ferhat");
                    EngineDrivers.Engine_LEFT();
                }
                if(Program.lrpin3==1){
                    Console.WriteLine("merkeziyetçi ferhat");
                    EngineDrivers.Engine_FORWARD();
                }
                Thread.Sleep(150);
              //  TCRT5000.WriteAllPins();
            }
        }
        internal static void BeastMode(){
            //calibrate 
            while(true){
            int count =0;
            int lastpin=0;//so its null
            for(int i= 1;i<6;i++){
                if(SpesificLineRead(i)==1){
                    count++;
                    lastpin=i;
                }
            }
            if(count == 1){
                //lastpindeki değer tek basına true dondu yanı bır dönme olayı olmamasına ragmen yoldan sapıyoruz KALİBRE EEEETTTT
                if(lastpin == 1){
                    //kanka cok cıktın saga don
                    PwmVirtualMode.PWM_RİGHT(0,75);
                }
                if(lastpin == 2){
                    //kanka azcık cıktın saga don
                     PwmVirtualMode.PWM_RİGHT(25,75);
                }
                if(lastpin == 3){
                    PwmVirtualMode.PWM_FORWARD();
                    continue;
                }
                if(lastpin == 4){
                    //kanka azcık cıktın sola don
                    PwmVirtualMode.PWM_LEFT_SYNC(25,75);
                }
                if(lastpin == 5){
                    //kanka cok cıktın sola don
                    PwmVirtualMode.PWM_LEFT_SYNC(0,75);
                }
            }else{
                //1 den fazla deger true dondugu ıcın calıbrasyon saglanamıyor

            }




            //normal dönüş
             if(Program.lrpin1==1 && Program.lrpin2==1){
                    Console.WriteLine("sağcı ferhat");
                   PwmVirtualMode.PWM_RİGHT();
                   
                }
                if(Program.lrpin4==1 && Program.lrpin5==1){
                     Console.WriteLine("solcu ferhat");
                    PwmVirtualMode.PWM_LEFT();
                }
                if(Program.lrpin3==1){
                    Console.WriteLine("merkeziyetçi ferhat");
                    PwmVirtualMode.PWM_FORWARD();
                }
                count=0;
                lastpin=0;
            }
        }
        internal static void ListenPins(){  
            GC.PreparePin(26,PinMode.Input);
            GC.PreparePin(19,PinMode.Input);
            GC.PreparePin(13,PinMode.Input);
            GC.PreparePin(3,PinMode.Input);
            GC.PreparePin(4,PinMode.Input);



            while(1==1){
            Thread.Sleep(30);
            
                Program.lrpin1=GC.ReadPin(26);
                Program.lrpin2=GC.ReadPin(19);
                Program.lrpin3=GC.ReadPin(13);
                Program.lrpin4=GC.ReadPin(3);
                Program.lrpin5=GC.ReadPin(4);
         


         
            }
            
        }



        //herhangibi bir döngü yok sadece ekrana yazdır 
        internal static string WriteAllPins(){
            //preapare pins 2  3  4  14 15
            //debug için string döndür 
            string wreturn=string.Empty;
            GC.PreparePin(26,PinMode.Input);
            GC.PreparePin(19,PinMode.Input);
            GC.PreparePin(13,PinMode.Input);
            GC.PreparePin(3,PinMode.Input);
            GC.PreparePin(4,PinMode.Input);
            int[] pins = { 26,19,13,3,4 };
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
