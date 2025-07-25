using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVienApp
{
    public partial class frmLichSuMuon : Form
    {
        public frmLichSuMuon()
        {
            InitializeComponent();
        }

        private void frmLichSuMuon_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Vui lòng nhập đầy đủ thông tin phiếu mượn của bạn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //loadDuLieu();
        }

        private void loadDuLieu()
        {
            QLTVEntities db = new QLTVEntities();
            dgvPhieuMuon.DataSource = db.PhieuMuons
                .OrderByDescending(p => p.MaPhieu)
                .Select(p => new {
                    MaPhieu = "MP" + p.MaPhieu,
                    TenDG = p.DocGia.HoTen,
                    TenNV = p.NhanVien.HoTen,
                    p.NgayMuon,
                    p.HanTra,
                    DaTra = (
                    (p.NgayTra == null && p.HanTra.HasValue && DbFunctions.TruncateTime(p.HanTra) < DbFunctions.TruncateTime(DateTime.Now)) ||
                    (p.NgayTra != null && p.HanTra.HasValue && DbFunctions.TruncateTime(p.HanTra) < DbFunctions.TruncateTime(p.NgayTra))
                ) ? "Trễ hạn" : (p.DaTra == true ? "Đã trả" : "Chưa trả"),
                    NgayTra = (p.DaTra == true) ? p.NgayTra : null
                }).ToList();

            loadChiTietPM(0);
        }

        private void loadChiTietPM(int maPhieu)
        {
            QLTVEntities db = new QLTVEntities();
            dgvChiTiet.DataSource = db.ChiTietPhieuMuons.Where(p => p.MaPM == maPhieu).Select(p => new {
                //MaChiTiet = "MCT" + p.MaChiTiet,
                MaTaiLieu = "TL" + p.MaTL,
                p.TaiLieu.TenTaiLieu,
                p.TaiLieu.DanhMucTaiLieu.TenDanhMuc,
                p.TaiLieu.TacGia.TenTG,
                p.TaiLieu.NhaXuatBan.TenNXB,
                p.SoLuong
            }).ToList();
        }

        private void dgvPhieuMuon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string maPhieuStr = dgvPhieuMuon.Rows[e.RowIndex].Cells["MaPhieu"].Value.ToString();
                if (maPhieuStr.StartsWith("MP"))
                {
                    string soMaPhieu = maPhieuStr.Substring(2);
                    if (int.TryParse(soMaPhieu, out int maPhieu)) loadChiTietPM(maPhieu);
                }
            }
            if (e.RowIndex == -1) return;
        }

        //private void btnXoa_Click(object sender, EventArgs e)
        //{
        //    DialogResult result = MessageBox.Show(
        //       "Bạn có muốn xóa phiếu đăng ký không?",
        //       "Thông báo!",
        //       MessageBoxButtons.YesNo,
        //       MessageBoxIcon.Question
        //   );

        //    if (result == DialogResult.No) return;

        //    int maPhieu = int.Parse(dgvChiTiet.Rows[0].Cells["MaPhieu2"].Value.ToString());
        //    DB_Test db = new DB_Test();

        //    int tongSach = 0;

        //    // cập nhật lại số lượng sách
        //    foreach (DataGridViewRow row in dgvChiTiet.Rows)
        //    {
        //        string maSach = row.Cells["MaSach"].Value.ToString();
        //        int soLuong = int.Parse(row.Cells["SoLuong"].Value.ToString());
        //        tongSach += soLuong;

        //        Sach sach = db.Saches.Where(p => ("S" + p.ID.ToString()) == maSach).FirstOrDefault();
        //        sach.SoSachMuon -= soLuong;
        //    }

        //    // cập nhật số sách đang mượn của user
        //    NguoiDung nguoiDung = db.NguoiDungs.Where(p=>p.ID == frmMainUser.ID).FirstOrDefault();
        //    nguoiDung.SoSachMuon -= tongSach;

        //    // xóa phiếu mượn và phiếu chi tiết
        //    PhieuMuon phieuMuon = db.PhieuMuons.Where(p => p.MaPhieu == maPhieu).FirstOrDefault();
        //    List<ChiTietPhieuMuon> chiTietPhieuMuon = db.ChiTietPhieuMuons.Where(p => p.MaPhieu == maPhieu).ToList();
        //    db.PhieuMuons.Remove(phieuMuon);
        //    db.ChiTietPhieuMuons.RemoveRange(chiTietPhieuMuon);

        //    // lưu vào database
        //    db.SaveChanges();
        //    loadDuLieu();
        //    if (dgvPhieuMuon.Rows.Count == 0)
        //    {
        //        dgvChiTiet.DataSource = null;
        //        dgvChiTiet.Rows.Clear();
        //    }
        //    MessageBox.Show("Xóa phiếu đăng ký thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //}

        //private void cbLoc_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (cbLoc.Text == "Tất cả")
        //    {
        //        loadDuLieu();
        //        return;
        //    }

        //    DB_Test db = new DB_Test();
        //    List<PhieuMuon> phieuMuons = new List<PhieuMuon>();

        //    if(cbLoc.Text == "Đăng ký mượn")
        //        phieuMuons = db.PhieuMuons.Where(p => p.TrangThai == 0).ToList();
        //    else if (cbLoc.Text == "Đã trả")
        //        phieuMuons = db.PhieuMuons.Where(p => p.TrangThai == 2).ToList();
        //    else if (cbLoc.Text == "Quá hạn")
        //        phieuMuons = db.PhieuMuons.Where(p => p.TrangThai == 1 
        //        && DbFunctions.TruncateTime(DateTime.Now) > DbFunctions.TruncateTime(p.HanTra)).ToList();
        //    else
        //        phieuMuons = db.PhieuMuons.Where(p => p.TrangThai == 1
        //        && DbFunctions.TruncateTime(DateTime.Now) <= DbFunctions.TruncateTime(p.HanTra)).ToList();

        //    dgvPhieuMuon.DataSource = phieuMuons
        //                   .Select(p => new
        //                   {
        //                       p.MaPhieu,
        //                       p.NgayDangKyMuon,
        //                       TrangThai = (p.TrangThai == 0) ? "Đăng ký mượn" :
        //                        (p.TrangThai == 2) ? "Đã trả" :
        //                        DateTime.Now.Date > p.HanTra.Value.Date ? "Quá hạn" : "Đang mượn",
        //                       p.NgayMuon,
        //                       p.HanTra,
        //                       p.NgayTra
        //                   }).ToList();

        //    loadChiTietPhieu();
        //}

        private void dgvPhieuMuon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvPhieuMuon.Rows[e.RowIndex].Cells["DaTra"].Value.ToString() == "Trễ hạn")
                e.CellStyle.ForeColor = Color.Red;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text) && string.IsNullOrEmpty(txtMaPhieu.Text) && string.IsNullOrEmpty(txtSDT.Text)) 
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin phiếu mượn của bạn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }
            string email = txtEmail.Text.Trim();
            string maPhieu = txtMaPhieu.Text.Trim();
            string sdt = txtSDT.Text.Trim();

            QLTVEntities db = new QLTVEntities();
            var ketQua = db.PhieuMuons
            .Where(pm =>
                (string.IsNullOrEmpty(email) || pm.DocGia.Email.Contains(email)) &&
                (string.IsNullOrEmpty(maPhieu) || pm.MaPhieu.ToString().Contains(maPhieu)) &&
                (string.IsNullOrEmpty(sdt) || pm.DocGia.SDT.Contains(sdt))
            )
            .ToList();

            dgvPhieuMuon.DataSource =  db.PhieuMuons
            .Where(pm =>
            (string.IsNullOrEmpty(email) || pm.DocGia.Email.Contains(email)) &&
            (string.IsNullOrEmpty(maPhieu) || ("MP" + pm.MaPhieu.ToString()).Contains(maPhieu)) &&
            (string.IsNullOrEmpty(sdt) || pm.DocGia.SDT.Contains(sdt)))
            .Select(p => new
            {
                MaPhieu = "MP" + p.MaPhieu,
                TenDG = p.DocGia.HoTen,
                TenNV = p.NhanVien.HoTen,
                p.NgayMuon,
                p.HanTra,
                DaTra = (
                    (p.NgayTra == null && p.HanTra.HasValue && DbFunctions.TruncateTime(p.HanTra) < DbFunctions.TruncateTime(DateTime.Now)) ||
                    (p.NgayTra != null && p.HanTra.HasValue && DbFunctions.TruncateTime(p.HanTra) < DbFunctions.TruncateTime(p.NgayTra))
                ) ? "Trễ hạn" : (p.DaTra == true ? "Đã trả" : "Chưa trả"),
                NgayTra = (p.DaTra == true) ? p.NgayTra : null
            }).ToList();
        }
    }
}
