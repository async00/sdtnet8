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
                VirtualPwm vpwm14=new VirtualPwm(14,100);
                VirtualPwm vpwm15=new VirtualPwm(15,100);
                var pwmclass12  = new PwmController(12,100);
                var pwmclass19=new PwmController(18,100);
                string previouskey=string.Empty;
            while(true){
                    
                     if (Console.KeyAvailable)
                {
                var key = Console.ReadKey(intercept: true);
                if (key.Key == ConsoleKey.W && !(previouskey=="w"))
                {
                    vpwm14.Stop();
                    vpwm15.Stop();
                    pwmclass12.Stop();
                    pwmclass19.Stop();
                    GC.Write(26,PinValue.High);
                    GC.Write(3,PinValue.High);
                    GC.Write(17,PinValue.High);
                    GC.Write(27,PinValue.High);
                    vpwm14.SetPercent(100);
                    vpwm15.SetPercent(0);
                    pwmclass12.SetDutyCycle(0);
                    pwmclass19.SetDutyCycle(255);
                    pwmclass12.Start();
                    pwmclass19.Start();
                    LogSys.InfoLog("pWWwm12 255 yazdir !! ILERI IIII  ");
                    previouskey="w";
                   
                }
                if (key.Key == ConsoleKey.A&& !(previouskey=="a"))
                {
                    pwmclass12.Stop();
                    pwmclass19.Stop();
                    GC.Write(26,PinValue.High);
                    GC.Write(3,PinValue.High);
                    GC.Write(17,PinValue.High);
                    GC.Write(27,PinValue.High);

                    //12 SA GMOTOR ILERI
                    //13 SAG MOTOER GERI 
                    
                    pwmclass12.SetDutyCycle(0);
                    pwmclass19.SetDutyCycle(0);
                    pwmclass12.Start();
                    pwmclass19.Start();
                    LogSys.InfoLog("pwm12 255 yazdir !! ILERI IIII  ");
                    previouskey="a";
                }
                if (key.Key == ConsoleKey.S&& !(previouskey=="s"))
                {
                    vpwm14.Stop();
                    vpwm15.Stop();
                    pwmclass12.Stop();
                    pwmclass19.Stop();
                  GC.Write(26,PinValue.High);
                    GC.Write(3,PinValue.High);
                    GC.Write(17,PinValue.High);
                    GC.Write(27,PinValue.High);

                  
                    //12 SA GMOTOR ILERI
                    //13 SAG MOTOER GERI 
                    vpwm14.SetPercent(0);
                    vpwm15.SetPercent(100);
                    pwmclass12.SetDutyCycle(255);
                    pwmclass19.SetDutyCycle(0);
                    pwmclass12.Start();
                    pwmclass19.Start();
                    LogSys.InfoLog("pwm12 255 yazdir !! ILERI IIII  ");
                    previouskey="s";
                }
                if (key.Key == ConsoleKey.D&& !(previouskey=="d"))
                {
                    pwmclass12.Stop();
                    pwmclass19.Stop();
                   GC.Write(26,PinValue.High);
                    GC.Write(3,PinValue.High);
                    GC.Write(17,PinValue.High);
                    GC.Write(27,PinValue.High);

                  
                    //12 SA GMOTOR ILERI
                    //13 SAG MOTOER GERI 
                    
                    pwmclass12.SetDutyCycle(255);
                    pwmclass19.SetDutyCycle(0);
                    pwmclass12.Start();
                    pwmclass19.Start();
                    LogSys.InfoLog("pwm12 255 yazdir !! ILERI IIII  ");
                    previouskey="d";
                    
                }
                if (key.Key == ConsoleKey.Spacebar)
                {
                    Console.WriteLine("breaaak ");
                    EngineDrivers.Engine_RESET();
                }
                if(key.Key == ConsoleKey.X){
                    Console.WriteLine("x pressed exiting ");
                    break;
                }

            }
                    }
        }
        
    }
}