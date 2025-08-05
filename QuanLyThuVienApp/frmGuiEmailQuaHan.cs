using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;


namespace QuanLyThuVienApp
{
    public partial class frmGuiEmailQuaHan : Form
    {
        public static int OTP;
        public static DateTime thoiGian;

        public frmGuiEmailQuaHan()
        {
            InitializeComponent();
        }

        private void frmQuanLyBanDoc_Load(object sender, EventArgs e)
        {
            loadDuLieu();
        }

        private void loadDuLieu()
        {
            QLTVEntities db = new QLTVEntities();
            var dsQuaHan = db.PhieuMuons
                .Where(p => p.DaTra == false && p.HanTra.HasValue &&
                       (
                           (p.NgayTra == null && DbFunctions.TruncateTime(p.HanTra) < DbFunctions.TruncateTime(DateTime.Now)) ||
                           (p.NgayTra != null && DbFunctions.TruncateTime(p.HanTra) < DbFunctions.TruncateTime(p.NgayTra))
                       )
                )
                .Select(p => new
                {
                    MaPhieu = "MP" + p.MaPhieu,
                    TenDocGia = p.DocGia.HoTen,
                    EmailDG = p.DocGia.Email,
                    HanTra = p.HanTra.Value
                }).ToList();

            dgvQuaHan.DataSource = dsQuaHan;

            // Thêm nút "Gửi Mail" nếu chưa có
            if (!dgvQuaHan.Columns.Contains("btnGuiMail"))
            {
                DataGridViewButtonColumn btnGui = new DataGridViewButtonColumn();
                btnGui.Name = "btnGuiMail";
                btnGui.HeaderText = "";
                btnGui.Text = "Gửi Mail";
                btnGui.UseColumnTextForButtonValue = true;
                dgvQuaHan.Columns.Add(btnGui);
            }
        }

        
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaPhieu.Clear();
            txtEmail.Clear();
            txtTen.Clear();
            txtHanTra.Clear();
            loadDuLieu();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string luaChon = cbTimKiem.Text;
            if (luaChon == "") return;

            QLTVEntities db = new QLTVEntities();
            List<PhieuMuon> phieuMuons = new List<PhieuMuon>();

            if (luaChon == "Mã phiếu")
                phieuMuons = db.PhieuMuons.Where(p => p.DaTra == false && p.HanTra.HasValue &&
                       (
                           (p.NgayTra == null && DbFunctions.TruncateTime(p.HanTra) < DbFunctions.TruncateTime(DateTime.Now)) ||
                           (p.NgayTra != null && DbFunctions.TruncateTime(p.HanTra) < DbFunctions.TruncateTime(p.NgayTra))
                       ) && ("MP" + p.MaPhieu.ToString()).Contains(txtTimKiem.Text)
                ).ToList();

            else if (luaChon == "Họ tên độc giả")
                phieuMuons = db.PhieuMuons.Where(p => p.DaTra == false && p.HanTra.HasValue &&
                       (
                           (p.NgayTra == null && DbFunctions.TruncateTime(p.HanTra) < DbFunctions.TruncateTime(DateTime.Now)) ||
                           (p.NgayTra != null && DbFunctions.TruncateTime(p.HanTra) < DbFunctions.TruncateTime(p.NgayTra))
                       ) && (p.DocGia.HoTen.Contains(txtTimKiem.Text))
                ).ToList();

            else if (luaChon == "Email")
                phieuMuons = db.PhieuMuons.Where(p => p.DaTra == false && p.HanTra.HasValue &&
                       (
                           (p.NgayTra == null && DbFunctions.TruncateTime(p.HanTra) < DbFunctions.TruncateTime(DateTime.Now)) ||
                           (p.NgayTra != null && DbFunctions.TruncateTime(p.HanTra) < DbFunctions.TruncateTime(p.NgayTra))
                       ) && (p.DocGia.Email.Contains(txtTimKiem.Text))
                ).ToList();

            else if (luaChon == "Hạn trả")
            {
                DateTime ngayTim;
                if (DateTime.TryParseExact(txtTimKiem.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out ngayTim))
                {
                    phieuMuons = db.PhieuMuons
                        .Where(p => p.DaTra == false && p.HanTra.HasValue &&
                            (
                                (p.NgayTra == null && DbFunctions.TruncateTime(p.HanTra) < DbFunctions.TruncateTime(DateTime.Now)) ||
                                (p.NgayTra != null && DbFunctions.TruncateTime(p.HanTra) < DbFunctions.TruncateTime(p.NgayTra))
                            ) &&
                            DbFunctions.TruncateTime(p.HanTra) == DbFunctions.TruncateTime(ngayTim)
                        )
                        .ToList();
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập ngày hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else return;

            dgvQuaHan.DataSource = phieuMuons.Select(p => new
            {
                MaPhieu = "MP" + p.MaPhieu,
                TenDocGia = p.DocGia.HoTen,
                EmailDG = p.DocGia.Email,
                HanTra = p.HanTra.Value
            }).ToList();

            if (dgvQuaHan.Rows.Count > 0)
            {
                HienThiDuLieu(0);
            }
            else
            {
                txtMaPhieu.Clear();
                txtEmail.Clear();
                txtTen.Clear();
                txtHanTra.Clear();
            }
        }
        private void HienThiDuLieu(int index)
        {
            if (index == -1) return;

            txtMaPhieu.Text = dgvQuaHan.Rows[index].Cells["MaPhieu"].Value.ToString();
            txtEmail.Text = dgvQuaHan.Rows[index].Cells["EmailDG"].Value.ToString();
            txtTen.Text = dgvQuaHan.Rows[index].Cells["TenDocGia"].Value.ToString();
            txtHanTra.Text = ((DateTime)dgvQuaHan.Rows[index].Cells["HanTra"].Value).ToString("dd/MM/yyyy");
        }
        private void dgvBanDoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            if (dgvQuaHan.Rows.Count > 0)
            {
               HienThiDuLieu(e.RowIndex);
            }
            else
            {
                txtMaPhieu.Clear();
                txtEmail.Clear();
                txtTen.Clear();
                txtHanTra.Clear();
            }
        }
    }
}
