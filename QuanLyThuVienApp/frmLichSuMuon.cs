using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVienApp
{
    public partial class frmLichSuMuon : Form
    {
        private class PhieuMuonResult
        {
            public string MaPhieu { get; set; }
            public string TenDG { get; set; }
            public string TenNV { get; set; }
            public DateTime? NgayMuon { get; set; }
            public DateTime? HanTra { get; set; }
            public string DaTra { get; set; }
            public DateTime? NgayTra { get; set; }
        }

        private List<PhieuMuonResult> _filteredPhieuMuons = new List<PhieuMuonResult>();
        private void LoadDataToGrid()
        {
            string selectedFilter = cbLoc.SelectedItem.ToString();

            var displayList = _filteredPhieuMuons;

            if (selectedFilter != "Tất cả")
                displayList = _filteredPhieuMuons.Where(p => p.DaTra == selectedFilter).ToList();

            dgvPhieuMuon.DataSource = displayList;
        }

        public frmLichSuMuon()
        {
            InitializeComponent();
        }

        private void frmLichSuMuon_Load(object sender, EventArgs e)
        {
            loadDuLieu();
            cbLoc.SelectedIndex = 0;
            cbLoc.Enabled = false;
        }

        private void loadDuLieu()
        {
            QLTVEntities db = new QLTVEntities();
            var danhSachPhieuMuon = db.PhieuMuons
                .Include(p => p.DocGia)
                .Include(p => p.NhanVien)
                .OrderByDescending(p => p.MaPhieu)
                .ToList();

            dgvPhieuMuon.DataSource = danhSachPhieuMuon
            .Where(p => p.MaPhieu == 0)
            .Select(p => new
            {
                MaPhieu = "MP" + p.MaPhieu,
                TenDG = p.DocGia.HoTen != null ? p.DocGia.HoTen : string.Empty,
                TenNV = p.NhanVien.HoTen != null ? p.NhanVien.HoTen : string.Empty,
                p.NgayMuon,
                p.HanTra,
                DaTra = (
                    (p.NgayMuon == null && (DateTime.Now - p.NgayTao).TotalSeconds > 15) ? "Đã huỷ" :
                     p.NgayMuon == null ? "Chờ duyệt" :
                     p.DaTra == true ? "Đã trả" :
                    (p.NgayTra == null && p.HanTra.HasValue && p.HanTra.Value.Date < DateTime.Now.Date) ? "Trễ hạn" : "Chưa trả"
                ),
                NgayTra = (p.DaTra == true) ? p.NgayTra : null
            }).ToList();
            loadChiTietPM(0);
        }

        private void loadChiTietPM(int maPhieu)
        {
            QLTVEntities db = new QLTVEntities();
            dgvChiTiet.DataSource = db.ChiTietPhieuMuons.Where(p => p.MaPM == maPhieu).Select(p => new
            {
                //MaChiTiet = "MCT" + p.MaChiTiet,
                MaTaiLieu = "TL" + p.MaTL,
                p.TaiLieu.TenTaiLieu,
                p.TaiLieu.DanhMucTaiLieu.TenDanhMuc,
                p.TaiLieu.TacGia.TenTG,
                p.TaiLieu.NhaXuatBan.TenNXB,
                p.SoLuongBD
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

        private void dgvPhieuMuon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvPhieuMuon.Rows[e.RowIndex].Cells["DaTra"].Value.ToString() == "Trễ hạn")
                e.CellStyle.ForeColor = Color.Red;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string maPhieu = txtMaPhieu.Text.Trim();
            string ms = txtMS.Text.Trim();

            if (string.IsNullOrEmpty(email) && string.IsNullOrEmpty(maPhieu) && string.IsNullOrEmpty(ms))
            {
                MessageBox.Show("Vui lòng nhập thông tin phiếu mượn của bạn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            string maPhieuSearch = maPhieu.Replace("MP", "").Trim();

            QLTVEntities db = new QLTVEntities();
            var now = DateTime.Now;

            _filteredPhieuMuons = db.PhieuMuons
            .Where(pm =>
                (string.IsNullOrEmpty(email) || pm.DocGia.Email.Contains(email)) &&
                (string.IsNullOrEmpty(maPhieuSearch) || SqlFunctions.StringConvert((double)pm.MaPhieu).Contains(maPhieuSearch)) &&
                (string.IsNullOrEmpty(ms) || pm.DocGia.MaSo.Contains(ms))
            )
            .Select(p => new PhieuMuonResult
            {
                MaPhieu = "MP" + p.MaPhieu,
                TenDG = p.DocGia != null ? p.DocGia.HoTen : string.Empty,
                TenNV = p.NhanVien != null ? p.NhanVien.HoTen : string.Empty,
                NgayMuon = p.NgayMuon,
                HanTra = p.HanTra,
                DaTra = p.NgayMuon == null
                    ? (DbFunctions.DiffSeconds(p.NgayTao, now) > 15 ? "Đã huỷ" : "Chờ duyệt")
                    : p.DaTra == true ? "Đã trả"
                    : (p.NgayTra == null && p.HanTra.HasValue && DbFunctions.TruncateTime(p.HanTra) < DbFunctions.TruncateTime(now)) ? "Trễ hạn"
                    : "Chưa trả",
                NgayTra = p.DaTra == true ? p.NgayTra : null
            })
            .ToList();

            cbLoc.Enabled = _filteredPhieuMuons.Count > 0;
            LoadDataToGrid();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtEmail.Text = string.Empty;
            txtMaPhieu.Text = string.Empty;
            txtMS.Text = string.Empty;
            cbLoc.SelectedIndex = 0;
            loadDuLieu();
        }

        private void cbLoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDuLieu();
            LoadDataToGrid();
        }
    }
}
