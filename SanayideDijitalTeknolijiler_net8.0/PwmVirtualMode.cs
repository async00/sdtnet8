using System.ComponentModel;
using System.Device.Gpio;
using SanayideDijitalTeknolijiler_net8._0;
using Swan.Logging;
using Unosquare.RaspberryIO.Abstractions;

namespace SanayideDijitalTeknolijiler_net8._0
{
    public class PwmVirtualMode
    {
        internal static void  Start()
        {
                GC.PreparePin(26,PinMode.Output);
                GC.PreparePin(3,PinMode.Output);

                GC.PreparePin(17,PinMode.Output);
                GC.PreparePin(27,PinMode.Output);

                GC.PreparePin(23,PinMode.Output);
                GC.PreparePin(24,PinMode.Output);
                //1.motor
                VirtualPwm vpwm14=new VirtualPwm(14,100);
                VirtualPwm vpwm15=new VirtualPwm(15,100);
                //2.motor
                VirtualPwm vpwm12 = new  VirtualPwm(12,100);
                VirtualPwm vpwm18 = new VirtualPwm(13,100);

                //linear
                VirtualPwm vpm20 = new VirtualPwm(20,100);
                VirtualPwm vpm21 = new VirtualPwm(21,100);

                string previouskey=string.Empty;
            while(true){
                    
                     if (Console.KeyAvailable)
                {
                var key = Console.ReadKey(intercept: true);
                if (key.Key == ConsoleKey.W && !(previouskey=="w"))
                {
                    vpwm14.Stop();
                    vpwm15.Stop();
                    vpwm12.Stop();
                    vpwm18.Stop();
                    GC.Write(26,PinValue.High);
                    GC.Write(3,PinValue.High);
                    GC.Write(17,PinValue.High);
                    GC.Write(27,PinValue.High);

                  
                    //12 SA GMOTOR ILERI
                    //13 SAG MOTOER GERI 
                    vpwm14.SetPercent(0);
                    vpwm15.SetPercent(100);
                    vpwm12.SetPercent(0);
                    vpwm18.SetPercent(100);
                    LogSys.InfoLog("pwm12 255 yazdir !! ILERI IIII  ");
                    previouskey="w";

                   
                   
                }
                if (key.Key == ConsoleKey.A&& !(previouskey=="a"))
                {

                     vpwm14.Stop();
                    vpwm15.Stop();
                    vpwm12.Stop();
                    vpwm18.Stop();
                    GC.Write(26,PinValue.High);
                    GC.Write(3,PinValue.High);
                    GC.Write(17,PinValue.High);
                    GC.Write(27,PinValue.High);

                  
                    //12 SA GMOTOR ILERI
                    //13 SAG MOTOER GERI 
                    vpwm14.SetPercent(0);
                    vpwm15.SetPercent(100);
                    vpwm12.SetPercent(100);
                    vpwm18.SetPercent(0);
                    LogSys.InfoLog("pwm12 255 yazdir !! ILERI IIII  ");
                    previouskey="a";

                    

                    
                }
                if (key.Key == ConsoleKey.S&& !(previouskey=="s"))
                {
                    vpwm14.Stop();
                    vpwm15.Stop();
                    vpwm12.Stop();
                    vpwm18.Stop();
                    GC.Write(26,PinValue.High);
                    GC.Write(3,PinValue.High);
                    GC.Write(17,PinValue.High);
                    GC.Write(27,PinValue.High);
                    vpwm14.SetPercent(100);
                    vpwm15.SetPercent(0);
                    vpwm12.SetPercent(100);
                    vpwm18.SetPercent(0);
                    LogSys.InfoLog("pWWwm12 255 yazdir !! ILERI IIII  ");
                    previouskey="s";
                }
                if (key.Key == ConsoleKey.D&& !(previouskey=="d"))
                {
                   vpwm14.Stop();
                    vpwm15.Stop();
                    vpwm12.Stop();
                    vpwm18.Stop();
                    GC.Write(26,PinValue.High);
                    GC.Write(3,PinValue.High);
                    GC.Write(17,PinValue.High);
                    GC.Write(27,PinValue.High);

                  
                    //12 SA GMOTOR ILERI
                    //13 SAG MOTOER GERI 
                    vpwm14.SetPercent(100);
                    vpwm15.SetPercent(0);
                    vpwm12.SetPercent(0);
                    vpwm18.SetPercent(100);
                    LogSys.InfoLog("pwm12 255 yazdir !! ILERI IIII  ");
                    previouskey="d";
                    
                }
                if (key.Key == ConsoleKey.Spacebar)
                {
                    vpwm14.SetPercent(0);
                    vpwm15.SetPercent(0);
                    vpwm12.SetPercent(0);
                    vpwm18.SetPercent(0);
                }
                if(key.Key == ConsoleKey.X){
                    Console.WriteLine("x pressed exiting ");
                    break;
                }
                if(key.Key ==ConsoleKey.P&& !(previouskey=="p")){
                    //lınear push kaldır
                    GC.Write(23,PinValue.High);
                    GC.Write(24,PinValue.High);
                    vpm20.Stop();
                    vpm21.Stop();

                    vpm20.SetPercent(100);
                    vpm21.SetPercent(0);
                    previouskey = "p";
                    LogSys.ErrorLog("linear toggle");
                }
                if(key.Key ==ConsoleKey.O&& !(previouskey=="o")){
                    //lınear stop durdur

                     GC.Write(23,PinValue.High);
                    GC.Write(24,PinValue.High);
                    vpm20.Stop();
                    vpm21.Stop();

                    vpm20.SetPercent(0);
                    vpm21.SetPercent(0);
                    previouskey = "o";
                      LogSys.ErrorLog("linear toggle");
                }
                if(key.Key ==ConsoleKey.L&& !(previouskey=="l")){
                    //lınear back indir
                     GC.Write(23,PinValue.High);
                    GC.Write(24,PinValue.High); 
                    vpm20.Stop();
                    vpm21.Stop();

                    vpm20.SetPercent(0);
                    vpm21.SetPercent(100);
                    previouskey = "l";
                      LogSys.ErrorLog("linear toggle");
                }

            }
                    }
        }
        
    }
}