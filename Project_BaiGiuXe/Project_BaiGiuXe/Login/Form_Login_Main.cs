using Project_BaiGiuXe.Tinh_nang_pho_bien;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace Project_BaiGiuXe.Login
{
    public partial class Form_Login_Main : Form
    {
        public Form_Login_Main()
        {
            InitializeComponent();
        }

        Class_Login login = new Class_Login();
        Form_HoTro form_HoTro = new Form_HoTro();

        //IU/UX
        private void textBox_userName_TextChanged(object sender, EventArgs e)
        {
            if (textBox_userName.Text != "" && textBox_passWord.Text != "")
            {
                button_login.Enabled = true;
                button_login.BackColor = Color.FromArgb(255, 70, 85);
            }
            else
            {
                button_login.Enabled = false;
                button_login.BackColor = Color.Transparent;
            }
        }

        private void textBox_passWord_TextChanged(object sender, EventArgs e)
        {
            if (textBox_userName.Text != "" && textBox_passWord.Text != "")
            {
                button_login.Enabled = true;
                button_login.BackColor = Color.FromArgb(255, 70, 85);
            }
            else
            {
                button_login.Enabled = false;
                button_login.BackColor = Color.Transparent;
            }
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            if (checkBox_ghiNhoDN.Checked == true)
            {
                login.luuDangNhap(textBox_userName.Text.Trim(), textBox_passWord.Text.Trim(), comboBox_loaiDangNhap.SelectedIndex);
            }
            else
            {
                Properties.Settings.Default.Reset();
            }
            
            string result = login.dangNhap(comboBox_loaiDangNhap, textBox_userName, textBox_passWord);
                
            switch (result)
            {
            case "ad":
                this.DialogResult = DialogResult.Yes;
                    break;
            case "bx":
                this.DialogResult = DialogResult.OK;
                    break;
            case "non":
                break;
            }
        }

        private void checkBox_isShowPass_CheckedChanged(object sender, EventArgs e)
            {
                if (checkBox_isShowPass.Checked == false)
                {
                    textBox_passWord.PasswordChar = '•';
                }
                else textBox_passWord.PasswordChar = '\0';
            }

        private void Form_Login_Main_Load(object sender, EventArgs e)
        {
            textBox_userName.Text = Properties.Settings.Default.username;
            textBox_passWord.Text = Properties.Settings.Default.password;
            comboBox_loaiDangNhap.SelectedIndex = Properties.Settings.Default.loaiUser;
            checkBox_ghiNhoDN.Checked = true;
        }

        private void checkBox_ghiNhoDN_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_ghiNhoDN.Checked == true)
            {
                login.luuDangNhap(textBox_userName.Text.Trim(), textBox_passWord.Text.Trim(), comboBox_loaiDangNhap.SelectedIndex);
            }
            else
            {
                Properties.Settings.Default.Reset();
            }
        }

        private void button_tatLogin_Click(object sender, EventArgs e)
        {
            if (TinhNang.ShowXacNhan("Xác nhận tắt chương trình", "Tắt chương trình ?")==DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void linkLabel_khongTheGN_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //form_HoTro.ShowDialog();
            form_HoTro.ShowDialog(); ;
        }
        //
    }
}
