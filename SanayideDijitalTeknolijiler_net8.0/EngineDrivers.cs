using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Device.Gpio;
using System.Threading.Tasks;

namespace SanayideDijitalTeknolijiler_net8._0
{
    internal class EngineDrivers
    {
        
        internal static int pin1=5;
        internal static int pin2=6;
        internal static int pin3=20;
        internal static int pin4=21;
        private static int pwm1 = 4; 
        private static int pwm2 = 23; 
        public static void Preapare_Engine_Pins(){
            //motor 1
            GC.PreparePin(pin1,PinMode.Output);
            GC.PreparePin(pin2,PinMode.Output);
            //motor 2
            GC.PreparePin(pin3,PinMode.Output);
            GC.PreparePin(pin4,PinMode.Output);
            //pwm
            GC.PreparePin(pwm1, PinMode.Output);
            GC.PreparePin(pwm2, PinMode.Output);
        }
        public static void SetEngineSpeed_E1()
        {
            //bu kodların acilen değişmesi lazım 
            //bu kodların anlık olarak direkt veri girmesi lazım
            //dönüşleri yaparken böyle bir for döngüsnde zaman kaybedersek olmaz
            //anında hızı düşürmem gerekecek
            //BU BİR YUNUSA UYARIDIR
            int pin=4;
            double speed=1;
            int onTime = (int)(speed * 1000); 
            int offTime = 1000 - onTime;     

            for (int i = 0; i < 100; i++)
            {
                GC.Write(pin, PinValue.High);
                Thread.Sleep(onTime);
                GC.Write(pin, PinValue.Low);
                Thread.Sleep(offTime);
            }
        }
         public static void SetEngineSpeed_E2()
        {
            //bu kodların acilen değişmesi lazım 
            //bu kodların anlık olarak direkt veri girmesi lazım
            //dönüşleri yaparken böyle bir for döngüsnde zaman kaybedersek olmaz
            //anında hızı düşürmem gerekecek
            //BU BİR YUNUSA UYARIDIR
            int pin=23;
            double speed=1;
            int onTime = (int)(speed * 1000); 
            int offTime = 1000 - onTime;     
            

            for (int i = 0; i < 100; i++)
            {
                GC.Write(pin, PinValue.High);
                Thread.Sleep(onTime);
                GC.Write(pin, PinValue.Low);
                Thread.Sleep(offTime);
            }
        }

        public static void Engine_FORWARD()
        {
            GC.Write(pin1,PinValue.Low);
            GC.Write(pin2,PinValue.High);

            //2.motor ileri
            GC.Write(pin3,PinValue.Low);
            GC.Write(pin4,PinValue.High);

            

            
        }
        public static void Engine_BACKWARD()
        {
            GC.Write(pin1,PinValue.High);
            GC.Write(pin2,PinValue.Low);

            //2.motor ileri
            GC.Write(pin3,PinValue.High);
            GC.Write(pin4,PinValue.Low);
        }
        public static void Engine_LEFT()
        {
            GC.Write(pin1,PinValue.High);
            GC.Write(pin2,PinValue.Low);
            GC.Write(pin3,PinValue.Low);
            GC.Write(pin4,PinValue.Low);
        }
        public static void Engine_RIGHT()
        {
        //1.motor geri
            GC.Write(pin1,PinValue.High);
            GC.Write(pin2,PinValue.Low);
            GC.Write(pin3,PinValue.Low);
            GC.Write(pin4,PinValue.Low);
        }
        
        public static void Engine_RESET()
        {
            

            GC.Write(pin1,PinValue.Low);
            GC.Write(pin2,PinValue.Low);
            GC.Write(pin3,PinValue.Low);
            GC.Write(pin4,PinValue.Low);
        }

    }
}
