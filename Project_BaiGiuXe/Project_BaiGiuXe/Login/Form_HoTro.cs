using Project_BaiGiuXe.Sql_Connection;
using Project_BaiGiuXe.Tinh_nang_pho_bien;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_BaiGiuXe.Login
{
    public partial class Form_HoTro : Form
    {
        public Form_HoTro()
        {
            InitializeComponent();
        }

        Class_HoTro hoTro = new Class_HoTro();

        private void Form_HoTro_Load(object sender, EventArgs e)
            {
            Class_Connection db = new Class_Connection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Table_LoaiHoTro", db.getConnection);           
        }

        private void button_gui_Click(object sender, EventArgs e)
        {
            if (TinhNang.ShowXacNhan("Gửi yêu cầu", "Xác nhận gửi ?") == DialogResult.Yes)
            {
                hoTro.guiHoTro(textBox_tenNguoiGui, textBox_loaiHoTro, textBox_noiDung);
            }
        }
        
    }
}
