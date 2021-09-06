using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VpnKillSwitch
{
    class PowerShell
    {
        public static String execute(string progrem, string args)
        {
            //info
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = progrem;
            info.Arguments = args;
            info.RedirectStandardOutput = true;
            info.UseShellExecute = false;
            info.CreateNoWindow = true;

            // process
            Process p = new Process();
            p.StartInfo = info;
            p.Start();

            return p.StandardOutput.ReadToEnd();
        }
        public static string executeCommad(string command)
        {
            return execute("powershell.exe", command);
        }
    }
}
