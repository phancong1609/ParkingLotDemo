using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_BaiGiuXe.Sql_Connection
{
    public class Class_Connection
    {
        SqlConnection con = new SqlConnection
            (@"Data Source=.;Initial Catalog=QLBX;Integrated Security=True");
        

        public SqlConnection getConnection
        {
            get
            {
                return con;
            }
        }
        

        public void openConnection()
        {
            if ((con.State == ConnectionState.Closed))
            {
                con.Open();
            }

        }


        public void closeConnection()
        {
            if ((con.State == ConnectionState.Open))
            {
                con.Close();
            }

        }
    }
}
