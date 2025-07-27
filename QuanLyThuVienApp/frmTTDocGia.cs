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
    public partial class frmTTDocGia : Form
    {
        public static int? maDG;

        public frmTTDocGia()
        {
            InitializeComponent();
        }

        public frmTTDocGia(int? _maDG)
        {
            maDG = _maDG;
            InitializeComponent();
            txtID.Text = "DG" + maDG.ToString();
        }

        private void frmCaNhan_Load(object sender, EventArgs e)
        {
            loadDuLieu();

            btnLuuTen.Hide();
            btnHuyTen.Hide();

            btnLuuSDT.Hide();
            btnHuySDT.Hide();

            btnLuuEmail.Hide();
            btnHuyEmail.Hide();
        }

        private void loadDuLieu()
        {
            QLTVEntities db = new QLTVEntities();
            DocGia DG = db.DocGias.Where(p => p.MaDocGia == maDG).FirstOrDefault();

            if (DG == null) return;

            if (DG.HoTen != null) txtHoVaTen.Text = DG.HoTen.ToString();
            else txtHoVaTen.Text = string.Empty;

            if (DG.SDT != null) txtSDT.Text = DG.SDT.ToString();
            else txtSDT.Text = string.Empty;

            if (DG.Email != null) txtEmail.Text = DG.Email.ToString();
            else txtEmail.Text = string.Empty;

            if (DG.BiKhoa == true) 
            { 
                txtTrangThai.Text = "Bị khoá" ;
                btnBiKhoa.Text = "Mở khoá";
            }
            else
            {
                txtTrangThai.Text = "Đang hoạt động";
                btnBiKhoa.Text = "Khoá tài khoản";
            }
        }

        private void btnDoiTen_Click(object sender, EventArgs e)
        {
            txtHoVaTen.ReadOnly = false;
            btnLuuTen.Show();
            btnHuyTen.Show();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtHoVaTen.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            QLTVEntities db = new QLTVEntities();
            DocGia DG = db.DocGias.Where(p => p.MaDocGia == maDG).FirstOrDefault();
            
            DG.HoTen = txtHoVaTen.Text;
            db.SaveChanges();
            txtHoVaTen.ReadOnly = true;
            btnLuuTen.Hide();
            btnHuyTen.Hide();
            loadDuLieu();
         
            MessageBox.Show("Thay đổi tên thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnHuyTen_Click(object sender, EventArgs e)
        {
            QLTVEntities db = new QLTVEntities();
            DocGia DG = db.DocGias.Where(p => p.MaDocGia == maDG).FirstOrDefault();

            txtHoVaTen.Text = DG.HoTen.ToString();
            btnHuyTen.Hide();
            btnLuuTen.Hide();
            txtHoVaTen.ReadOnly = true;
        }

        private void btnDoiEmail_Click(object sender, EventArgs e)
        {
            btnLuuEmail.Show();
            btnHuyEmail.Show();
            txtEmail.ReadOnly = false;
        }

        private void btnHuyEmail_Click(object sender, EventArgs e)
        {
            QLTVEntities db = new QLTVEntities();
            DocGia DG = db.DocGias.Where(p => p.MaDocGia == maDG).FirstOrDefault();

            txtEmail.Text = DG.Email.ToString();
            btnHuyEmail.Hide();
            btnLuuEmail.Hide();
            txtEmail.ReadOnly = true;
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

        private void btnLuuEmail_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                MessageBox.Show("Vui lòng nhập Email!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!isEmail(txtEmail.Text))
            {
                MessageBox.Show("Email không hợp lệ!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string newE = txtEmail.Text.Trim();
            QLTVEntities db = new QLTVEntities();
            DocGia DG = db.DocGias.Where(p => p.Email.Trim() == newE).FirstOrDefault();

            if (DG != null)
            {
                MessageBox.Show("Email đã được sử dụng!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DocGia DGOld = db.DocGias.Where(p => p.MaDocGia == maDG).FirstOrDefault();

            if (txtEmail.Text == DGOld.Email)
            {
                MessageBox.Show("Cần nhập email mới!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Random random = new Random();
            string OTP = random.Next(100000, 999999).ToString();

            try
            {
                GuiEmail.guiEmail(txtEmail.Text, "Mã xác thực của bạn là " + OTP);

                frmXacThucDG frm = new frmXacThucDG(txtEmail.Text, OTP, DateTime.Now);
                frm.ShowDialog();

                if (frm.ktXacThuc)
                {
                    DGOld.Email = txtEmail.Text;
                    db.SaveChanges();

                    txtEmail.ReadOnly = true;
                    btnLuuEmail.Hide();
                    btnHuyEmail.Hide();
                    loadDuLieu();
                }
                else
                {
                    MessageBox.Show("Email chưa được xác minh!\nKhông thể đổi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //frmXacThucDG frm = new frmXacThucDG(nhanVien.DGID, xacNhan =>
                //{
                //    if (xacNhan)
                //    {
                //        nhanVien.Email = txtEmail.Text;
                //        db.SaveChanges();

                //        txtEmail.ReadOnly = true;
                //        btnLuuEmail.Hide();
                //        btnHuyEmail.Hide();
                //        loadDuLieu();
                //    }
                //});
                //frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnDoiSDT_Click(object sender, EventArgs e)
        {
            btnLuuSDT.Show();
            btnHuySDT.Show();
            txtSDT.ReadOnly = false;
        }
        private bool IsInvalidPhoneNumber(string sdt)
        {
            if (string.IsNullOrWhiteSpace(sdt)) return true;

            if (!Regex.IsMatch(sdt, @"^\d{10}$")) return true;

            if (!Regex.IsMatch(sdt, @"^(03|05|07|08|09)\d{8}$")) return true;

            return false;
        }

        private void btnLuuSDT_Click(object sender, EventArgs e)
        {
            if (txtSDT.Text == "")
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            QLTVEntities db = new QLTVEntities();
            DocGia DG = db.DocGias.Where(p => p.MaDocGia == maDG).FirstOrDefault();
            
            if (!IsInvalidPhoneNumber(txtSDT.Text))
            {
                DG.SDT = txtSDT.Text;
            }
            else
            {
                MessageBox.Show("Số điện thoại không hợp lệ. Vui lòng nhập lại", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            db.SaveChanges();
            btnLuuSDT.Hide();
            btnHuySDT.Hide();
            txtSDT.ReadOnly = true;
            loadDuLieu();

            MessageBox.Show("Thay đổi số điện thoại thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnHuySDT_Click(object sender, EventArgs e)
        {
            QLTVEntities db = new QLTVEntities();
            DocGia DG = db.DocGias.Where(p => p.MaDocGia == maDG).FirstOrDefault();
            txtSDT.Text = DG.SDT.ToString();
            btnHuySDT.Hide();
            btnLuuSDT.Hide();
            txtSDT.ReadOnly = true;
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

            if (DG.BiKhoa == false)
            {
                DialogResult result = MessageBox.Show(
                   "Bạn có muốn mở khoá này không?",
                   "Thông báo!",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question
                );

                if (result == DialogResult.No) return;

                DG.BiKhoa = true;
                db.SaveChanges();
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

                DG.BiKhoa = false;
                db.SaveChanges();
            }

            loadDuLieu();
        }
    }
}
