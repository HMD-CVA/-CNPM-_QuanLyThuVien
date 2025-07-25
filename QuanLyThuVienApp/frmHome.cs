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
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void frmHome_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            frmInfor frm = new frmInfor();
            frm.MdiParent = this;
            frm.Show();
        }
        private void btnSach_Click(object sender, EventArgs e)
        {
            frmTaiLieuDG frm = new frmTaiLieuDG();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnCaNhan_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
                form.Close();
            frmDangNhap frm = new frmDangNhap();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnQLPhieuMuon_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
                form.Close();
            frmLichSuMuon frm = new frmLichSuMuon();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnPhieuMuon_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
                form.Close();
            frmMuonTaiLieu frm = new frmMuonTaiLieu();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
