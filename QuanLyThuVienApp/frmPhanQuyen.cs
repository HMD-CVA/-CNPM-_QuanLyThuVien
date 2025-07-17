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
    public partial class frmPhanQuyen : Form
    {
        public frmPhanQuyen()
        {
            InitializeComponent();
        }

        private void frmCapQuyen_Load(object sender, EventArgs e)
        {
            radioUser.Checked = true;
        }

        private void radioUser_CheckedChanged(object sender, EventArgs e)
        {
            loadUser();
        }

        private void radioAdmin_CheckedChanged(object sender, EventArgs e)
        {
            loadAdmin();
        }

        private void radioDangKhoa_CheckedChanged(object sender, EventArgs e)
        {
            loadDangKhoa();
        }

        private void loadUser()
        {
            QLTVEntities db = new QLTVEntities();
            List<int> taiKhoan_User = db.NguoiDungs.Where(p => p.QuyenHan == "user" && p.BiKhoa == false).Select(p => p.ID).ToList();
            dgvNguoiDung.DataSource = db.NhanViens.Where(p => taiKhoan_User.Contains(p.NguoiDungID))
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

            btnCapQuyenAdmin.Show();
            btnKhoaTaiKhoan.Show();
            btnHuyQuyenAdmin.Hide();
            btnMoKhoa.Hide();

            loadChiTiet();
        }

        private void loadAdmin()
        {
            QLTVEntities db = new QLTVEntities();
            List<int> taiKhoan_Admin = db.NguoiDungs.Where(p => p.QuyenHan == "admin").Select(p => p.ID).ToList();
            dgvNguoiDung.DataSource = db.NhanViens.Where(p => taiKhoan_Admin.Contains(p.NguoiDungID))
                .Select(p => new
                {
                    MaNV = "AD" + p.MaNV,
                    p.HoTen,
                    p.NgaySinh,
                    p.SDT,
                    p.DiaChi,
                    p.Email,
                    p.NgayDangKi,
                    QuyenHan = "admin",
                }).ToList();

            btnCapQuyenAdmin.Hide();
            btnKhoaTaiKhoan.Hide();
            btnHuyQuyenAdmin.Show();
            btnMoKhoa.Hide();

            loadChiTiet();
        }

        private void loadDangKhoa()
        {
            QLTVEntities db = new QLTVEntities();
            List<int> taiKhoan_UserLocked = db.NguoiDungs.Where(p => p.BiKhoa == true).Select(p => p.ID).ToList();
            dgvNguoiDung.DataSource = db.NhanViens.Where(p => taiKhoan_UserLocked.Contains(p.NguoiDungID))
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

            btnCapQuyenAdmin.Hide();
            btnKhoaTaiKhoan.Hide();
            btnHuyQuyenAdmin.Hide();
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
                List<int> listUser = db.NguoiDungs.Where(p => p.QuyenHan == "user" && p.BiKhoa == false).Select(p => p.ID).ToList();

                if (luaChon == "Mã")
                    nguoiDungs = db.NhanViens.Where(p => listUser.Contains(p.NguoiDungID) 
                    && ("NV" + p.MaNV.ToString()).Contains(txtTimKiem.Text)).ToList();

                else if (luaChon == "Tên người dùng")
                    nguoiDungs = db.NhanViens.Where(p => listUser.Contains(p.NguoiDungID) 
                    && p.HoTen.Contains(txtTimKiem.Text)).ToList();

                else if (luaChon == "Email")
                    nguoiDungs = db.NhanViens.Where(p => listUser.Contains(p.NguoiDungID) 
                    && p.Email.Contains(txtTimKiem.Text)).ToList();

                else if (luaChon == "SDT")
                    nguoiDungs = db.NhanViens.Where(p => listUser.Contains(p.NguoiDungID)
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
                    QuyenHan = "user",
                }).ToList();
            }
            else if (radioAdmin.Checked)
            {
                List<int> listUser = db.NguoiDungs.Where(p => p.QuyenHan == "admin").Select(p => p.ID).ToList();

                if (luaChon == "Mã")
                    nguoiDungs = db.NhanViens.Where(p => listUser.Contains(p.NguoiDungID) && ("AD" + p.MaNV.ToString()).Contains(txtTimKiem.Text)).ToList();
                else if (luaChon == "Tên người dùng")
                    nguoiDungs = db.NhanViens.Where(p => listUser.Contains(p.NguoiDungID) && p.HoTen.Contains(txtTimKiem.Text)).ToList();
                else if (luaChon == "Email")
                    nguoiDungs = db.NhanViens.Where(p => listUser.Contains(p.NguoiDungID) && p.Email.Contains(txtTimKiem.Text)).ToList();
                else if (luaChon == "SDT")
                    nguoiDungs = db.NhanViens.Where(p => listUser.Contains(p.NguoiDungID) && p.Email.Contains(txtTimKiem.Text)).ToList();
                else return;

                dgvNguoiDung.DataSource = nguoiDungs.Select(p => new
                {
                    MaNV = "AD" + p.MaNV,
                    p.HoTen,
                    p.NgaySinh,
                    p.SDT,
                    p.DiaChi,
                    p.Email,
                    p.NgayDangKi,
                    QuyenHan = "admin",
                }).ToList();
            }
            else if (radioDangKhoa.Checked)
            {
                List<int> listUser = db.NguoiDungs.Where(p => p.QuyenHan == "user" && p.BiKhoa == true).Select(p => p.ID).ToList();

                if (luaChon == "Mã")
                    nguoiDungs = db.NhanViens.Where(p => p.TrangThaiXacThuc == true && listUser.Contains(p.NguoiDungID)
                    && ("NV" + p.MaNV.ToString()).Contains(txtTimKiem.Text)).ToList();

                else if (luaChon == "Tên người dùng")
                    nguoiDungs = db.NhanViens.Where(p => listUser.Contains(p.NguoiDungID) && p.TrangThaiXacThuc == true
                    && p.HoTen.Contains(txtTimKiem.Text)).ToList();

                else if (luaChon == "Email")
                    nguoiDungs = db.NhanViens.Where(p => listUser.Contains(p.NguoiDungID) && p.TrangThaiXacThuc == true
                    && p.Email.Contains(txtTimKiem.Text)).ToList();

                else if (luaChon == "SDT")
                    nguoiDungs = db.NhanViens.Where(p => listUser.Contains(p.NguoiDungID) && p.TrangThaiXacThuc == true
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
            else if (radioAdmin.Checked) loadAdmin();
            else loadDangKhoa();
        }
        private void btnCapQuyenAdmin_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;

            DialogResult result = MessageBox.Show(
                "Bạn có chắc cấp quyền admin cho tài khoản này?",
                "Thông báo!",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No) return;

            QLTVEntities db = new QLTVEntities();
            int maNV = int.Parse(txtID.Text.Substring(2));
            var ngD = db.NhanViens.FirstOrDefault(p => p.MaNV == maNV);

            NguoiDung nguoiDung = db.NguoiDungs.Where(p => p.ID == ngD.NguoiDungID).FirstOrDefault();

            nguoiDung.QuyenHan = "admin";
            db.SaveChanges();
            loadUser();

            MessageBox.Show("Cấp quyền admin thành công!", "Thonpg báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnHuyQuyenAdmin_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;

            DialogResult result = MessageBox.Show(
                "Bạn có chắc hủy quyền admin của tài khoản này?",
                "Thông báo!",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No) return;

            QLTVEntities db = new QLTVEntities();
            int maNV = int.Parse(txtID.Text.Substring(2));
            var ngD = db.NhanViens.FirstOrDefault(p => p.MaNV == maNV);

            NguoiDung nguoiDung = db.NguoiDungs.Where(p => p.ID == ngD.NguoiDungID).FirstOrDefault();

            nguoiDung.QuyenHan = "user";
            db.SaveChanges();
            loadAdmin();

            MessageBox.Show("Hủy quyền admin thành công!", "Thonpg báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnKhoaTaiKhoan_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;

            DialogResult result = MessageBox.Show(
                "Tài khoản này sẽ không thể mượn tài liệu mới?",
                "Thông báo!",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No) return;

            QLTVEntities db = new QLTVEntities();
            int maNV = int.Parse(txtID.Text.Substring(2));
            var ngD = db.NhanViens.FirstOrDefault(p => p.MaNV == maNV);

            NguoiDung nguoiDung = db.NguoiDungs.Where(p => p.ID == ngD.NguoiDungID).FirstOrDefault();
            nguoiDung.BiKhoa = true;
            db.SaveChanges();
            loadUser();

            MessageBox.Show("Khóa tài khoản thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnMoKhoa_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;

            DialogResult result = MessageBox.Show(
                "Tài khoản này sẽ có thể mượn tài liệu?",
                "Thông báo!",
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

            MessageBox.Show("Mở khóa tài khoản thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
