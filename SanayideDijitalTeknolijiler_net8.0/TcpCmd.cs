using SanayideDijitalTeknolijiler_net8._0;
using Swan.Logging;

namespace SanayideDijitalTeknolijiler_net8._0
{
    public static class TcpCmd
    {
        internal static void Executor(){
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
                    EngineDrivers.Engine_STOP();
                }
                Thread.Sleep(150);
                oldmessage=message;
                }
               
            }
        }
    }
}