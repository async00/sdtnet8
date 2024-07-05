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
        public static void Preapare_Engine_Pins(){
            //motor 1
            GC.PreparePin(2,PinMode.Output);
            GC.PreparePin(3,PinMode.Output);
            //motor 2
            GC.PreparePin(20,PinMode.Output);
            GC.PreparePin(21,PinMode.Output);
        }
        public static void Engine_FORWARD()
        {
            GC.Write(2,PinValue.High);
            GC.Write(3,PinValue.Low);
            GC.Write(20,PinValue.High);
            GC.Write(21,PinValue.Low);
        }
        public static void Engine_LEFT()
        {
            //1.motor ileri
            GC.Write(2,PinValue.High);
            GC.Write(3,PinValue.Low);

            //2.motor geri
            GC.Write(20,PinValue.Low);
            GC.Write(21,PinValue.High);
        }
        public static void Engine_RIGHT()
        {
        //1.motor geri
            GC.Write(2,PinValue.Low);
            GC.Write(3,PinValue.High);

            //2.motor ileri
            GC.Write(20,PinValue.High);
            GC.Write(21,PinValue.Low);
        }
        public static void Engine_BACKWARD()
        {
            GC.Write(2,PinValue.Low);
            GC.Write(3,PinValue.High);
            GC.Write(20,PinValue.Low);
            GC.Write(21,PinValue.High);
        }
        public static void Engine_STOP()
        {
            GC.Write(2,PinValue.Low);
            GC.Write(3,PinValue.Low);
            GC.Write(20,PinValue.Low);
            GC.Write(21,PinValue.Low);
        }

    }
}
