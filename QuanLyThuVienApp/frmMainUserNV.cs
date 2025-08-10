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
    public partial class frmMainUserNV : MetroFramework.Forms.MetroForm
    {
        public static string quyenHan = "user";
        public static string tenDN;
        public static string text;
        private int maNV;

        public frmMainUserNV()
        {
            InitializeComponent();
        }

        public frmMainUserNV(string _tenDangNhap, bool? _biKhoa)
        {
            InitializeComponent();

            if (_biKhoa == true)
            {

                MessageBox.Show("Tài khoản của bạn đang bị khóa, vui lòng liên hệ ADMIN thư viện để được xử lý!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                frmHomes frm = new frmHomes();
                this.Hide();
                frm.ShowDialog();
                this.Close();
                return;
            }
            else if( _biKhoa == false)
            {
                QLTVEntities db = new QLTVEntities();
                NguoiDung ngD = db.NguoiDungs.Where(p => p.TenDangNhap == _tenDangNhap).FirstOrDefault();
                NhanVien nguoiDung = db.NhanViens.Where(p => p.NguoiDungID == ngD.ID).FirstOrDefault();
                text = "Chào mừng nhân viên: " + nguoiDung.HoTen + " đã quay trở lại!";
                maNV = nguoiDung.MaNV;
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
        
        //private void btnThongTin_Click(object sender, EventArgs e)
        //{
        //    foreach (Form form in this.MdiChildren)
        //        form.Close();
        //    frmThongTinNV frm = new frmThongTinNV(tenDN, quyenHan);
        //    frm.MdiParent = this;
        //    frm.Show();
        //}

        //private void btnGioiThieu_Click(object sender, EventArgs e)
        //{
        //    foreach (Form form in this.MdiChildren)
        //        form.Close();
        //    frmInfor frm = new frmInfor();
        //    frm.MdiParent = this;
        //    frm.Show();
        //}

        //private void btnDangXuat_Click(object sender, EventArgs e)
        //{
        //    frmHomes frm = new frmHomes();
        //    this.Hide();
        //    frm.ShowDialog();
        //    this.Close();
        //}

        //private void btnMuonSach_Click(object sender, EventArgs e)
        //{
        //    foreach (Form form in this.MdiChildren)
        //        form.Close();
        //    frmQuanLyPhieuMuon frm = new frmQuanLyPhieuMuon(maNV, this);
        //    frm.MdiParent = this;
        //    frm.Show();
        //}

        //private void btnThongKe_Click(object sender, EventArgs e)
        //{
        //    foreach (Form form in this.MdiChildren)
        //        form.Close();
        //    //frmCColumn_SachTheoTheLoai frm = new frmCColumn_SachTheoTheLoai();
        //    //frm.MdiParent = this;
        //    //frm.Show();
        //}

        //private void btnTroGiup_Click(object sender, EventArgs e)
        //{
        //    foreach (Form form in this.MdiChildren)
        //        form.Close();
        //    frmTroGiup frm = new frmTroGiup();
        //    frm.MdiParent = this;
        //    frm.Show();
        //}

        //private void btnLichSuMuon_Click(object sender, EventArgs e)
        //{
        //    foreach (Form form in this.MdiChildren)
        //        form.Close();
        //    frmQuanLyTaiLieu frm = new frmQuanLyTaiLieu();
        //    frm.MdiParent = this;
        //    frm.Show();
        //}

        //private void btnQLDocGia_Click(object sender, EventArgs e)
        //{
        //    foreach (Form form in this.MdiChildren)
        //        form.Close();
        //    frmQuanLyDocGia frm = new frmQuanLyDocGia();
        //    frm.MdiParent = this;
        //    frm.Show();
        //}

        //private void btnGuiEmail_Click(object sender, EventArgs e)
        //{
        //    foreach (Form form in this.MdiChildren)
        //        form.Close();
        //    frmGuiEmailQuaHan frm = new frmGuiEmailQuaHan();
        //    frm.MdiParent = this;
        //    frm.Show();
        //}

        bool menuExpand = false;
        private void menuTransition_Tick(object sender, EventArgs e)
        {
            if (menuExpand == false)
            {
                menuContainer.Height += 10;
                if (menuContainer.Height >= 391)
                {
                    menuTransition.Stop();
                    menuExpand = true;
                }
            }
            else
            {
                menuContainer.Height -= 10;
                if (menuContainer.Height <= 58)
                {
                    menuTransition.Stop();
                    menuExpand = false;
                }
            }
        }

        private void menu_Click(object sender, EventArgs e)
        {
            menuTransition.Start();
        }

        bool sidebarExpand = true;

        private void sidebarTransition_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                sidebar.Width -= 10;
                if (sidebar.Width <= 67)
                {
                    sidebarExpand = false;
                    sidebarTransition.Stop();
                }
            }
            else
            {
                sidebar.Width += 10;
                if (sidebar.Width >= 236)
                {
                    sidebarExpand = true;
                    sidebarTransition.Stop();
                }
            }
        }

        private void btnHam_Click(object sender, EventArgs e)
        {
            sidebarTransition.Start();
        }

        private void btnCaNhan_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
                form.Close();
            frmThongTinNV frm = new frmThongTinNV(tenDN, quyenHan);
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void btnTroGiup_Click_1(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
                form.Close();
            frmTroGiup frm = new frmTroGiup();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void btnInfor_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
                form.Close();
            frmInfor frm = new frmInfor();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void btnDangXuat_Click_1(object sender, EventArgs e)
        {
            frmHomes frm = new frmHomes();
            this.Hide();
            frm.ShowDialog();
            this.Close();
        }

        private void btnQLSach_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
                form.Close();
            frmQuanLyTaiLieu frm = new frmQuanLyTaiLieu();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void btnPhieuMuon_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
                form.Close();
            frmQuanLyPhieuMuon frm = new frmQuanLyPhieuMuon(maNV, this);
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void btnQLDocGia_Click_1(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
                form.Close();
            frmQuanLyDocGia frm = new frmQuanLyDocGia();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void btnGuiEmail_Click_1(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
                form.Close();
            frmGuiEmailQuaHan frm = new frmGuiEmailQuaHan();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void btnThongKe_Click_1(object sender, EventArgs e)
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

        private void btnQLTaiLieu_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
                form.Close();
            frmQuanLyTaiLieu frm = new frmQuanLyTaiLieu();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnQLDocGia_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
                form.Close();
            frmQuanLyDocGia frm = new frmQuanLyDocGia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnGuiEmail_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
                form.Close();
            frmGuiEmailQuaHan frm = new frmGuiEmailQuaHan();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
