using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public static bool giaHan = false;
        public frmQuanLyPhieuMuon()
        {
            InitializeComponent();
        }

        private void frmQuanLyPhieuMuon_Load(object sender, EventArgs e)
        {
            loadPhieuMuon();
            rdbAll.Checked = true;
        }
        
        /* Trạng thái phiếu
            0: đăng ký mượn
            1: đang mượn/quá hạn
            2: đã trả
         */

        private void optionPhieuMuon(List<PhieuMuon> phieuMuons)
        {
            btnHoaDonPhat.Show();
            btnTraSach.Show();
            btnGiaHan.Show();
            //btnMuonMoi.Hide();
            btnHuyPhieu.Hide();
            btnChoMuon.Hide();

            lbTienPhat1.Show();
            lbTienPhat2.Show();


            dgvPhieuMuon.DataSource = phieuMuons.Where(p => p.DaTra == false)
            .Select(p => new
            {
                MaPhieu = "MP" + p.MaPhieu,
                HoTenDG = p.DocGia.HoTen,
                HoTenNV = p.NhanVien.HoTen,
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
        private void optionPhieuTra(List<PhieuMuon> phieuMuons)
        {
            btnHoaDonPhat.Hide();
            btnTraSach.Hide();
            btnGiaHan.Hide();
            //btnMuonMoi.Hide();
            btnHuyPhieu.Hide();
            btnChoMuon.Hide();

            lbTienPhat1.Hide();
            lbTienPhat2.Hide();


            dgvPhieuMuon.DataSource = phieuMuons.Where(p => p.DaTra == true)
            .Select(p => new
            {
                MaPhieu = "MP" + p.MaPhieu,
                HoTenDG = p.DocGia.HoTen,
                HoTenNV = p.NhanVien.HoTen,
                p.NgayMuon,
                p.HanTra,
                DaTra = (p.DaTra == true) ? "Đã trả" : "Chưa trả",
                NgayTra = (p.DaTra == true) ? p.NgayTra : null
            }).ToList();
        }
        public void loadPhieuMuon()
        {
            QLTVEntities db = new QLTVEntities();
            dgvPhieuMuon.DataSource = db.PhieuMuons.Select(p => new {
                MaPhieu = "MP" + p.MaPhieu,
                HoTenDG = p.DocGia.HoTen,
                HoTenNV = p.NhanVien.HoTen,
                p.NgayMuon,
                p.HanTra,
                DaTra = (p.DaTra == true) ? "Đã trả" : "Chưa trả",
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
            btnHoaDonPhat.Hide();
            btnTraSach.Hide();
            btnGiaHan.Hide();
            //btnMuonMoi.Hide();
            btnHuyPhieu.Hide();
            btnChoMuon.Hide();

            lbTienPhat1.Hide();
            lbTienPhat2.Hide();
            loadChiTietPM(0);
            loadPhieuMuon();
        }
        
        private void dgvPhieuMuon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //dgvPhieuMuon.Columns["NgayMuon"].DefaultCellStyle.Format = "dd/MM/yyyy";
            //dgvPhieuMuon.Columns["HanTra"].DefaultCellStyle.Format = "dd/MM/yyyy";
            //dgvPhieuMuon.Columns["NgayTra"].DefaultCellStyle.Format = "dd/MM/yyyy";
            if (dgvChiTietPM.Columns[e.ColumnIndex].Name == "HanTra")
            {
                DateTime hanTra = (DateTime)dgvChiTietPM.Rows[e.RowIndex].Cells["HanTra"].Value;
                if (DateTime.Now.Date > hanTra.Date)
                    dgvChiTietPM.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            QLTVEntities db = new QLTVEntities();
            List<PhieuMuon> phieuMuon = new List<PhieuMuon>();

            //if (cbTimKiem.Text == "Mã phiếu")
            //{
            //    phieuMuon = db.PhieuMuons.Where(p => p.MaPhieu.ToString().Contains(txtTimKiem.Text)).ToList();
            //    if (radioPhieuDangKy.Checked)
            //        optionPhieuDangKy(phieuMuon);
            //    else if (radioPhieuMuon.Checked)
            //        optionPhieuMuon(phieuMuon);
            //    else optionPhieuTra(phieuMuon);
            //}
            //else if (cbTimKiem.Text == "Mã bạn đọc")
            //{
            //    phieuMuon = db.PhieuMuons.Where(p => ("DB" + p.IDBanDoc.ToString()).Contains(txtTimKiem.Text)).ToList();
            //    if (radioPhieuDangKy.Checked)
            //        optionPhieuDangKy(phieuMuon);
            //    else if (radioPhieuMuon.Checked)
            //        optionPhieuMuon(phieuMuon);
            //    else optionPhieuTra(phieuMuon);
            //}
            //else if (cbTimKiem.Text == "Tên bạn đọc")
            //{
            //    phieuMuon = db.PhieuMuons.Where(p => p.NguoiDung.HoTen.Contains(txtTimKiem.Text)).ToList();
            //    if (radioPhieuDangKy.Checked)
            //        optionPhieuDangKy(phieuMuon);
            //    else if (radioPhieuMuon.Checked)
            //        optionPhieuMuon(phieuMuon);
            //    else optionPhieuTra(phieuMuon);
            //}
            //else return;
            loadPhieuMuon();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            //if (radioPhieuDangKy.Checked)
            //{
            //    radioPhieuDangKy.Checked = false;
            //    radioPhieuDangKy.Checked = true;
            //}
            //else if (radioPhieuMuon.Checked)
            //{
            //    radioPhieuMuon.Checked = false;
            //    radioPhieuMuon.Checked = true;
            //}
            //else {
            //    radioPhieuTra.Checked = false;
            //    radioPhieuTra.Checked = true;
            //}
        }

        private void btnTraSach_Click(object sender, EventArgs e)
        {
            if (dgvPhieuMuon.Rows.Count == 0) return;


            DialogResult result = MessageBox.Show(
                "Xác nhận đã thanh toán " + lbTienPhat2.Text + " tiền phạt!", 
                "Thông báo!",                  
                MessageBoxButtons.YesNo,              
                MessageBoxIcon.Question               
            );

            if (result == DialogResult.No) return;

            QLTVEntities db = new QLTVEntities();
            int tongSach = 0;
            //foreach(DataGridViewRow row in dgvPhieuMuon.Rows)
            //{
            //    int idSach = int.Parse(row.Cells["MaSach"].Value.ToString().Substring(1));
            //    int soLuong = int.Parse(row.Cells["SoLuong"].Value.ToString());
            //    tongSach += soLuong;
            //    Sach sach = db.Saches.Where(p=>p.ID == idSach).FirstOrDefault();
            //    sach.SoSachMuon -= soLuong;
            //}

            //int maPhieu = int.Parse(dgvPhieuMuon.Rows[0].Cells["MaPhieu2"].Value.ToString());
            //int IDBanDoc = int.Parse(dgvPhieuMuon.Rows[0].Cells["IDBanDoc"].Value.ToString());

            //NguoiDung nguoiDung = db.NguoiDungs.Where(p => p.ID == IDBanDoc).FirstOrDefault();
            //nguoiDung.SoSachMuon -= tongSach;

            //PhieuMuon phieuMuon = db.PhieuMuons.Where(p=>p.MaPhieu == maPhieu).FirstOrDefault();
            //phieuMuon.TrangThai = 2;
            //phieuMuon.NgayTra = DateTime.Now;

            //db.SaveChanges();
            //btnLamMoi.PerformClick();

            MessageBox.Show("Trả sách thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGiaHan_Click(object sender, EventArgs e)
        {
            //if (dgvPhieuMuon.Rows.Count == 0) return;

            //giaHan = false;
            //int maPhieu = int.Parse(dgvPhieuMuon.Rows[0].Cells["MaPhieu2"].Value.ToString());
            //frmGiaHan frm = new frmGiaHan(maPhieu);

            //frm.ShowDialog();
            //if (giaHan) btnLamMoi.PerformClick();
        }

        private void btnHuyPhieu_Click(object sender, EventArgs e)
        {
            if (dgvPhieuMuon.Rows.Count == 0) return;

            DialogResult result = MessageBox.Show(
                "Bạn có muốn hủy phiếu đăng ký mượn sách này không?",
                "Thông báo!",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No) return;

            QLTVEntities db = new QLTVEntities();
            int tongSach = 0;
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

        private void btnChoMuon_Click(object sender, EventArgs e)
        {
            if (dgvPhieuMuon.Rows.Count == 0) return;

            DialogResult result = MessageBox.Show(
                "Bạn có muốn xác nhận cho mượn không?",
                "Thông báo!",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No) return;

            int maPhieu = int.Parse(dgvPhieuMuon.Rows[0].Cells["MaPhieu2"].Value.ToString());
            QLTVEntities db = new QLTVEntities();
            PhieuMuon phieuMuon = db.PhieuMuons.Where(p => p.MaPhieu == maPhieu).FirstOrDefault();

            //phieuMuon.TrangThai = 1;
            phieuMuon.NgayMuon = DateTime.Now;
            phieuMuon.HanTra = DateTime.Now.AddDays(14);

            db.SaveChanges();
            btnLamMoi.PerformClick();

            MessageBox.Show("Cho mượn thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnMuonMoi_Click(object sender, EventArgs e)
        {
            frmMuonTaiLieu frm = new frmMuonTaiLieu();
            frm.Owner = this;
            frm.ShowDialog();
        }

        private void btnHoaDonPhat_Click(object sender, EventArgs e)
        {
            if (dgvPhieuMuon.Rows.Count == 0) return;

            DateTime hanTra = (DateTime)dgvPhieuMuon.Rows[0].Cells["HanTra"].Value;
            int soNgay = (DateTime.Now.Date - hanTra.Date).Days;
            int id = int.Parse(dgvPhieuMuon.Rows[0].Cells["IDBanDoc"].Value.ToString());
            string strHanTra = hanTra.ToString("dd/MM/yyyy");

            if (soNgay <= 0) soNgay = 0;

            //frmReportHoaDonPhat frm = new frmReportHoaDonPhat(id, strHanTra, soNgay);
            //frm.Owner = this;
            //frm.ShowDialog();
        }
    }
}
