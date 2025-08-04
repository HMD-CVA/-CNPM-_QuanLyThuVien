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
            //loadDuLieu();
        }

        private void loadDuLieu()
        {
            QLTVEntities db = new QLTVEntities();
            var dsQuaHan = db.PhieuMuons
                .Where(p => p.DaTra == false && p.HanTra.HasValue && 
                       ((p.NgayTra == null && p.HanTra.Value.Date < DateTime.Now.Date) ||
                       (p.NgayTra != null && p.HanTra.Value.Date < p.NgayTra.Value.Date))
                )
                .Select(p => new
                {
                    MaPhieu = "MP" + p.MaPhieu,
                    TenDocGia = p.DocGia.HoTen,
                    EmailDG = p.DocGia.Email,
                    HanTra = p.HanTra.Value.ToString("dd/MM/yyyy")
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
            loadDuLieu();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            //string luaChon = cbTimKiem.Text;
            //if (luaChon == "") return;

            //DB_Test db = new DB_Test();
            //List<NguoiDung> nguoiDungs = new List<NguoiDung>();

            //if (luaChon == "Mã bạn đọc")
            //    nguoiDungs = db.NguoiDungs.Where(p => p.QuyenHan == "user" && p.TrangThaiXacThuc == true
            //    && p.BiKhoa == false && ("BD" + p.ID.ToString()).Contains(txtTimKiem.Text)).ToList();
            //else if (luaChon == "Tên bạn đọc")
            //    nguoiDungs = db.NguoiDungs.Where(p => p.QuyenHan == "user" && p.TrangThaiXacThuc == true
            //    && p.BiKhoa == false && p.HoTen.Contains(txtTimKiem.Text)).ToList();
            //else if (luaChon == "Email")
            //    nguoiDungs = db.NguoiDungs.Where(p => p.QuyenHan == "user" && p.TrangThaiXacThuc == true
            //    && p.BiKhoa == false && p.Email.Contains(txtTimKiem.Text)).ToList();
            //else return;

            //dgvQuaHan.DataSource = nguoiDungs.Select(p => new
            //{
            //    MaBanDoc = "BD" + p.ID,
            //    p.HoTen,
            //    p.Email,
            //    p.NgayDangKi,
            //    p.SoSachMuon
            //}).ToList();

            //if (dgvQuaHan.Rows.Count > 0)
            //{
            //    txtID.Text = dgvQuaHan.Rows[0].Cells["MaBanDoc"].Value.ToString();
            //    txtSuaEmail.Text = dgvQuaHan.Rows[0].Cells["Email"].Value.ToString();
            //    txtSuaTen.Text = dgvQuaHan.Rows[0].Cells["HoTen"].Value.ToString();
            //}
            //else
            //{
            //    txtID.Clear();
            //    txtSuaEmail.Clear();
            //    txtSuaTen.Clear();
            //}

        }

        private void dgvBanDoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex == -1) return;

            //if (dgvQuaHan.Rows.Count > 0)
            //{
            //    txtID.Text = dgvQuaHan.Rows[e.RowIndex].Cells["MaBanDoc"].Value.ToString();
            //    txtSuaEmail.Text = dgvQuaHan.Rows[e.RowIndex].Cells["Email"].Value.ToString();
            //    txtSuaTen.Text = dgvQuaHan.Rows[e.RowIndex].Cells["HoTen"].Value.ToString();
            //}
            //else
            //{
            //    txtID.Clear();
            //    txtEmail.Clear();
            //    txtSuaTen.Clear();
            //}
        }
    }
}
