using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Runtime.Caching;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVienApp
{
    public partial class frmQuanLyPhieuMuon : Form
    {
        private int maNV;
        private int? maDG;
        public static bool giaHan = false;
        private Form frmMainUser;
        public frmQuanLyPhieuMuon()
        {
            InitializeComponent();
            loadPhieuMuon();
            loadChiTietPM(0);
        }
        public frmQuanLyPhieuMuon(int _maNV, Form frmMainUser)
        {
            InitializeComponent();
            maNV = _maNV;
            this.frmMainUser = frmMainUser;
        }

        private void frmQuanLyPhieuMuon_Load(object sender, EventArgs e)
        {
            LibraryHelper.KiemTraVaKhoaTaiKhoan();
            loadPhieuMuon();
            loadChiTietPM(0);
            OffButton();
            rdbAll.Checked = true; 
            lab_Huy.ForeColor = Color.Red;
        }
        private void OffButton()
        {
            btnInPM.Enabled = false;
            btnTraSach.Enabled = false;
            btnGiaHan.Enabled = false;
            btnChoMuon.Enabled = false;
            btnTTDG.Enabled = false;
        }
        private void OnButton()
        {
            btnInPM.Enabled = true;
            btnTraSach.Enabled = true;
            btnGiaHan.Enabled = true;
            btnChoMuon.Enabled = true;
            btnTTDG.Enabled = true;
        }
        private void optionPhieuMuon(List<PhieuMuon> phieuMuons)
        {
            dgvPhieuMuon.DataSource = phieuMuons
            .Where(p => p.DaTra == false && p.HanTra.Value.Date >= DateTime.Now.Date)
            .OrderByDescending(p => p.MaPhieu)
            .Select(p => new
            {
                MaPhieu = "MP" + p.MaPhieu,
                HoTenDG = p.DocGia.HoTen,
                HoTenNV = (p.MaNV == null) ? "" : p.NhanVien.HoTen,
                p.NgayMuon,
                p.HanTra,
                DaTra = "Chưa trả",
                NgayTra = (DateTime?)null
            }).ToList();
        }
        private void optionPhieuTre(List<PhieuMuon> phieuMuons)
        {
            dgvPhieuMuon.DataSource = phieuMuons
            .Where(p => p.DaTra == false && (p.NgayTra == null && p.HanTra.Value.Date < DateTime.Now.Date))
            .OrderByDescending(p => p.MaPhieu)
            .Select(p => new
            {
                MaPhieu = "MP" + p.MaPhieu,
                HoTenDG = p.DocGia.HoTen,
                HoTenNV = (p.MaNV == null) ? "" : p.NhanVien.HoTen,
                p.NgayMuon,
                p.HanTra,
                DaTra = "Trễ hạn",
                NgayTra = (DateTime?)null
            })
            .ToList();
        }
        private void optionPhieuTra(List<PhieuMuon> phieuMuons)
        {
            dgvPhieuMuon.DataSource = phieuMuons
            .Where(p => p.DaTra == true)
            .OrderByDescending(p => p.MaPhieu)
            .Select(p => new
            {
                MaPhieu = "MP" + p.MaPhieu,
                HoTenDG = p.DocGia.HoTen,
                HoTenNV = (p.MaNV == null) ? "" : p.NhanVien.HoTen, 
                p.NgayMuon,
                p.HanTra,
                DaTra =  "Đã trả",
                p.NgayTra 
            }).ToList();
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

        public void loadPhieuMuon()
        {
            QLTVEntities db = new QLTVEntities();

            var danhSachPhieuMuon = db.PhieuMuons
                .Include(p => p.DocGia)
                .Include(p => p.NhanVien)
                .OrderByDescending(p => p.MaPhieu)
                .ToList();

            dgvPhieuMuon.DataSource = danhSachPhieuMuon.Select(p => new
            {
                MaPhieu = "MP" + p.MaPhieu,
                HoTenDG = p.DocGia != null ? p.DocGia.HoTen : string.Empty,
                HoTenNV = p.NhanVien != null ? p.NhanVien.HoTen : string.Empty,
                p.NgayMuon,
                p.HanTra,
                DaTra = (
                    (p.NgayMuon == null && (DateTime.Now - p.NgayTao).TotalMinutes > 15) ? "Đã huỷ" :
                     p.NgayMuon == null ? "Chờ duyệt" :
                     p.DaTra == true ? "Đã trả" :
                    (p.NgayTra == null && p.HanTra.HasValue && p.HanTra.Value.Date < DateTime.Now.Date) ? "Trễ hạn":  "Chưa trả"
                ),
                NgayTra = (p.DaTra == true) ? p.NgayTra : null
            }).ToList();
        }
        private void AddButtonTraToCTPM()
        {
            // Tránh thêm nhiều lần
            if (!dgvChiTietPM.Columns.Contains("btnTra"))
            {
                DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn();
                btnColumn.Name = "btnTra";
                btnColumn.HeaderText = "";
                btnColumn.Text = "Trả";
                btnColumn.UseColumnTextForButtonValue = true;
                btnColumn.Width = 60;
                dgvChiTietPM.Columns.Add(btnColumn);
            }
        }

        private void loadChiTietPM(int maPhieu)
        {
            QLTVEntities db = new QLTVEntities();
            dgvChiTietPM.DataSource = db.ChiTietPhieuMuons.Where(p => p.MaPM == maPhieu).Select(p => new {
                p.MaChiTiet,
                MaPM = p.MaPM.ToString(),
                MaTaiLieu = "TL" + p.MaTL,
                p.TaiLieu.TenTaiLieu,
                p.TaiLieu.DanhMucTaiLieu.TenDanhMuc,
                p.TaiLieu.TacGia.TenTG,
                p.TaiLieu.NhaXuatBan.TenNXB,
                SoLuong = (p.SoLuong == 0) ? "Đã trả" : p.SoLuong.ToString() 
            }).ToList();
            AddButtonTraToCTPM();
        }
        private void dgvPhieuMuon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lab_Huy.Text = string.Empty;
            OffButton();
            btnTTDG.Enabled = true;
            if (e.RowIndex < 0) return;
          
            string maPhieuStr = dgvPhieuMuon.Rows[e.RowIndex].Cells["MaPhieu"].Value.ToString();
            if (maPhieuStr.StartsWith("MP"))
            {
                string soMaPhieu = maPhieuStr.Substring(2);

                QLTVEntities db = new QLTVEntities();
                maDG = db.PhieuMuons.Where(p => p.MaPhieu.ToString() == soMaPhieu).Select(p => (int?)p.MaDG).FirstOrDefault();


                int.TryParse(soMaPhieu, out int maPhieuGhiNho);

                if (int.TryParse(soMaPhieu, out int maPhieu)) loadChiTietPM(maPhieu);

                string daTra = dgvPhieuMuon.Rows[e.RowIndex].Cells["DaTra"].Value.ToString();

                if (daTra != "Đã huỷ" && daTra != "Chờ duyệt")
                {
                    OnButton();
                    return;
                }

                if (daTra == "Chờ duyệt")
                {
                    btnChoMuon.Enabled = true;
                    if (daTra == "Đã huỷ")
                    {
                        lab_Huy.Text = "Phiếu mượn này đã bị huỷ!";
                        loadPhieuMuon();
                        ChonLaiPhieu(maPhieuGhiNho);
                        return;
                    }
                    return;
                }
                if (dgvPhieuMuon.Rows[e.RowIndex].Cells["NgayMuon"].Value == null && daTra != "Đã huỷ")
                {
                    btnChoMuon.Show();
                    btnChoMuon.Enabled = true;
                }
                else
                {
                    btnChoMuon.Enabled = false;

                    if (daTra == "Đã huỷ")
                    {
                        lab_Huy.Text = "Phiếu mượn này đã bị huỷ!";
                        loadPhieuMuon();
                        ChonLaiPhieu(maPhieuGhiNho);
                        return;
                    }
                }
            }
        }
        private void radioPhieuMuon_CheckedChanged(object sender, EventArgs e)
        {
            loadChiTietPM(0);
            QLTVEntities db = new QLTVEntities();
            optionPhieuMuon(db.PhieuMuons.ToList());
            
        }
        private void radioPhieuTra_CheckedChanged(object sender, EventArgs e)
        {
            loadChiTietPM(0);
            QLTVEntities db = new QLTVEntities();
            optionPhieuTra(db.PhieuMuons.ToList());
        }
        private void rdbAll_CheckedChanged(object sender, EventArgs e)
        {
            loadChiTietPM(0);
            loadPhieuMuon();
        }
        private void rdbTreHan_CheckedChanged(object sender, EventArgs e)
        {
            loadChiTietPM(0);
            QLTVEntities db = new QLTVEntities();
            optionPhieuTre(db.PhieuMuons.ToList());
        }
        private void dgvPhieuMuon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if (e.RowIndex < 0 || e.ColumnIndex < 0 || e.ColumnIndex >= dgvPhieuMuon.Columns.Count)
            //    return;

            //var colName = dgvPhieuMuon.Columns[e.ColumnIndex].Name;

            //if (colName == "DaTra" && dgvPhieuMuon.Columns.Contains("DaTra"))
            //{
            //    var cellValue = dgvPhieuMuon.Rows[e.RowIndex].Cells["DaTra"].Value?.ToString();

            //    if (cellValue == "Trễ hạn")
            //    {
            //        dgvPhieuMuon.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
            //    }
            //}
        }
        private void dgvChiTietPM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || dgvChiTietPM.Columns[e.ColumnIndex].Name != "btnTra") return;
            int soLuong = dgvChiTietPM.Rows[e.RowIndex].Cells["SoLuong"].Value.ToString() == "Đã trả" ? 0 : int.Parse(dgvChiTietPM.Rows[e.RowIndex].Cells["SoLuong"].Value.ToString());
            int maPhieu = int.Parse(dgvChiTietPM.Rows[e.RowIndex].Cells["MaPM"].Value.ToString());
            int maTL = int.Parse(dgvChiTietPM.Rows[e.RowIndex].Cells["MaTaiLieu"].Value.ToString().Substring(2));
            int maCT = int.Parse(dgvChiTietPM.Rows[e.RowIndex].Cells["MaChiTiet"].Value.ToString());
            

            if (soLuong <= 0)
            {
                MessageBox.Show("Đã trả hết tài liệu này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //string maSachFull = txtMaTaiLieu.Text;
            //int maSach = int.Parse(maSachFull.Substring(2));

            //int soLuongHienTai = int.Parse(txtDaDK.Text.ToString());
            
            int soLuongXoa = 1;

            if (soLuong > 1)
            {
                using (var nhapSoLuongForm = new frmNhapSLMuonXoa(soLuong, false)) // false = chế độ xóa
                {
                    if (nhapSoLuongForm.ShowDialog() == DialogResult.OK)
                    {
                        soLuongXoa = nhapSoLuongForm.SoLuong;
                    }
                    else return;
                }
            }
            QLTVEntities db = new QLTVEntities();
            
            ChiTietPhieuMuon ctPM = db.ChiTietPhieuMuons.Where(p => p.MaChiTiet == maCT && p.MaPM == maPhieu && p.MaTL == maTL).FirstOrDefault();
            ctPM.SoLuong -= soLuongXoa;
            
            TaiLieu tl = db.TaiLieux.Where(p => p.MaTaiLieu == maTL).FirstOrDefault();
            tl.SoTaiLieuMuon -= soLuongXoa;

            PhieuMuon pm = db.PhieuMuons.Where(p => p.MaPhieu == maPhieu && p.DaTra == false).FirstOrDefault();      
            pm.TongSLMuon -= soLuongXoa;
            if (pm.TongSLMuon <= 0)
            {
                pm.TongSLMuon = 0;
                pm.DaTra = true;
            }

            db.SaveChanges();

            MessageBox.Show("Đã trả thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            loadPhieuMuon();
            ChonLaiPhieu(maPhieu);
            loadChiTietPM(maPhieu);
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
                //MessageBox.Show("Không có phiếu mượn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvPhieuMuon.SelectedRows.Count == 0)
            {
                MessageBox.Show("Hãy chọn 1 phiếu mượn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có xác nhận độc giả này đã trả đủ sách không ?", "Thông báo",
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

            MessageBox.Show("Trả sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadPhieuMuon();
            loadChiTietPM(0);
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
        }

        private void btnHuyPhieu_Click(object sender, EventArgs e)
        {
            if (dgvPhieuMuon.Rows.Count == 0) return;
            if (dgvPhieuMuon.CurrentRow == null) return;

            DialogResult result = MessageBox.Show(
                "Bạn có muốn hủy phiếu đăng ký mượn sách này không?",
                "Thông báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No) return;

            DataGridViewRow row = dgvPhieuMuon.CurrentRow;

            int maPhieu = int.Parse(row.Cells["MaPhieu"].Value.ToString().Substring(2));

            QLTVEntities db = new QLTVEntities();
            PhieuMuon phieuMuon = db.PhieuMuons.Where(p => p.MaPhieu == maPhieu).FirstOrDefault();
            phieuMuon.NgayMuon = null;
            phieuMuon.NgayTao = DateTime.Now.AddDays(-1);

            int tongTL = 0;
            foreach (DataGridViewRow Irow in dgvChiTietPM.Rows)
            {
                int maTL = int.Parse(Irow.Cells["MaTaiLieu"].Value.ToString().Substring(2));
                int soLuong = int.Parse(Irow.Cells["SoLuong"].Value.ToString());
                tongTL += soLuong;
                TaiLieu TL = db.TaiLieux.Where(p => p.MaTaiLieu == maTL).FirstOrDefault();
                TL.SoTaiLieuMuon -= soLuong;
            }

            db.SaveChanges();
            btnLamMoi.PerformClick();

            MessageBox.Show("Hủy phiếu đăng ký thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadPhieuMuon();
        }

        private void btnMuonMoi_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
                form.Close();
            frmMuonTaiLieu frm = new frmMuonTaiLieu(maNV);
            frm.MdiParent = frmMainUser;

            frm.Dock = DockStyle.Fill;
            frm.FormClosed += (s, args) =>
            {
                loadPhieuMuon(); // Gọi lại hàm load dữ liệu
            };
            frm.Show();
        }

        private void btnINHoaDon_Click(object sender, EventArgs e)
        {
            if (dgvPhieuMuon.Rows.Count == 0) return;
            if (dgvPhieuMuon.CurrentRow == null) return;
            DataGridViewRow row = dgvPhieuMuon.CurrentRow;
            
            int maPhieu = int.Parse(row.Cells["MaPhieu"].Value.ToString().Substring(2));

            frmReportPrintPhieuMuon frm = new frmReportPrintPhieuMuon(maPhieu);
            frm.Owner = this;
            frm.ShowDialog();            
        }

        private void btnChoMuon_Click(object sender, EventArgs e)
        {
            if (dgvPhieuMuon.Rows.Count == 0) return;

            // Lấy dòng đang chọn
            DataGridViewRow selectedRow = dgvPhieuMuon.SelectedRows[0];

            string trangThai = selectedRow.Cells["DaTra"].Value?.ToString();

            if (trangThai == "Đã huỷ")
            {
                btnChoMuon.Enabled = false;
                MessageBox.Show("Phiếu mượn này đã bị huỷ do hết thời gian chờ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                loadPhieuMuon(); // gọi lại để cập nhật
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có muốn xác nhận cho mượn không?",
                "Thông báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No) return;

            int maPhieu = int.Parse(dgvPhieuMuon.SelectedRows[0].Cells["MaPhieu"].Value.ToString().Substring(2));
            QLTVEntities db = new QLTVEntities();
            PhieuMuon phieuMuon = db.PhieuMuons.Where(p => p.MaPhieu == maPhieu).FirstOrDefault();

            phieuMuon.MaNV = maNV;
            phieuMuon.NgayMuon = DateTime.Now;
            phieuMuon.HanTra = DateTime.Now.AddDays(7);

            db.SaveChanges();
            btnLamMoi.PerformClick();

            MessageBox.Show("Cho mượn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnTTDG_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
                form.Close();
            frmThongTinDocGia frm = new frmThongTinDocGia(maDG);
            frm.ShowDialog();
        }

        private void btnXLTreHan_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
                form.Close();
            frmQuanLyPhieuMuonTreHan frm = new frmQuanLyPhieuMuonTreHan();
            frm.MdiParent = frmMainUser;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }
    }
}
