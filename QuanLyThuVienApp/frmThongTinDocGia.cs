using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVienApp
{
    public partial class frmThongTinDocGia : Form
    {
        public static int? maDG;

        public frmThongTinDocGia()
        {
            InitializeComponent();
        }

        public frmThongTinDocGia(int? _maDG)
        {
            maDG = _maDG;
            InitializeComponent();
            txtID.Text = "DG" + maDG.ToString();
        }

        private void frmCaNhan_Load(object sender, EventArgs e)
        {
            LibraryHelper.KiemTraVaKhoaTaiKhoan();
            loadDuLieu();
        }

        private void loadDuLieu()
        {
            QLTVEntities db = new QLTVEntities();
            DocGia DG = db.DocGias.Where(p => p.MaDocGia == maDG).FirstOrDefault();

            if (DG == null) return;

            txtID.Text = "DG" + DG.MaDocGia.ToString();

            if (DG.HoTen != null) txtHoVaTen.Text = DG.HoTen.ToString();
            else txtHoVaTen.Text = string.Empty;

            if (DG.MaSo != null) txtMaSo.Text = DG.MaSo.ToString();
            else txtMaSo.Text = string.Empty;

            if (DG.Email != null) txtEmail.Text = DG.Email.ToString();
            else txtEmail.Text = string.Empty;

            if (DG.LoaiDG == false)
            {
                labMS.Text = "Mã số sinh viên";
                txtLoaiDG.Text = "Sinh Viên";
            }
            else
            {
                labMS.Text = "Mã số giảng viên";
                txtLoaiDG.Text = "Giảng Viên";
            }

            if (DG.BiKhoa == true)
            {
                txtTrangThai.Text = "Bị khoá";
                btnBiKhoa.Text = "Mở khoá";
            }
            else
            {
                txtTrangThai.Text = "Đang hoạt động";
                btnBiKhoa.Text = "Khoá tài khoản";
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBiKhoa_Click(object sender, EventArgs e)
        {
            QLTVEntities db = new QLTVEntities();
            DocGia DG = db.DocGias.Where(p => p.MaDocGia == maDG).FirstOrDefault();

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
