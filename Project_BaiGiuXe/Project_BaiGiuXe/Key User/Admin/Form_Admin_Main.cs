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
    public partial class Form_Admin_Main : Form
    {
        public Form_Admin_Main()
        {
            InitializeComponent();
        }

        Class_User user = new Class_User();
        Class_NV nv = new Class_NV();
        Class_HoTro hoTro = new Class_HoTro();
        Class_Connection db = new Class_Connection();
        Class_CaLam ca = new Class_CaLam();

        private void button_login_Click(object sender, EventArgs e)
        {
            if (panel_infoUser.Visible == false)
            {
                panel_infoUser.Visible = true;
                panel_infoUser.BringToFront();
            }
            else
            {
                panel_infoUser.Visible = false;
            }
        }

        private void Form_Admin_Main_MouseClick(object sender, MouseEventArgs e)
        {
            panel_infoUser.Visible = false;
        }

        private void button_dsUser_Click(object sender, EventArgs e)
        {
            if (panel_dsUser.Visible == false)
            {
                panel_dsUser.Visible = true;
                panel_dsUser.BringToFront();
                panel_dsUser.Location = new Point(69, 136);
            }
            else
            {
                panel_dsUser.Visible = false;
            }
            //Panel_QLUser
            SqlCommand cmd = new SqlCommand("SELECT *FROM Table_User", db.getConnection);
            user.loadDsUser(cmd, dataGridView_dsUser);
            SqlCommand cmd1 = new SqlCommand("SELECT * FROM Table_LoaiUser", db.getConnection);
            comboBox_loaiUser.DataSource = TinhNang.XuatBangBangCmd(cmd1);
            comboBox_loaiUser.DisplayMember = "LoaiUser";
            comboBox_loaiUser.ValueMember = "MaLoaiUser";
        }

        private void button_dsHoTro_Click(object sender, EventArgs e)
        {
            if (panel_dsYeuCau.Visible == false)
            {
                panel_dsYeuCau.Visible = true;
                panel_dsYeuCau.BringToFront();
                panel_dsYeuCau.Location = new Point(69, 136);
            }
            else
            {
                panel_dsYeuCau.Visible = false;
            }
            //Panel_QL
            SqlCommand cmd2 = new SqlCommand("SELECT *FROM Table_HoTro", db.getConnection);
            hoTro.loadDsHoTro(cmd2, dataGridView_dsYeuCau);
            SqlCommand cmd3 = new SqlCommand("SELECT * FROM Table_LoaiHoTro", db.getConnection);

        }

        private void button_dangXuat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_thoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form_Admin_Main_Load(object sender, EventArgs e)
        {
            //Panel_QLUser
            SqlCommand cmd = new SqlCommand("SELECT *FROM Table_User",db.getConnection);
            user.loadDsUser(cmd, dataGridView_dsUser);
            SqlCommand cmd1 = new SqlCommand("SELECT * FROM Table_LoaiUser", db.getConnection);
            comboBox_loaiUser.DataSource = TinhNang.XuatBangBangCmd(cmd1);
            comboBox_loaiUser.DisplayMember = "LoaiUser";
            comboBox_loaiUser.ValueMember = "MaLoaiUser";

            //Panel_QL
            SqlCommand cmd2 = new SqlCommand("SELECT *FROM Table_HoTro",db.getConnection);
            hoTro.loadDsHoTro(cmd2, dataGridView_dsYeuCau);
            SqlCommand cmd3 = new SqlCommand("SELECT * FROM Table_LoaiHoTro", db.getConnection);
            checkBox_chuaGiaiQuyet.Checked = false;
            //Panel_Lich
            dataGridView_lichLamViec.DataSource = TinhNang.XuatBangBangCmd(new SqlCommand("Select*From Table_LichLamViecBX", db.getConnection));

            //Panel_NV
            nv.loadPanelNV(dataGridView_dsNV);

        }

        private void dataGridView_dsUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox_uid.Text = dataGridView_dsUser.CurrentRow.Cells[0].Value.ToString();
            textBox_userName.Text = dataGridView_dsUser.CurrentRow.Cells[1].Value.ToString();
            textBox_passWord.Text = dataGridView_dsUser.CurrentRow.Cells[2].Value.ToString();
            comboBox_loaiUser.SelectedValue = dataGridView_dsUser.CurrentRow.Cells[3].Value.ToString();
        }

        private void button_capNhat_Click(object sender, EventArgs e)
        {
            
            if (TinhNang.ShowXacNhan("Cập nhật user", "Xác nhận cập nhật thông tin user?")==DialogResult.Yes)
            {
                SqlCommand cmd = new SqlCommand("UPDATE [dbo].[Table_User] SET [UserName] = @userName, [PassWord] = @passWord, [MaLoaiUser] = @maLoaiUser WHERE [Uid] = @uid", db.getConnection);
                cmd.Parameters.AddWithValue("@uid", textBox_uid.Text);
                cmd.Parameters.AddWithValue("@userName", textBox_userName.Text);
                cmd.Parameters.AddWithValue("@passWord", textBox_passWord.Text);
                cmd.Parameters.AddWithValue("@maLoaiUser", comboBox_loaiUser.SelectedValue.ToString());
                TinhNang.CUDDuLieu(cmd);
            }    
        }

        private void dataGridView_dsYeuCau_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox_maHoTro.Text = dataGridView_dsYeuCau.CurrentRow.Cells[0].Value.ToString();
            textBox_loaiHoTro.Text = dataGridView_dsYeuCau.CurrentRow.Cells[1].Value.ToString();
            textBox_tenNguoiGui.Text = dataGridView_dsYeuCau.CurrentRow.Cells[2].Value.ToString();
            textBox_noiDungHoTro.Text = dataGridView_dsYeuCau.CurrentRow.Cells[3].Value.ToString();
            if (Convert.IsDBNull(dataGridView_dsYeuCau.CurrentRow.Cells[4].Value))
            {
                dataGridView_dsYeuCau.CurrentRow.Cells[4].Value = false;
            }
            checkBox_daGiaiQuyet.Checked = (bool)dataGridView_dsYeuCau.CurrentRow.Cells[4].Value;
        }

        private void button_capNhatYeuCau_Click(object sender, EventArgs e)
        {
            if (TinhNang.ShowXacNhan("Cập nhật yêu cầu", "Xác nhận cập nhật thông tin yêu cầu?") == DialogResult.Yes)
            {
                SqlCommand cmd = new SqlCommand("UPDATE [dbo].[Table_HoTro] SET [LoaiHoTro] = @loaiHoTro, [NguoiGui] = @nguoiGui, [NoiDung] = @noiDung, [DaGiaiQuyet] = @daGiaiQuyet WHERE [MaHoTro] = @maHoTro", db.getConnection);
                cmd.Parameters.AddWithValue("@maHoTro", textBox_maHoTro.Text);
                cmd.Parameters.AddWithValue("@loaiHoTro", textBox_loaiHoTro.Text);
                cmd.Parameters.AddWithValue("@nguoiGui", textBox_tenNguoiGui.Text);
                cmd.Parameters.AddWithValue("@noiDung", textBox_noiDungHoTro.Text);
                cmd.Parameters.AddWithValue("@daGiaiQuyet", checkBox_daGiaiQuyet.Checked);
                TinhNang.CUDDuLieu(cmd);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_chuaGiaiQuyet.Checked)
            {
                SqlCommand cmd2 = new SqlCommand("SELECT * FROM Table_HoTro Where DaGiaiQuyet = 0 OR  DaGiaiQuyet IS NULL", db.getConnection);
                hoTro.loadDsHoTro(cmd2, dataGridView_dsYeuCau);
            }
            else
            {
                SqlCommand cmd2 = new SqlCommand("SELECT * FROM Table_HoTro", db.getConnection);
                hoTro.loadDsHoTro(cmd2, dataGridView_dsYeuCau);
            }
        }

        private void button_themNV_Click(object sender, EventArgs e)
        {
            if (TinhNang.isHoTen(textBox_hoNV) &&
            TinhNang.isHoTen(textBox_tenNV) &&
            TinhNang.isPicture(pictureBox_anhNV) &&
            TinhNang.isSoDuocPhep(textBox_sDT, 10, 11) &&
            TinhNang.isKhacRong(textBox_diaChi))
            {
                nv.themNV(textBox_hoNV, textBox_tenNV, dateTimePicker_ngaySinh, textBox_sDT, textBox_diaChi, pictureBox_anhNV);
            }
        }

        private void button_taiAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JPEG Files PNG Files (*.png)|*.png|(*.jpeg)|*.jpeg|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox_anhNV.Image = Image.FromFile(openFileDialog.FileName);
            }
        }

        private void button_NV_Click(object sender, EventArgs e)
        {
            if (panel_dsNV.Visible == false)
            {
                panel_dsNV.Visible = true;
                panel_dsNV.BringToFront();
                panel_dsNV.Location = new Point(69, 136);
            }
            else
            {
                panel_dsNV.Visible = false;
            }
            //Panel_NV
            nv.loadPanelNV(dataGridView_dsNV);
        }

        private void button_xoaNV_Click(object sender, EventArgs e)
        {
            if (TinhNang.isKhacRong(textBox_maNV))
            {
                nv.xoaNV(textBox_maNV);
                nv.loadPanelNV(dataGridView_dsNV);
            }           
        }

        private void dataGridView_dsNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox_maNV.Text = dataGridView_dsNV.CurrentRow.Cells[0].Value.ToString();
            textBox_hoNV.Text = dataGridView_dsNV.CurrentRow.Cells[1].Value.ToString();
            textBox_tenNV.Text = dataGridView_dsNV.CurrentRow.Cells[2].Value.ToString();
            dateTimePicker_ngaySinh.Value = (DateTime)dataGridView_dsNV.CurrentRow.Cells[3].Value;
            textBox_sDT.Text = dataGridView_dsNV.CurrentRow.Cells[4].Value.ToString();
            textBox_diaChi.Text = dataGridView_dsNV.CurrentRow.Cells[5].Value.ToString();
            pictureBox_anhNV.Image = TinhNang.docAnhTuTable((byte[])dataGridView_dsNV.CurrentRow.Cells[6].Value);
        }

        private void button_capNhatNV_Click(object sender, EventArgs e)
        {
            if (TinhNang.isHoTen(textBox_hoNV) &&
            TinhNang.isHoTen(textBox_tenNV) &&
            TinhNang.isPicture(pictureBox_anhNV) &&
            TinhNang.isSoDuocPhep(textBox_sDT, 10, 11) &&
            TinhNang.isKhacRong(textBox_diaChi)&&
            TinhNang.isKhacRong(textBox_maNV))
            {
                nv.suaNV(textBox_maNV,textBox_hoNV, textBox_tenNV, dateTimePicker_ngaySinh, textBox_sDT, textBox_diaChi, pictureBox_anhNV);
                nv.loadPanelNV(dataGridView_dsNV);
            }
        }

        private void button_inDSNV_Click(object sender, EventArgs e)
        {
        }

        private void button_TaoLich_Click(object sender, EventArgs e)
        {
            if (TinhNang.isKhacRong(textBox_soNVBXMoiCa))
                ca.TaoLichLamViec("SELECT * FROM Table_NV", "sp_Insert_LichLamViecBX", dateTimePicker_NgayBatDauTaoLichLamViec.Value, int.Parse(textBox_soNVBXMoiCa.Text));
        }

        private void button_LichLamViec_Click(object sender, EventArgs e)
        {
            if (panel_lichLamViec.Visible == false)
            {
                panel_lichLamViec.Visible = true;
                panel_lichLamViec.Location = new Point(69, 136);
                panel_lichLamViec.BringToFront();               
            }
            else
            {
                panel_lichLamViec.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView_lichLamViec.DataSource = TinhNang.XuatBangBangCmd(new SqlCommand("Select*From Table_LichLamViecBX", db.getConnection));
        }

        private void button_ChonLich_Click(object sender, EventArgs e)
        {
            dataGridView_lichLamViec.DataSource = TinhNang.XuatBangBangCmd(new SqlCommand("Select*From Table_LichLamViecBX", db.getConnection));
        }

        private void button_tatNV_Click(object sender, EventArgs e)
        {
            panel_dsNV.Visible = false;
        }

        private void button_tatLichLamViec_Click(object sender, EventArgs e)
        {
            panel_lichLamViec.Visible = false;
        }

        private void button_qlUser_Click(object sender, EventArgs e)
        {
            panel_dsUser.Visible = false;
        }

        private void button_xoaLich_Click(object sender, EventArgs e)
        {
            SqlCommand cmd1 = new SqlCommand("DELETE FROM Table_LichLamViecBX WHERE Ngay >= @ngay", db.getConnection);
            cmd1.Parameters.AddWithValue("@ngay", dateTimePicker_NgayBatDauTaoLichLamViec.Value.Date);
            TinhNang.CUDDuLieu(cmd1);
        }

        private void button_timNV_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView_lichLamViec_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMa123.Text = dataGridView_lichLamViec.CurrentRow.Cells[0].Value.ToString();
            if (DateTime.TryParse(dataGridView_lichLamViec.CurrentRow.Cells[1].Value.ToString(), out DateTime dateValue))
            {
                textBox1.Text = dateValue.ToString("MM/dd/yyyy"); // Customize the format as needed
            }
            textBox2.Text = dataGridView_lichLamViec.CurrentRow.Cells[2].Value.ToString();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            if (txtMa123.Text != null && nv.existed_ID(txtMa123, textBox1, textBox2) == false)
            {
                nv.themLich(txtMa123, textBox1, textBox2);
                nv.loadPanelLich(dataGridView_lichLamViec);
            }
            else
            {
                MessageBox.Show("Nhân viên đã được phân công vào ca này sẵn rồi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btRemove_Click(object sender, EventArgs e)
        {
            if (txtMa123.Text != null)
            {
                nv.xoaLich(txtMa123, textBox1, textBox2);
                nv.loadPanelLich(dataGridView_lichLamViec);
            }
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            if (txtMa123.Text != null && nv.existed_ID(txtMa123, textBox1, textBox2) == false)
            {
                nv.suaLich(txtMa123, textBox1, textBox2);
                nv.loadPanelLich(dataGridView_lichLamViec);
            }
            else
            {
                MessageBox.Show("Nhân viên đã được phân công vào ca này sẵn rồi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
