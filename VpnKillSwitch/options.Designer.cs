
namespace VpnKillSwitch
{
    partial class OptionsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_exception = new System.Windows.Forms.ListBox();
            this.btn_exception_add = new System.Windows.Forms.Button();
            this.btn_exception_remove = new System.Windows.Forms.Button();
            this.cbx_method = new System.Windows.Forms.ComboBox();
            this.btn_choose = new System.Windows.Forms.Button();
            this.chk_full_internet_block = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_public_ip = new System.Windows.Forms.Label();
            this.lbl_local_ip = new System.Windows.Forms.Label();
            this.lbl_method = new System.Windows.Forms.Label();
            this.lbl_location = new System.Windows.Forms.Label();
            this.ofd_exception = new System.Windows.Forms.OpenFileDialog();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_reload_information = new System.Windows.Forms.Button();
            this.lbl_disable_to_change = new System.Windows.Forms.Label();
            this.lbl_disable_to_change_2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mthod : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(468, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Exception Programs : ";
            // 
            // lb_exception
            // 
            this.lb_exception.FormattingEnabled = true;
            this.lb_exception.Location = new System.Drawing.Point(471, 25);
            this.lb_exception.Name = "lb_exception";
            this.lb_exception.Size = new System.Drawing.Size(317, 420);
            this.lb_exception.TabIndex = 2;
            this.lb_exception.SelectedIndexChanged += new System.EventHandler(this.lb_exception_SelectedIndexChanged);
            // 
            // btn_exception_add
            // 
            this.btn_exception_add.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_exception_add.Location = new System.Drawing.Point(422, 354);
            this.btn_exception_add.Name = "btn_exception_add";
            this.btn_exception_add.Size = new System.Drawing.Size(43, 39);
            this.btn_exception_add.TabIndex = 3;
            this.btn_exception_add.Text = "+";
            this.btn_exception_add.UseVisualStyleBackColor = true;
            this.btn_exception_add.Click += new System.EventHandler(this.btn_exception_add_Click);
            // 
            // btn_exception_remove
            // 
            this.btn_exception_remove.Enabled = false;
            this.btn_exception_remove.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_exception_remove.Location = new System.Drawing.Point(422, 399);
            this.btn_exception_remove.Name = "btn_exception_remove";
            this.btn_exception_remove.Size = new System.Drawing.Size(43, 39);
            this.btn_exception_remove.TabIndex = 4;
            this.btn_exception_remove.Text = "-";
            this.btn_exception_remove.UseVisualStyleBackColor = true;
            this.btn_exception_remove.Click += new System.EventHandler(this.btn_exception_remove_Click);
            // 
            // cbx_method
            // 
            this.cbx_method.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_method.FormattingEnabled = true;
            this.cbx_method.Items.AddRange(new object[] {
            "OpenVpn",
            "OpenConnect",
            "AnyConnect",
            "Custom"});
            this.cbx_method.Location = new System.Drawing.Point(65, 9);
            this.cbx_method.Name = "cbx_method";
            this.cbx_method.Size = new System.Drawing.Size(121, 21);
            this.cbx_method.TabIndex = 5;
            this.cbx_method.SelectedIndexChanged += new System.EventHandler(this.cbx_method_SelectedIndexChanged);
            // 
            // btn_choose
            // 
            this.btn_choose.Location = new System.Drawing.Point(192, 9);
            this.btn_choose.Name = "btn_choose";
            this.btn_choose.Size = new System.Drawing.Size(75, 23);
            this.btn_choose.TabIndex = 6;
            this.btn_choose.Text = "choose";
            this.btn_choose.UseVisualStyleBackColor = true;
            this.btn_choose.Click += new System.EventHandler(this.btn_choose_Click);
            // 
            // chk_full_internet_block
            // 
            this.chk_full_internet_block.AutoSize = true;
            this.chk_full_internet_block.Location = new System.Drawing.Point(12, 85);
            this.chk_full_internet_block.Name = "chk_full_internet_block";
            this.chk_full_internet_block.Size = new System.Drawing.Size(242, 17);
            this.chk_full_internet_block.TabIndex = 7;
            this.chk_full_internet_block.Text = "Only Access to Internet With current Public IP";
            this.chk_full_internet_block.UseVisualStyleBackColor = true;
            this.chk_full_internet_block.CheckedChanged += new System.EventHandler(this.chk_full_internet_block_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::VpnKillSwitch.Properties.Resources.openvpn_icon1;
            this.pictureBox1.Location = new System.Drawing.Point(-139, 224);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(543, 365);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 432);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "© Mohammad Foroughi";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "custom location :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "public ip :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 164);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "local ip :";
            // 
            // lbl_public_ip
            // 
            this.lbl_public_ip.AutoSize = true;
            this.lbl_public_ip.Location = new System.Drawing.Point(95, 143);
            this.lbl_public_ip.Name = "lbl_public_ip";
            this.lbl_public_ip.Size = new System.Drawing.Size(16, 13);
            this.lbl_public_ip.TabIndex = 15;
            this.lbl_public_ip.Text = "---";
            // 
            // lbl_local_ip
            // 
            this.lbl_local_ip.AutoSize = true;
            this.lbl_local_ip.Location = new System.Drawing.Point(95, 164);
            this.lbl_local_ip.Name = "lbl_local_ip";
            this.lbl_local_ip.Size = new System.Drawing.Size(16, 13);
            this.lbl_local_ip.TabIndex = 16;
            this.lbl_local_ip.Text = "---";
            // 
            // lbl_method
            // 
            this.lbl_method.AutoSize = true;
            this.lbl_method.Location = new System.Drawing.Point(95, 184);
            this.lbl_method.Name = "lbl_method";
            this.lbl_method.Size = new System.Drawing.Size(16, 13);
            this.lbl_method.TabIndex = 18;
            this.lbl_method.Text = "---";
            // 
            // lbl_location
            // 
            this.lbl_location.AutoSize = true;
            this.lbl_location.Location = new System.Drawing.Point(106, 41);
            this.lbl_location.Name = "lbl_location";
            this.lbl_location.Size = new System.Drawing.Size(16, 13);
            this.lbl_location.TabIndex = 19;
            this.lbl_location.Text = "---";
            // 
            // ofd_exception
            // 
            this.ofd_exception.Filter = "EXE file|*.exe";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 184);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Method : ";
            // 
            // btn_reload_information
            // 
            this.btn_reload_information.Location = new System.Drawing.Point(8, 208);
            this.btn_reload_information.Name = "btn_reload_information";
            this.btn_reload_information.Size = new System.Drawing.Size(75, 23);
            this.btn_reload_information.TabIndex = 20;
            this.btn_reload_information.Text = "Reload";
            this.btn_reload_information.UseVisualStyleBackColor = true;
            this.btn_reload_information.Click += new System.EventHandler(this.btn_reload_information_Click);
            // 
            // lbl_disable_to_change
            // 
            this.lbl_disable_to_change.Location = new System.Drawing.Point(64, 9);
            this.lbl_disable_to_change.Name = "lbl_disable_to_change";
            this.lbl_disable_to_change.Size = new System.Drawing.Size(214, 31);
            this.lbl_disable_to_change.TabIndex = 21;
            this.lbl_disable_to_change.Text = "Disable to change";
            // 
            // lbl_disable_to_change_2
            // 
            this.lbl_disable_to_change_2.Location = new System.Drawing.Point(419, 354);
            this.lbl_disable_to_change_2.Name = "lbl_disable_to_change_2";
            this.lbl_disable_to_change_2.Size = new System.Drawing.Size(46, 84);
            this.lbl_disable_to_change_2.TabIndex = 22;
            this.lbl_disable_to_change_2.Text = "Disable to change";
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbl_disable_to_change_2);
            this.Controls.Add(this.lbl_disable_to_change);
            this.Controls.Add(this.btn_reload_information);
            this.Controls.Add(this.lbl_location);
            this.Controls.Add(this.lbl_method);
            this.Controls.Add(this.lbl_local_ip);
            this.Controls.Add(this.lbl_public_ip);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.chk_full_internet_block);
            this.Controls.Add(this.btn_choose);
            this.Controls.Add(this.cbx_method);
            this.Controls.Add(this.btn_exception_remove);
            this.Controls.Add(this.btn_exception_add);
            this.Controls.Add(this.lb_exception);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OptionsForm";
            this.Text = "Options";
            this.Load += new System.EventHandler(this.OptionsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lb_exception;
        private System.Windows.Forms.Button btn_exception_add;
        private System.Windows.Forms.Button btn_exception_remove;
        private System.Windows.Forms.ComboBox cbx_method;
        private System.Windows.Forms.Button btn_choose;
        private System.Windows.Forms.CheckBox chk_full_internet_block;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_public_ip;
        private System.Windows.Forms.Label lbl_local_ip;
        private System.Windows.Forms.Label lbl_method;
        private System.Windows.Forms.Label lbl_location;
        private System.Windows.Forms.OpenFileDialog ofd_exception;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_reload_information;
        private System.Windows.Forms.Label lbl_disable_to_change;
        private System.Windows.Forms.Label lbl_disable_to_change_2;
    }
}