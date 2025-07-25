using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

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
            progressBar1.BringToFront();
            this.UseWaitCursor = true;
            Application.DoEvents();
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
            txtHoTen.Focus();
            progressBar1.Visible = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            
            this.Close();   
        }

        private bool isEmail(string inputEmail)
        {
            inputEmail = inputEmail ?? string.Empty;
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputEmail))
                return (true);
            else
                return (false);
        }
        private bool KiemTraSoDienThoai(string sdt)
        {
            sdt = sdt.Trim();
            string pattern = @"^(0[3|5|7|8|9])+([0-9]{8})$";
            return Regex.IsMatch(sdt, pattern);
        }

        private async void btnDangKy_Click(object sender, EventArgs e)
        {
            if (txtSDT.Text == "" || txtHoTen.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!KiemTraSoDienThoai(txtSDT.Text))
            {
                MessageBox.Show("Số điện thoại không hợp lệ!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSDT.Focus();
                return;
            }

            QLTVEntities db = new QLTVEntities();        

            DialogResult result = MessageBox.Show(
                "Bạn có chắc thông tin này đã chính xác?",
                "Thông báo!",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No) return;

            string OTP = string.Empty;
            ShowLoading();
            Application.DoEvents();
            await Task.Run(() =>
            {
                Random random = new Random();
                OTP = random.Next(100000, 999999).ToString();
                GuiEmail.guiEmail(emailDG, "Mã xác thực của bạn là: " + OTP);
                
            });
            HideLoading();


            // Ẩn frmB và mở frmC
            this.Hide();
            using (frmXacThucDG frm = new frmXacThucDG(emailDG, OTP, DateTime.Now))
            {
                var dialogResult = frm.ShowDialog(); // ShowDialog sẽ block tới khi frmC đóng

                if (dialogResult == DialogResult.OK)
                {
                    // Nếu xác thực thành công
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
