using SanayideDijitalTeknolijiler_net8._0;
using System;
using System.Device.Gpio;
using System.Security.Cryptography.X509Certificates;

namespace SanayideDijitalTeknolijiler_net8._0
{
    class Program
    {
        static void Main(string[] args)
        {

            LogSys.InfoLog("LogSystem running");
            Thread listenerserver_thread = new Thread(TcpServer.Listen);
            listenerserver_thread.Start();//thread olarak tcp listener

            //renk denemesi
            LogSys.GrayLog("-------------------color board-------------------");
            LogSys.SuccesLog("mutlu ferhat");
            LogSys.InfoLog("düsünceli ferhat");
            LogSys.WarnLog("gergin ferhat");
            LogSys.ErrorLog("kızgın ferhat");
            LogSys.GrayLog("-------------------color board-------------------");
            GC.PreparePin(2,PinMode.Output);
            for(int i=0;i<10;i++){
                GC.Write(2,PinValue.High);
                Thread.Sleep(700);
                GC.Write(2,PinValue.Low);
            }
            LogSys.WarnLog("PİN TAMAMEN KAPANIYOR AMK !!!");
            GC.ClosePin(2);
            

        }
    }
}
