﻿using SanayideDijitalTeknolijiler_net8._0;
using System;
using System.Device.Gpio;
using System.Security.Cryptography.X509Certificates;

namespace SanayideDijitalTeknolijiler_net8._0
{
    class Program
    {
        //çizgi sensör pin değişkenleri
        internal static int lrpin1,lrpin2,lrpin3,lrpin4,lrpin5;
        static void Main(string[] args)
        {   
            //sistemi başlat ve tcpden gelen verileri dinle
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

            //MOTOR PİNLERİ HAZIRLA
            EngineDrivers.Preapare_Engine_Pins();
            LogSys.InfoLog("Motor pinleri hazırlandı");

            //TCPDEN GELEN KODLARI EXECUTE ET
            Thread tcpcmdexecutor_t=new Thread(TcpCmd.Executor);
            tcpcmdexecutor_t.Start();
            LogSys.SuccesLog("Tcp Cli Activated....");
            LogSys.WarnLog("Mode=debug");

            //çizgi sensöründen gelen verileri işle ve  lrpin1...'lere eşitle
            TCRT5000.SpesificLineRead(1);
            Thread tcrt5_t=new Thread(TCRT5000.ListenPins);
            tcrt5_t.Start();
            LogSys.SuccesLog("Çizgi sensörü dinleniyor");
            

        }
    }
}
