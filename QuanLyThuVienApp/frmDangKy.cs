using System;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVienApp
{
    public partial class frmDangKy : MetroFramework.Forms.MetroForm
    {
        public bool checkDK = false; 
        private string emailDG;
        private void ShowLoading()
        {
            progressBar1.Visible = true;
            progressBar1.MarqueeAnimationSpeed = 30;
            this.UseWaitCursor = true;
        }
        private void HideLoading()
        {
            progressBar1.Visible = false;
            progressBar1.MarqueeAnimationSpeed = 0;
            this.UseWaitCursor = false;
        }
        private frmDangKy()
        {
            InitializeComponent();
            txtHoTen.Focus();
        }
        public frmDangKy(string _EmailDG)
        {
            InitializeComponent();
            emailDG = _EmailDG;
            txtEmail.Text = emailDG;
            txtEmail.ReadOnly = true;
            txtHoTen.Focus();
        }

        private void frmDangKy_Load(object sender, EventArgs e)
        {
            progressBar1.Visible = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private bool KiemTraSoDienThoai(string sdt)
        {
            sdt = sdt.Trim();
            string pattern = @"^(0[3|5|7|8|9])+([0-9]{8})$";
            return Regex.IsMatch(sdt, pattern);
        }

        private async void btnDangKy_Click(object sender, EventArgs e)
        {
            string hoTen = txtHoTen.Text.Trim();
            string sdt = txtSDT.Text.Trim();

            if (string.IsNullOrWhiteSpace(hoTen) || string.IsNullOrWhiteSpace(sdt))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!KiemTraSoDienThoai(sdt))
            {
                MessageBox.Show("Số điện thoại không hợp lệ!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSDT.Focus();
                return;
            }

            if (MessageBox.Show("Bạn có chắc thông tin này đã chính xác?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;   

            string OTP = new Random().Next(100000, 999999).ToString();
            ShowLoading();
            await Task.Run(() => GuiEmail.guiEmail(emailDG, "Mã xác thực của bạn là: " + OTP));
            HideLoading();

            this.Hide();
            using (frmXacThucDG frm = new frmXacThucDG(emailDG, OTP, DateTime.Now))
            {
                var dialogResult = frm.ShowDialog(); // ShowDialog sẽ block tới khi frmC đóng

                if (dialogResult == DialogResult.OK)
                {
                    // Nếu xác thực thành công
                    QLTVEntities db = new QLTVEntities();
                    DocGia DG = new DocGia();
                    DG.HoTen = txtHoTen.Text.Trim();
                    DG.Email = emailDG;
                    DG.SDT = txtSDT.Text.Trim();
                    DG.BiKhoa = false;
                    db.DocGias.Add(DG);
                    db.SaveChanges();

                    MessageBox.Show("Chào mừng bạn đến với thư viện!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    checkDK = true;
                    this.DialogResult = DialogResult.OK; // cho frmA biết là đăng ký thành công
                    this.Close();
                }
                else
                {
                    // Xác thực thất bại hoặc người dùng đóng frmXacThuc
                    MessageBox.Show("Xác thực không thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Show();
                }
            }
        }
    }
}
