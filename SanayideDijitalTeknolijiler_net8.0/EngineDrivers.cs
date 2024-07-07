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
        //tcpden gelen değere göre veri girme
        //6 13 19 26
        private static int pin1=6;
        private static int pin2=13;
        private static int pin3=19;
        private static int pin4=26;
        public static void Preapare_Engine_Pins(){
            //motor 1
            GC.PreparePin(pin1,PinMode.Output);
            GC.PreparePin(pin2,PinMode.Output);
            //motor 2
            GC.PreparePin(pin3,PinMode.Output);
            GC.PreparePin(pin4,PinMode.Output);
        }
        public static void Engine_FORWARD()
        {
            GC.Write(pin1,PinValue.High);
            GC.Write(pin2,PinValue.Low);
            GC.Write(pin3,PinValue.High);
            GC.Write(pin4,PinValue.Low);
        }
        public static void Engine_LEFT()
        {
            //1.motor ileri
            GC.Write(pin1,PinValue.High);
            GC.Write(pin2,PinValue.Low);

            //2.motor geri
            GC.Write(pin3,PinValue.Low);
            GC.Write(pin4,PinValue.High);
        }
        public static void Engine_RIGHT()
        {
        //1.motor geri
            GC.Write(pin1,PinValue.Low);
            GC.Write(pin2,PinValue.High);

            //2.motor ileri
            GC.Write(pin3,PinValue.High);
            GC.Write(pin4,PinValue.Low);
        }
        public static void Engine_BACKWARD()
        {
            GC.Write(pin1,PinValue.Low);
            GC.Write(pin2,PinValue.High);
            GC.Write(pin3,PinValue.Low);
            GC.Write(pin4,PinValue.High);
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
