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
    public partial class frmQuanLyDocGia_Test_ : Form
    {
        public frmQuanLyDocGia_Test_()
        {
            InitializeComponent();

        }
        private void loadDuLieuDG()
        {
            QLTVEntities db = new QLTVEntities();
            dgvDocGia.DataSource = db.DocGias.Select(p => new
            {
                MaDocGia = "DG" + p.MaDocGia,
                p.HoTen,
                p.SDT,
                p.Email,
                BiKhoa = (p.BiKhoa == true) ? "Bị khoá" : "Hoạt động"
            }).ToList();
        }
        //private void btnThemDG_Click(object sender, EventArgs e)
        //{
        //    frmDangKy frm = new frmDangKy();
        //    frm.FormClosed += frmDangKy_FormClosed;
        //    frm.Show();
        //}
    }
}
