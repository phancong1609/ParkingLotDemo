namespace Project_BaiGiuXe.Login
{
    partial class Form_Login_Main
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_tatLogin = new System.Windows.Forms.Button();
            this.comboBox_loaiDangNhap = new System.Windows.Forms.ComboBox();
            this.checkBox_isShowPass = new System.Windows.Forms.CheckBox();
            this.linkLabel_khongTheGN = new System.Windows.Forms.LinkLabel();
            this.button_login = new System.Windows.Forms.Button();
            this.checkBox_ghiNhoDN = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_passWord = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label_userName = new System.Windows.Forms.Label();
            this.textBox_userName = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.button_tatLogin);
            this.panel1.Controls.Add(this.comboBox_loaiDangNhap);
            this.panel1.Controls.Add(this.checkBox_isShowPass);
            this.panel1.Controls.Add(this.linkLabel_khongTheGN);
            this.panel1.Controls.Add(this.button_login);
            this.panel1.Controls.Add(this.checkBox_ghiNhoDN);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBox_passWord);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label_userName);
            this.panel1.Controls.Add(this.textBox_userName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(554, 1080);
            this.panel1.TabIndex = 0;
            // 
            // button_tatLogin
            // 
            this.button_tatLogin.FlatAppearance.BorderSize = 0;
            this.button_tatLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_tatLogin.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button_tatLogin.ForeColor = System.Drawing.Color.Black;
            this.button_tatLogin.Location = new System.Drawing.Point(0, -9);
            this.button_tatLogin.Name = "button_tatLogin";
            this.button_tatLogin.Size = new System.Drawing.Size(41, 49);
            this.button_tatLogin.TabIndex = 15;
            this.button_tatLogin.Text = "×";
            this.button_tatLogin.UseVisualStyleBackColor = true;
            this.button_tatLogin.Click += new System.EventHandler(this.button_tatLogin_Click);
            // 
            // comboBox_loaiDangNhap
            // 
            this.comboBox_loaiDangNhap.BackColor = System.Drawing.SystemColors.Control;
            this.comboBox_loaiDangNhap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_loaiDangNhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox_loaiDangNhap.Font = new System.Drawing.Font("Segoe UI Variable Display", 19.8F, System.Drawing.FontStyle.Bold);
            this.comboBox_loaiDangNhap.FormattingEnabled = true;
            this.comboBox_loaiDangNhap.Items.AddRange(new object[] {
            "Administator",
            "Quản lí bãi xe"});
            this.comboBox_loaiDangNhap.Location = new System.Drawing.Point(83, 573);
            this.comboBox_loaiDangNhap.Name = "comboBox_loaiDangNhap";
            this.comboBox_loaiDangNhap.Size = new System.Drawing.Size(384, 52);
            this.comboBox_loaiDangNhap.TabIndex = 9;
            // 
            // checkBox_isShowPass
            // 
            this.checkBox_isShowPass.AutoSize = true;
            this.checkBox_isShowPass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBox_isShowPass.Location = new System.Drawing.Point(435, 498);
            this.checkBox_isShowPass.Name = "checkBox_isShowPass";
            this.checkBox_isShowPass.Size = new System.Drawing.Size(18, 17);
            this.checkBox_isShowPass.TabIndex = 7;
            this.checkBox_isShowPass.UseVisualStyleBackColor = true;
            this.checkBox_isShowPass.CheckedChanged += new System.EventHandler(this.checkBox_isShowPass_CheckedChanged);
            // 
            // linkLabel_khongTheGN
            // 
            this.linkLabel_khongTheGN.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(70)))), ((int)(((byte)(85)))));
            this.linkLabel_khongTheGN.AutoSize = true;
            this.linkLabel_khongTheGN.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.linkLabel_khongTheGN.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.linkLabel_khongTheGN.LinkColor = System.Drawing.Color.DimGray;
            this.linkLabel_khongTheGN.Location = new System.Drawing.Point(114, 1020);
            this.linkLabel_khongTheGN.Name = "linkLabel_khongTheGN";
            this.linkLabel_khongTheGN.Size = new System.Drawing.Size(315, 27);
            this.linkLabel_khongTheGN.TabIndex = 6;
            this.linkLabel_khongTheGN.TabStop = true;
            this.linkLabel_khongTheGN.Text = "Không thể đăng nhập ? Gửi hỗ trợ";
            this.linkLabel_khongTheGN.VisitedLinkColor = System.Drawing.Color.Black;
            this.linkLabel_khongTheGN.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_khongTheGN_LinkClicked);
            // 
            // button_login
            // 
            this.button_login.BackColor = System.Drawing.Color.Transparent;
            this.button_login.BackgroundImage = global::Project_BaiGiuXe.Properties.Resources.Login_button;
            this.button_login.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_login.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_login.Enabled = false;
            this.button_login.FlatAppearance.BorderSize = 0;
            this.button_login.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(52)))), ((int)(((byte)(63)))));
            this.button_login.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(70)))), ((int)(((byte)(85)))));
            this.button_login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_login.Location = new System.Drawing.Point(202, 774);
            this.button_login.Name = "button_login";
            this.button_login.Size = new System.Drawing.Size(150, 150);
            this.button_login.TabIndex = 5;
            this.button_login.UseVisualStyleBackColor = false;
            this.button_login.Click += new System.EventHandler(this.button_login_Click);
            // 
            // checkBox_ghiNhoDN
            // 
            this.checkBox_ghiNhoDN.AutoSize = true;
            this.checkBox_ghiNhoDN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBox_ghiNhoDN.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBox_ghiNhoDN.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.checkBox_ghiNhoDN.Location = new System.Drawing.Point(83, 662);
            this.checkBox_ghiNhoDN.Name = "checkBox_ghiNhoDN";
            this.checkBox_ghiNhoDN.Size = new System.Drawing.Size(253, 32);
            this.checkBox_ghiNhoDN.TabIndex = 4;
            this.checkBox_ghiNhoDN.Text = " GHI NHỚ ĐĂNG NHẬP";
            this.checkBox_ghiNhoDN.UseVisualStyleBackColor = true;
            this.checkBox_ghiNhoDN.CheckedChanged += new System.EventHandler(this.checkBox_ghiNhoDN_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI Variable Small Semibol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.ForeColor = System.Drawing.Color.OrangeRed;
            this.label3.Location = new System.Drawing.Point(383, 543);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 27);
            this.label3.TabIndex = 3;
            this.label3.Text = "BẠN LÀ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Variable Small Semibol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.OrangeRed;
            this.label1.Location = new System.Drawing.Point(351, 454);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 27);
            this.label1.TabIndex = 3;
            this.label1.Text = "MẬT KHẨU";
            // 
            // textBox_passWord
            // 
            this.textBox_passWord.BackColor = System.Drawing.SystemColors.Control;
            this.textBox_passWord.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_passWord.Font = new System.Drawing.Font("Segoe UI Variable Display", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.textBox_passWord.Location = new System.Drawing.Point(83, 484);
            this.textBox_passWord.Name = "textBox_passWord";
            this.textBox_passWord.PasswordChar = '•';
            this.textBox_passWord.Size = new System.Drawing.Size(384, 44);
            this.textBox_passWord.TabIndex = 2;
            this.textBox_passWord.TextChanged += new System.EventHandler(this.textBox_passWord_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI Variable Display", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.ForeColor = System.Drawing.Color.OrangeRed;
            this.label2.Location = new System.Drawing.Point(171, 267);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(185, 44);
            this.label2.TabIndex = 1;
            this.label2.Text = "Đăng nhập";
            // 
            // label_userName
            // 
            this.label_userName.AutoSize = true;
            this.label_userName.BackColor = System.Drawing.Color.Transparent;
            this.label_userName.Font = new System.Drawing.Font("Segoe UI Variable Small Semibol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label_userName.ForeColor = System.Drawing.Color.OrangeRed;
            this.label_userName.Location = new System.Drawing.Point(291, 366);
            this.label_userName.Name = "label_userName";
            this.label_userName.Size = new System.Drawing.Size(176, 27);
            this.label_userName.TabIndex = 1;
            this.label_userName.Text = "TÊN ĐĂNG NHẬP";
            // 
            // textBox_userName
            // 
            this.textBox_userName.BackColor = System.Drawing.SystemColors.Control;
            this.textBox_userName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_userName.Font = new System.Drawing.Font("Segoe UI Variable Display", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.textBox_userName.Location = new System.Drawing.Point(83, 396);
            this.textBox_userName.Name = "textBox_userName";
            this.textBox_userName.Size = new System.Drawing.Size(384, 44);
            this.textBox_userName.TabIndex = 0;
            this.textBox_userName.TextChanged += new System.EventHandler(this.textBox_userName_TextChanged);
            // 
            // Form_Login_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = global::Project_BaiGiuXe.Properties.Resources.Login_bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1902, 1080);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Login_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form_Login_Main_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox_userName;
        private System.Windows.Forms.Label label_userName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_passWord;
        private System.Windows.Forms.CheckBox checkBox_ghiNhoDN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_login;
        private System.Windows.Forms.LinkLabel linkLabel_khongTheGN;
        private System.Windows.Forms.CheckBox checkBox_isShowPass;
        private System.Windows.Forms.ComboBox comboBox_loaiDangNhap;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_tatLogin;
    }
}