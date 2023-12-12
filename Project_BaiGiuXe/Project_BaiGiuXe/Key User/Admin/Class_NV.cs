using Project_BaiGiuXe.Sql_Connection;
using Project_BaiGiuXe.Tinh_nang_pho_bien;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace Project_BaiGiuXe.Key_User.Admin
{
    internal class Class_NV
    {
        Class_Connection db = new Class_Connection();
        Class_User user = new Class_User();

        public void themNV(TextBox textBox_HoNV, TextBox textBox_tenNV, DateTimePicker dateTimePicker_ngaySinh, TextBox textBox_sDT, TextBox textBox_diaChi, PictureBox pictureBox_anhNV)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[Table_NV] (HoNV, TenNV, NgaySinh, SDT, DiaChi, Anh) VALUES (@hoNV, @tenNV, @ngaySinh, @SDT, @diaChi, @anh);", db.getConnection);
            cmd.Parameters.AddWithValue("@hoNV", textBox_HoNV.Text);
            cmd.Parameters.AddWithValue("@tenNV", textBox_tenNV.Text);
            cmd.Parameters.Add("@ngaySinh", SqlDbType.Date).Value = dateTimePicker_ngaySinh.Value;
            cmd.Parameters.AddWithValue("@SDT", textBox_sDT.Text);
            cmd.Parameters.AddWithValue("@diaChi", textBox_diaChi.Text);
            cmd.Parameters.AddWithValue("@anh", TinhNang.GetImageBytes(pictureBox_anhNV));

            TinhNang.CUDDuLieu(cmd);
        }

        public void xoaNV(TextBox textBox_maNV)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM [dbo].[Table_NV] WHERE MaNV = @maNV", db.getConnection);
            cmd.Parameters.AddWithValue("@maNV", textBox_maNV.Text);
            TinhNang.CUDDuLieu(cmd);
        }

        public void suaNV(TextBox textBox_MaNV, TextBox textBox_HoNV, TextBox textBox_TenNV, DateTimePicker dateTimePicker_NgaySinh, TextBox textBox_SDT, TextBox textBox_DiaChi, PictureBox pictureBox_AnhNV)
        {
            SqlCommand cmd = new SqlCommand("UPDATE Table_NV SET HoNV = @hoNV, TenNV = @tenNV, NgaySinh = @ngaySinh, SDT = @SDT, DiaChi = @diaChi, Anh = @anh WHERE MaNV = @maNV", db.getConnection);
            cmd.Parameters.AddWithValue("@hoNV", textBox_HoNV.Text);
            cmd.Parameters.AddWithValue("@tenNV", textBox_TenNV.Text);
            cmd.Parameters.Add("@ngaySinh", SqlDbType.Date).Value = dateTimePicker_NgaySinh.Value;
            cmd.Parameters.AddWithValue("@SDT", textBox_SDT.Text);
            cmd.Parameters.AddWithValue("@diaChi", textBox_DiaChi.Text);
            cmd.Parameters.AddWithValue("@anh", TinhNang.GetImageBytes(pictureBox_AnhNV));
            cmd.Parameters.AddWithValue("@maNV", textBox_MaNV.Text);
            TinhNang.CUDDuLieu(cmd);
        }

        public void loadPanelNV(DataGridView dataGridView_dsNV)
        {
            SqlCommand cmd = new SqlCommand("SELECT *FROM Table_NV", db.getConnection);
            user.loadDsUser(cmd, dataGridView_dsNV);
            SqlCommand cmd1 = new SqlCommand("SELECT * FROM Table_LoaiNV", db.getConnection);
        }

        public void loadPanelLich(DataGridView dataGridView_dsNV)
        {
            SqlCommand cmd = new SqlCommand("SELECT *FROM Table_LichLamViecBX", db.getConnection);
            user.loadDsUser(cmd, dataGridView_dsNV);
            SqlCommand cmd1 = new SqlCommand("SELECT * FROM Table_LichLamViecBX", db.getConnection);
        }

        public void suaLich(TextBox txtMa123, TextBox textBox1, TextBox textBox2)
        {
            SqlCommand cmd = new SqlCommand("UPDATE Table_LichLamViecBX SET Ngay = @ngay, BuoiLam = @buoilam WHERE MaNV = @maNV", db.getConnection);
            cmd.Parameters.AddWithValue("@maNV", txtMa123.Text);
            cmd.Parameters.Add("@ngay", SqlDbType.Date).Value = textBox1.Text;
            cmd.Parameters.AddWithValue("@buoilam", textBox2.Text);
            TinhNang.CUDDuLieu(cmd);
        }

        public void xoaLich(TextBox txtMa123, TextBox textBox1, TextBox textBox2)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM [dbo].[Table_LichLamViecBX] WHERE MaNV = @maNV and Ngay=@ngay and BuoiLam=@buoilam", db.getConnection);
            cmd.Parameters.AddWithValue("@maNV", txtMa123.Text);
            cmd.Parameters.Add("@ngay", SqlDbType.Date).Value = textBox1.Text;
            cmd.Parameters.AddWithValue("@buoilam", textBox2.Text);
            TinhNang.CUDDuLieu(cmd);
        }

        public DataTable LoadThongTinCaNhan(SqlCommand cmd)
        {
            return TinhNang.XuatBangBangCmd(cmd);
        }

        public void themLich(TextBox txtMa123, TextBox textBox1, TextBox textBox2)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[Table_LichLamViecBX] (MaNV, Ngay, BuoiLam) VALUES (@hoNV, @tenNV, @ngaySinh);", db.getConnection);
            cmd.Parameters.AddWithValue("@hoNV", txtMa123.Text);
            cmd.Parameters.Add("@tenNV", SqlDbType.Date).Value = textBox1.Text;
            cmd.Parameters.AddWithValue("@ngaySinh", textBox2.Text);

            TinhNang.CUDDuLieu(cmd);
        }
        public DataTable getStudents(SqlCommand command)
        {
            command.Connection = db.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public bool existed_ID(TextBox txtMa123, TextBox textBox1, TextBox textBox2)
        {
            string dateFormat = "MM/dd/yyyy"; // Adjust the format based on your database
            DataTable table = new DataTable();
            if (DateTime.TryParseExact(textBox1.Text, dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateValue))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Table_LichLamViecBX WHERE MaNV = @maNV AND Ngay = @ngay AND BuoiLam = @buoilam", db.getConnection);
                cmd.Parameters.AddWithValue("@maNV", txtMa123.Text);
                cmd.Parameters.Add("@ngay", SqlDbType.Date).Value = dateValue;
                cmd.Parameters.AddWithValue("@buoilam", textBox2.Text);

                table = getStudents(cmd);
            }
            return table.Rows.Count > 0;
        }
    }
}
