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
        public static List<Tuple<int, string>> dsLyDo = new List<Tuple<int, string>>();
        private int maCT;
        private int maLD;
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
            cbLydo.SelectedIndex = -1;
            cbLydo.Enabled = false;
            for (int i = 0; i < cbLydo.Items.Count; i++)
            {
                dsLyDo.Add(Tuple.Create(i, cbLydo.Items[i].ToString()));
            }
            loadPhieuMuon();
        }

        public void loadPhieuMuon()
        {
            QLTVEntities db = new QLTVEntities();

            var danhSachPhieuMuon = db.PhieuMuons
                .Include(p => p.DocGia)
                .Include(p => p.NhanVien)
                .OrderByDescending(p => p.MaPhieu)
                .ToList();

            dgvPhieuMuon.DataSource = danhSachPhieuMuon
            .Where(p => p.NgayMuon != null && p.MaNV != null && p.HanTra != null)
            .Select(p => new
            {
                MaPhieu = "MP" + p.MaPhieu,
                HoTenDG = p.DocGia != null ? p.DocGia.HoTen : string.Empty,
                HoTenNV = p.NhanVien != null ? p.NhanVien.HoTen : string.Empty,
                p.NgayMuon,
                p.HanTra,
                DaTra = (
                     p.DaTra == true ? "Đã trả" :
                    (p.NgayTra == null && p.HanTra.HasValue && p.HanTra.Value.Date < DateTime.Now.Date) ? "Trễ hạn" : "Chưa trả"
                ),
                NgayTra = (p.DaTra == true) ? p.NgayTra : null
            }).ToList();

            btnHuyLD.Visible = false;
            btnLuuLD.Visible = false;
            AddButtonHLDToCTPM();
        }
        private void AddButtonHLDToCTPM()
        {
            // Tránh thêm nhiều lần
            if (!dgvChiTietPM.Columns.Contains("btnLD"))
            {
                DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn();
                btnColumn.Name = "btnLD";
                btnColumn.HeaderText = "";
                btnColumn.Text = "Sự cố";
                btnColumn.UseColumnTextForButtonValue = true;
                btnColumn.Width = 60;
                dgvChiTietPM.Columns.Add(btnColumn);
            }
            dgvChiTietPM.Columns["btnLD"].Visible = true;
        }
        private void loadChiTietPM(int maPhieu)
        {
            QLTVEntities db = new QLTVEntities();
            var data = db.ChiTietPhieuMuons
                .Where(p => p.MaPM == maPhieu)
                .Select(p => new {
                    p.MaChiTiet,
                    MaPM = p.MaPM.ToString(),
                    MaTaiLieu = "TL" + p.MaTL,
                    p.TaiLieu.TenTaiLieu,
                    p.TaiLieu.DanhMucTaiLieu.TenDanhMuc,
                    p.TaiLieu.TacGia.TenTG,
                    p.TaiLieu.NhaXuatBan.TenNXB,
                    p.SoLuongBD,
                    SoLuong = (p.SoLuong == 0 && p.PhieuMuon.NgayMuon != null) ? "Đã trả" :
                              (p.SoLuong < 0) ? "Đã huỷ" : p.SoLuong.ToString(),
                    p.MaLyDo
                })
                .ToList();
            dgvChiTietPM.DataSource = data;
            
        }

        private void dgvPhieuMuon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cbLydo.SelectedIndex = -1;
            cbLydo.Enabled = false;
            btnLuuLD.Visible = false;
            btnHuyLD.Visible = false;
            if (e.RowIndex < 0) return;
            cbLydo.Text = string.Empty;
            QLTVEntities db = new QLTVEntities();
            string maPhieuStr = dgvPhieuMuon.Rows[e.RowIndex].Cells["MaPhieu"].Value.ToString();

            string daTraValue = dgvPhieuMuon.Rows[e.RowIndex].Cells["DaTra"].Value?.ToString();

            if (daTraValue == "Trễ hạn")
            {
                dgvChiTietPM.Columns["btnLD"].Visible = false;
                cbLydo.SelectedIndex = 1;
                int maPhieus = int.Parse(maPhieuStr.Substring(2));

                var listCT = db.ChiTietPhieuMuons.Where(p => p.MaPM == maPhieus);
                foreach (var t in listCT)
                {
                    t.MaLyDo = 1;
                }
                db.SaveChanges();
            }
            else
            {
                dgvChiTietPM.Columns["btnLD"].Visible = true;
            }

            if (maPhieuStr.StartsWith("MP"))
            {
                maPhieuStr = maPhieuStr.Substring(2);
            }

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
        private void dgvChiTietPM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            maCT = int.Parse(dgvChiTietPM.Rows[e.RowIndex].Cells["MaChiTiet"].Value.ToString());
            if (dgvChiTietPM.Columns[e.ColumnIndex].Name != "btnLD")
            {
                QLTVEntities db = new QLTVEntities();
                ChiTietPhieuMuon ctpm = db.ChiTietPhieuMuons.Where(p => p.MaChiTiet == maCT).FirstOrDefault();
                if (ctpm.MaLyDo != null) cbLydo.SelectedIndex = ctpm.MaLyDo ?? 0;
                else cbLydo.SelectedIndex = 0;
                    return;
            }
            cbLydo.Enabled = true;
            btnHuyLD.Visible = true;
            btnLuuLD.Visible = true;
            int maLyDo = cbLydo.SelectedIndex;
            MessageBox.Show("Vui lòng chọn sự cố!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cbLydo.Focus();
            
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
            string lyDo = cbLydo.Text;
            frmReportHoaDonPhat frm = new frmReportHoaDonPhat(lyDo, maPhieu, TinhTienPhat(maPhieu));
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
        private void ChonLaiPhieu(int maPhieu)
        {
            string maPhieuStr = "MP" + maPhieu.ToString();
            foreach (DataGridViewRow row in dgvPhieuMuon.Rows)
            {
                if (row.Cells["MaPhieu"].Value != null &&
                    row.Cells["MaPhieu"].Value.ToString() == maPhieuStr)
                {
                    row.Selected = true;
                    dgvPhieuMuon.CurrentCell = row.Cells[0]; // Đặt lại focus
                    break;
                }
            }
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
            ChonLaiPhieu(maPhieu);
        }

        private void btnHuyLD_Click(object sender, EventArgs e)
        {
            btnHuyLD.Visible = false;
            btnLuuLD.Visible = false;
            cbLydo.Enabled = false;
            QLTVEntities db = new QLTVEntities();
            ChiTietPhieuMuon ct = db.ChiTietPhieuMuons.Where(p => p.MaChiTiet == maCT).FirstOrDefault();
            cbLydo.SelectedIndex = ct.MaLyDo ?? 0;
        }

        private void btnLuuLD_Click(object sender, EventArgs e)
        {
            maLD = cbLydo.SelectedIndex;
            QLTVEntities db = new QLTVEntities();
            ChiTietPhieuMuon ct = db.ChiTietPhieuMuons.Where(p => p.MaChiTiet == maCT).FirstOrDefault();
            if (ct.PhieuMuon.DaTra == true && maLD == 1)
            {
                MessageBox.Show("Phiếu mượn đã được trả đúng hạn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ct.MaLyDo = maLD;
            db.SaveChanges();
            MessageBox.Show("Đã thêm sự cố thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnHuyLD.Visible = false;
            btnLuuLD.Visible = false;
            cbLydo.Enabled = false;
        }
    }
}
