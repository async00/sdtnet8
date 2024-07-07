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
                }
                else if(message.Contains("spc")){
                    string local =message.Replace("spc","").Trim();
                    LogSys.SuccesLog($"Line {local} is "+TCRT5000.SpesificLineRead(Convert.ToInt32(local)).ToString());
                }
                
                Thread.Sleep(150);
               
                
        }
    }
}