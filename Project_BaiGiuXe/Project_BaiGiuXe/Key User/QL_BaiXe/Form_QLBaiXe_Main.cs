﻿using Project_BaiGiuXe.Key_User.QL_BaiXe; using System; using System.Collections.Generic; using System.ComponentModel; using System.Data; using System.Drawing; using System.Linq; using System.Text; using System.Threading.Tasks; using System.Windows.Forms; using AForge.Video; using AForge.Video.DirectShow; using Project_BaiGiuXe.Tinh_nang_pho_bien; using System.Data.SqlClient; using Project_BaiGiuXe.Sql_Connection; using Project_BaiGiuXe.Key_User.Admin; using System.IO; using System.Net.Sockets; using System.Diagnostics; using System.Net;  namespace Project_BaiGiuXe.Key_User.QL_BaiXe {     public partial class Form_QLBaiXe_Main : Form     {         public Form_QLBaiXe_Main()         {             InitializeComponent();         }          private VideoCaptureDevice videoSourceXe;         private VideoCaptureDevice videoSourceCard;         Class_Connection db = new Class_Connection();         Class_Xe xe = new Class_Xe();          Class_NV nv = new Class_NV();         Class_CaLam ca = new Class_CaLam();          private void button_info_Click(object sender, EventArgs e)         {             if (panel_infoUser.Visible == false)             {                 panel_infoUser.Visible = true;                 panel_infoUser.BringToFront();             }             else             {                 panel_infoUser.Visible = false;             }         }          private void Form_QLBaiXe_Main_MouseClick(object sender, MouseEventArgs e)         {             panel_infoUser.Visible = false;         }          private void button_raVaoBai_Click(object sender, EventArgs e)         {             if (panel_raVaoBai.Visible == false)             {                 panel_raVaoBai.Visible = true;                 panel_raVaoBai.BringToFront();                 panel_raVaoBai.Location = new Point(69, 136);                 //thêm                 openCam();             }             else             {                 panel_raVaoBai.Visible = false;             }         }          private BinaryReader reader;         private Process process;         private Process process2;         private TcpClient client;         bool isclosed= false;         private void openQrscan()         {             var listener = new TcpListener(IPAddress.Loopback, 12345);             listener.Start();             process = new Process             {                 StartInfo = new ProcessStartInfo                 {                     FileName = "python",                     Arguments = "QRscan.py",                     UseShellExecute = false,                     RedirectStandardOutput = true,                     RedirectStandardError = true,                     CreateNoWindow = true,                 }             };             process.Start();               client = listener.AcceptTcpClient();             reader = new BinaryReader(client.GetStream());             var t = new System.Threading.Thread(ReceiveImages);             t.IsBackground = true;             t.Start();         }          private void ReceiveImages()         {             bool isClientClosed = false;              while (!isClientClosed)             {                 try                 {                     var size = reader.ReadInt32();                      var data = reader.ReadBytes(size);                      using (var ms = new MemoryStream(data))                     {                         var bmp = new Bitmap(ms);                          pictureBox_camNguoiGui.Invoke(new Action(() =>                         {                             pictureBox_camNguoiGui.Image = bmp;                         }));                     }                 }                 catch (IOException)                 {                     isClientClosed = true;                     string cardid = process.StandardOutput.ReadToEnd().Trim();                     if (isclosed == false)
                    {
                        MessageBox.Show("Hãy giữ xe ở vị trí sẵn sàng", "Thông báo");                     }                     this.Invoke(new Action(() =>                     {                         if (isclosed == true) return;                          Bitmap imageXe = (Bitmap)pictureBox_camXe.Image;                         if (imageXe != null)                         {                             // Tạo một đối tượng Bitmap để lưu trữ hình ảnh được chụp từ camera                             Bitmap bitmap = new Bitmap(imageXe);                             string filePath = "Images/image.jpg";                             string directoryPath = Path.GetDirectoryName(filePath);                             if (!Directory.Exists(directoryPath))
                            {
                                Directory.CreateDirectory(directoryPath);
                            }                              bitmap.Save(filePath);                             bitmap.Dispose(); 
                        }                          process2 = new Process                         {                             StartInfo = new ProcessStartInfo                             {                                 FileName = "python",                                 Arguments = "HM.py",                                 UseShellExecute = false,                                 RedirectStandardOutput = true,                                 RedirectStandardError = true,                                 CreateNoWindow = true,                             }                         };                         process2.Start();                          string np = process2.StandardOutput.ReadToEnd().Replace("\n", "").Replace("\r", "").Replace(Environment.NewLine, "").Trim();                          //SQL PROCESSING                         SqlCommand cmd = new SqlCommand("SELECT * FROM Table_Card WHERE MaCard = @card",db.getConnection);                         cmd.Parameters.AddWithValue("@card", cardid);                         DataTable timCard = TinhNang.XuatBangBangCmd(cmd);                                                   if (timCard.Rows[0][2].ToString() != "" )                          {                             if (np == timCard.Rows[0][2].ToString())                             {                                 xe.xuatXe(np, cardid);                             }                             else                                 TinhNang.ShowThongBao("Xuất xe", "Nhầm thẻ hoặc sai biển số xe", MessageBoxIcon.Warning);                                                    }                         else                         {                             xe.themXe(np, imageXe, cardid);                         }                          openQrscan();                     }));                 }             }         }                  #region OLD             private void openCam()         {             try             {                 // Lấy danh sách thiết bị camera                 FilterInfoCollection devices = new FilterInfoCollection(FilterCategory.VideoInputDevice);                 // Nếu có ít nhất một thiết bị camera được kết nối                 if (devices.Count >= 2)                 {                     // Khởi tạo đối tượng VideoCaptureDevice để kết nối với camera đầu tiên                     videoSourceXe = new VideoCaptureDevice(devices[1].MonikerString);                     //videoSourceCard = new VideoCaptureDevice(devices[1].MonikerString);                      // Thiết lập sự kiện NewFrame để lấy hình ảnh từ camera và hiển thị trên PictureBox                     videoSourceXe.NewFrame += new NewFrameEventHandler(videoSourceXe_NewFrame);                     //videoSourceCard.NewFrame += new NewFrameEventHandler(videoSourceCard_NewFrame);                      videoSourceXe.Start();                     //videoSourceCard.Start();                     openQrscan();                 }                 else                 {                     MessageBox.Show("Không tìm thấy đủ thiết bị camera!");                 }             }             catch (Exception ex)             {                 TinhNang.ShowThongBao("Lỗi phần cứng", "Có vẽ phần cứng gặp trục\n" + ex.Message, MessageBoxIcon.Error);             }         }         #endregion         private void videoSourceXe_NewFrame(object sender, NewFrameEventArgs eventArgs)         {                  Bitmap imageXe = (Bitmap)eventArgs.Frame.Clone();             //imageXe.RotateFlip(RotateFlipType.RotateNoneFlipX);              Bitmap scaledImage = new Bitmap(imageXe, imageXe.Width / 3, imageXe.Height / 3);             pictureBox_camXe.Image = scaledImage;         }         private void videoSourceCard_NewFrame(object sender, NewFrameEventArgs eventArgs)         {                       Bitmap imageNguoi = (Bitmap)eventArgs.Frame.Clone();             imageNguoi.RotateFlip(RotateFlipType.RotateNoneFlipX);              Bitmap scaledImage = new Bitmap(imageNguoi, imageNguoi.Width / 3, imageNguoi.Height / 3);             pictureBox_camNguoiGui.Image = scaledImage;         }          //thêm         private void panel_raVaoBai_VisibleChanged(object sender, EventArgs e)         {             if (panel_raVaoBai.Visible == false)             {
                // Dừng chụp hình khi form đóng
                if (videoSourceXe != null && videoSourceXe.IsRunning)                 {                     videoSourceXe.SignalToStop();                     videoSourceXe.WaitForStop();                     videoSourceXe = null;


                }                 if (videoSourceCard != null && videoSourceCard.IsRunning)                 {                     videoSourceCard.SignalToStop();                     videoSourceCard.WaitForStop();                     videoSourceCard = null;
                }                 isclosed = true;                 if (process.HasExited == false)                     process.Kill();             }             else                 isclosed = false;         }          private void button_tatRaVaoBai_Click(object sender, EventArgs e)         {             panel_raVaoBai.Visible = false;         }          private void button_xeTrongBai_Click(object sender, EventArgs e)         {                   }          private void linkLabel_lichSuGuiXe_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)         {          }          private void button_tatLichSuGuiXe_Click(object sender, EventArgs e)         {             panel_lichSu.Visible = false;         }          private void button_lichSuDoXe_Click(object sender, EventArgs e)         {             if (panel_lichSu.Visible == false)             {                 panel_lichSu.Visible = true;                 panel_lichSu.BringToFront();                 panel_lichSu.Location = new Point(69, 136);             }             else             {                 panel_lichSu.Visible = false;             }             dataGridView_dsXeDaGui.DataSource = TinhNang.XuatBangBangCmd(new SqlCommand("Select * from Table_Xe where NgayRaBai IS NOT NULL", db.getConnection));             dateTimePicker_ngayDaVaoBai.CustomFormat = "yyyy-MM-dd HH:mm:ss";             dateTimePicker_ngayDaRaBai.CustomFormat = "yyyy-MM-dd HH:mm:ss";         }          private void button_xeTrongBai_Click_1(object sender, EventArgs e)         {             if (panel_baiXe.Visible == false)             {                 panel_baiXe.Visible = true;                 panel_baiXe.BringToFront();                 panel_baiXe.Location = new Point(69, 136);             }             else             {                 panel_baiXe.Visible = false;             }             dataGridView_dsXeTrongBai.DataSource = TinhNang.XuatBangBangCmd(new SqlCommand("Select BienSoXe, NgayVaoBai from Table_Xe where NgayRaBai IS NULL", db.getConnection));             dateTimePicker_ngayVaoBaiChiTiet.CustomFormat = "yyyy-MM-dd HH:mm:ss";         }          private void button_tatChiTietXe_Click(object sender, EventArgs e)         {             panel_baiXe.Visible = false;         }          private void linkLabel_chiTietPhiDichVu_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)         {          }          //thêm         private void button_dangXuat_Click(object sender, EventArgs e)         {             panel_raVaoBai.Visible = false;             this.Close();         }         //thêm         private void button_thoat_Click(object sender, EventArgs e)         {             panel_raVaoBai.Visible = false;             Application.Exit();         }           private void Form_QLBaiXe_Main_Load(object sender, EventArgs e)         {              //panel BaiXe             dataGridView_dsXeTrongBai.DataSource = TinhNang.XuatBangBangCmd(new SqlCommand("Select BienSoXe, NgayVaoBai from Table_Xe where NgayRaBai IS NULL", db.getConnection));             dateTimePicker_ngayVaoBaiChiTiet.CustomFormat = "yyyy-MM-dd HH:mm:ss";              //panel LSXe             dataGridView_dsXeDaGui.DataSource = TinhNang.XuatBangBangCmd(new SqlCommand("Select * from Table_Xe where NgayRaBai IS NOT NULL ", db.getConnection));             dateTimePicker_ngayDaVaoBai.CustomFormat = "yyyy-MM-dd HH:mm:ss";             dateTimePicker_ngayDaRaBai.CustomFormat = "yyyy-MM-dd HH:mm:ss";         }           private void button_timXeTheoMaXe_Click(object sender, EventArgs e)         {             SqlCommand cmd = new SqlCommand("Select * from Table_Xe where BienSoXe = @MaSoXe", db.getConnection);             cmd.Parameters.AddWithValue("@MaSoXe", textBox_maSoXeChiTiet.Text);             DataTable tb = TinhNang.XuatBangBangCmd(cmd);             if (tb.Rows.Count > 0)             {                 dateTimePicker_ngayVaoBaiChiTiet.Value = DateTime.Parse(tb.Rows[0][1].ToString());             }             else             {                 TinhNang.ShowThongBao("Tìm xe", "Không tồn tại xe này!", MessageBoxIcon.Error);             }         }          private void dataGridView_dsXeTrongBai_CellClick(object sender, DataGridViewCellEventArgs e)         {             textBox_maSoXeChiTiet.Text = dataGridView_dsXeTrongBai.CurrentRow.Cells[0].Value.ToString();             button_timXeTheoMaXe_Click(sender, e);         }         //         private void button_timMaXeDaGui_Click(object sender, EventArgs e)         {             SqlCommand cmd = new SqlCommand("Select * from Table_Xe where BienSoXe = @maSoXe", db.getConnection);             cmd.Parameters.AddWithValue("@MaSoXe", textBox_maSoXeDaGui.Text);             DataTable tb = TinhNang.XuatBangBangCmd(cmd);             if (tb.Rows.Count > 0)             {                 dateTimePicker_ngayDaVaoBai.Value = DateTime.Parse(tb.Rows[0][1].ToString());                 if (tb.Rows[0][2].ToString() != "")                 {                     dateTimePicker_ngayDaRaBai.Value = DateTime.Parse(tb.Rows[0][2].ToString());                 }                 textBox_phiGuiXeDaTinh.Text = xe.tinhPhiGuiXe(tb, DateTime.Parse(tb.Rows[0][2].ToString())).ToString();             }             else             {                 TinhNang.ShowThongBao("Tìm xe", "Không tồn tại xe này!", MessageBoxIcon.Error);             }         }           private void dataGridView_dsXeDaGui_CellClick(object sender, DataGridViewCellEventArgs e)         {             textBox_maSoXeDaGui.Text = dataGridView_dsXeDaGui.CurrentRow.Cells[0].Value.ToString();             button_timMaXeDaGui_Click(sender, e);         }          private void button_vaoCa_Click(object sender, EventArgs e)         {             ca.checkIn(TinhNang.LoginUID);         }          private void button_RaCa_Click(object sender, EventArgs e)         {             ca.checkOut(TinhNang.LoginUID);          }     } } 