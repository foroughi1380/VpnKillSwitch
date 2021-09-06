
namespace VpnKillSwitch
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.actionbtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.status = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbl_option = new System.Windows.Forms.Label();
            this.lbl_wait = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // actionbtn
            // 
            this.actionbtn.Location = new System.Drawing.Point(12, 12);
            this.actionbtn.Name = "actionbtn";
            this.actionbtn.Size = new System.Drawing.Size(63, 59);
            this.actionbtn.TabIndex = 0;
            this.actionbtn.Text = "Disable";
            this.actionbtn.UseVisualStyleBackColor = true;
            this.actionbtn.Click += new System.EventHandler(this.actionbtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(81, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "status : ";
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.Location = new System.Drawing.Point(131, 20);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(66, 13);
            this.status.TabIndex = 2;
            this.status.Text = "No detected";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(93, 26);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::VpnKillSwitch.Properties.Resources.openvpn_icon1;
            this.pictureBox1.Location = new System.Drawing.Point(102, -20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(304, 157);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // lbl_option
            // 
            this.lbl_option.AutoSize = true;
            this.lbl_option.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_option.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_option.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbl_option.Location = new System.Drawing.Point(79, 40);
            this.lbl_option.Name = "lbl_option";
            this.lbl_option.Size = new System.Drawing.Size(44, 14);
            this.lbl_option.TabIndex = 5;
            this.lbl_option.Text = "Options";
            this.lbl_option.Click += new System.EventHandler(this.lbl_option_Click);
            // 
            // lbl_wait
            // 
            this.lbl_wait.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_wait.Location = new System.Drawing.Point(0, 0);
            this.lbl_wait.Name = "lbl_wait";
            this.lbl_wait.Size = new System.Drawing.Size(289, 82);
            this.lbl_wait.TabIndex = 7;
            this.lbl_wait.Text = "label2";
            this.lbl_wait.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 82);
            this.Controls.Add(this.lbl_wait);
            this.Controls.Add(this.lbl_option);
            this.Controls.Add(this.status);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.actionbtn);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Vpn Kill Switch";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button actionbtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Label lbl_option;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label lbl_wait;
    }
}

