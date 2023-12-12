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

namespace Project_BaiGiuXe.Key_User.Admin
{
    public partial class Form1 : Form
    {
        Panel panelChild = new Panel();
        Class_Connection db = new Class_Connection();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            combox_ChonLich.SelectedIndex = 0;
            dataGridView_lichLamViec.DataSource = TinhNang.XuatBangBangCmd(new SqlCommand("Select*From Table_LichLamViecVP", db.getConnection));
        }

        private void button_xoaLich_Click(object sender, EventArgs e)
        {
            switch (combox_ChonLich.SelectedIndex)
            {
                case 0:

                    SqlCommand cmd = new SqlCommand("DELETE FROM Table_LichLamViecVP WHERE Ngay >= @ngay", db.getConnection);
                    cmd.Parameters.AddWithValue("@ngay", dateTimePicker_NgayBatDauTaoLichLamViec.Value);
                    TinhNang.CUDDuLieu(cmd);
                    break;
                case 1:
                    SqlCommand cmd1 = new SqlCommand("DELETE FROM Table_LichLamViecBX WHERE Ngay >= @ngay", db.getConnection);
                    cmd1.Parameters.AddWithValue("@ngay", dateTimePicker_NgayBatDauTaoLichLamViec.Value);
                    TinhNang.CUDDuLieu(cmd1);
                    break;
                case 2:
                    SqlCommand cmd2 = new SqlCommand("DELETE FROM Table_LichLamViecDV WHERE Ngay >= @ngay", db.getConnection);
                    cmd2.Parameters.AddWithValue("@ngay", dateTimePicker_NgayBatDauTaoLichLamViec.Value);
                    TinhNang.CUDDuLieu(cmd2);
                    break;
            }





        }

        private void button_ChonLich_Click(object sender, EventArgs e)
        {
            switch (combox_ChonLich.SelectedIndex)
            {
                case 0:
                    dataGridView_lichLamViec.DataSource = TinhNang.XuatBangBangCmd(new SqlCommand("Select*From Table_LichLamViecVP", db.getConnection));
                    break;
                case 1:
                    dataGridView_lichLamViec.DataSource = TinhNang.XuatBangBangCmd(new SqlCommand("Select*From Table_LichLamViecBX", db.getConnection));
                    break;
                case 2:
                    dataGridView_lichLamViec.DataSource = TinhNang.XuatBangBangCmd(new SqlCommand("Select*From Table_LichLamViecDV", db.getConnection));
                    break;
            }
        }

        private void button_tatLichLamViec_Click(object sender, EventArgs e)
        {
            panel_lichLamViec.Visible = false;
        }

        private void button_TaoLich_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            combox_ChonLich.SelectedIndex = 0;
            dataGridView_lichLamViec.DataSource = TinhNang.XuatBangBangCmd(new SqlCommand("Select*From Table_LichLamViecVP", db.getConnection));
        }
    }
}
