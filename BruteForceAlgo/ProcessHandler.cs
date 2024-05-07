using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BruteForceAlgo
{
    internal class ProcessHandler
    {
        private string path = "C:\\Users\\Nico\\source\\repos\\C#\\AE-Vertiefung\\BruteForceOpfer\\bin\\Debug\\net8.0\\BruteForceOpfer.exe";
        private string argue = string.Empty;

        public ProcessHandler()
        {
        }

        public int StartProgram(string argue)
        {
            this.argue = argue;

            Process process = new();

            process.StartInfo.FileName = path;
            process.StartInfo.Arguments = argue;

            process.Start();

            process.WaitForExit();

            return process.ExitCode;
        }
    }
}