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
    public partial class frmQuanLyPhieuMuon : Form
    {
        private int maNV;
        public static bool giaHan = false;
        private Form frmMainUser;
        public frmQuanLyPhieuMuon()
        {
            InitializeComponent();
        }
        public frmQuanLyPhieuMuon(int _maNV, Form frmMainUser)
        {
            InitializeComponent();
            maNV = _maNV;
            this.frmMainUser = frmMainUser;
        }

        private void frmQuanLyPhieuMuon_Load(object sender, EventArgs e)
        {
            loadPhieuMuon();
            rdbAll.Checked = true;
            btnHoaDonPhat.Show();
            btnTraSach.Show();
            btnGiaHan.Show();
            btnMuonMoi.Show();
            
        }

        /* Trạng thái phiếu
            0: đăng ký mượn
            1: đang mượn/quá hạn
            2: đã trả
         */

        private void optionPhieuMuon(List<PhieuMuon> phieuMuons)
        {
            //btnHoaDonPhat.Show();
            //btnTraSach.Show();
            //btnGiaHan.Show();
            ////btnMuonMoi.Hide();
            //btnHuyPhieu.Hide();
            ////btnChoMuon.Hide();

            //lbTienPhat1.Show();
            //lbTienPhat2.Show();


            dgvPhieuMuon.DataSource = phieuMuons.Where(p => p.DaTra == false)
            .OrderByDescending(p => p.MaPhieu)
            .Select(p => new
            {
                MaPhieu = "MP" + p.MaPhieu,
                HoTenDG = p.DocGia.HoTen,
                HoTenNV = (p.MaNV == null) ? "" : p.NhanVien.HoTen,
                p.NgayMuon,
                p.HanTra,
                DaTra = (p.DaTra == true) ? "Đã trả" : "Chưa trả",
                NgayTra = (p.DaTra == true) ? p.NgayTra : null
            }).ToList();

            //dgvChiTietPM.Columns["MaPhieu"].HeaderText = "Mã phiếu";
            //dgvChiTietPM.Columns["IDBanDoc"].HeaderText = "Mã bạn đọc";
            //dgvChiTietPM.Columns["TenBanDoc"].HeaderText = "Tên bạn đọc";
            //dgvChiTietPM.Columns["NgayMuon"].HeaderText = "Ngày mượn";
            //dgvChiTietPM.Columns["HanTra"].HeaderText = "Hạn trả";
            //dgvChiTietPM.Columns["NgayMuon"].DefaultCellStyle.Format = "dd/MM/yyyy";
            //dgvChiTietPM.Columns["HanTra"].DefaultCellStyle.Format = "dd/MM/yyyy";

            //if (dgvChiTietPM.Rows.Count > 0)
            //{
            //    DateTime hanTra = (DateTime)dgvChiTietPM.Rows[0].Cells["HanTra"].Value;
            //    int soNgay = (DateTime.Now.Date - hanTra.Date).Days;
            //    if (soNgay > 0) lbTienPhat2.Text = soNgay.ToString() + "000 VNĐ";
            //}
            //else lbTienPhat2.Text = "0 VNĐ";
        }
        private void optionPhieuTre(List<PhieuMuon> phieuMuons)
        {
            //btnHoaDonPhat.Show();
            //btnTraSach.Show();
            //btnGiaHan.Show();
            ////btnMuonMoi.Hide();
            //btnHuyPhieu.Hide();
            ////btnChoMuon.Hide();

            //lbTienPhat1.Show();
            //lbTienPhat2.Show();


            dgvPhieuMuon.DataSource = phieuMuons
            .Where(p =>
                p.HanTra.HasValue &&
                ((p.NgayTra == null && p.HanTra.Value.Date < DateTime.Now.Date) || (p.NgayTra != null && p.HanTra.Value.Date < p.NgayTra.Value.Date))
            )
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
            //btnHoaDonPhat.Hide();
            //btnTraSach.Hide();
            //btnGiaHan.Hide();
            ////btnMuonMoi.Hide();
            //btnHuyPhieu.Hide();
            ////btnChoMuon.Hide();

            //lbTienPhat1.Hide();
            //lbTienPhat2.Hide();


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
                DaTra = (p.DaTra == true) ? "Đã trả" : "Chưa trả",
                NgayTra = (p.DaTra == true) ? p.NgayTra : null
            }).ToList();
        }
        public void loadPhieuMuon()
        {
            QLTVEntities db = new QLTVEntities();
            dgvPhieuMuon.DataSource = db.PhieuMuons
                .OrderByDescending(p => p.MaPhieu)
                .Select(p => new {
                MaPhieu = "MP" + p.MaPhieu,
                HoTenDG = p.DocGia.HoTen,
                HoTenNV = p.NhanVien.HoTen,
                p.NgayMuon,
                p.HanTra,
                DaTra = (
                    (p.NgayTra == null && p.HanTra.HasValue && DbFunctions.TruncateTime(p.HanTra) < DbFunctions.TruncateTime(DateTime.Now)) ||
                    (p.NgayTra != null && p.HanTra.HasValue && DbFunctions.TruncateTime(p.HanTra) < DbFunctions.TruncateTime(p.NgayTra))
                ) ? "Trễ hạn" :  (p.DaTra == true ? "Đã trả" : "Chưa trả"),
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
            if (e.RowIndex >= 0)
            {
                string maPhieuStr = dgvPhieuMuon.Rows[e.RowIndex].Cells["MaPhieu"].Value.ToString();
                if (maPhieuStr.StartsWith("MP"))
                {
                    string soMaPhieu = maPhieuStr.Substring(2);
                    if (int.TryParse(soMaPhieu, out int maPhieu)) loadChiTietPM(maPhieu);
                }
            }
            //if (e.RowIndex == -1) return;

            //QLTVEntities db = new QLTVEntities();
            //int maPhieu = int.Parse(dgvChiTietPM.Rows[e.RowIndex].Cells["MaPhieu"].Value.ToString());

            //dgvPhieuMuon.DataSource = db.ChiTietPhieuMuons.Where(p => p.MaPhieu == maPhieu)
            //    .Select(p => new {
            //        MaPhieu = maPhieu,
            //        MaSach = "S" + p.IDSach,
            //        p.Sach.TenSach,
            //        p.SoLuong,
            //        p.PhieuMuon.IDBanDoc,
            //        p.PhieuMuon.HanTra
            //    }).ToList();

            //if (radioPhieuMuon.Checked)
            //{
            //    DateTime hanTra = (DateTime)dgvChiTietPM.Rows[e.RowIndex].Cells["HanTra"].Value;
            //    int soNgay = (DateTime.Now.Date - hanTra.Date).Days;
            //    if (soNgay > 0) lbTienPhat2.Text = soNgay.ToString() + "000 VNĐ";
            //    else lbTienPhat2.Text = "0 VNĐ";
            //}
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
            //btnHoaDonPhat.Hide();
            //btnTraSach.Hide();
            //btnGiaHan.Hide();
            ////btnMuonMoi.Hide();
            ////btnChoMuon.Hide();

            //lbTienPhat1.Hide();
            //lbTienPhat2.Hide();
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
            //dgvPhieuMuon.Columns["NgayMuon"].DefaultCellStyle.Format = "dd/MM/yyyy";
            //dgvPhieuMuon.Columns["HanTra"].DefaultCellStyle.Format = "dd/MM/yyyy";
            //dgvPhieuMuon.Columns["NgayTra"].DefaultCellStyle.Format = "dd/MM/yyyy";
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
            //else return;
            //loadPhieuMuon();
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

            //DialogResult result = MessageBox.Show(
            //    "Xác nhận đã thanh toán " + lbTienPhat2.Text + " tiền phạt!", 
            //    "Thông báo!",                  
            //    MessageBoxButtons.YesNo,              
            //    MessageBoxIcon.Question               
            //);

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


            //int IDBanDoc = int.Parse(dgvPhieuMuon.Rows[0].Cells["IDBanDoc"].Value.ToString());

            //NguoiDung nguoiDung = db.NguoiDungs.Where(p => p.ID == IDBanDoc).FirstOrDefault();
            //nguoiDung.SoSachMuon -= tongSach;

            //PhieuMuon phieuMuon = db.PhieuMuons.Where(p=>p.MaPhieu == maPhieu).FirstOrDefault();
            //phieuMuon.TrangThai = 2;
            //phieuMuon.NgayTra = DateTime.Now;

            db.SaveChanges();
            btnLamMoi.PerformClick();

            MessageBox.Show("Trả sách thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            
            DataGridViewRow row = dgvPhieuMuon.CurrentRow;

            int maPhieu = int.Parse(row.Cells["MaPhieu"].Value.ToString().Substring(2));

            QLTVEntities db = new QLTVEntities();
            PhieuMuon phieuMuon = db.PhieuMuons.Where(p => p.MaPhieu == maPhieu).FirstOrDefault();

            DialogResult result = MessageBox.Show(
                "Bạn có muốn hủy phiếu đăng ký mượn sách này không?",
                "Thông báo!",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No) return;

            //QLTVEntities db = new QLTVEntities();
            //int tongSach = 0;
            //foreach (DataGridViewRow row in dgvPhieuMuon.Rows)
            //{
            //    int idSach = int.Parse(row.Cells["MaSach"].Value.ToString().Substring(1));
            //    int soLuong = int.Parse(row.Cells["SoLuong"].Value.ToString());
            //    tongSach += soLuong;
            //    Sach sach = db.Saches.Where(p => p.ID == idSach).FirstOrDefault();
            //    sach.SoSachMuon -= soLuong;
            //}

            //int maPhieu = int.Parse(dgvPhieuMuon.Rows[0].Cells["MaPhieu2"].Value.ToString());
            //int IDBanDoc = int.Parse(dgvPhieuMuon.Rows[0].Cells["IDBanDoc"].Value.ToString());

            //NguoiDung nguoiDung = db.NguoiDungs.Where(p => p.ID == IDBanDoc).FirstOrDefault();
            //nguoiDung.SoSachMuon -= tongSach;

            //List<ChiTietPhieuMuon> chiTietPhieuMuons = db.ChiTietPhieuMuons.Where(p => p.MaPhieu == maPhieu).ToList();
            //db.ChiTietPhieuMuons.RemoveRange(chiTietPhieuMuons);

            //PhieuMuon phieuMuon = db.PhieuMuons.Where(p => p.MaPhieu == maPhieu).FirstOrDefault();
            //db.PhieuMuons.Remove(phieuMuon);

            //db.SaveChanges();
            btnLamMoi.PerformClick();

            MessageBox.Show("Hủy phiếu đăng ký thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnMuonMoi_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
                form.Close();
            frmMuonTaiLieu frm = new frmMuonTaiLieu(maNV);
            frm.MdiParent = frmMainUser;
            frm.Show();
        }

        private void btnHoaDonPhat_Click(object sender, EventArgs e)
        {
            if (dgvPhieuMuon.Rows.Count == 0) return;
            if (dgvPhieuMuon.CurrentRow == null) return;
            DataGridViewRow row = dgvPhieuMuon.CurrentRow;
            
            int maPhieu = int.Parse(row.Cells["MaPhieu"].Value.ToString().Substring(2));


            //DateTime hanTra = (DateTime)dgvPhieuMuon.Rows[0].Cells["HanTra"].Value;
            //int soNgay = (DateTime.Now.Date - hanTra.Date).Days;
            //int id = int.Parse(dgvPhieuMuon.Rows[0].Cells["HoTenDG"].Value.ToString());
            //string strHanTra = hanTra.ToString("dd/MM/yyyy");

            //if (soNgay <= 0) soNgay = 0;

            frmReportPrintPhieuMuon frm = new frmReportPrintPhieuMuon(maPhieu);
            frm.Owner = this;
            frm.ShowDialog();
        }
    }
}
