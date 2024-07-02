using GpioLedExample;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class TcpServer
{
//BERKAY TARAFINDAN YAZILDI
    private readonly int _port;
    private TcpListener _server;
    private bool _isRunning;

    public TcpServer(int port)
    {
        _port = port;
    }

    public void Listen()
    {
        if (_isRunning)
        {
            Console.WriteLine("Server is already running.");
            return;
        }

        try
        {
            IPAddress localAddr = IPAddress.Parse("0.0.0.0");//LOCALHOST
            _server = new TcpListener(localAddr, _port);
            _server.Start();
            _isRunning = true;

            Console.WriteLine($"TCP AÇILDI PORT :  {_port}...");

            while (_isRunning)
            {
                // Bağlantı isteği bekle
                TcpClient client = _server.AcceptTcpClient();

                // Yeni bir iş parçacığı başlat
                Thread clientThread = new Thread(() => HandleClient(client));
                clientThread.Start();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception: {e.Message}");
        }
        finally
        {
            Stop();
        }
    }

    private void HandleClient(TcpClient client)
    {
        using (NetworkStream stream = client.GetStream())
        {
            byte[] buffer = new byte[1024];
            int bytesRead;

            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                // Gelen veriyi ekrana yazdır
                string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                Console.WriteLine($"Received text: {message}");
                Program.lastreceviedstring=message;
            }
        }

        client.Close();
    }

    public void Stop()
    {
        if (_isRunning)
        {
            _server.Stop();
            _isRunning = false;
            Console.WriteLine("Server stopped.");
        }
    }
}
