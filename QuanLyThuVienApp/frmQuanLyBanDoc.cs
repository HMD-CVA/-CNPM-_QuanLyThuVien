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
    public partial class frmQuanLyBanDoc : Form
    {
        private string maDG;
        public static int OTP;
        public static DateTime thoiGian;

        private void ShowLoading()
        {
            progressBar1.Visible = true;
            progressBar1.BringToFront();
            this.UseWaitCursor = true;
            Application.DoEvents();
        }

        private void HideLoading()
        {
            progressBar1.Visible = false;
            this.UseWaitCursor = false;
        }

        public frmQuanLyBanDoc()
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
                p.HoTen,
                p.Email,
                p.SDT,
                BiKhoa = (p.BiKhoa == true) ? "Bị khoá" : "Đang hoạt động",
                SoLuong = db.PhieuMuons.Where(pm => pm.MaDG == p.MaDocGia).ToList().Count,
            }).ToList();
        }

        private bool isEmail(string inputEmail)
        {
            inputEmail = inputEmail ?? string.Empty;
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputEmail))
                return (true);
            else
                return (false);
        }

        private async void btnDangKy_Click(object sender, EventArgs e)
        {

            if (txtEmail.Text == "" || txtTen.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string email = txtEmail.Text.Trim();

            if (!isEmail(email))
            {
                MessageBox.Show("Email không hợp lệ!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có muốn đăng ký tài khoản mới không?",
                "Thông báo!",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No) return;

            QLTVEntities db = new QLTVEntities();
            DocGia dg = db.DocGias.Where(p => p.Email == txtEmail.Text).FirstOrDefault();

            if (dg != null)
            {
                MessageBox.Show("Email đã được độc giả khác sử dụng!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            Random random = new Random();
            string OTP = random.Next(100000, 999999).ToString();

            ShowLoading();
            await Task.Run(() =>
            {
                GuiEmail.guiEmail(email, "Mã xác thực của bạn là " + OTP);
            });
            HideLoading();

            frmXacThucDG frm = new frmXacThucDG(email, OTP, DateTime.Now);
            frm.ShowDialog();

            if (frm.ktXacThuc == false)
            {
                MessageBox.Show("Xác thực không thành công hoặc bị huỷ!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dg = new DocGia();
            dg.HoTen = txtTen.Text.Trim();
            dg.Email = email;
            dg.SDT = txtSDT.Text.Trim();
            dg.BiKhoa = false;

            db.DocGias.Add(dg);
            db.SaveChanges();

            MessageBox.Show("Đăng ký độc giả mới thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadDuLieu();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            loadDuLieu();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string luaChon = cbTimKiem.Text;
            if (luaChon == "") return;

            QLTVEntities db = new QLTVEntities();
            List<NguoiDung> nguoiDungs = new List<NguoiDung>();

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

            //dgvBanDoc.DataSource = nguoiDungs.Select(p => new
            //{
            //    MaBanDoc = "BD" + p.ID,
            //    p.HoTen,
            //    p.Email,
            //    p.NgayDangKi,
            //    p.SoSachMuon
            //}).ToList();

            if (dgvBanDoc.Rows.Count > 0)
            {
                txtID.Text = dgvBanDoc.Rows[0].Cells["MaBanDoc"].Value.ToString();
                txtSuaEmail.Text = dgvBanDoc.Rows[0].Cells["Email"].Value.ToString();
                txtSuaTen.Text = dgvBanDoc.Rows[0].Cells["HoTen"].Value.ToString();
            }
            else
            {
                txtID.Clear();
                txtSuaEmail.Clear();
                txtSuaTen.Clear();
            }

        }

        private void btnSuaEmail_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;

            DialogResult result = MessageBox.Show(
                "Bạn có muốn thay đổi thông tin của độc giả này không?",
                "Thông báo!",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No) return;

            foreach (Form form in this.MdiChildren)
                form.Close();
            frmTTDocGia frm = new frmTTDocGia(int.Parse(maDG));
           
            frm.FormClosed += (s, args) => {
                loadDuLieu();
            };
            frm.ShowDialog();
        }

        private void dgvBanDoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            if (dgvBanDoc.Rows.Count > 0)
            {
                maDG = dgvBanDoc.Rows[e.RowIndex].Cells["MaDocGia"].Value.ToString().Substring(2);
                txtID.Text = dgvBanDoc.Rows[e.RowIndex].Cells["MaDocGia"].Value.ToString();
                txtSuaEmail.Text = dgvBanDoc.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                txtSuaTen.Text = dgvBanDoc.Rows[e.RowIndex].Cells["HoTen"].Value.ToString();
                txtSuaSDT.Text = dgvBanDoc.Rows[e.RowIndex].Cells["SDT"].Value.ToString();
            }
            else
            {
                txtID.Clear();
                txtSuaSDT.Clear();
                txtSuaTen.Clear();
                txtSuaEmail.Clear();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;

            DialogResult result = MessageBox.Show(
                "Bạn có muốn xoá độc giả này không?",
                "Thông báo!",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No) return;

            QLTVEntities db = new QLTVEntities();

            int SLPhieuChuaTra = db.PhieuMuons.Where(p => p.MaDG.ToString() == maDG.ToString() && p.DaTra == false).Count();
            int SLPhieuDaTra = db.PhieuMuons.Where(p => p.MaDG.ToString() == maDG.ToString() && p.DaTra == true).Count();

            if (SLPhieuChuaTra > 0)
            {
                MessageBox.Show("Độc giả đang có phiếu mượn chưa trả!\nKhông thể xoá!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (SLPhieuDaTra > 0)
            {
                DialogResult qr = MessageBox.Show(
                    "Độc giả này vẫn có phiếu mượn!\nNếu xoá thì mọi phiếu mượn của độc giả cũng sẽ bị xoá.\nBạn có muốn xoá không ?",
                    "Thông báo!",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );
                if (qr == DialogResult.No) return;
            }

            var listRemove = db.PhieuMuons.Where(p => p.MaDG.ToString() == maDG).ToList();

            db.PhieuMuons.RemoveRange(listRemove);
            db.SaveChanges();

            DocGia dg = db.DocGias.Where(p => p.MaDocGia.ToString() == maDG).FirstOrDefault();
            db.DocGias.Remove(dg);

            db.SaveChanges();

            MessageBox.Show("Xoá độc giả thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadDuLieu();
        }
    }
}
