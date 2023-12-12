using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project_BaiGiuXe.Sql_Connection;
using Project_BaiGiuXe.Tinh_nang_pho_bien;

namespace Project_BaiGiuXe.Login
{
    internal class Class_Login
    {
        public string dangNhap(ComboBox loaiDangNhap, TextBox texBox_userName, TextBox textBox_passWord)
        {
            try
            {
                Class_Connection db = new Class_Connection();
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable table_lg = new DataTable();

                string query = "SELECT * FROM Table_User WHERE Username = @User AND Password = @Pass ";

                switch (loaiDangNhap.SelectedIndex)
                {
                    case 0:
                        query += "AND MaLoaiUser = @Loai";
                        SqlCommand cmd0 = new SqlCommand(query, db.getConnection);
                        cmd0.Parameters.AddWithValue("@Loai", "AD");
                        cmd0.Parameters.AddWithValue("@User", texBox_userName.Text.Trim());
                        cmd0.Parameters.AddWithValue("@Pass", textBox_passWord.Text.Trim());
                        adapter.SelectCommand = cmd0;
                        adapter.Fill(table_lg);
                        if ((table_lg.Rows.Count > 0))
                        {
                            TinhNang.LoginUID = table_lg.Rows[0][0].ToString();
                            return @"ad";
                        }
                        else
                        {
                            MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return @"non";
                        }                    
                    case 1:
                        query += "AND MaLoaiUser = @Loai";
                        SqlCommand cmd2 = new SqlCommand(query, db.getConnection);
                        cmd2.Parameters.AddWithValue("@Loai", "BX");
                        cmd2.Parameters.AddWithValue("@User", texBox_userName.Text.Trim());
                        cmd2.Parameters.AddWithValue("@Pass", textBox_passWord.Text.Trim());
                        adapter.SelectCommand = cmd2;
                        adapter.Fill(table_lg);
                        if ((table_lg.Rows.Count > 0))
                        {
                            TinhNang.LoginUID = table_lg.Rows[0][0].ToString();
                            return @"bx";
                        }
                        else
                        {
                            MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return @"non";
                        }


                    default:
                        TinhNang.ShowThongBao("Lỗi đăng nhập", "Đăng nhập không khả dụng", MessageBoxIcon.Error);
                        return @"non";
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return @"non";
            }

        }

        public void luuDangNhap(string userName, string passWord, int comboBox_SelectedIndex)
        {
            Properties.Settings.Default.username = userName;
            Properties.Settings.Default.password = passWord;
            Properties.Settings.Default.loaiUser = comboBox_SelectedIndex;
            Properties.Settings.Default.Save();
        }
    }
}
