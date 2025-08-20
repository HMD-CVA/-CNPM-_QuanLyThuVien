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
    public partial class frmQuanLyTaiKhoanNV : Form
    {
        public Form frmMainAdmin;
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

        public frmQuanLyTaiKhoanNV()
        {
            InitializeComponent();
        }

        public frmQuanLyTaiKhoanNV(Form _frmMainAdmin)
        {
            InitializeComponent();
            frmMainAdmin = _frmMainAdmin;
        }

        private void frmQuanLyBanDoc_Load(object sender, EventArgs e)
        {
            LibraryHelper.KiemTraVaKhoaTaiKhoan();
            loadDuLieu();
        }

        private async void loadDuLieu()
        {
            ShowLoading();
            await Task.Run(() =>
            {
                QLTVEntities db = new QLTVEntities();
                var data = db.NhanViens.Where(p => p.NguoiDung.QuyenHan == "user" && p.TrangThaiAnHien == true)
                .Select(p => new
                {
                    MaNV = "NV" + p.NguoiDungID,
                    p.NguoiDung.TenDangNhap,
                    p.HoTen,
                    p.Email,
                    p.NgayDangKi,
                    TrangThai =  (p.NguoiDung.BiKhoa == true) ? "Tạm khóa"  : (p.TrangThaiXacThuc == false) ? "Chờ kích hoạt" : "Hoạt động"
                }).ToList();

                Invoke(new Action(() => {
                    dgvNhanVien.DataSource = data;
                    if (dgvNhanVien.Rows.Count > 0) HienThiDuLieu(0);
                }));
            });
            HideLoading();
        }
        private void HienThiDuLieu(int index)
        {
            txtID.Text = dgvNhanVien.Rows[index].Cells["MaNV"].Value.ToString();
            txtSuaEmail.Text = dgvNhanVien.Rows[index].Cells["Email"].Value.ToString();
            txtSuaTen.Text = dgvNhanVien.Rows[index].Cells["HoTen"].Value.ToString();
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
            string email = txtEmail.Text.Trim();
            string hoTen = txtTen.Text.Trim();


            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(hoTen))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            if (!isEmail(email))
            {
                MessageBox.Show("Email không hợp lệ!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            QLTVEntities db = new QLTVEntities();
            NhanVien nhanViens = db.NhanViens.Where(p => p.Email == email).FirstOrDefault();

            if (nhanViens != null && nhanViens.TrangThaiAnHien == true)
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
                nguoiDung.TrangThaiAnHien = true;
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
                nhanVien.TrangThaiAnHien = true;

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
            List<NhanVien> nhanViens = db.NhanViens.Where(p => p.NguoiDung.QuyenHan == "user" && p.TrangThaiAnHien == true).ToList();
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

            if (dgvNhanVien.Rows.Count > 0) HienThiDuLieu(0);
            else ClearFormInputs();
        }

        private void dgvBanDoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvNhanVien.Rows.Count > 0) HienThiDuLieu(e.RowIndex);
            else ClearFormInputs();
        }
        private void ClearFormInputs()
        {
            txtID.Clear();
            txtSuaEmail.Clear();
            txtSuaTen.Clear();
        }

        private void btnXemTT_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
                form.Close();
            
            frmQuanLyNhanVien frm = new frmQuanLyNhanVien();
            frm.MdiParent = frmMainAdmin;
            frm.Dock = DockStyle.Fill;

            frm.FormClosed += (s, args) =>
            {
                loadDuLieu();
            };

            frm.Show();
        }
    }
}
