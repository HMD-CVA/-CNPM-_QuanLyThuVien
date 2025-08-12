using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QuanLyThuVienApp
{
    public partial class frmThongKe : Form
    {
        public frmThongKe()
        {
            InitializeComponent();
        }

        private void frmThongKe_Load(object sender, EventArgs e)
        {
            cbThongKe.SelectedIndex = 0;
            LoadThongKeTL("Tất cả");
            LoadThongKeDG("Tất cả");
            LoadThongKeMT("Tất cả");
        }
        private void cboThongKe_SelectedIndexChanged(object sender, EventArgs e)
        {
            string kieuThongKe = cbThongKe.SelectedItem.ToString();
            LoadThongKeTL(kieuThongKe);
            LoadThongKeDG(kieuThongKe);
            LoadThongKeMT(kieuThongKe);
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {

        }
        private void LoadThongKeTL(string kieuThongKe)
        {
            using (QLTVEntities db = new QLTVEntities())
            {
                var duLieuChiTiet = db.ChiTietPhieuMuons.AsQueryable();
                DateTime homNay = DateTime.Today;

                // Lọc theo tuần hoặc tháng
                if (kieuThongKe == "Tuần")
                {
                    DateTime dauTuan = homNay.AddDays(-(int)homNay.DayOfWeek + 1);
                    DateTime cuoiTuan = dauTuan.AddDays(6);

                    duLieuChiTiet = duLieuChiTiet.Where(ct =>
                        ct.PhieuMuon.NgayMuon.HasValue &&
                        ct.PhieuMuon.NgayMuon.Value >= dauTuan &&
                        ct.PhieuMuon.NgayMuon.Value <= cuoiTuan);
                }
                else if (kieuThongKe == "Tháng")
                {
                    duLieuChiTiet = duLieuChiTiet.Where(ct =>
                        ct.PhieuMuon.NgayMuon.HasValue &&
                        ct.PhieuMuon.NgayMuon.Value.Month == homNay.Month &&
                        ct.PhieuMuon.NgayMuon.Value.Year == homNay.Year);
                }

                // ===== Thống kê bên trái =====
                int tongTaiLieu = db.TaiLieux.Sum(t => (int?)t.SoLuong) ?? 0;
                int taiLieuDangMuon = duLieuChiTiet
                    .Where(ct => ct.PhieuMuon.NgayTra == null && ct.SoLuong != -1)
                    .Sum(ct => (int?)ct.SoLuong) ?? 0;

                int taiLieuCoSan = tongTaiLieu - taiLieuDangMuon;
                int taiLieuQuaHan = duLieuChiTiet
                    .Where(ct => ct.PhieuMuon.NgayTra == null && ct.PhieuMuon.HanTra < homNay)
                    .Sum(ct => (int?)Math.Abs(ct.SoLuong ?? 0 - ct.SoLuongBD ?? 0)) ?? 0;

                lbTongTL.Text += " " + tongTaiLieu.ToString();
                lbTLDangMuon.Text += " " + taiLieuDangMuon.ToString();
                lbTLCoSan.Text += " " + taiLieuCoSan.ToString();
                lbTLQuaHan.Text += " " + taiLieuQuaHan.ToString();

                // ===== Biểu đồ bên phải =====
                var topTaiLieu = duLieuChiTiet
                    .Where(ct => ct.SoLuong != -1)
                    .GroupBy(ct => ct.MaTL)
                    .Select(nhom => new
                    {
                        TenTaiLieu = nhom.FirstOrDefault().TaiLieu.TenTaiLieu,
                        SoLanMuon = nhom.Sum(x => x.SoLuongBD)
                    })
                    .OrderByDescending(x => x.SoLanMuon)
                    .Take(5)
                    .ToList();

                var bieuDoCot = chartTopSach.Series[0];
                bieuDoCot.Points.Clear();
                bieuDoCot.Name = "Tài Liệu";

                foreach (var item in topTaiLieu)
                {
                    bieuDoCot.Points.AddXY(item.TenTaiLieu, item.SoLanMuon);
                }
            }
        }
        private void LoadThongKeDG(string kieuThongKe)
        {
            using (QLTVEntities db = new QLTVEntities())
            {
                DateTime homNay = DateTime.Today;
                var phieuQuery = db.PhieuMuons.AsQueryable();

                // Lọc theo tuần hoặc tháng
                if (kieuThongKe == "Tuần")
                {
                    DateTime dauTuan = homNay.AddDays(-(int)homNay.DayOfWeek + 1); // Thứ 2
                    DateTime cuoiTuan = dauTuan.AddDays(6);

                    phieuQuery = phieuQuery.Where(pm =>
                        pm.NgayMuon.HasValue &&
                        pm.NgayMuon.Value >= dauTuan &&
                        pm.NgayMuon.Value <= cuoiTuan);
                }
                else if (kieuThongKe == "Tháng")
                {
                    phieuQuery = phieuQuery.Where(pm =>
                        pm.NgayMuon.HasValue &&
                        pm.NgayMuon.Value.Month == homNay.Month &&
                        pm.NgayMuon.Value.Year == homNay.Year);
                }

                // Tổng số độc giả
                int tongDG = db.DocGias.Count();

                // Độc giả đang mượn
                int dgDangMuon = phieuQuery
                    .Where(pm => pm.NgayTra == null && pm.TongSLMuon != 0)
                    .Select(pm => pm.MaDG)
                    .Distinct()
                    .Count();

                // Độc giả vi phạm quá hạn
                int dgViPham = phieuQuery
                    .Where(pm => pm.NgayTra == null && pm.HanTra < homNay)
                    .Select(pm => pm.MaDG)
                    .Distinct()
                    .Count();

                // Gán giá trị vào Label
                lbTongDG.Text += " " + tongDG.ToString();
                lbDGDangMuon.Text += " " + dgDangMuon.ToString();
                lbDGViPham.Text += " " + dgViPham.ToString();

                // Biểu đồ tròn
                var bieuDo = chartDocGia.Series[0];
                bieuDo.Points.Clear();
                bieuDo.Points.AddXY("Vi phạm", dgViPham);
                bieuDo.Points.AddXY("Không vi phạm", tongDG - dgViPham);
            }
        }
        private void LoadThongKeMT(string kieuThongKe)
        {
            using (QLTVEntities db = new QLTVEntities())
            {
                DateTime homNay = DateTime.Today;
                DateTime fromDate = DateTime.MinValue;
                DateTime toDate = homNay;

                if (kieuThongKe == "Tuần")
                {
                    fromDate = homNay.AddDays(-(int)homNay.DayOfWeek + 1);
                    toDate = fromDate.AddDays(6);
                }
                else if (kieuThongKe == "Tháng")
                {
                    fromDate = new DateTime(homNay.Year, homNay.Month, 1);
                    toDate = fromDate.AddMonths(1).AddDays(-1);
                }

                // Lấy dữ liệu phiếu mượn
                var duLieuPhieuMuon = db.PhieuMuons
                    .Where(pm => pm.NgayMuon.HasValue &&
                                 pm.NgayMuon.Value >= fromDate &&
                                 pm.NgayMuon.Value <= toDate)
                    .ToList(); // Chuyển sang memory để xử lý

                // Thống kê
                int tongLuotMuon = duLieuPhieuMuon.Count;
                int tongLuotTra = duLieuPhieuMuon.Count(pm => pm.NgayTra != null);
                int traDungHan = duLieuPhieuMuon.Count(pm => pm.NgayTra != null && pm.NgayTra <= pm.HanTra);
                int traTreHan = duLieuPhieuMuon.Count(pm => pm.NgayTra != null && pm.NgayTra > pm.HanTra);

                // Cập nhật label
                lbTongLuotMuon.Text = "Tổng lượt mượn: " + tongLuotMuon;
                lbTongLuotTra.Text = "Tổng lượt trả: " + tongLuotTra;
                lbTraDungHan.Text = "Trả đúng hạn: " + traDungHan;
                lbTraTreHan.Text = "Trả trễ hạn: " + traTreHan;

                // Biểu đồ đường (số lượt mượn theo ngày)
                var thongKeNgayMuon = duLieuPhieuMuon
                .GroupBy(pm => pm.NgayMuon.Value.Date)
                .Select(g => new
                {
                    Ngay = g.Key,
                    SoLuot = g.Count()
                })
                .OrderBy(x => x.Ngay)
                .ToList();

                var bieuDoDuong = chartMuonTra.Series[0];
                bieuDoDuong.Points.Clear();

                foreach (var item in thongKeNgayMuon)
                {
                    bieuDoDuong.Points.AddXY(item.Ngay.ToString("dd/MM"), item.SoLuot);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void lbDGDangMuon_Click(object sender, EventArgs e)
        {

        }
    }
}