using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVienApp
{
    public partial class frmXacThucNV : MetroFramework.Forms.MetroForm
    {
        string nv = "NhanViens";
        private Timer countdownTimer;
        private int remainingSeconds = 45;
        private int ID;
        private bool kiemTra = false;
        private readonly Action<bool> callback;
        private void ShowLoading()
        {
            progressBar1.Visible = true;
            progressBar1.BringToFront();
            this.UseWaitCursor = true;
            Application.DoEvents();
        }

        private void HideLoading()
        {
            progressBar1.Visible = false;
            this.UseWaitCursor = false;
        }
        private void startTimer(int seconds)
        {
            lblTimer.Text = seconds.ToString() + "s";
            remainingSeconds = seconds;
            countdownTimer.Start();
        }
        public frmXacThucNV()
        {
            InitializeComponent();
        }

        public frmXacThucNV(int _ID)
        {
            ID = _ID;
            InitializeComponent();
        }
        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            remainingSeconds--;

            lblTimer.Text = remainingSeconds + "s";

            if (remainingSeconds <= 0)
            {
                countdownTimer.Stop();
                MessageBox.Show("Mã xác thực đã hết hạn!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public frmXacThucNV(int _ID, Action<bool> callback)
        {
            ID = _ID;
            kiemTra = true;
            InitializeComponent();
            this.callback = callback;
        }

        private void frmXacNhanOTP_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Vui lòng xác thực tài khoản của bạn thông qua Email trước khi sử dụng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            countdownTimer = new Timer();
            countdownTimer.Interval = 1000; // 1 giây
            countdownTimer.Tick += CountdownTimer_Tick;
            startTimer(remainingSeconds);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (kiemTra) callback(false);
            countdownTimer.Stop();
            this.Close();
        }
        
        private async void btnGuiLai_Click(object sender, EventArgs e)
        {
            QLTVEntities db = new QLTVEntities();
            NhanVien nguoiDung = db.NhanViens.Where(p => p.NguoiDungID == ID).SingleOrDefault();

            Random random = new Random();
            string OTP = random.Next(100000, 999999).ToString();

            ShowLoading();
            await Task.Run(() =>
            {
                nguoiDung.MaOTP = OTP;
                GuiEmail.guiEmail(nguoiDung.Email, "Mã xác thực của bạn là " + OTP);
                nguoiDung.ThoiGianNhanOTP = DateTime.Now;
                db.SaveChanges();
            });
            HideLoading();
            startTimer(remainingSeconds);
        }

        private void btnXacThuc_Click(object sender, EventArgs e)
        {
            if (txtMaXacThuc.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã xác thực!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            QLTVEntities db = new QLTVEntities();
            NhanVien nguoiDung = db.NhanViens.Where(p => p.MaNV == ID).SingleOrDefault();

            if (nguoiDung == null) return;

            if (txtMaXacThuc.Text != nguoiDung.MaOTP)
            {
                MessageBox.Show("Mã xác thực không chính xác!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaXacThuc.Focus();
                return;
            }

            if (remainingSeconds < 0 || (DateTime.Now - nguoiDung.ThoiGianNhanOTP.Value).TotalSeconds > 45)
            {
                countdownTimer.Stop();
                MessageBox.Show("Mã xác thực đã hết hạn!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            NguoiDung ngD = db.NguoiDungs.Where(p => p.ID == nguoiDung.NguoiDungID).SingleOrDefault();
            nguoiDung.TrangThaiXacThuc = true;
            nguoiDung.NgayDangKi = DateTime.Now;
            ngD.BiKhoa = false;
            ngD.QuyenHan = "user";
            countdownTimer.Stop();
            db.SaveChanges();
            MessageBox.Show("Xác thực thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (kiemTra) callback(true);    
            this.Close();
        }
    }
}
