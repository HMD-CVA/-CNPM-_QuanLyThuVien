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
    public partial class frmHomes : MetroFramework.Forms.MetroForm
    {
        public static string quyenHan = "user";
        public static string tenDN;
        public static string text;

        public frmHomes()
        {
            InitializeComponent();
        }

        public frmHomes(string _tenDangNhap, bool? _biKhoa)
        {
            InitializeComponent();

            if (_biKhoa == true)
            {
                text = "Tài khoản của bạn đang bị khóa, vui lòng đến thư viện để được xử lý!";
                tslbThongTin.ForeColor = Color.Red;
                btnMuonSach.Enabled = false;
                btnSach.Enabled = false;
            }
            else if( _biKhoa == false)
            {
                QLTVEntities db = new QLTVEntities();
                NguoiDung ngD = db.NguoiDungs.Where(p => p.TenDangNhap == _tenDangNhap).FirstOrDefault();
                NhanVien nguoiDung = db.NhanViens.Where(p => p.NguoiDungID == ngD.ID).FirstOrDefault();
                text = "Chào mừng nhân viên: " + nguoiDung.HoTen + " đã quay trở lại!";
            }
                
            tenDN = _tenDangNhap;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            frmInfor frm = new frmInfor();
            frm.MdiParent = this;
            frm.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tslbThongTin.Text = text;
            tslbTimer.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss  ");
        }
        
        private void btnThongTin_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
                form.Close();
            frmDangNhap frm = new frmDangNhap();
            this.Hide();
            frm.ShowDialog();
            this.Close();
        }

        private void btnGioiThieu_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
                form.Close();
            frmInfor frm = new frmInfor();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
               "Bạn có muốn thoát không?",
               "Thông báo!",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question
            );

            if (result == DialogResult.No) return;
            Application.Exit();
        }

        private void btnSach_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
                form.Close();
            frmTaiLieuDG frm = new frmTaiLieuDG();
            frm.MdiParent = this;  
            frm.Show();
        }

        private void btnMuonSach_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
                form.Close();
            frmMuonTaiLieuDG frm = new frmMuonTaiLieuDG();
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void btnLichSuMuon_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
                form.Close();
            frmLichSuMuon frm = new frmLichSuMuon();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
                form.Close();
            //frmCColumn_SachTheoTheLoai frm = new frmCColumn_SachTheoTheLoai();
            //frm.MdiParent = this;
            //frm.Show();
        }

        private void btnTroGiup_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
                form.Close();
            frmTroGiup frm = new frmTroGiup();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
