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
        }

        public frmReportPrintPhieuMuon(int _maPhieu)
        {
            maPhieu = _maPhieu;
            InitializeComponent();
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
            if (phieuMuon.DaTra == true)
            {
                trangThai = "Đã trả";
            }
            else
            {
                if (phieuMuon.HanTra.HasValue && DateTime.Now.Date > phieuMuon.HanTra.Value.Date)
                {
                    trangThai = "Trễ hạn";
                }
                else
                {
                    trangThai = "Chưa trả";
                }
            }

            ReportParameter[] para = new ReportParameter[7];
            para[0] = new ReportParameter("NguoiIn", phieuMuon.NhanVien.HoTen);
            para[1] = new ReportParameter("HoTenDocGia", phieuMuon.DocGia.HoTen);
            para[2] = new ReportParameter("SDT", phieuMuon.DocGia.SDT.ToString());
            para[3] = new ReportParameter("Email", phieuMuon.DocGia.Email.ToString());
            para[4] = new ReportParameter("NgayMuon", phieuMuon.NgayMuon.Value.ToString("dd/MM/yyyy"));
            para[5] = new ReportParameter("HanTra", phieuMuon.HanTra.Value.ToString("dd/MM/yyyy"));
            para[6] = new ReportParameter("TrangThai", trangThai);

            reportViewer1.LocalReport.SetParameters(para);
            this.reportViewer1.RefreshReport();

            List<ChiTietPhieuMuon> ctPM = db.ChiTietPhieuMuons.Where(p => p.MaPM == maPhieu).ToList();

            DataTable dt = new DataTable();
            dt.TableName = "ChiTietPhieuMuon";
            dt.Columns.Add("MaPM", typeof(string));
            dt.Columns.Add("MaTL", typeof(string));
            dt.Columns.Add("SoLuong", typeof(int));

            foreach (var item in ctPM)
            {
                dt.Rows.Add(item.MaPM, item.TaiLieu.TenTaiLieu, item.SoLuong);
            }
            ReportDataSource rds = new ReportDataSource("DataSet1", dt);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));
            reportViewer1.RefreshReport();
        }
    }
}
