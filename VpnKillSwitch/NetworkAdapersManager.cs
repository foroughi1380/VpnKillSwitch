using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Net;
using System.IO;

namespace VpnKillSwitch
{
    class NetworkManager
    {
        public static NetConnectProfile getNetConnectionProfile()
        {
            NetConnectProfile profile = new NetConnectProfile();

            string output = PowerShell.executeCommad("Get-NetConnectionProfile").Trim();

            foreach (string l in output.Split('\n'))
            {
                string[] sections = l.Split(':');
                switch (sections[0].Trim())
                {
                    case "Name":
                        profile.name = sections[1].Trim();
                        break;
                    case "InterfaceAlias":
                        profile.alias = sections[1].Trim();
                        break;
                    case "InterfaceIndex":
                        profile.index = sections[1].Trim();
                        break;
                    case "NetworkCategory":
                        profile.category = sections[1].Trim();
                        break;
                }
            }


            return profile;
        }
        public static string getPulibcIPAddress()
        {
            
            String address = "";
            try
            {
                WebRequest request = WebRequest.Create("http://checkip.dyndns.org/");
                using (WebResponse response = request.GetResponse())
                using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                {
                    address = stream.ReadToEnd();
                }

                int first = address.IndexOf("Address: ") + 9;
                int last = address.LastIndexOf("</body>");
                address = address.Substring(first, last - first);
            }
            catch (Exception e) {
                address = "N/A";
            }
            

            return address;
        }
        public static string[] getAvalbledAdaptersNames(){
            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
            string[] ret = new string[adapters.Length];

            for (int i = 0; i < ret.Length; i++) {
                ret[i] = adapters[i].Name;
            }

            return ret;
        }

        public class NetworkAdapter {
            private NetConnectProfile profile;
            public NetworkAdapter(NetConnectProfile profile) {
                this.profile = profile;
            }
            public NetworkAdapter() : this(getNetConnectionProfile()) {}

            public  void changeNetToPrivate()
            {
                NetConnectProfile profile = getNetConnectionProfile();
                PowerShell.executeCommad(String.Format("Set-NetConnectionProfile -Name \"{0}\" -NetworkCategory Private", this.profile.name));
            }
            public  void changeNetToPublic()
            {
                NetConnectProfile profile = getNetConnectionProfile();
                PowerShell.executeCommad(String.Format("Set-NetConnectionProfile -Name \"{0}\" -NetworkCategory Public", this.profile.name));
            }

            public bool enable() {
                return runNetsh("interface set interface \"" + this.profile.alias + "\" enable");
            }

            public bool disable()
            {
                return runNetsh("interface set interface \"" + this.profile.alias + "\" disable");
            }

            public IpStatusInformation getInformation() {
                IpStatusInformation info = new IpStatusInformation();

                NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface adapter in adapters) {
                    if (adapter.Name == this.profile.alias) {
                        UnicastIPAddressInformation informaion = adapter.GetIPProperties().UnicastAddresses[0];
                        info.ip = informaion.Address.ToString();
                        info.subnet = informaion.IPv4Mask.ToString();
                    
                    }
                    break;
                    
                }

                return info;
            }

            public bool setIpAutomatically() {
                return runNetsh(String.Format("interface ipv4 set address name=\"{0}\" source=dhcp", this.profile.alias ));
            }

            public bool setIpAddress(string address, string sub, string gateway) {
                return runNetsh(String.Format("interface ipv4 set address name=\"{0}\" static {1} {2} {3}", this.profile.alias, address, sub, gateway));
            }
            public bool setGateWay(string gateway) {
                return runNetsh(string.Format("interface ip add address '{0}'  gateway={1} gwmetric=2", this.profile.alias, gateway));
            }



            //utility functions
            private bool runNetsh(string args) {
                string ret = PowerShell.executeCommad("netsh " + args);
                return ! ret.Contains("error");
            }

            //utility architact
            public struct IpStatusInformation {
                public string ip, subnet, getway;
            }
        }
        public struct NetConnectProfile
        {
            public string name, alias, index, category;
        }
    }
}
