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
    public partial class frmReportPrintPhieuMuon : Form
    {
        private int maPhieu;

        public frmReportPrintPhieuMuon()
        {
            InitializeComponent();
            loadFRM();
        }

        public frmReportPrintPhieuMuon(int _maPhieu)
        {
            InitializeComponent();
            maPhieu = _maPhieu;
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
            if (phieuMuon == null)
            {
                MessageBox.Show("Phiếu mượn không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string trangThai = string.Empty;
            if (phieuMuon.HanTra.HasValue &&
               ((phieuMuon.NgayTra.HasValue && phieuMuon.HanTra.Value.Date < phieuMuon.NgayTra.Value.Date) ||
                (!phieuMuon.NgayTra.HasValue && phieuMuon.HanTra.Value.Date < DateTime.Now.Date)))
            {
                trangThai = "Trễ hạn";
            }
            else if (phieuMuon.DaTra == true)
            {
                trangThai = "Đã trả";
            }
            else
            {
                trangThai = "Chưa trả";
            }

            ReportParameter[] para = new ReportParameter[9];
            para[0] = new ReportParameter("NguoiIn", phieuMuon.NhanVien.HoTen);
            para[1] = new ReportParameter("HoTenDocGia", phieuMuon.DocGia.HoTen);
            para[2] = new ReportParameter("SDT", phieuMuon.DocGia.MaSo.ToString());
            para[3] = new ReportParameter("Email", phieuMuon.DocGia.Email.ToString());
            para[4] = new ReportParameter("NgayMuon", phieuMuon.NgayMuon.Value.ToString("dd/MM/yyyy"));
            para[5] = new ReportParameter("HanTra", phieuMuon.HanTra.Value.ToString("dd/MM/yyyy"));
            para[6] = new ReportParameter("TrangThai", trangThai);
            para[7] = new ReportParameter("MaPhieu", "MP" + phieuMuon.MaPhieu.ToString());
            para[8] = new ReportParameter("NgayTra", phieuMuon.NgayTra.HasValue ? phieuMuon.NgayTra.Value.ToString("dd/MM/yyyy"): "Chưa trả");


            reportViewer1.LocalReport.SetParameters(para);
            this.reportViewer1.RefreshReport();

            List<ChiTietPhieuMuon> ctPM = db.ChiTietPhieuMuons.Where(p => p.MaPM == maPhieu).ToList();

            DataTable dt = new DataTable();
            dt.TableName = "ChiTietPhieuMuon";
            dt.Columns.Add("MaPM", typeof(string));
            dt.Columns.Add("MaTL", typeof(string));
            dt.Columns.Add("SoLuongBD", typeof(int));
            dt.Columns.Add("SoLuong", typeof(string));

            foreach (var item in ctPM)
            {
                dt.Rows.Add(item.MaPM, item.TaiLieu.TenTaiLieu, item.SoLuongBD , item.SoLuong == 0 ? "Đã trả" : item.SoLuong.ToString());
            }
            ReportDataSource rds = new ReportDataSource("DataSet1", dt);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));
            reportViewer1.RefreshReport();
        }
    }
}
