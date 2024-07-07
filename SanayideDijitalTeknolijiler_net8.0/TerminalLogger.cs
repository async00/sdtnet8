using System.Diagnostics;
using System.IO;

namespace SanayideDijitalTeknolijiler_net8._0{
public class TerminalLogger
{

    //bu classı sadece daha kolay log alıp yazak diye yaptım irdeleme 
    private readonly Process _terminalProcess;
    private readonly StreamWriter _writer;

    private TerminalLogger(Process terminalProcess)
    {
        _terminalProcess = terminalProcess;
        _writer = new StreamWriter(_terminalProcess.StandardInput.BaseStream);
    }

    public static TerminalLogger BeginTerminal(string terminalCommand = "xterm")
    {
        ProcessStartInfo startInfo = new ProcessStartInfo
        {
            FileName = "/bin/bash",
            Arguments = $"-c \"{terminalCommand}\"",
            RedirectStandardInput = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        Process terminalProcess = Process.Start(startInfo);
        return new TerminalLogger(terminalProcess);
    }

    public void WriteToTerminal(string message)
    {
        _writer.WriteLine(message);
        _writer.Flush();
    }

    public void CloseTerminal()
    {
        _writer.Close();
        _terminalProcess.Kill();
    }
    public void ClearTerminal()
    {
        _writer.WriteLine("clear");
        _writer.Flush();
    }
}
}