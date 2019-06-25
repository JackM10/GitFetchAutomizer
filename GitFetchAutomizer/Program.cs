using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

class Program
{
    private const string mainPath = @"C:\Code";
    private static string[] allSubDirectories = Directory.GetDirectories(mainPath);

    static void Main()
    {
        Parallel.ForEach(allSubDirectories, (directory) =>
        {
            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = @"C:\Windows\System32\cmd.exe",
                    Arguments = "/c start git fetch",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true,
                    WorkingDirectory = directory
                }
            };

            proc.Start();
        });

        Environment.ExitCode = 0;
    }
}

