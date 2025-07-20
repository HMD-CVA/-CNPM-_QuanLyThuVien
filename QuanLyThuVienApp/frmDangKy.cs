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
        public frmDangKy()
        {
            InitializeComponent();
            txtHoTen.Focus();
        }

        private void frmDangKy_Load(object sender, EventArgs e)
        {
            txtHoTen.Focus();
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
            if (txtSDT.Text == "" || txtEmail.Text == "" || txtHoTen.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!isEmail(txtEmail.Text)) 
            {
                MessageBox.Show("Email không hợp lệ!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return;
            }

            if (!KiemTraSoDienThoai(txtSDT.Text))
            {
                MessageBox.Show("Số điện thoại không hợp lệ!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSDT.Focus();
                return;
            }

            QLTVEntities db = new QLTVEntities();        
            DocGia docGia = db.DocGias.Where(p => p.Email == txtEmail.Text.Trim()).SingleOrDefault();

            if (docGia != null)
            {
                MessageBox.Show("Email đã được sử dụng!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc thêm độc giả này?",
                "Thông báo!",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No) return;

            ShowLoading();
            await Task.Run(() =>
            {
                DocGia DG = new DocGia();
                DG.HoTen = txtHoTen.Text.Trim();
                DG.Email = txtEmail.Text.Trim();
                DG.SDT = txtSDT.Text.Trim();
                DG.BiKhoa = false;
                db.DocGias.Add(DG);
                db.SaveChanges();
            });
            HideLoading();

            MessageBox.Show("Đã thêm thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtHoTen.Text = string.Empty;
            txtEmail.Text = string.Empty;   
            txtSDT.Text = string.Empty;
        }
    }
}
