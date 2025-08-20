using Microsoft.Reporting.WinForms;
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
    public partial class frmReportHoaDonPhat : Form
    {
        private List<Tuple<int, string>> dsCombo = new List<Tuple<int, string>>(frmQuanLyPhieuMuonTreHan.dsLyDo);
        private int soNgay, soTien, maPhieu;
        private string lyDo, hanTra, NguoiBiPhat, NguoiIn, Email;

        public frmReportHoaDonPhat()
        {
            InitializeComponent();
            loadFRM();
        }

        public frmReportHoaDonPhat(string _lyDo, int _maPhieu, int _soTien)
        {
            maPhieu = _maPhieu;
            soTien = _soTien;
            lyDo = _lyDo;
            InitializeComponent();
            loadFRM();
        }

        private void loadFRM()
        {
            // Lấy thông tin cài đặt trang từ RDLC
            var pageSettings = reportViewer1.LocalReport.GetDefaultPageSettings();

            // Lấy kích thước giấy (PaperSize) theo inch
            float widthInch = pageSettings.PaperSize.Width / 100.0f;
            float heightInch = pageSettings.PaperSize.Height / 100.0f;

            // Chuyển đổi từ inch sang pixel (1 inch = 96 px)
            int widthPx = (int)(widthInch * 96);
            int heightPx = (int)(heightInch * 96);

            // Cộng thêm khoảng padding cho vừa khung
            int padding = 50;

            // Cập nhật kích thước form
            this.Width = widthPx + padding;
            this.Height = heightPx + padding;

            // Cập nhật kích thước reportViewer
            reportViewer1.Width = this.ClientSize.Width;
            reportViewer1.Height = this.ClientSize.Height;

            // Đặt chế độ zoom
            reportViewer1.ZoomMode = ZoomMode.FullPage;
        }

        private void frmReportHoaDonPhat_Load(object sender, EventArgs e)
        {
            QLTVEntities db = new QLTVEntities();
            PhieuMuon phieuMuon = db.PhieuMuons.Where(p => p.MaPhieu == maPhieu).FirstOrDefault();


            Email = phieuMuon.DocGia.Email;
            NguoiBiPhat = phieuMuon.DocGia.HoTen;
            NguoiIn = phieuMuon.NhanVien.HoTen;
            hanTra = phieuMuon.HanTra.Value.ToString("dd/MM/yyyy");

            DateTime hanTras = phieuMuon.HanTra.Value.Date;
            DateTime ngayTras = phieuMuon.DaTra == true && phieuMuon.NgayTra.HasValue
                                ? phieuMuon.NgayTra.Value.Date
                                : DateTime.Today;

            soNgay = (ngayTras - hanTras).Days >= 0 ? (ngayTras - hanTras).Days : 0;

            ReportParameter[] para = new ReportParameter[7];
            para[0] = new ReportParameter("NguoiIn", NguoiIn);
            para[1] = new ReportParameter("NguoiBiPhat", NguoiBiPhat);
            para[2] = new ReportParameter("HanTra", hanTra);
            para[3] = new ReportParameter("Email", Email);
            para[4] = new ReportParameter("SoNgay", soNgay.ToString());
            para[5] = new ReportParameter("SoTien", soTien.ToString());
            para[6] = new ReportParameter("MaPhieu", "MP" + maPhieu.ToString());

            reportViewer1.LocalReport.SetParameters(para);
            this.reportViewer1.RefreshReport();

            List<ChiTietPhieuMuon> ctPM = db.ChiTietPhieuMuons.Where(p => p.MaPM == maPhieu).ToList();

            DataTable dt = new DataTable();
            dt.TableName = "ChiTietPhieuMuon";
            dt.Columns.Add("MaPM", typeof(string));
            dt.Columns.Add("MaTL", typeof(string));
            dt.Columns.Add("SoLuong", typeof(int));
            dt.Columns.Add("MaLyDo", typeof(string));

            foreach (var item in ctPM)
            {
                var lyDo = dsCombo.FirstOrDefault(x => x.Item1 == item.MaLyDo);
                string lyDoText = lyDo != null ? lyDo.Item2 : "Không có";
                dt.Rows.Add(item.MaPM, item.TaiLieu.TenTaiLieu, item.SoLuong, lyDoText);
            }
            ReportDataSource rds = new ReportDataSource("DataSet1", dt);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));
            reportViewer1.RefreshReport();
        }
    }
}
