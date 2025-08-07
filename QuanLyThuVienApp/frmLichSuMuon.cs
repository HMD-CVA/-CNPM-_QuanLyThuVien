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
            cbLoc.Enabled = false;
        }

        private void loadDuLieu()
        {
            QLTVEntities db = new QLTVEntities();
            dgvPhieuMuon.DataSource = db.PhieuMuons
                .Where(p => p.MaPhieu == 0)
                .OrderByDescending(p => p.MaPhieu)
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
            _filteredPhieuMuons = db.PhieuMuons
            .Where(pm =>
                (string.IsNullOrEmpty(email) || pm.DocGia.Email.Contains(email)) &&
                (string.IsNullOrEmpty(maPhieuSearch) || pm.MaPhieu.ToString().Contains(maPhieuSearch)) &&
                (string.IsNullOrEmpty(ms) || pm.DocGia.MaSo.Contains(ms))
            )
            .Select(p => new PhieuMuonResult
            {
                //MaPhieuGoc = p.MaPhieu,
                MaPhieu = "MP" + p.MaPhieu,
                TenDG = p.DocGia.HoTen,
                TenNV = p.NhanVien.HoTen,
                NgayMuon = p.NgayMuon,
                HanTra = p.HanTra,
                DaTra = (
                    (p.NgayTra == null && p.HanTra.HasValue && DbFunctions.TruncateTime(p.HanTra) < DbFunctions.TruncateTime(DateTime.Now)) ||
                    (p.NgayTra != null && p.HanTra.HasValue && DbFunctions.TruncateTime(p.HanTra) < DbFunctions.TruncateTime(p.NgayTra))
                ) ? "Trễ hạn" : (p.DaTra == true ? "Đã trả" : "Chưa trả"),
                NgayTra = (p.DaTra == true) ? p.NgayTra : null
            }).ToList();

            cbLoc.Enabled = _filteredPhieuMuons.Count > 0;
            cbLoc.SelectedIndex = 0; // Reset về "Tất cả"
            LoadDataToGrid();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtEmail.Text = string.Empty;
            txtMaPhieu.Text = string.Empty;
            txtMS.Text = string.Empty;
            cbLoc.Text = string.Empty;
            loadDuLieu();
        }

        private void cbLoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDuLieu();
            LoadDataToGrid();
        }
    }
}
