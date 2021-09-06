using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VpnKillSwitch
{
    public partial class OptionsForm : Form
    {
        public static Dictionary<Methods, string[]> METHOD_LOCATION;
        static OptionsForm() {
            METHOD_LOCATION = new Dictionary<Methods, string[]>();
            METHOD_LOCATION.Add(Methods.OpenVpn, new string[] { @"C:\Program Files(x86)\OpenVPN\bin\openvpn.exe", @"C:\Program Files\OpenVPN\bin\openvpn.exe" });
            METHOD_LOCATION.Add(Methods.OpenConnect, new string[] { @"C:\Program Files(x86)\OpenConnect-GUI\openconnect-gui.exe", @"C:\Program Files\OpenConnect-GUI\openconnect-gui.exe" });
            METHOD_LOCATION.Add(Methods.AnyConnect, new string[] { @"C:\Program Files\Cisco\Cisco AnyConnect Secure Mobility Client\vpnui.exe", @"C:\Program Files\Cisco\Cisco AnyConnect Secure Mobility Client\vpnui.exe" });
        }

        private DataBase db;
        private bool _cbx_exception_fromuser = true;

        public  static string METHOD_TYPE = "method_type", METHOD_CUSTOM_LOCATION = "method_custom_locaton" , ACCESS_IP = "access_ip";
        public OptionsForm()
        {
            db = new DataBase();
            InitializeComponent();
            
        }
        public void setStatus(bool isEnabled) {
            lbl_disable_to_change.Visible = isEnabled;
            lbl_disable_to_change_2.Visible = isEnabled;
        }
        private void OptionsForm_Load(object sender, EventArgs e)
        {
            fillMethod();
            fillExceptionList();
            btn_reload_information.PerformClick();
        }

        private void fillExceptionList()
        {
            btn_exception_remove.Enabled = false;
            lb_exception.Items.Clear();
            foreach (string s in db.getPaths())
            {
                lb_exception.Items.Add(s);
            }
        }

        private void fillMethod()
        {
            Methods m = (Methods)Enum.Parse(typeof(Methods), db.get(METHOD_TYPE, Methods.OpenVpn.ToString()));
            changeMethod(m, false);
            chk_full_internet_block.Checked = bool.Parse(db.get(ACCESS_IP, "false"));
        }

        private void changeMethod(Methods m, bool fromUser = true)
        {
            btn_choose.Enabled = m == Methods.Custom;
            lbl_location.Text = btn_choose.Enabled ? db.get(METHOD_CUSTOM_LOCATION, "N/A") : "N/A";

            if (fromUser)
            {
                db.set(METHOD_TYPE, m.ToString());
            }
            else
            {
                _cbx_exception_fromuser = false;
                cbx_method.SelectedIndex = (int)m;
            }
        }


        private void btn_exception_add_Click(object sender, EventArgs e)
        {
            ofd_exception.ShowDialog();
            if (ofd_exception.FileName != null && ofd_exception.FileName != "") {
                if (db.isPathExists(ofd_exception.FileName)) {
                    MessageBox.Show("The file's path exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                db.insertPath(ofd_exception.FileName);
                fillExceptionList();
            }
        }


        private void btn_exception_remove_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to remove : \n path : " + lb_exception.SelectedItem, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes) {
                db.removePath(lb_exception.SelectedItem.ToString());
                fillExceptionList();
            }
        }

        private void lb_exception_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_exception_remove.Enabled = lb_exception.SelectedIndex != -1;
        }
        private void cbx_method_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_cbx_exception_fromuser)
            {
                changeMethod( (Methods)Enum.Parse(typeof(Methods), cbx_method.SelectedItem.ToString() ));
            }

            _cbx_exception_fromuser = true;
        }

        //------------
        

        private void btn_choose_Click(object sender, EventArgs e)
        {
            ofd_exception.ShowDialog();
            if (ofd_exception.FileName != null && ofd_exception.FileName != "")
            {
                if(db.set(METHOD_CUSTOM_LOCATION, ofd_exception.FileName))
                {
                    lbl_location.Text = ofd_exception.FileName;
                }
            }
        }

        private void btn_reload_information_Click(object sender, EventArgs e)
        {
            btn_reload_information.Enabled = false;
            new Thread(() =>
            {
                string publicIp = NetworkManager.getPulibcIPAddress();
                string localIp = new NetworkManager.NetworkAdapter().getInformation().ip;
                string method = db.get(METHOD_TYPE, Methods.OpenVpn.ToString());
                this.Invoke((MethodInvoker) delegate() {
                    setInformaiton(publicIp , localIp , method);
                    btn_reload_information.Enabled = true;
                } , null);
            }).Start();
        }
        void test() { }
        private void setInformaiton(string publicIp , string localIp , string method) {
            
            this.lbl_public_ip.Text = publicIp;
            this.lbl_local_ip.Text = localIp;
            this.lbl_method.Text = method;
        }

        private void chk_full_internet_block_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_full_internet_block.Checked == bool.Parse(db.get(ACCESS_IP, "false")) == true) return;

            chk_full_internet_block.Enabled = false;
            if (chk_full_internet_block.Checked)
            {
                string pip = NetworkManager.getPulibcIPAddress();
                if (MessageBox.Show("Do you accept this ip \nip address : " + pip, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    new NetworkManager.NetworkAdapter().setGateWay(pip);
                    db.set(ACCESS_IP, "true");
                }
                else {
                    chk_full_internet_block.Checked = false;
                }
               
            }
            else {
                new NetworkManager.NetworkAdapter().setIpAutomatically();
                db.set(ACCESS_IP, "false");
            }
            chk_full_internet_block.Enabled = true;
        }

        public enum Methods { 
            OpenVpn , OpenConnect , AnyConnect , Custom
        }
    }
}
