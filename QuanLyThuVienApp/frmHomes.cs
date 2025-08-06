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
        public static string strHello = "Chào mừng độc giả đã đến với thư viện!" ;

        public frmHomes()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            LibraryHelper.KiemTraVaKhoaTaiKhoan();
            timer1.Enabled = true;
            frmInfor frm = new frmInfor();
            frm.MdiParent = this;
            frm.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tslbThongTin.Text = strHello;
            tslbTimer.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss  ");
        }
        
        //private void btnThongTin_Click(object sender, EventArgs e)
        //{
        //    foreach (Form form in this.MdiChildren)
        //        form.Close();
        //    frmDangNhap frm = new frmDangNhap();
        //    this.Hide();
        //    frm.ShowDialog();
        //    this.Close();
        //}

        //private void btnGioiThieu_Click(object sender, EventArgs e)
        //{
        //   foreach (Form form in this.MdiChildren)
        //        form.Close();
        //    frmInfor frm = new frmInfor();
        //    frm.MdiParent = this;
        //    frm.Show();
        //}

        //private void btnDangXuat_Click(object sender, EventArgs e)
        //{
        //    DialogResult result = MessageBox.Show(
        //       "Bạn có muốn thoát không?",
        //       "Thông báo!",
        //       MessageBoxButtons.YesNo,
        //       MessageBoxIcon.Question
        //    );

        //    if (result == DialogResult.No) return;
        //    Application.Exit();
        //}

        //private void btnSach_Click(object sender, EventArgs e)
        //{
        //    foreach (Form form in this.MdiChildren)
        //        form.Close();
        //    frmTaiLieuDG frm = new frmTaiLieuDG();
        //    frm.MdiParent = this;  
        //    frm.Show();
        //}

        //private void btnMuonSach_Click(object sender, EventArgs e)
        //{
        //    foreach (Form form in this.MdiChildren)
        //        form.Close();
        //    frmMuonTaiLieuDG frm = new frmMuonTaiLieuDG();
        //    frm.MdiParent = this;
        //    frm.FormBorderStyle = FormBorderStyle.None;
        //    frm.Dock = DockStyle.Fill;
        //    frm.Show();
        //}

        //private void btnLichSuMuon_Click(object sender, EventArgs e)
        //{
        //    foreach (Form form in this.MdiChildren)
        //        form.Close();
        //    frmLichSuMuon frm = new frmLichSuMuon();
        //    frm.MdiParent = this;
        //    frm.Dock = DockStyle.Fill;
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

        bool menuExpand = false;
        private void menuTransition_Tick(object sender, EventArgs e)
        {
            if (menuExpand == false)
            {
                menuContainer.Height += 10;
                if (menuContainer.Height >= 317)
                {
                    menuTransition.Stop();
                    menuExpand = true;
                }
            } else
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
            } else
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
            frmDangNhap frm = new frmDangNhap();
            this.Hide();
            frm.ShowDialog();
            this.Close();
        }

        private void btnTroGiup_Click_1(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
                form.Close();
            frmTroGiup frm = new frmTroGiup();
            frm.MdiParent = this;
            frm.Show();
        }

        //private void btnInfor_Click(object sender, EventArgs e)
        //{
        //    foreach (Form form in this.MdiChildren)
        //        form.Close();
        //    frmInfor frm = new frmInfor();
        //    frm.MdiParent = this;
        //    frm.Show();
        //}

        private void btnInfor_Click_1(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
                form.Close();
            frmInfor frm = new frmInfor();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnDangXuat_Click_1(object sender, EventArgs e)
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

        private void btnSach_Click_1(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
                form.Close();
            frmTaiLieuDG frm = new frmTaiLieuDG();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnMuonSach_Click_1(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
                form.Close();
            frmMuonTaiLieuDG frm = new frmMuonTaiLieuDG();
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void btnLichSuMuon_Click_1(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
                form.Close();
            frmLichSuMuon frm = new frmLichSuMuon();
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
    }
}
