using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVienApp
{
    public partial class frmCaNhan : Form
    {
        public static string tenDN;
        public static string quyenHan;

        public frmCaNhan()
        {
            InitializeComponent();
        }

        public frmCaNhan(string _tenDN, string _quyenHan)
        {
            tenDN = _tenDN;
            quyenHan = _quyenHan;
            InitializeComponent();
        }

        private void frmCaNhan_Load(object sender, EventArgs e)
        {
            loadDuLieu();
            btnLuuTenDN.Hide();
            btnHuyTenDN.Hide();

            btnLuuTen.Hide();
            btnHuyTen.Hide();

            btnLuuNgaySinh.Hide();
            btnHuyNgaySinh.Hide();

            btnLuuSDT.Hide();
            btnHuySDT.Hide();

            btnLuuDC.Hide();
            btnHuyDC.Hide();

            btnLuuEmail.Hide();
            btnHuyEmail.Hide();
        }

        private void loadDuLieu()
        {
            QLTVEntities db = new QLTVEntities();
            NguoiDung ngD = db.NguoiDungs.Where(p => p.TenDangNhap == tenDN).FirstOrDefault();
            NhanVien nguoiDung = db.NhanViens.Where(p => p.NguoiDungID == ngD.ID).FirstOrDefault();

            if (nguoiDung == null) return;

            if (ngD.TenDangNhap != null) txtTenDangNhap.Text = ngD.TenDangNhap.ToString();
            else txtTenDangNhap.Text = string.Empty;

            if (nguoiDung.HoTen != null) txtHoVaTen.Text = nguoiDung.HoTen.ToString();
            else txtHoVaTen.Text = string.Empty;

            if (nguoiDung.NgaySinh != null) txtNgaySinh.Text = nguoiDung.NgaySinh.Value.ToString("dd/MM/yyyy");
            else txtNgaySinh.Text = string.Empty;

            if (nguoiDung.SDT != null) txtSDT.Text = nguoiDung.SDT.ToString();
            else txtSDT.Text = string.Empty;

            if (nguoiDung.DiaChi != null) txtDiaChi.Text = nguoiDung.DiaChi.ToString();
            else txtDiaChi.Text = string.Empty;

            if (nguoiDung.Email != null) txtEmail.Text = nguoiDung.Email.ToString();
            else txtEmail.Text = string.Empty;
                
            if (quyenHan == "user") txtID.Text = "NV" + ngD.ID;
            else txtID.Text = "AD" + ngD.ID;
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            QLTVEntities db = new QLTVEntities();
            NguoiDung nguoiDung = db.NguoiDungs.Where(p => p.TenDangNhap == tenDN).FirstOrDefault();
            frmDoiMatKhau frm = new frmDoiMatKhau(nguoiDung.ID);
            frm.ShowDialog();
        }
        private void btnHuyTenDN_Click(object sender, EventArgs e)
        {
            QLTVEntities db = new QLTVEntities();
            NguoiDung nguoiDung = db.NguoiDungs.Where(p => p.TenDangNhap == tenDN).FirstOrDefault();
            txtTenDangNhap.Text = nguoiDung.TenDangNhap.ToString();
            btnHuyTenDN.Hide();
            btnLuuTenDN.Hide();
            txtTenDangNhap.ReadOnly = true;
        }
        private void btnLuuTenDN_Click(object sender, EventArgs e)
        {
            if (txtTenDangNhap.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập mới!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string tenDNCu = tenDN;
            string tenDNMoi = txtTenDangNhap.Text;

            using (QLTVEntities db = new QLTVEntities())
            {
                // Kiểm tra tên mới đã tồn tại chưa
                bool daTonTai = db.NguoiDungs.Any(p => p.TenDangNhap == tenDNMoi);
                if (daTonTai)
                {
                    MessageBox.Show("Tên đăng nhập đã được sử dụng!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var nguoiDung = db.NguoiDungs.FirstOrDefault(p => p.TenDangNhap == tenDNCu);
                if (nguoiDung != null)
                {
                    nguoiDung.TenDangNhap = tenDNMoi;
                    db.SaveChanges();  
                }

                MessageBox.Show("Đổi tên đăng nhập thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            txtTenDangNhap.ReadOnly = true;
            btnLuuTenDN.Hide();
            btnHuyTenDN.Hide();
            tenDN = txtTenDangNhap.Text;
            loadDuLieu();
        }
        private void btnDoiTenDangNhap_Click(object sender, EventArgs e)
        {
            btnLuuTenDN.Show();
            btnHuyTenDN.Show();
            txtTenDangNhap.ReadOnly = false;
        }
        private void btnDoiTen_Click(object sender, EventArgs e)
        {
            txtHoVaTen.ReadOnly = false;
            btnLuuTen.Show();
            btnHuyTen.Show();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtHoVaTen.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            QLTVEntities db = new QLTVEntities();
            NguoiDung nguoiDung = db.NguoiDungs.Where(p => p.TenDangNhap == tenDN).FirstOrDefault();
            NhanVien nhanVien = db.NhanViens.Where(p => p.NguoiDungID == nguoiDung.ID).FirstOrDefault();

            nhanVien.HoTen = txtHoVaTen.Text;
            db.SaveChanges();
            txtHoVaTen.ReadOnly = true;
            btnLuuTen.Hide();
            btnHuyTen.Hide();
            loadDuLieu();

            if (nguoiDung.QuyenHan == "admin") frmMainAdmin.text = "Chào mừng quản trị viên: " + txtHoVaTen.Text + " đã quay trở lại!";
            else if (nguoiDung.BiKhoa == false) frmMainUser.text = "Chào mừng nhân viên: " + txtHoVaTen.Text + " đã quay trở lại!";

            MessageBox.Show("Thay đổi tên thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnHuyTen_Click(object sender, EventArgs e)
        {
            QLTVEntities db = new QLTVEntities();
            NguoiDung nguoiDung = db.NguoiDungs.Where(p => p.TenDangNhap == tenDN).FirstOrDefault();
            NhanVien nhanVien = db.NhanViens.Where(p => p.NguoiDungID == nguoiDung.ID).FirstOrDefault();
            txtHoVaTen.Text = nhanVien.HoTen.ToString();
            btnHuyTen.Hide();
            btnLuuTen.Hide();
            txtHoVaTen.ReadOnly = true;
        }

        private void btnDoiEmail_Click(object sender, EventArgs e)
        {
            btnLuuEmail.Show();
            btnHuyEmail.Show();
            txtEmail.ReadOnly = false;
        }

        private void btnHuyEmail_Click(object sender, EventArgs e)
        {
            QLTVEntities db = new QLTVEntities();
            NguoiDung nguoiDung = db.NguoiDungs.Where(p => p.TenDangNhap == tenDN).FirstOrDefault();
            NhanVien nhanVien = db.NhanViens.Where(p => p.NguoiDungID == nguoiDung.ID).FirstOrDefault();
            txtEmail.Text = nhanVien.Email.ToString();
            btnHuyEmail.Hide();
            btnLuuEmail.Hide();
            txtEmail.ReadOnly = true;
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

        private void btnLuuEmail_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                MessageBox.Show("Vui lòng nhập Email!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!isEmail(txtEmail.Text))
            {
                MessageBox.Show("Email không hợp lệ!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string newE = txtEmail.Text.Trim();
            QLTVEntities db = new QLTVEntities();
            NhanVien nhanVien = db.NhanViens.Where(p => p.Email.Trim() == newE).FirstOrDefault();

            if (nhanVien != null)
            {
                MessageBox.Show("Email đã được sử dụng!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                //if (nhanVien.TrangThaiXacThuc == true)
                //{
                //    MessageBox.Show("Email đã được sử dụng!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}
                //else
                //{
                //    db.NguoiDungs.Remove(nguoiDung);
                //    db.SaveChanges();
                //}
            }

            NguoiDung nguoiDung = db.NguoiDungs.Where(p => p.TenDangNhap == tenDN).FirstOrDefault();
            nhanVien = db.NhanViens.Where(p => p.NguoiDungID == nguoiDung.ID).FirstOrDefault();

            if (txtEmail.Text == nhanVien.Email)
            {
                MessageBox.Show("Cần nhập email mới!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Random random = new Random();
            string OTP = random.Next(100000, 999999).ToString();

            try
            {
                GuiEmail.guiEmail(txtEmail.Text, "Mã xác thực của bạn là " + OTP);

                nhanVien.MaOTP = OTP;
                nhanVien.ThoiGianNhanOTP = DateTime.Now;
                db.SaveChanges();

                frmXacThuc frm = new frmXacThuc(nhanVien.NguoiDungID, xacNhan =>
                {
                    if (xacNhan)
                    {
                        nhanVien.Email = txtEmail.Text;
                        db.SaveChanges();

                        txtEmail.ReadOnly = true;
                        btnLuuEmail.Hide();
                        btnHuyEmail.Hide();
                        loadDuLieu();
                    }
                });
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDoiDC_Click(object sender, EventArgs e)
        {
            btnLuuDC.Show();
            btnHuyDC.Show();
            txtDiaChi.ReadOnly = false;
        }

        private void btnLuuDC_Click(object sender, EventArgs e)
        {
            if (txtDiaChi.Text == "")
            {
                MessageBox.Show("Vui lòng nhập địa chỉ!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            QLTVEntities db = new QLTVEntities();
            NguoiDung nguoiDung = db.NguoiDungs.Where(p => p.TenDangNhap == tenDN).FirstOrDefault();
            NhanVien nhanVien = db.NhanViens.Where(p => p.NguoiDungID == nguoiDung.ID).FirstOrDefault();

            nhanVien.DiaChi = txtDiaChi.Text;
            db.SaveChanges();
            txtDiaChi.ReadOnly = true;
            btnLuuDC.Hide();
            btnHuyDC.Hide();
            loadDuLieu();

            MessageBox.Show("Thay đổi địa chỉ thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnHuyDC_Click(object sender, EventArgs e)
        {
            QLTVEntities db = new QLTVEntities();
            NguoiDung nguoiDung = db.NguoiDungs.Where(p => p.TenDangNhap == tenDN).FirstOrDefault();
            NhanVien nhanVien = db.NhanViens.Where(p => p.NguoiDungID == nguoiDung.ID).FirstOrDefault();
            txtDiaChi.Text = nhanVien.DiaChi.ToString();
            btnHuyDC.Hide();
            btnLuuDC.Hide();
            txtDiaChi.ReadOnly = true;
        }

        private void btnDoiSDT_Click(object sender, EventArgs e)
        {
            btnLuuSDT.Show();
            btnHuySDT.Show();
            txtSDT.ReadOnly = false;
        }

        private void btnDoiNgaySinh_Click(object sender, EventArgs e)
        {
            btnLuuNgaySinh.Show();
            btnHuyNgaySinh.Show();
            txtNgaySinh.ReadOnly = false;
        }

        private void btnLuuNgaySinh_Click(object sender, EventArgs e)
        {
            if (txtNgaySinh.Text == "")
            {
                MessageBox.Show("Vui lòng nhập ngày sinh!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            QLTVEntities db = new QLTVEntities();
            NguoiDung nguoiDung = db.NguoiDungs.Where(p => p.TenDangNhap == tenDN).FirstOrDefault();
            NhanVien nhanVien = db.NhanViens.Where(p => p.NguoiDungID == nguoiDung.ID).FirstOrDefault();
            DateTime ngaySinh;
            if (DateTime.TryParseExact(txtNgaySinh.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out ngaySinh))
            {
                nhanVien.NgaySinh = ngaySinh;
            }
            else
            {
                MessageBox.Show("Ngày sinh không hợp lệ. Vui lòng nhập đúng định dạng dd/MM/yyyy", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            db.SaveChanges();
            txtNgaySinh.ReadOnly = true;
            btnLuuNgaySinh.Hide();
            btnHuyNgaySinh.Hide();
            loadDuLieu();

            MessageBox.Show("Thay đổi ngày sinh thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnHuyNgaySinh_Click(object sender, EventArgs e)
        {
            QLTVEntities db = new QLTVEntities();
            NguoiDung nguoiDung = db.NguoiDungs.Where(p => p.TenDangNhap == tenDN).FirstOrDefault();
            NhanVien nhanVien = db.NhanViens.Where(p => p.NguoiDungID == nguoiDung.ID).FirstOrDefault();
            txtNgaySinh.Text = nhanVien.NgaySinh.Value.ToString("dd/MM/yyyy");
            btnHuyNgaySinh.Hide();
            btnLuuNgaySinh.Hide();
            txtNgaySinh.ReadOnly = true;
        }
        private bool IsInvalidPhoneNumber(string sdt)
        {
            if (string.IsNullOrWhiteSpace(sdt)) return true;

            if (!Regex.IsMatch(sdt, @"^\d{10}$")) return true;

            if (!Regex.IsMatch(sdt, @"^(03|05|07|08|09)\d{8}$")) return true;

            return false;
        }

        private void btnLuuSDT_Click(object sender, EventArgs e)
        {
            if (txtNgaySinh.Text == "")
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            QLTVEntities db = new QLTVEntities();
            NguoiDung nguoiDung = db.NguoiDungs.Where(p => p.TenDangNhap == tenDN).FirstOrDefault();
            NhanVien nhanVien = db.NhanViens.Where(p => p.NguoiDungID == nguoiDung.ID).FirstOrDefault();
            if (!IsInvalidPhoneNumber(txtSDT.Text))
            {
                nhanVien.SDT = txtSDT.Text;
            }
            else
            {
                MessageBox.Show("Số điện thoại không hợp lệ. Vui lòng nhập lại", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            db.SaveChanges();
            btnLuuSDT.Hide();
            btnHuySDT.Hide();
            txtSDT.ReadOnly = true;
            loadDuLieu();

            MessageBox.Show("Thay đổi số điện thoại thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnHuySDT_Click(object sender, EventArgs e)
        {
            QLTVEntities db = new QLTVEntities();
            NguoiDung nguoiDung = db.NguoiDungs.Where(p => p.TenDangNhap == tenDN).FirstOrDefault();
            NhanVien nhanVien = db.NhanViens.Where(p => p.NguoiDungID == nguoiDung.ID).FirstOrDefault();
            txtSDT.Text = nhanVien.SDT.ToString();
            btnHuySDT.Hide();
            btnLuuSDT.Hide();
            txtSDT.ReadOnly = true;
        }
    }
}
