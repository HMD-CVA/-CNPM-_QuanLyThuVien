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
    public partial class frmXacThuc : MetroFramework.Forms.MetroForm
    {
        private Timer countdownTimer;
        private int remainingSeconds = 30;
        private int ID;
        private bool kiemTra = false;
        private readonly Action<bool> callback;
        private void startTimer(int seconds)
        {
            lblTimer.Text = seconds.ToString() + "s";
            remainingSeconds = seconds;
            countdownTimer.Start();
        }
        public frmXacThuc()
        {
            InitializeComponent();
        }

        public frmXacThuc(int _ID)
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
        public frmXacThuc(int _ID, Action<bool> callback)
        {
            ID = _ID;
            kiemTra = true;
            InitializeComponent();
            this.callback = callback;
        }

        private void frmXacNhanOTP_Load(object sender, EventArgs e)
        {
            countdownTimer = new Timer();
            countdownTimer.Interval = 1000; // 1 giây
            countdownTimer.Tick += CountdownTimer_Tick;
            startTimer(30);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (kiemTra) callback(false);
            this.Close();
        }
        
        private void btnGuiLai_Click(object sender, EventArgs e)
        {
            QLTVEntities db = new QLTVEntities();
            NhanVien nguoiDung = db.NhanViens.Where(p => p.NguoiDungID == ID).SingleOrDefault();

            Random random = new Random();
            string OTP = random.Next(100000, 999999).ToString();

            nguoiDung.MaOTP = OTP;
            GuiEmail.guiEmail(nguoiDung.Email, "Mã xác thực của bạn là " + OTP);
            nguoiDung.ThoiGianNhanOTP = DateTime.Now;
            db.SaveChanges();
            startTimer(30);
        }

        private void btnXacThuc_Click(object sender, EventArgs e)
        {
            if (txtMaXacThuc.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã xác thực!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            QLTVEntities db = new QLTVEntities();
            NhanVien nguoiDung = db.NhanViens.Where(p => p.NguoiDungID == ID).SingleOrDefault();

            if (nguoiDung == null) return;

            if (txtMaXacThuc.Text != nguoiDung.MaOTP)
            {
                MessageBox.Show("Mã xác thực không chính xác!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaXacThuc.Focus();
                return;
            }

            if (remainingSeconds < 0 || (DateTime.Now - nguoiDung.ThoiGianNhanOTP.Value).TotalSeconds > 30)
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
