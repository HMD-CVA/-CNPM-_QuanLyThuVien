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
    public partial class frmXacThucDG : MetroFramework.Forms.MetroForm
    {
        public static bool ktXacThuc = false;
        private Timer countdownTimer;
        private int remainingSeconds = 30;
        private string email;
        private string OTP;
        private DateTime TGNhan;
        private bool kiemTra = false;
        private readonly Action<bool> callback;
        private void startTimer(int seconds)
        {
            lblTimer.Text = seconds.ToString() + "s";
            remainingSeconds = seconds;
            countdownTimer.Start();
        }
        public frmXacThucDG()
        {
            InitializeComponent();
        }

        public frmXacThucDG(string _email, string _otp, DateTime _tgnhan)
        {
            email = _email;
            OTP = _otp;
            TGNhan = _tgnhan;
            InitializeComponent();
        }
        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            remainingSeconds--;

            lblTimer.Text = remainingSeconds + "s";

            if (remainingSeconds <= 0)
            {
                countdownTimer.Stop();
                MessageBox.Show(this, "Mã xác thực đã hết hạn!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public frmXacThucDG(string _Email, string _OTP, DateTime _TGNhan, Action<bool> callback)
        {
            email= _Email;
            OTP = _OTP;
            TGNhan = _TGNhan;
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
            countdownTimer.Stop();
            if (kiemTra) callback(false);
            this.Close();
        }
        
        private void btnGuiLai_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            string newOTP = random.Next(100000, 999999).ToString();

            OTP = newOTP;
            GuiEmail.guiEmail(email, "Mã xác thực của bạn là " + OTP);
            TGNhan = DateTime.Now;

            startTimer(30);
        }

        private void btnXacThuc_Click(object sender, EventArgs e)
        {
            if (txtMaXacThuc.Text == "")
            {
                MessageBox.Show(this, "Vui lòng nhập mã xác thực!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaXacThuc.Focus();
                return;
            }

            if (txtMaXacThuc.Text != OTP)
            {
                MessageBox.Show(this, "Mã xác thực không chính xác!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaXacThuc.Focus();
                return;
            }

            if (remainingSeconds < 0 || (DateTime.Now - TGNhan).TotalSeconds > 30)
            {
                MessageBox.Show(this, "Mã xác thực đã hết hạn!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaXacThuc.Focus();
                return;
            }
            countdownTimer.Stop();
            MessageBox.Show(this, "Xác thực thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ktXacThuc = true;
            if (kiemTra) callback(true);
            this.DialogResult = DialogResult.OK; // rất quan trọng để frmB biết đã OK
            this.Close();
        }
    }
}
