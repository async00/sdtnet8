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

            //MOTOR DENEME
            EngineDrivers.Preapare_Engine_Pins();
            string oldmessage=string.Empty;
            Thread tcpcmdexecutor_t=new Thread(TcpCmd.Executor);
            tcpcmdexecutor_t.Start();
            LogSys.SuccesLog("Tcp Cli Activated....");
            LogSys.WarnLog("Debug mode starting ");
            LogSys.WarnLog("TCRT5000 READ !");
            TCRT5000.ReadAllPin();
        }
    }
}
