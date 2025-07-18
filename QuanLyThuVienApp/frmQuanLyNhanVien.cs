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

        private void frmQuanLyBanDoc_Load(object sender, EventArgs e)
        {
            loadDuLieu();
        }

        private async void loadDuLieu()
        {
            ShowLoading();
            await Task.Run(() =>
            {
                QLTVEntities db = new QLTVEntities();
                var data = db.NhanViens.Where(p => p.NguoiDung.QuyenHan == "user")
                    .Select(p => new
                    {
                        MaNV = "NV" + p.NguoiDungID,
                        p.NguoiDung.TenDangNhap,
                        p.HoTen,
                        p.Email,
                        p.NgayDangKi,
                        TrangThai = (p.TrangThaiXacThuc == false) ? "Chờ kích hoạt" : (p.NguoiDung.BiKhoa == true) ? "Tạm khóa" : "Hoạt động"
                    }).ToList();
                Invoke(new Action(() => {
                    dgvNhanVien.DataSource = data;
                    if (dgvNhanVien.Rows.Count > 0)
                    {       
                        txtID.Text = dgvNhanVien.Rows[0].Cells["MaNV"].Value.ToString();
                        txtSuaEmail.Text = dgvNhanVien.Rows[0].Cells["Email"].Value.ToString();
                        txtSuaTen.Text = dgvNhanVien.Rows[0].Cells["HoTen"].Value.ToString();
                    }
                }));
            });
            HideLoading();
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            txtEmail.Clear();
            txtTen.Clear();
        }

        private async void btnDangKy_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == "" || txtTen.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string email = txtEmail.Text.Trim();
            string hoTen = txtTen.Text.Trim();
            if (!isEmail(email))
            {
                MessageBox.Show("Email không hợp lệ!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            QLTVEntities db = new QLTVEntities();
            NhanVien nhanViens = db.NhanViens.Where(p => p.Email == email).FirstOrDefault();

            if (nhanViens != null)
            {
                MessageBox.Show("Email đã được sử dụng!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult result = MessageBox.Show(
                "Bạn có muốn đăng ký tài khoản mới không?",
                "Thông báo!",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No) return;
            ShowLoading();
            await Task.Run(() =>
            {
                Random random = new Random();
                string matKhau = random.Next(100000, 999999).ToString();

                MD5 mD5 = MD5.Create();
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(matKhau);
                byte[] hashBytes = mD5.ComputeHash(inputBytes);

                string tenDangNhap = "nv" + (db.NguoiDungs.Max(u => (int?)u.ID) ?? 0 + 1).ToString();
                NguoiDung nguoiDung = new NguoiDung();
                nguoiDung.TenDangNhap = tenDangNhap;
                nguoiDung.MatKhau = hashBytes;
                nguoiDung.QuyenHan = "user";
                nguoiDung.BiKhoa = false;
                db.NguoiDungs.Add(nguoiDung);
                db.SaveChanges();
           
                NhanVien nhanVien = new NhanVien();
                nhanVien.HoTen = hoTen;
                nhanVien.Email = email;
                nhanVien.NgayDangKi = null;
                nhanVien.MaOTP = null;
                nhanVien.ThoiGianNhanOTP = null;
                nhanVien.TrangThaiXacThuc = false;
                nhanVien.NguoiDungID = nguoiDung.ID;

                db.NhanViens.Add(nhanVien);
                db.SaveChanges();
                GuiEmail.guiEmail(email, $"Tên đăng nhập của bạn là: {nguoiDung.TenDangNhap}\nMật khẩu đăng nhập của bạn là: {matKhau}\n\nCảnh báo: Vui lòng đăng nhập và đổi thông tin ngay để bảo đảm tính bảo mật!");
            });
            HideLoading();
            txtEmail.Clear();
            txtTen.Clear();
            loadDuLieu();
            MessageBox.Show("Tạo tài khoản nhân viên thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);  
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            loadDuLieu();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string luaChon = cbTimKiem.Text;
            string tuKhoa = txtTimKiem.Text.Trim();
            if (string.IsNullOrWhiteSpace(luaChon) || string.IsNullOrWhiteSpace(tuKhoa)) return;

            QLTVEntities db = new QLTVEntities();
            List<NhanVien> nhanViens = db.NhanViens.Where(p => p.NguoiDung.QuyenHan == "user").ToList();
            List<NhanVien> ketQua = new List<NhanVien>();

            if (luaChon == "Mã nhân viên")
                ketQua = nhanViens.Where(nv => ("NV" + nv.NguoiDungID.ToString()).Contains(tuKhoa)).ToList();
            else if (luaChon == "Tên nhân viên")
                ketQua = nhanViens.Where(nv => nv.HoTen != null && nv.HoTen.Contains(tuKhoa)).ToList();
            else if (luaChon == "Email")
                ketQua = nhanViens.Where(nv => nv.Email != null && nv.Email.Contains(tuKhoa)).ToList();
            else return;

            dgvNhanVien.DataSource = ketQua.Select(nv => new
            {
                MaNV = "NV" + nv.NguoiDungID,
                nv.NguoiDung.TenDangNhap,
                nv.HoTen,
                nv.Email,
                nv.NgayDangKi,
                TrangThai = nv.NguoiDung.BiKhoa == true ? "Tạm khóa" : nv.TrangThaiXacThuc == false ? "Chưa kích hoạt" : "Hoạt động"
            }).ToList();

            if (dgvNhanVien.Rows.Count > 0)
            {
                txtID.Text = dgvNhanVien.Rows[0].Cells["MaNV"].Value.ToString();
                txtSuaEmail.Text = dgvNhanVien.Rows[0].Cells["Email"].Value.ToString();
                txtSuaTen.Text = dgvNhanVien.Rows[0].Cells["HoTen"].Value.ToString();
            }
            else
            {
                txtID.Clear();
                txtSuaEmail.Clear();
                txtSuaTen.Clear();
            }
        }

        private async void btnXoaTK_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để xoá.");
                return;
            }

            string maNV = dgvNhanVien.CurrentRow.Cells["MaNV"].Value.ToString();
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
                MessageBox.Show("Tài khoản này hiện đang bị khóa, không thể xoá!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có muốn xoá tài khoản này không?",
                "Thông báo!",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No) return;

            ShowLoading();
            await Task.Run(() => {
                   
                   var nv = db.NhanViens.SingleOrDefault(p => p.NguoiDungID == nguoiDungID);
                   if (nv != null) db.NhanViens.Remove(nv);

                   var nd = db.NguoiDungs.SingleOrDefault(p => p.ID == nguoiDungID);
                   if (nd != null) db.NguoiDungs.Remove(nd);

                   db.SaveChanges();   
            });
            HideLoading();
            loadDuLieu();
            MessageBox.Show("Xoá tài khoản thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void btnResetTK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần đặt lại tài khoản.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int id = int.Parse(txtID.Text.Substring(2));
            string emailMoi = txtSuaEmail.Text.Trim();
            string hoTenMoi = txtSuaTen.Text.Trim();
            if (!isEmail(emailMoi))
            {
                MessageBox.Show("Email không hợp lệ!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            QLTVEntities db = new QLTVEntities();
            NguoiDung nguoiDung_Check = db.NguoiDungs.FirstOrDefault(p => p.ID == id);
            if (nguoiDung_Check.BiKhoa == true)
            {
                MessageBox.Show("Tài khoản này hiện đang bị khóa, không thể đặt lại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            NhanVien nhanViens = db.NhanViens.Where(p => p.Email == emailMoi && p.NguoiDungID != nguoiDung_Check.ID).FirstOrDefault();

            if (nhanViens != null)
            {
                MessageBox.Show("Email đã được sử dụng!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có muốn đặt lại tài khoản này không?",
                "Thông báo!",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No) return;

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
                nhanVien.HoTen = hoTenMoi;

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
            loadDuLieu();
            if(thongBaoLoi != null) MessageBox.Show(thongBaoLoi, "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (thanhCong) MessageBox.Show("Mật khẩu mới sẽ được gửi về email đăng ký!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void dgvBanDoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            if (dgvNhanVien.Rows.Count > 0)
            {
                txtID.Text = dgvNhanVien.Rows[e.RowIndex].Cells["MaNV"].Value.ToString();
                txtSuaEmail.Text = dgvNhanVien.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                txtSuaTen.Text = dgvNhanVien.Rows[e.RowIndex].Cells["HoTen"].Value.ToString();
            }
            else
            {
                txtID.Clear();
                txtEmail.Clear();
                txtSuaTen.Clear();
            }
        }
    }
}
