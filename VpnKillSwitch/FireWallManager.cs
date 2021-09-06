using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using System.ComponentModel;

namespace VpnKillSwitch
{
    class FireWallManager
    {
        //utility functions
        public static void blockOutboundConnections(){
            PowerShell.executeCommad("Set-NetFirewallProfile -DefaultInboundAction Block -DefaultOutboundAction Block -Profile Domain,Private");
        }
        public static void allowOutboundConnections()
        {
            PowerShell.executeCommad("Set-NetFirewallProfile -DefaultInboundAction Block -DefaultOutboundAction Allow -Profile Domain,Private");
        }
        public static bool getOutboundDefaultConnection() {
            bool ret = true;
            string output = PowerShell.executeCommad("Get-NetFirewallProfile").Trim() ;
            bool allow = false;
            foreach (string l in output.Split('\n'))
            {
                string[] sections = l.Split(':');
                if (sections.Length < 2) continue;
                if (sections[0].Trim() == "Name" && (sections[1].Trim() == "Private" || sections[1].Trim() == "Domain")) {
                    allow = true;
                }
                else
                if (sections[0].Trim() == "DefaultOutboundAction" && allow) {
                    ret = ret && (sections[1].Trim() == "Block");
                    allow = false;
                }
            }

            return ret;
        }

        public static void createRouleAllowProgram(string path) {
            string name = createMD5(path);
            PowerShell.executeCommad(String.Format("netsh advfirewall firewall add rule name = \"{0}\" dir = in action = allow enable = yes profile=domain,private,public program='{1}'", name, path));
            PowerShell.executeCommad(String.Format("netsh advfirewall firewall add rule name = \"{0}\" dir = out action = allow  enable = yes profile=domain,private,public program='{1}'", name, path));
        }
        public static void deleteRouleAllowProgram(string path) {
            string name = createMD5(path);
            PowerShell.executeCommad(String.Format("netsh advfirewall firewall delete rule name=\"{0}\" program='{1}'", name, path));
        }



        // structs


        //------------

        public static string createMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        public static class Helper {

            public static void Enable(ISynchronizeInvoke inv , string program , Action callback)
            {
                new Thread(() => {
                    new NetworkManager.NetworkAdapter().changeNetToPrivate();
                    FireWallManager.blockOutboundConnections();
                    string[] paths = DataBase.db.getPaths();
                    foreach (string path in paths)
                    {
                        FireWallManager.createRouleAllowProgram(path);
                    }
                    FireWallManager.createRouleAllowProgram(program);
                    inv.Invoke(callback, null);
                }).Start(); 
            }

            public static void Disable(ISynchronizeInvoke inv ,  string program , Action callback)
            {
                new Thread(() =>
                {
                    new NetworkManager.NetworkAdapter().changeNetToPublic();
                    FireWallManager.allowOutboundConnections();
                    string[] paths = DataBase.db.getPaths();
                    foreach (string path in paths) {
                        FireWallManager.deleteRouleAllowProgram(path);
                    }
                    FireWallManager.deleteRouleAllowProgram(program);
                    inv.Invoke(callback , null);
                }).Start();
            }

            public static void IsEnable(ISynchronizeInvoke inv ,  Action<bool> callback)
            {
                new Thread(() =>
                {
                    inv.Invoke(callback, new Object[] { FireWallManager.getOutboundDefaultConnection() });
                }).Start();
            }
        }
    }
}
