using System.ComponentModel;
using System.Device.Gpio;
using SanayideDijitalTeknolijiler_net8._0;
using Swan.Logging;
using Unosquare.RaspberryIO.Abstractions;

namespace SanayideDijitalTeknolijiler_net8._0
{
    public static class TcpCmd
    {
        internal static void Executor(){
            LogSys.InfoLog("Executor started");
            string oldmessage=string.Empty;
            while(true){
                string message =TcpServer.GetLastMessage();
                if(message!=oldmessage){
                    if(message=="fw"){
                    LogSys.SuccesLog("GO GO");
                    EngineDrivers.Engine_FORWARD();
                }
                else if(message=="bw"){
                     LogSys.SuccesLog("BACKWARD");
                    EngineDrivers.Engine_BACKWARD();
                }
                else if(message=="lf"){
                    LogSys.SuccesLog("LEFT");
                    EngineDrivers.Engine_LEFT();
                }
                else if(message=="rg"){
                    LogSys.SuccesLog("RIGHT");
                    EngineDrivers.Engine_RIGHT();
                }
                else if(message=="stop"){
                    LogSys.SuccesLog("STOP");
                    EngineDrivers.Engine_RESET();
                }
                Thread.Sleep(150);
                oldmessage=message;
                }
               
            }
        }
        internal static void ManuelExecution(string message){
                GC.PreparePin(2,PinMode.Output);
                GC.PreparePin(3,PinMode.Output);
                GC.PreparePin(17,PinMode.Output);
                GC.PreparePin(27,PinMode.Output);
                var pwmclass12  = new PwmController(12,100);
                var pwmclass18=new PwmController(18,100);
                var pwmclass13  = new PwmController(13,100);
                var pwmclass19=new PwmController(19,100);

                if(message=="fw"){
                    LogSys.SuccesLog("GO GO");
                    EngineDrivers.Engine_FORWARD();
                }
                else if(message=="bw"){
                    LogSys.SuccesLog("BACKWARD");
                    EngineDrivers.Engine_BACKWARD();
                }
                else if(message=="lf"){
                    LogSys.SuccesLog("LEFT");
                    EngineDrivers.Engine_LEFT();
                    
                }
                else if (message == "pwmmode"){
                    // pwm0 channnekl = 12 18
                    // pwm1 channel  = 13 19 
                    pwmclass12.Start();
                    pwmclass18.Start();
                    pwmclass13.Start();
                    pwmclass19.Start();
                    LogSys.InfoLog("pwm pins setted and starrted  ");
                }
                else if(message == "virtualmode"){
                    PwmVirtualMode.Start();
                }
                else if(message=="beastmode"){
                    PwmVirtualMode.PWM_BEGİN();
                    TCRT5000.BeastMode();
                    
                }
                else if(message == "tcrtmode"){
                    while(true){
                        TCRT5000.WriteAllPins();
                        var key = Console.ReadKey(intercept: true);
                if (key.Key == ConsoleKey.X)
                {
                    break;
                }
                    }
                }
                else if (message== "pwmoff"){
                    pwmclass12.Stop();
                    pwmclass18.Stop();
                    pwmclass13.Stop();
                    pwmclass19.Stop();
                }
                 else if(message=="automode"){
                    LogSys.ErrorLog("dondu hanim ");
                    TCRT5000.döndü_hanım();
                    
                }
                 else if(message == "pwmdrivermode")
                {
                    while(true){
                     if (Console.KeyAvailable)
            {
               var key = Console.ReadKey(intercept: true);
                if (key.Key == ConsoleKey.W)
                { 
                    GC.Write(26,PinValue.High);
                    GC.Write(3,PinValue.High);
                    GC.Write(17,PinValue.High);
                    GC.Write(27,PinValue.High);
                    pwmclass12.SetDutyCycle(255);
                    pwmclass13.SetDutyCycle(0);
                    pwmclass12.Start();
                    pwmclass13.Start();
                    LogSys.InfoLog("pwm12 255 yazdir !! ILERI IIII  ");
                    
                }
                if (key.Key == ConsoleKey.A)
                {

                   GC.Write(26,PinValue.High);
                    GC.Write(3,PinValue.High);
                    GC.Write(17,PinValue.High);
                    GC.Write(27,PinValue.High);
                    //12 SA GMOTOR ILERI
                    //13 SAG MOTOER GERI 
                    
                    pwmclass12.SetDutyCycle(0);
                    pwmclass13.SetDutyCycle(255);
                    pwmclass18.SetDutyCycle(255);
                    pwmclass19.SetDutyCycle(0);
                    pwmclass12.Start();
                    pwmclass13.Start();
                    pwmclass18.Start();
                    pwmclass19.Start();
                    LogSys.InfoLog("pwm12 255 yazdir !! ILERI IIII  ");
                }
                if (key.Key == ConsoleKey.S)
                {

                  GC.Write(2,PinValue.High);
                    GC.Write(3,PinValue.High);
                    GC.Write(17,PinValue.High);
                    GC.Write(27,PinValue.High);
                  
                    //12 SA GMOTOR ILERI
                    //13 SAG MOTOER GERI 
                    pwmclass12.SetDutyCycle(0);
                    pwmclass13.SetDutyCycle(255);
                    pwmclass18.SetDutyCycle(0);
                    pwmclass19.SetDutyCycle(255);
                    pwmclass12.Start();
                    pwmclass13.Start();
                    pwmclass18.Start();
                    pwmclass19.Start();
                    LogSys.InfoLog("pwm12 255 yazdir !! ILERI IIII  ");
                    
                }
                if (key.Key == ConsoleKey.D)
                {

                   GC.Write(2,PinValue.High);
                    GC.Write(3,PinValue.High);
                    GC.Write(17,PinValue.High);
                    GC.Write(27,PinValue.High);
                  
                    //12 SA GMOTOR ILERI
                    //13 SAG MOTOER GERI 
                    
                    pwmclass12.SetDutyCycle(255);
                    pwmclass13.SetDutyCycle(0);
                    pwmclass18.SetDutyCycle(0);
                    pwmclass19.SetDutyCycle(255);
                    pwmclass12.Start();
                    pwmclass13.Start();
                    pwmclass18.Start();
                    pwmclass19.Start();
                    LogSys.InfoLog("pwm12 255 yazdir !! ILERI IIII  ");
                    
                }
                if (key.Key == ConsoleKey.Spacebar)
                {
                    Console.WriteLine("breaaak ");
                    EngineDrivers.Engine_RESET();
                }

            }
                    }
                }


                else if(message == "drivermode")
                {
                    while(true){
                     if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(intercept: true);
                if (key.Key == ConsoleKey.W)
                {
                    EngineDrivers.Engine_RESET();
                    EngineDrivers.Engine_BACKWARD();
                    
                }
                if (key.Key == ConsoleKey.A)
                {
                    EngineDrivers.Engine_RESET();
                    EngineDrivers.Engine_LEFT();
                    EngineDrivers.Engine_RIGHT(true);
                }
                if (key.Key == ConsoleKey.S)
                {
                     EngineDrivers.Engine_RESET();
                    EngineDrivers.Engine_FORWARD();
                    
                }
                if (key.Key == ConsoleKey.D)
                {
                    EngineDrivers.Engine_RESET();
                    EngineDrivers.Engine_RIGHT();
                    EngineDrivers.Engine_LEFT(true);
                    
                }
                if (key.Key == ConsoleKey.Spacebar)
                {
                    Console.WriteLine("breaaak ");
                    EngineDrivers.Engine_RESET();
                }

            }
                    }
                }

                else if(message=="rg"){
                    LogSys.SuccesLog("RIGHT");
                    EngineDrivers.Engine_RIGHT();
                }
                else if(message=="stop"){
                    LogSys.SuccesLog("STOP");
                    EngineDrivers.Engine_RESET();
                }
                else if(message=="distance"){
                    LogSys.SuccesLog(DistanceSens.GetDistance().ToString());
                }//MANUEL PIN CONTROL
                else if(message.Contains("spc")){
                    string local =message.Replace("spc","").Trim();
                    LogSys.SuccesLog($"Line {local} is "+TCRT5000.SpesificLineRead(Convert.ToInt32(local)).ToString());
                }
                else if(message.Contains("pin1")){
                     EngineDrivers.pin1=Convert.ToInt32(message.Replace("pin1","").Trim());
                }
                else if(message.Contains("pin2")){
                     EngineDrivers.pin2=Convert.ToInt32(message.Replace("pin2","").Trim());
                }
                else if(message.Contains("pin3")){
                     EngineDrivers.pin3=Convert.ToInt32(message.Replace("pin3","").Trim());
                }
                else if(message.Contains("pin4")){
                     EngineDrivers.pin4=Convert.ToInt32(message.Replace("pin4","").Trim());
                }
                else if(message.Contains("u_pin")){
                    string cutted_l=message.Replace("u_pin","").Trim();
                        if(GC.ReadPin(Convert.ToInt16(cutted_l))==1){
                            GC.Write(Convert.ToInt32(cutted_l),PinValue.High);
                            LogSys.SuccesLog(cutted_l+" set to high");
                        }
                        else{
                             GC.Write(Convert.ToInt32(cutted_l),PinValue.Low);
                            LogSys.SuccesLog(cutted_l+" set to low");
                        }
                }
                Thread.Sleep(150);
               
                
        }
    }
}