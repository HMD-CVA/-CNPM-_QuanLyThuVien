using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVienApp
{
    public partial class frmDoiMatKhau : MetroFramework.Forms.MetroForm
    {
        public static int ID;
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        public frmDoiMatKhau(int _ID)
        {
            ID = _ID;   
            InitializeComponent();
        }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            string mkCu = txtMKCu.Text.Trim();
            string mkMoi1 = txtMKMoi1.Text.Trim();
            string mkMoi2 = txtMKMoi2.Text.Trim();

            if (string.IsNullOrWhiteSpace(mkCu) || string.IsNullOrWhiteSpace(mkMoi1) || string.IsNullOrWhiteSpace(mkMoi2))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            QLTVEntities db = new QLTVEntities();
            NguoiDung nguoiDung = db.NguoiDungs.Where(p => p.ID == ID).FirstOrDefault();

            MD5 mD5 = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(txtMKCu.Text);
            byte[] matKhauCu = mD5.ComputeHash(inputBytes);

            if (!matKhauCu.SequenceEqual(nguoiDung.MatKhau))
            {
                MessageBox.Show("Mật khẩu cũ không đúng!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //if(txtMKMoi1.Text.Length < 6)
            //{
            //    MessageBox.Show("Mật khẩu có tối thiểu 6 ký tự!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            if (mkCu == mkMoi1)
            {
                MessageBox.Show("Mật khẩu mới không được trùng mật khẩu cũ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (mkMoi1 != mkMoi2)
            {
                MessageBox.Show("Mật khẩu mới không khớp với xác nhận!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            inputBytes = System.Text.Encoding.ASCII.GetBytes(txtMKMoi2.Text);
            byte[] matKhauMoi = mD5.ComputeHash(inputBytes);
            nguoiDung.MatKhau = matKhauMoi;
            db.SaveChanges();

            MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
