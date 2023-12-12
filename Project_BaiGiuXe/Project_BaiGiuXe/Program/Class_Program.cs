using Project_BaiGiuXe.Key_User.Admin;
using Project_BaiGiuXe.Key_User.QL_BaiXe;
using Project_BaiGiuXe.Login;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_BaiGiuXe.Program
{
    internal class Class_Program
    {
        //public static DataTable userinfo;
        public static bool isLogin = true;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            while (isLogin)
            {
                Form_Login_Main lg = new Form_Login_Main();
                if (lg.ShowDialog() == DialogResult.Yes)
                {
                    isLogin = false;
                    Application.Run(new Form_Admin_Main());
                }
                else if (lg.DialogResult == DialogResult.OK)
                {
                    isLogin = false;
                    Application.Run(new Form_QLBaiXe_Main());
                }
                isLogin = lg.DialogResult != DialogResult.Cancel;
            }
            //Application.Run(new Form_Login_Main());
            Application.Exit();
        }


    }
}
