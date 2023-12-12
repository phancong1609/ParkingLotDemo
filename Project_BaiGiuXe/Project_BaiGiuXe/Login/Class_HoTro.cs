using Project_BaiGiuXe.Sql_Connection;
using Project_BaiGiuXe.Tinh_nang_pho_bien;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_BaiGiuXe.Login
{
    internal class Class_HoTro
    {
        public void guiHoTro(TextBox nguoiGui, TextBox loaiYeuCau, TextBox noiDung)
        {
            Class_Connection db = new Class_Connection();
            SqlCommand cmd = new SqlCommand("INSERT INTO Table_Hotro (LoaiHotro, NguoiGui, NoiDung) VALUES (@loaiHoTro, @nguoiGui, @noiDung);", db.getConnection);
            cmd.Parameters.AddWithValue("@loaiHoTro", loaiYeuCau.Text.Trim());
            cmd.Parameters.AddWithValue("@nguoiGui", nguoiGui.Text.Trim());
            cmd.Parameters.AddWithValue("@noiDung", noiDung.Text.Trim());
            TinhNang.CUDDuLieu(cmd);
        }
    }
}
