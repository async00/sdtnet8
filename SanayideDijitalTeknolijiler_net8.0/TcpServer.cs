using SanayideDijitalTeknolijiler_net8._0;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Xml.Linq;

public class TcpServer
{
    //BERKAY TARAFINDAN YAZILDI
    private static string lastrecmessage = string.Empty;
    private static readonly int _port=2804;
    private static TcpListener _server;
    private static bool _isRunning;

    internal static string GetLastMessage()
    {

        return lastrecmessage;//en son gelen text mesajını döndür
    }
    public static void Listen()
    {
        if (_isRunning)
        {
           LogSys.WarnLog("Server is already running.");
            return;
        }

        try
        {
            IPAddress localAddr = IPAddress.Parse("0.0.0.0");//raspberry pide isen 0.0.0.0
            _server = new TcpListener(localAddr, _port);
            _server.Start();
            _isRunning = true;

            LogSys.SuccesLog($"Tcp server started on "+_port);

            while (_isRunning)
            {
                // Bağlantı isteği bekle
                TcpClient client = _server.AcceptTcpClient();

                // Yeni bir iş parçacığı başlat
              
                HandleClient(client);
            }
        }
        catch (Exception e)
        {
           LogSys.ErrorLog($"Exception at tcp server starting: {e.Message}");
        }
        finally
        {
            Stop();
        }
    }

    private static void HandleClient(TcpClient client)
    {
        using (NetworkStream stream = client.GetStream())
        {
            byte[] buffer = new byte[1024];
            int bytesRead;

            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                // Gelen veriyi ekrana yazdır
                string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                LogSys.InfoLog($"CLIENT: {message}");
                if(message=="fw"){
                    EngineDrivers.Engine_FORWARD();
            }
        }
    }
        client.Close();
    }

    public static void Stop()
    {
        if (_isRunning)
        {
            _server.Stop();
            _isRunning = false;
            LogSys.SuccesLog("Server stopped.");
        }
    }
}
