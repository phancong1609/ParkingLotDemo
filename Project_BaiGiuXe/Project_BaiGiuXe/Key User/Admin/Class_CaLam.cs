using Project_BaiGiuXe.Sql_Connection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_BaiGiuXe.Tinh_nang_pho_bien;
using System.Windows.Forms;
using System.IO;

namespace Project_BaiGiuXe.Key_User.Admin
{
    public class Class_CaLam
    {
        public void TaoLichLamViec(string queryIn, string queryOut, DateTime startedDate, int employeesPerShift)
        {
            Class_Connection db = new Class_Connection();
            SqlCommand cmd = new SqlCommand(queryIn, db.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable employeesTable = new DataTable();
            adapter.Fill(employeesTable);

            // Trộn danh sách nhân viên
            TronDsNV(employeesTable);

            DataTable workSchedule = TaoLichLamViec(employeesTable, employeesPerShift, startedDate);

            XuatLichlamViec(workSchedule, queryOut);

            Console.Read();

        }
        static DataTable TaoLichLamViec(DataTable employeesTable, int employeesPerShift, DateTime startedDate)
        {
            DataTable workSchedule = new DataTable();
            workSchedule.Columns.Add("Day");
            workSchedule.Columns.Add("Shift");
            workSchedule.Columns.Add("Employee");

            int totalShifts = employeesTable.Rows.Count * 3;
            int shiftsPerEmployee = totalShifts / employeesTable.Rows.Count;
            DateTime day = startedDate;

            for (int shift = 0; shift < totalShifts; shift++)
            {
                int k=0;
                for (int i = 0; i < employeesPerShift; i++)
                {
                    int employeeIndex = (shift / shiftsPerEmployee + i) % employeesTable.Rows.Count;
                    string employee = employeesTable.Rows[employeeIndex]["MaNV"].ToString();
                    workSchedule.Rows.Add(day, GetShiftName(shift), employee);
                }
                if(GetShiftName(shift)=="Toi")
                    day = day.AddDays(1);
            }

            return workSchedule;
        }

        static string GetShiftName(int shift)
        {
            string[] shifts = { "Sang", "Chieu", "Toi" };
            return shifts[shift % 3];
        }

        static void XuatLichlamViec(DataTable workSchedule, string query)
        {
            Console.WriteLine("Lich lam viec:");
            Class_Connection db = new Class_Connection();
            try
            {
                foreach (DataRow row in workSchedule.Rows)
                {
                    string shift = row["Shift"].ToString();
                    string employee = row["Employee"].ToString();
                    DateTime day = Convert.ToDateTime(row["Day"]);

                    Console.WriteLine($"{day.ToShortDateString()} : Buoi {shift}: {employee}");

                    using (SqlCommand cmd = new SqlCommand(query, db.getConnection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MaNV", employee);
                        cmd.Parameters.AddWithValue("@BuoiLam", shift);
                        cmd.Parameters.AddWithValue("@Ngay", day);

                        TinhNang.CUDDuLieuKhongThongBao(cmd);
                    }
                }
                TinhNang.ShowThongBao("Tạo lịch", "Hoàn tất tạo lịch làm việc", System.Windows.Forms.MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                TinhNang.ShowThongBao("Lỗi hệ thống", ex.Message, System.Windows.Forms.MessageBoxIcon.Error);
            }  
        }

        static void TronDsNV(DataTable employeesTable)
        {
            Random random = new Random();

            for (int i = employeesTable.Rows.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                DataRow temp = employeesTable.NewRow();
                temp.ItemArray = employeesTable.Rows[j].ItemArray;
                employeesTable.Rows[j].ItemArray = employeesTable.Rows[i].ItemArray;
                employeesTable.Rows[i].ItemArray = temp.ItemArray;
            }
        }

        public void checkIn(string uid)
        {
            Class_Connection db = new Class_Connection();
            SqlCommand cmd = new SqlCommand("EXEC AddAttendance @Uid", db.getConnection);
            cmd.Parameters.AddWithValue("@Uid", uid);
            TinhNang.CUDDuLieu(cmd);
        }

        public void checkOut(string uid)
        {
            Class_Connection db = new Class_Connection();
            SqlCommand cmd = new SqlCommand("EXEC OutAttendance @Uid", db.getConnection);
            cmd.Parameters.AddWithValue("@Uid", uid);
            TinhNang.CUDDuLieu(cmd);
        }
    }
}
