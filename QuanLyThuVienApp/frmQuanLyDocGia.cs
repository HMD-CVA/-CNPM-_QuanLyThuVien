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

namespace QuanLyThuVienApp
{
    public partial class frmQuanLyDocGia : Form
    {
        private string maDG;
        public static int OTP;
        public static DateTime thoiGian;

        public frmQuanLyDocGia()
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
            dgvBanDoc.DataSource = db.DocGias.Select(p => new
            {
                MaDocGia = "DG" + p.MaDocGia,
                p.MaSo,
                p.HoTen,
                p.Email,
                LoaiDG = (p.LoaiDG == false) ? "Sinh viên" : "Giảng viên",
                BiKhoa = (p.BiKhoa == true) ? "Bị khoá" : "Đang hoạt động",
                SoLuong = db.PhieuMuons.Where(pm => pm.MaDG == p.MaDocGia).ToList().Count,
            }).ToList();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            loadDuLieu();
            ResetBTN();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string luaChon = cbTimKiem.Text;
            if (luaChon == "") return;

            QLTVEntities db = new QLTVEntities();
            List<DocGia> docGias = new List<DocGia>();

            if (luaChon == "Mã độc giả")
                docGias = db.DocGias.Where(p => ("DG" + p.MaDocGia.ToString()).Contains(txtTimKiem.Text)).ToList();
            else if (luaChon == "Tên độc giả")
                docGias = db.DocGias.Where(p => p.HoTen.Contains(txtTimKiem.Text)).ToList();
            else if (luaChon == "Email")
                docGias = db.DocGias.Where(p => p.Email.Contains(txtTimKiem.Text)).ToList();
            else return;

            dgvBanDoc.DataSource = docGias.Select(p => new
            {
                MaDocGia = "DG" + p.MaDocGia,
                p.MaSo,
                p.HoTen,
                p.Email,
                BiKhoa = (p.BiKhoa == true) ? "Bị khoá" : "Đang hoạt động",
                SoLuong = db.PhieuMuons.Where(pm => pm.MaDG == p.MaDocGia).ToList().Count,
            }).ToList();

            HienThiDuLieu(0);
        }

        private void HienThiDuLieu(int index)
        {
            if (dgvBanDoc.Rows.Count > 0)
            {
                txtMaDG.Text = dgvBanDoc.Rows[index].Cells["MaDocGia"].Value.ToString();
                txtEmail.Text = dgvBanDoc.Rows[index].Cells["Email"].Value.ToString();
                txtHoVaTen.Text = dgvBanDoc.Rows[index].Cells["HoTen"].Value.ToString();
                txtMaSo.Text = dgvBanDoc.Rows[index].Cells["MaSo"].Value.ToString();
                txtLoaiDG.Text = dgvBanDoc.Rows[index].Cells["LoaiDG"].Value.ToString();
                txtTrangThai.Text = dgvBanDoc.Rows[index].Cells["BiKhoa"].Value.ToString();
            }
            else ResetBTN();
        }
        private  void ResetBTN()
        {
            txtMaDG.Clear();
            txtEmail.Clear();
            txtHoVaTen.Clear();
            txtMaSo.Clear();
            txtLoaiDG.Clear();
            txtTrangThai.Clear();
        }
        private void dgvBanDoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            maDG = dgvBanDoc.Rows[e.RowIndex].Cells["MaDocGia"].Value.ToString().Substring(2);
            HienThiDuLieu(e.RowIndex);
        }

        private void btnBiKhoa_Click(object sender, EventArgs e)
        {
            QLTVEntities db = new QLTVEntities();
            DocGia DG = db.DocGias.Where(p => p.MaDocGia.ToString() == maDG).FirstOrDefault();

            if (DG == null) return;

            if (DG.BiKhoa == true)
            {
                DialogResult result = MessageBox.Show(
                   "Bạn có muốn mở khoá này không?",
                   "Thông báo!",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question
                );

                if (result == DialogResult.No) return;

                PhieuMuon phieuMuonTreHan = db.PhieuMuons
                    .Where(p => p.MaDG == DG.MaDocGia && p.DaTra == false && p.HanTra.HasValue &&
                                System.Data.Entity.DbFunctions.DiffDays(p.HanTra, DateTime.Now) > 30)
                    .FirstOrDefault();

                if (phieuMuonTreHan != null)
                {
                    MessageBox.Show("Độc giả này có phiếu mượn quá hạn 30 ngày chưa trả!\nKhông thể mở khoá", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                DialogResult result = MessageBox.Show(
                   "Bạn có muốn khoá này không?",
                   "Thông báo!",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question
                );

                if (result == DialogResult.No) return;
            }
            DG.BiKhoa = !DG.BiKhoa;
            db.SaveChanges();
            loadDuLieu();
        }
    }
}
