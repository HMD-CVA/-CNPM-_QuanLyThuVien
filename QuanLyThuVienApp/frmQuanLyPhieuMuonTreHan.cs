using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVienApp
{
    public partial class frmQuanLyPhieuMuonTreHan : Form
    {
        private int? maDG;
        public static bool giaHan = false;
        public int TienPhat { get; private set; }
        public int SoNgayTre { get; private set; }
        public frmQuanLyPhieuMuonTreHan()
        {
            InitializeComponent();
        }

        public frmQuanLyPhieuMuonTreHan(int _maPhieu)
        {
            InitializeComponent();
            TienPhat = TinhTienPhat(_maPhieu);
        }

        private void frmQuanLyPhieuMuon_Load(object sender, EventArgs e)
        {
            LibraryHelper.KiemTraVaKhoaTaiKhoan();
            loadPhieuMuon();
        }

        private void loadPhieuMuon()
        {
            QLTVEntities db = new QLTVEntities();

            var today = DateTime.Today;

            var danhSachPhieuMuon = db.PhieuMuons
                .Include(p => p.DocGia)
                .Include(p => p.NhanVien)
                .OrderByDescending(p => p.MaPhieu)
                .Where(p => (p.NgayTra == null && p.HanTra.HasValue && p.HanTra.Value < today))
                .ToList();

            dgvPhieuMuon.DataSource = danhSachPhieuMuon.Select(p => new
            {
                MaPhieu = "MP" + p.MaPhieu,
                HoTenDG = p.DocGia != null ? p.DocGia.HoTen : string.Empty,
                HoTenNV = p.NhanVien != null ? p.NhanVien.HoTen : string.Empty,
                p.NgayMuon,
                p.HanTra,
                DaTra = "Trễ hạn",
                NgayTra = (p.DaTra == true) ? p.NgayTra : null
            }).ToList();
        }

        private void loadChiTietPM(int maPhieu)
        {
            QLTVEntities db = new QLTVEntities();
            dgvChiTietPM.DataSource = db.ChiTietPhieuMuons.Where(p => p.MaPM == maPhieu).Select(p => new {
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
            if (e.RowIndex < 0) return;
            string maPhieuStr = dgvPhieuMuon.Rows[e.RowIndex].Cells["MaPhieu"].Value.ToString();
            if (maPhieuStr.StartsWith("MP"))
            {
                maPhieuStr = maPhieuStr.Substring(2);
            }

            QLTVEntities db = new QLTVEntities();
            maDG = db.PhieuMuons.Where(p => p.MaPhieu.ToString() == maPhieuStr).Select(p => (int?)p.MaDG).FirstOrDefault();

            int.TryParse(maPhieuStr, out int maPhieuGhiNho);

            if (int.TryParse(maPhieuStr, out int maPhieu)) loadChiTietPM(maPhieu);

            //string daTra = dgvPhieuMuon.Rows[e.RowIndex].Cells["DaTra"].Value.ToString();

            int tienPhat = TinhTienPhat(maPhieuGhiNho);
            lbTienPhat2.Text = tienPhat.ToString() + " VNĐ";
        }

        private void dgvPhieuMuon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvPhieuMuon.Rows.Count) return;
            if (dgvPhieuMuon.Columns[e.ColumnIndex].Name == "DaTra")
            {
                string daTraValue = dgvPhieuMuon.Rows[e.RowIndex].Cells["DaTra"].Value?.ToString();
                if (daTraValue == "Trễ hạn")
                {
                    dgvPhieuMuon.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                loadPhieuMuon();
                return;
            }

            QLTVEntities db = new QLTVEntities();
            List<PhieuMuon> phieuMuon = new List<PhieuMuon>();

            if (cbTimKiem.Text == "Mã phiếu")
            {
                if (keyword.StartsWith("MP", StringComparison.OrdinalIgnoreCase)) keyword = keyword.Substring(2);

                dgvPhieuMuon.DataSource = db.PhieuMuons.Where(p => p.MaPhieu.ToString().Contains(keyword))
                .Select(p => new
                {
                    MaPhieu = "MP" + p.MaPhieu,
                    HoTenDG = p.DocGia.HoTen,
                    HoTenNV = (p.MaNV == null) ? "" : p.NhanVien.HoTen,
                    p.NgayMuon,
                    p.HanTra,
                    DaTra = (p.DaTra == true) ? "Đã trả" : (p.NgayTra == null && p.HanTra.HasValue && DbFunctions.TruncateTime(p.HanTra) < DbFunctions.TruncateTime(DateTime.Now) ? "Trễ hạn" : "Chưa trả"),
                    NgayTra = (p.DaTra == true) ? p.NgayTra : null
                }).ToList();
            }
            else if (cbTimKiem.Text == "Tên độc giả")
            {
                dgvPhieuMuon.DataSource = db.PhieuMuons.Where(p => p.DocGia.HoTen.ToString().Contains(keyword))
                .Select(p => new
                {
                    MaPhieu = "MP" + p.MaPhieu,
                    HoTenDG = p.DocGia.HoTen,
                    HoTenNV = (p.MaNV == null) ? "" : p.NhanVien.HoTen,
                    p.NgayMuon,
                    p.HanTra,
                    DaTra = (p.DaTra == true) ? "Đã trả" : (p.NgayTra == null && p.HanTra.HasValue && DbFunctions.TruncateTime(p.HanTra) < DbFunctions.TruncateTime(DateTime.Now) ? "Trễ hạn" : "Chưa trả"),
                    NgayTra = (p.DaTra == true) ? p.NgayTra : null
                }).ToList();
            }
            else if (cbTimKiem.Text == "Tên nhân viên")
            {
                dgvPhieuMuon.DataSource = db.PhieuMuons.Where(p => p.NhanVien.HoTen.ToString().Contains(keyword))
               .Select(p => new
               {
                   MaPhieu = "MP" + p.MaPhieu,
                   HoTenDG = p.DocGia.HoTen,
                   HoTenNV = (p.MaNV == null) ? "" : p.NhanVien.HoTen,
                   p.NgayMuon,
                   p.HanTra,
                   DaTra = (p.DaTra == true) ? "Đã trả" : (p.NgayTra == null && p.HanTra.HasValue && DbFunctions.TruncateTime(p.HanTra) < DbFunctions.TruncateTime(DateTime.Now) ? "Trễ hạn" : "Chưa trả"),
                   NgayTra = (p.DaTra == true) ? p.NgayTra : null
               }).ToList();
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            loadPhieuMuon();
        }

        private void btnTraSach_Click(object sender, EventArgs e)
        {
            if (dgvChiTietPM.Rows.Count == 0)
            {
                //MessageBox.Show("Không có phiếu mượn!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvPhieuMuon.SelectedRows.Count == 0)
            {
                MessageBox.Show("Hãy chọn 1 phiếu mượn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có xác nhận độc giả này đã trả đủ sách không ?", "Thông báo!",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No) return;

            DataGridViewRow selectedRow = dgvPhieuMuon.SelectedRows[0];
            int maPhieu = int.Parse(selectedRow.Cells["MaPhieu"].Value.ToString().Substring(2));

            QLTVEntities db = new QLTVEntities();

            PhieuMuon pm = db.PhieuMuons.Where(p => p.MaPhieu == maPhieu).FirstOrDefault();
            pm.DaTra = true;
            pm.NgayTra = DateTime.Now;
            //int tongSach = 0;
            foreach (DataGridViewRow row in dgvChiTietPM.Rows)
            {
                int idSach = int.Parse(row.Cells["MaTaiLieu"].Value.ToString().Substring(2));
                int soLuong = int.Parse(row.Cells["SoLuong"].Value.ToString());
                //tongSach += soLuong;
                TaiLieu tl = db.TaiLieux.Where(p => p.MaTaiLieu == idSach).FirstOrDefault();
                tl.SoTaiLieuMuon -= soLuong;
            }

            db.SaveChanges();
            btnLamMoi.PerformClick();

            MessageBox.Show("Trả sách thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadPhieuMuon();
            loadChiTietPM(0);
        }

        private void btnHoaDonPhat_Click(object sender, EventArgs e)
        {
            if (dgvPhieuMuon.Rows.Count == 0) return;

            string maPhieustr = dgvPhieuMuon.SelectedRows[0].Cells["MaPhieu"].Value.ToString();
            if (maPhieustr.StartsWith("MP"))
            {
                maPhieustr = maPhieustr.Substring(2);
            }
            int maPhieu = int.Parse(maPhieustr);

            frmReportHoaDonPhat frm = new frmReportHoaDonPhat(maPhieu, TinhTienPhat(maPhieu));
            frm.Owner = this;
            frm.ShowDialog();
        }

        private int TinhTienPhat(int maPhieu)
        {
            QLTVEntities db = new QLTVEntities();

            var phieuMuon = db.PhieuMuons.FirstOrDefault(p => p.MaPhieu == maPhieu);
            if (phieuMuon == null || !phieuMuon.HanTra.HasValue)
                return 0;

            DateTime hanTra = phieuMuon.HanTra.Value.Date;
            DateTime ngayTra = phieuMuon.DaTra == true && phieuMuon.NgayTra.HasValue
                                ? phieuMuon.NgayTra.Value.Date
                                : DateTime.Today;

            int soNgayTre = (ngayTra - hanTra).Days;

            if (soNgayTre <= 0)
            {
                SoNgayTre = 0;
                return 0;
            }
            SoNgayTre = soNgayTre;

            int tienPhat = 1000 * phieuMuon.TongSLMuon.GetValueOrDefault(); // Mỗi quyển trễ là 1000

            if (soNgayTre >= 30)
            {
                var docGia = db.DocGias.FirstOrDefault(dg => dg.MaDocGia == phieuMuon.MaDG);
                if (docGia != null)
                {
                    if (docGia.BiKhoa == false)
                    {
                        docGia.BiKhoa = true;
                        db.SaveChanges();
                        MessageBox.Show($"Độc giả đã bị cấm mượn vì có phiếu mượn trễ hạn quá 30 ngày!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }

            // Tính tiền phạt lũy tiến
            int ngay7dau = Math.Min(soNgayTre, 7);
            int ngay8_14 = Math.Min(Math.Max(soNgayTre - 7, 0), 7);
            int ngay15_29 = Math.Min(Math.Max(soNgayTre - 14, 0), 15);

            tienPhat += ngay7dau * 2000;    // 1 → 7 ngày  2.000 VNĐ/ngày
            tienPhat += ngay8_14 * 5000;    // 8 → 14 ngày 5.000 VNĐ/ngày
            tienPhat += ngay15_29 * 10000; // 15 → 29 ngày 10.000 VNĐ/ngày
          

            return tienPhat;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGiaHan_Click(object sender, EventArgs e)
        {
            if (dgvPhieuMuon.Rows.Count == 0) return;
            if (dgvPhieuMuon.CurrentRow == null) return;
            DataGridViewRow row = dgvPhieuMuon.CurrentRow;
            giaHan = false;
            int maPhieu = int.Parse(row.Cells["MaPhieu"].Value.ToString().Substring(2));

            QLTVEntities db = new QLTVEntities();
            PhieuMuon phieuMuon = db.PhieuMuons.Where(p => p.MaPhieu == maPhieu).FirstOrDefault();

            if (phieuMuon.DaTra == true)
            {
                MessageBox.Show("Phiếu mượn đã được trả!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }

            frmGiaHan frm = new frmGiaHan(maPhieu);
            frm.ShowDialog();
            if (giaHan) btnLamMoi.PerformClick();
            loadPhieuMuon();
        }
    }
}
