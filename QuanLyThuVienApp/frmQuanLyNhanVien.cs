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

namespace QuanLyThuVienApp
{
    public partial class frmQuanLyNhanVien : Form
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
        public frmQuanLyNhanVien()
        {
            InitializeComponent();
        }

        private void frmCapQuyen_Load(object sender, EventArgs e)
        {
            LibraryHelper.KiemTraVaKhoaTaiKhoan();
            radioUser.Checked = true;
            btnLuuEmail.Visible = false;
            progressBar1.Visible = false;   
        }

        private void radioUser_CheckedChanged(object sender, EventArgs e)
        {
            loadUser();
            btnResetTK.Enabled = true;
            btnXoaTK.Enabled = true;
        }

        private void radioDangKhoa_CheckedChanged(object sender, EventArgs e)
        {
            loadDangKhoa();
        }

        private void loadUser()
        {
            QLTVEntities db = new QLTVEntities();
            List<int> taiKhoan_User = db.NguoiDungs.Where(p => p.QuyenHan == "user" && p.BiKhoa == false && p.TrangThaiAnHien == true).Select(p => p.ID).ToList();
            dgvNguoiDung.DataSource = db.NhanViens.Where(p => taiKhoan_User.Contains(p.NguoiDungID) && p.TrangThaiAnHien == true)
                .Select(p => new
                {
                    MaNV = "NV" + p.MaNV,
                    p.HoTen,
                    p.NgaySinh,
                    p.SDT,
                    p.DiaChi,
                    p.Email,
                    p.NgayDangKi,
                    QuyenHan = "user",
                }).ToList();

            btnKhoaTaiKhoan.Show();
            btnMoKhoa.Hide();

            loadChiTiet();
        }

        private void loadDangKhoa()
        {
            QLTVEntities db = new QLTVEntities();
            List<int> taiKhoan_UserLocked = db.NguoiDungs.Where(p => p.BiKhoa == true && p.TrangThaiAnHien == true).Select(p => p.ID).ToList();
            dgvNguoiDung.DataSource = db.NhanViens.Where(p => taiKhoan_UserLocked.Contains(p.NguoiDungID) && p.TrangThaiAnHien == true)
                .Select(p => new
                {
                    MaNV = "NV" + p.MaNV,
                    p.HoTen,
                    p.NgaySinh,
                    p.SDT,
                    p.DiaChi,
                    p.Email,
                    p.NgayDangKi,
                    QuyenHan = "locked",
                }).ToList();

            btnKhoaTaiKhoan.Hide();
            btnMoKhoa.Show();

            loadChiTiet();
        }

        private void loadChiTiet(int rowIndex = 0)
        {
            if (dgvNguoiDung.Rows.Count > 0)
            { 
                txtID.Text = dgvNguoiDung.Rows[rowIndex].Cells["MaNV"].Value.ToString();

                if (dgvNguoiDung.Rows[rowIndex].Cells["HoTen"].Value != null) txtTen.Text = dgvNguoiDung.Rows[rowIndex].Cells["HoTen"].Value.ToString();
                else txtTen.Text = string.Empty;

                if (dgvNguoiDung.Rows[rowIndex].Cells["Email"].Value != null) txtEmail.Text = dgvNguoiDung.Rows[rowIndex].Cells["Email"].Value.ToString();
                else txtEmail.Text = string.Empty;

                if (dgvNguoiDung.Rows[rowIndex].Cells["NgaySinh"].Value != null) txtNgaySinh.Text = ((DateTime)dgvNguoiDung.Rows[rowIndex].Cells["NgaySinh"].Value).ToString("dd/MM/yyyy");
                else txtNgaySinh.Text = string.Empty;

                if (dgvNguoiDung.Rows[rowIndex].Cells["SDT"].Value != null) txtSDT.Text = dgvNguoiDung.Rows[rowIndex].Cells["SDT"].Value.ToString();
                else txtSDT.Text = string.Empty;

                if (dgvNguoiDung.Rows[rowIndex].Cells["DiaChi"].Value != null) txtDC.Text = dgvNguoiDung.Rows[rowIndex].Cells["DiaChi"].Value.ToString();
                else txtDC.Text = string.Empty;

                if (dgvNguoiDung.Rows[rowIndex].Cells["NgayDangKi"].Value != null) txtNgayDangKy.Text = ((DateTime)dgvNguoiDung.Rows[rowIndex].Cells["NgayDangKi"].Value).ToString("dd/MM/yyyy");
                else txtNgayDangKy.Text = string.Empty;

                if (dgvNguoiDung.Rows[rowIndex].Cells["QuyenHan"].Value != null) txtQuyenHan.Text = dgvNguoiDung.Rows[rowIndex].Cells["QuyenHan"].Value.ToString();
                else txtQuyenHan.Text = string.Empty;
            }
            else
            {
                txtID.Clear();
                txtTen.Clear();
                txtEmail.Clear();
                txtNgayDangKy.Clear();
                txtQuyenHan.Clear();
            }
        }
        private void dgvNguoiDung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            loadChiTiet(e.RowIndex);
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string luaChon = cbTimKiem.Text;
            if (luaChon == "") return;

            QLTVEntities db = new QLTVEntities();
            List<NhanVien> nguoiDungs = new List<NhanVien>();

            if (radioUser.Checked)
            {
                List<int> listUser = db.NguoiDungs.Where(p => p.QuyenHan == "user" && p.BiKhoa == false && p.TrangThaiAnHien == true).Select(p => p.ID).ToList();

                if (luaChon == "Mã")
                    nguoiDungs = db.NhanViens.Where(p => p.TrangThaiAnHien == true && listUser.Contains(p.NguoiDungID) 
                    && ("NV" + p.MaNV.ToString()).Contains(txtTimKiem.Text)).ToList();

                else if (luaChon == "Họ tên nhân viên")
                    nguoiDungs = db.NhanViens.Where(p => p.TrangThaiAnHien == true && listUser.Contains(p.NguoiDungID) 
                    && p.HoTen.Contains(txtTimKiem.Text)).ToList();

                else if (luaChon == "Email")
                    nguoiDungs = db.NhanViens.Where(p => p.TrangThaiAnHien == true && listUser.Contains(p.NguoiDungID) 
                    && p.Email.Contains(txtTimKiem.Text)).ToList();

                else if (luaChon == "SDT")
                    nguoiDungs = db.NhanViens.Where(p => p.TrangThaiAnHien == true && listUser.Contains(p.NguoiDungID)
                    && p.SDT.Contains(txtTimKiem.Text)).ToList();

                else return;

                dgvNguoiDung.DataSource = nguoiDungs
                .Select(p => new
                {
                    MaNV = "NV" + p.MaNV,
                    p.HoTen,
                    p.NgaySinh,
                    p.SDT,
                    p.DiaChi,
                    p.Email,
                    p.NgayDangKi,
                    QuyenHan = "user",
                }).ToList();
            } 
            else if (radioDangKhoa.Checked)
            {
                List<int> listUser = db.NguoiDungs.Where(p => p.QuyenHan == "user" && p.BiKhoa == true && p.TrangThaiAnHien == true).Select(p => p.ID).ToList();

                if (luaChon == "Mã")
                    nguoiDungs = db.NhanViens.Where(p => p.TrangThaiAnHien == true && p.TrangThaiXacThuc == true && listUser.Contains(p.NguoiDungID)
                    && ("NV" + p.MaNV.ToString()).Contains(txtTimKiem.Text)).ToList();

                else if (luaChon == "Họ tên nhân viên")
                    nguoiDungs = db.NhanViens.Where(p => p.TrangThaiAnHien == true && listUser.Contains(p.NguoiDungID) && p.TrangThaiXacThuc == true
                    && p.HoTen.Contains(txtTimKiem.Text)).ToList();

                else if (luaChon == "Email")
                    nguoiDungs = db.NhanViens.Where(p => p.TrangThaiAnHien == true && listUser.Contains(p.NguoiDungID) && p.TrangThaiXacThuc == true
                    && p.Email.Contains(txtTimKiem.Text)).ToList();

                else if (luaChon == "SDT")
                    nguoiDungs = db.NhanViens.Where(p => p.TrangThaiAnHien == true && listUser.Contains(p.NguoiDungID) && p.TrangThaiXacThuc == true
                    && p.SDT.Contains(txtTimKiem.Text)).ToList();

                else return;

                dgvNguoiDung.DataSource = nguoiDungs.Select(p => new
                {
                    MaNV = "NV" + p.MaNV,
                    p.HoTen,
                    p.NgaySinh,
                    p.SDT,
                    p.DiaChi,
                    p.Email,
                    p.NgayDangKi,
                    QuyenHan = "locked",
                }).ToList();
            }

            loadChiTiet();
        }
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            if (radioUser.Checked) loadUser();
            else loadDangKhoa();
        }
        
        private void btnKhoaTaiKhoan_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;

            QLTVEntities db = new QLTVEntities();
            int maNV = int.Parse(txtID.Text.Substring(2));
            
            string text = string.Empty;
            PhieuMuon pm = db.PhieuMuons.Where(p => p.MaNV == maNV && p.DaTra == false).FirstOrDefault();
            if (pm != null)
            {
                text = "Nhân viên vẫn đang phụ trách phiếu mượn chưa trả!\n\n";
            }

            DialogResult result = MessageBox.Show(
                text +
                "Bạn có chắc muốn khoá tài khoản này không ?",
                "Thông báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.No) return;

            
            var ngD = db.NhanViens.FirstOrDefault(p => p.MaNV == maNV);

            NguoiDung nguoiDung = db.NguoiDungs.Where(p => p.ID == ngD.NguoiDungID).FirstOrDefault();
            nguoiDung.BiKhoa = true;
            db.SaveChanges();
            loadUser();

            MessageBox.Show("Khóa tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnMoKhoa_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;

            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn mở khoá tài khoản này không ?",
                "Thông báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No) return;


            QLTVEntities db = new QLTVEntities();
            int maNV = int.Parse(txtID.Text.Substring(2));
            var ngD = db.NhanViens.FirstOrDefault(p => p.MaNV == maNV);


            NguoiDung nguoiDung = db.NguoiDungs.Where(p => p.ID == ngD.NguoiDungID).FirstOrDefault();
            nguoiDung.BiKhoa = false;
            db.SaveChanges();
            loadDangKhoa();

            MessageBox.Show("Mở khóa tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void btnResetTK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần đặt lại tài khoản.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MessageBox.Show("Vui lòng nhập email mới để đặt lại tài khoản.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtEmail.ReadOnly = false;
            txtEmail.Focus();
            btnLuuEmail.Visible = true;
        }

        private async void btnXoaTK_Click(object sender, EventArgs e)
        {
            if (dgvNguoiDung.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để xoá.");
                return;
            }

            string maNV = dgvNguoiDung.CurrentRow.Cells["MaNV"].Value.ToString();
            int nguoiDungID;

            if (!int.TryParse(maNV.Replace("NV", ""), out nguoiDungID))
            {
                MessageBox.Show("Mã nhân viên không hợp lệ.");
                return;
            }
            QLTVEntities db = new QLTVEntities();
            var nd_Check = db.NguoiDungs.SingleOrDefault(p => p.ID == nguoiDungID);
            if (nd_Check.BiKhoa == true)
            {
                MessageBox.Show("Tài khoản này hiện đang bị khóa, không thể xoá!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PhieuMuon nv_pm = db.PhieuMuons.Where(p => p.MaNV == nguoiDungID && p.DaTra == false).FirstOrDefault();
            if (nv_pm != null)
            {
                MessageBox.Show("Tài khoản này hiện đang phụ trách phiếu mượn chưa trả, không thể xoá!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có muốn xoá tài khoản này không?",
                "Thông báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No) return;

            ShowLoading();
            await Task.Run(() => {

                var nv = db.NhanViens.SingleOrDefault(p => p.NguoiDungID == nguoiDungID);
                if (nv != null) nv.TrangThaiAnHien = false;

                var nd = db.NguoiDungs.SingleOrDefault(p => p.ID == nguoiDungID);
                if (nd != null) nd.TrangThaiAnHien = false;

                db.SaveChanges();
            });
            HideLoading();
            loadUser();
            MessageBox.Show("Xoá tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private async void btnLuuEmail_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text.Trim().Substring(2));
            string emailMoi = txtEmail.Text.Trim();

            if (!isEmail(emailMoi) || string.IsNullOrEmpty(emailMoi))
            {
                MessageBox.Show("Email không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            QLTVEntities db = new QLTVEntities();
            NguoiDung nguoiDung_Check = db.NguoiDungs.FirstOrDefault(p => p.ID == id);
            if (nguoiDung_Check.BiKhoa == true)
            {
                MessageBox.Show("Tài khoản này hiện đang bị khóa, không thể đặt lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có muốn đặt lại tài khoản này không?",
                "Thông báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No) return;

            NhanVien nhanViens = db.NhanViens.Where(p => p.Email == emailMoi).FirstOrDefault();

            if (nhanViens != null && nhanViens.NguoiDungID != nguoiDung_Check.ID)
            {
                MessageBox.Show("Email đã được sử dụng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (nhanViens != null && nhanViens.NguoiDungID == nguoiDung_Check.ID)
            {
                MessageBox.Show("Vui lòng nhập email mới để đặt lại tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string thongBaoLoi = null;
            bool thanhCong = false;

            ShowLoading();
            await Task.Run(() =>
            {
                NguoiDung nguoiDung = db.NguoiDungs.FirstOrDefault(p => p.ID == id);
                NhanVien nhanVien = db.NhanViens.FirstOrDefault(p => p.NguoiDungID == id);
                if (nguoiDung == null || nhanVien == null)
                {
                    thongBaoLoi = "Không tìm thấy người dùng tương ứng!";
                    return;
                }

                Random random = new Random();
                string matKhau = random.Next(100000, 999999).ToString();
                MD5 mD5 = MD5.Create();
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(matKhau);
                byte[] hashBytes = mD5.ComputeHash(inputBytes);

                nguoiDung.MatKhau = hashBytes;

                bool doiEmail = nhanVien.Email != emailMoi;

                if (doiEmail)
                {
                    nhanVien.Email = emailMoi;
                    nhanVien.TrangThaiXacThuc = false;
                    nhanVien.NgayDangKi = null;
                    nhanVien.MaOTP = null;
                    nhanVien.ThoiGianNhanOTP = null;
                }


                db.SaveChanges();
                GuiEmail.guiEmail(nhanVien.Email,
                    $"Tài khoản của bạn đã được cập nhật.\n" +
                    $"Tên đăng nhập: {nguoiDung.TenDangNhap}\n" +
                    $"Mật khẩu mới: {matKhau}\n\n" +
                    $"Vui lòng đăng nhập và xác thực lại email!");

                thanhCong = true;

            });
            HideLoading();
            txtEmail.ReadOnly = true;
            btnLuuEmail.Visible = false;
            loadUser();
            if (thongBaoLoi != null) MessageBox.Show(thongBaoLoi, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (thanhCong) MessageBox.Show("Mật khẩu mới sẽ được gửi về email đăng ký!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
