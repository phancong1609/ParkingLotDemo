using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing;
using Project_BaiGiuXe.Sql_Connection;
using System.Drawing.Imaging;
using System.IO;

namespace Project_BaiGiuXe.Tinh_nang_pho_bien
{
    public class TinhNang
    {
        //Login UID
        public static string LoginUID;

        //Lam viec voi datagrid va table
        public static void ThemDuLieuVaoDGVBangCmd(SqlCommand cmd, DataGridView dataGridView)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView.DataSource = table;
            }
            catch (Exception ex)
            {
                TinhNang.ShowThongBao("Truyen du lieu vao datagridview", ex);
            }
        }

        public static DataTable XuatBangBangCmd(SqlCommand cmd)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
            catch (Exception ex)
            {
                TinhNang.ShowThongBao("Truyen du lieu vao datagridview", ex);
                return null;
            }
        }

        //Thong bao
        public static void ShowThongBao(string tieude, string noidung, MessageBoxIcon icon)
        {
            MessageBox.Show(noidung, tieude, MessageBoxButtons.OK, icon);
        }

        public static void ShowThongBao(string tieude, Exception ex)
        {
            MessageBox.Show(ex.Message, tieude, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult ShowXacNhan(string tieude, string noidung)
        {
            DialogResult result = MessageBox.Show(noidung, tieude, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            return result;
        }

        //Kiem soat du lieu dau vao
        public static bool isHoTen(TextBox ten)
        {
            bool result = false;
            if (string.IsNullOrWhiteSpace(ten.Text) || !Regex.IsMatch(ten.Text, @"^[\p{L}\s]+$"))
            {
                ShowThongBao("Loi dien ky tu", "Ho ten khong chua ky tu dac biet", MessageBoxIcon.Error);
                result = false;
            }
            else
            {
                result = true;
            }
            return result;
        }

        public static bool isSo(TextBox so)
        {
            bool result = false;
            if (string.IsNullOrWhiteSpace(so.Text) || !Regex.IsMatch(so.Text, @"^\d{10,12}$"))
            {
                ShowThongBao("Loi dien ky tu", "Co ky tu khac trong o so, hoac thieu so", MessageBoxIcon.Error);
                result = false;
            }
            else
            {
                result = true;
            }
            return result;
        }

        public static bool isKhacRong(TextBox textBox)
        {
            bool result = false;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                ShowThongBao("Loi dien ky tu", "Khong duoc de trong", MessageBoxIcon.Error);
                result = false;
            }
            else
            {
                result = true;
            }
            return result;
        }

        public static bool isSoDuocPhep(TextBox so, int san, int tran)
        {
            bool result = false;
            if (isSo(so))
            {
                if (so.Text.Length >= san && so.Text.Length <= tran)
                {
                    result = true;
                }
                else
                {
                    ShowThongBao("Loi dien ky tu", "So khong nam trong vung kha dung", MessageBoxIcon.Error);
                }
            }
            return result;

        }

        public static bool isPicture(PictureBox ShowPictureBox)
        {
            bool result = false;
            if (GetImageBytes(ShowPictureBox) == null)
            {
                ShowThongBao("loi dien ky tu", "Khong de trong anh", MessageBoxIcon.Error);
            }
            else
            {
                result = true;
            }

            return result;
        }

        //lam viec voi SQL
        public static void CUDDuLieu(SqlCommand cmd)
        {
            Class_Connection mydb = new Class_Connection();
            try
            {
                mydb.openConnection();

                // Gán kết nối cho SqlCommand
                cmd.Connection = mydb.getConnection;

                if ((cmd.ExecuteNonQuery() >= 1 ))
                {
                    ShowThongBao("Thực thi dữ liệu", "Thao tác dữ liệu thành công", MessageBoxIcon.Information);
                }
                else
                {
                    ShowThongBao("Thực thi dữ liệu", "Thao tác dữ liệu thất bại, Thử lại sau", MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                ShowThongBao("Thực thi dữ liệu", ex);
            }
            finally
            {
                mydb.closeConnection();
            }
        }
        public static void CUDDuLieuKhongThongBao(SqlCommand cmd)
        {
            Class_Connection mydb = new Class_Connection();
            try
            {
                mydb.openConnection();

                // Gán kết nối cho SqlCommand
                cmd.Connection = mydb.getConnection;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ShowThongBao("Thực thi dữ liệu", ex);
            }
            finally
            {
                mydb.closeConnection();
            }
        }

        public static bool isExist(SqlCommand cmd)
        {
            bool result = false;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            adapter.SelectCommand = cmd;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                result = true;
            }

            return result;
        }

        public static bool isAColummValue(SqlCommand cmd, string columnName, string valueYeuCau)
        {
            bool result = false;

            Class_Connection db = new Class_Connection();
            db.openConnection();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read() && reader[columnName].ToString() == valueYeuCau)
            {
                result = true;
            }

            return result;
        }

        //lam viec voi Anh
        public static void ThemAnhVaoPictureBox(PictureBox ShowPictureBox)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JPEG Files PNG Files (*.png)|*.png|(*.jpeg)|*.jpeg|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ShowPictureBox.Image = System.Drawing.Image.FromFile(openFileDialog.FileName);
            }
        }

        public static byte[] GetImageBytes(PictureBox ShowPictureBox)
        {
            try
            {
                byte[] imageBytes = null;
                if (ShowPictureBox.Image != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        // Create a copy of the image
                        System.Drawing.Image copyImage = new Bitmap(ShowPictureBox.Image);

                        // Save the copy image to memory stream
                        copyImage.Save(ms, ImageFormat.Jpeg);
                        imageBytes = ms.ToArray();
                    }
                }
                return imageBytes;
            }
            catch (Exception ex)
            {
                ShowThongBao("Chuyen doi anh", ex.Message, MessageBoxIcon.Error);
                return null;
            }

        }

        public static Image docAnhTuTable(byte[] bytePic)
        {

            // Chuyển đổi mảng byte thành hình ảnh
            using (MemoryStream memoryStream = new MemoryStream(bytePic))
            {
                Image image = Image.FromStream(memoryStream);

                // Hiển thị hình ảnh trong PictureBox
                return image;
            }
        }


    }
}
