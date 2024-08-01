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
                GC.PreparePin(2,PinMode.Output);
                GC.PreparePin(3,PinMode.Output);

                var pwmclass12  = new PwmController(12,100);
                var pwmclass19=new PwmController(19,100);

            while(true){
                     if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(intercept: true);
                if (key.Key == ConsoleKey.W)
                {
                    pwmclass12.Stop();
                    pwmclass19.Stop();
                    GC.Write(2,PinValue.High);
                    GC.Write(3,PinValue.High);

                    pwmclass12.SetDutyCycle(255);
                    pwmclass19.SetDutyCycle(0);
                    pwmclass12.Start();
                    pwmclass19.Start();
                    LogSys.InfoLog("pwm12 255 yazdir !! ILERI IIII  ");
                    
                }
                if (key.Key == ConsoleKey.A)
                {
                    pwmclass12.Stop();
                    pwmclass19.Stop();
                    GC.Write(2,PinValue.High);
                    GC.Write(3,PinValue.High);

                    //12 SA GMOTOR ILERI
                    //13 SAG MOTOER GERI 
                    
                    pwmclass12.SetDutyCycle(0);
                    pwmclass19.SetDutyCycle(0);
                    pwmclass12.Start();
                    pwmclass19.Start();
                    LogSys.InfoLog("pwm12 255 yazdir !! ILERI IIII  ");
                }
                if (key.Key == ConsoleKey.S)
                {
                        pwmclass12.Stop();
                    pwmclass19.Stop();
                  GC.Write(2,PinValue.High);
                    GC.Write(3,PinValue.High);

                  
                    //12 SA GMOTOR ILERI
                    //13 SAG MOTOER GERI 
                    pwmclass12.SetDutyCycle(0);
                    pwmclass19.SetDutyCycle(255);
                    pwmclass12.Start();
                    pwmclass19.Start();
                    LogSys.InfoLog("pwm12 255 yazdir !! ILERI IIII  ");
                    
                }
                if (key.Key == ConsoleKey.D)
                {
                    pwmclass12.Stop();
                    pwmclass19.Stop();
                   GC.Write(2,PinValue.High);
                    GC.Write(3,PinValue.High);

                  
                    //12 SA GMOTOR ILERI
                    //13 SAG MOTOER GERI 
                    
                    pwmclass12.SetDutyCycle(255);
                    pwmclass19.SetDutyCycle(0);
                    pwmclass12.Start();
                    pwmclass19.Start();
                    LogSys.InfoLog("pwm12 255 yazdir !! ILERI IIII  ");
                    
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