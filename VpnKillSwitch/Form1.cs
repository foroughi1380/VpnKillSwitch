using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VpnKillSwitch
{
    public partial class Form1 : Form
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
        private bool isEnabled;
        private OptionsForm of = new OptionsForm();
        public Form1()
        {
            InitializeComponent();
        }
        

        private void actionbtn_Click(object sender, EventArgs e)
        {
            if (!(sender as Button).Enabled)
                return;

            
            if (isEnabled)
            {
                showWait("please wait - disabling");
                Disable(checkStatus);
            }
            else
            {
                showWait("please wait - enabling");
                Active(checkStatus);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            const int margin = 10;
            int x = Screen.PrimaryScreen.WorkingArea.Right -
                this.Width - margin;
            int y = Screen.PrimaryScreen.WorkingArea.Bottom -
                this.Height - margin;
            this.Location = new Point(x, y);

            
            checkStatus();

        }



        private void checkStatus() {

            showWait("please wait - checking status");

            FireWallManager.Helper.IsEnable(this , e => {
                isEnabled = e;
                this.status.Text = isEnabled ? "Active" : "Inactive";
                this.status.ForeColor = isEnabled ? Color.Green : Color.Red;
                this.actionbtn.Text = isEnabled ? "Disable" : "Enable";
                if (isEnabled)
                {
                    this.notifyIcon1.Icon = Properties.Resources.green;
                }
                else {
                    this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
                }
                hideWait();
            });
            
        }

        private void Active(Action callback) {
            string location = getVpnMethodLocation();
            if (location != null)
            {
                FireWallManager.Helper.Enable(this, location, callback);
            }
            else {
                checkStatus();
            }
        }
        private void Disable(Action callback) {
            string location = getVpnMethodLocation();
            if (location != null)
            {
                FireWallManager.Helper.Disable(this, location, callback);
            }
            else {
                checkStatus();
            }
        }

        private string getVpnMethodLocation() {
            string type = DataBase.db.get(OptionsForm.METHOD_TYPE, OptionsForm.Methods.OpenVpn.ToString());
            OptionsForm.Methods m = (OptionsForm.Methods) Enum.Parse(typeof(OptionsForm.Methods), type);
            string location = null;

            if (m == OptionsForm.Methods.Custom)
            {
                location = DataBase.db.get(OptionsForm.METHOD_CUSTOM_LOCATION, null);
                if(location == null || File.Exists(location)) { 
                    MessageBox.Show("Your Path in Custom Method not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return location;
            }
            else {
                string[] locations = OptionsForm.METHOD_LOCATION[m];
                foreach (string path in locations) {
                    if (File.Exists(path)) {
                        location = path;
                        break;
                    }
                }

                if (location == null) {
                    MessageBox.Show(m.ToString() + " not found in your device.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return location;
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (Visible)
                Hide();
            else if(! of.Visible)
                Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void lbl_option_Click(object sender, EventArgs e)
        {
            of.setStatus(isEnabled);
            Hide();
            of.ShowDialog();
            Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }


        private void showWait(string message = "please wait") {
            lbl_wait.Text = message;
            lbl_wait.Visible = true;
        }
        private void hideWait() {
            lbl_wait.Visible = false;
        }
    }
}
