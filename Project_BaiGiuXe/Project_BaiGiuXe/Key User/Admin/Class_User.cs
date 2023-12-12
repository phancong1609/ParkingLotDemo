using Project_BaiGiuXe.Sql_Connection;
using Project_BaiGiuXe.Tinh_nang_pho_bien;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_BaiGiuXe.Key_User.Admin
{
    internal class Class_User
    {

        public void loadDsUser(SqlCommand cmd , DataGridView dataGridView)
        {
            TinhNang.ThemDuLieuVaoDGVBangCmd(cmd, dataGridView);
        }
    }
}
