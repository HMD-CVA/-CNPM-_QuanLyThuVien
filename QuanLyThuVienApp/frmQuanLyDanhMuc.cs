using MetroFramework.Controls;
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
    public partial class frmQuanLyDanhMuc : MetroFramework.Forms.MetroForm
    {
        public frmQuanLyDanhMuc()
        {
            InitializeComponent();
        }

        private void frmTheLoai_Load(object sender, EventArgs e)
        {
            loadDuLieu();
        }

        private void loadDuLieu()
        {
            QLTVEntities db = new QLTVEntities();
            dgvTheLoai.DataSource = db.DanhMucTaiLieux.Select(p => new
            {
                MaDanhMuc = "DM" + p.MaDanhMuc,
                p.TenDanhMuc,
                p.ViTri,
                p.SoLuongTL,
                p.MoTa
            }).ToList();

            if (dgvTheLoai.Rows.Count > 0)
            {
                HienThiDuLieu(0);
            }
        }
        private void HienThiDuLieu(int RowIndex)
        {
            txtMa.Text = dgvTheLoai.Rows[RowIndex].Cells["MaDanhMuc"].Value.ToString();
            txtTen.Text = dgvTheLoai.Rows[RowIndex].Cells["TenDanhMuc"].Value.ToString();
            txtShowViTri.Text = dgvTheLoai.Rows[RowIndex].Cells["ViTri"].Value.ToString();
            if (dgvTheLoai.Rows[RowIndex].Cells["MoTa"].Value != null) txtShowMoTa.Text = dgvTheLoai.Rows[RowIndex].Cells["MoTa"].Value.ToString();
            else txtShowMoTa.Text = string.Empty;
        }
        private void dgvTheLoai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            HienThiDuLieu(e.RowIndex);
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            QLTVEntities db = new QLTVEntities();
            List<DanhMucTaiLieu> theLoais = new List<DanhMucTaiLieu>();

            if (cbTim.Text == "Mã danh mục")
            {
                theLoais = db.DanhMucTaiLieux.Where(p => ("DM" + p.MaDanhMuc).Contains(txtTim.Text)).ToList();
            }
            else if (cbTim.Text == "Tên danh mục")
            {
                theLoais = db.DanhMucTaiLieux.Where(p => p.TenDanhMuc.Contains(txtTim.Text)).ToList();
            }
            else if (cbTim.Text == "Vị trí danh mục")
            {
                theLoais = db.DanhMucTaiLieux.Where(p => p.ViTri.Contains(txtTim.Text)).ToList();
            }
            else return;

            dgvTheLoai.DataSource = theLoais.Select(p => new
            {
                MaTheLoai = "DM" + p.MaDanhMuc,
                p.TenDanhMuc,
                p.ViTri,
                p.SoLuongTL,
                p.MoTa
            }).ToList();

            if (dgvTheLoai.Rows.Count > 0)
            {
                HienThiDuLieu(0);
            }
            else
            {
                txtMa.Clear();
                txtTen.Clear();
                txtShowViTri.Clear();
                txtMoTa.Clear();
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            loadDuLieu();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có muốn thêm thể loại mới không?",
                "Thông báo!",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No) return;

            if (txtTenTL.Text == "" && txtViTri.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DanhMucTaiLieu theLoai = new DanhMucTaiLieu();
            theLoai.TenDanhMuc = txtTenTL.Text;
            theLoai.ViTri = txtViTri.Text;
            theLoai.MoTa = txtMoTa.Text;
            theLoai.SoLuongTL = 0;

            QLTVEntities db = new QLTVEntities();
            db.DanhMucTaiLieux.Add(theLoai);
            db.SaveChanges();
            loadDuLieu();
            txtTenTL.Clear();
            txtViTri.Clear();
            txtMoTa.Clear();
            MessageBox.Show("Thêm thể loại thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
               "Bạn có muốn sửa thông tin thể loại này không?",
               "Thông báo!",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question
           );

            if (result == DialogResult.No) return;

            if (txtTen.Text == "" && txtShowViTri.Text == "" && txtShowMoTa.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            QLTVEntities db = new QLTVEntities();
            int maTL = int.Parse(txtMa.Text.Substring(2));
            DanhMucTaiLieu theLoai = db.DanhMucTaiLieux.Where(p => p.MaDanhMuc == maTL).FirstOrDefault();

            theLoai.TenDanhMuc = txtTen.Text;
            theLoai.ViTri = txtShowViTri.Text;
            theLoai.MoTa = txtShowMoTa.Text;

            db.SaveChanges();
            loadDuLieu();
            MessageBox.Show("Sửa thể loại thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
               "Bạn có muốn xóa thể loại này không?",
               "Thông báo!",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question
           );

            if (result == DialogResult.No) return;
            QLTVEntities db = new QLTVEntities();
            int maTL = int.Parse(txtMa.Text.Substring(2));
            DanhMucTaiLieu theLoai = db.DanhMucTaiLieux.Where(p => p.MaDanhMuc == maTL).FirstOrDefault();
            
            if (theLoai.SoLuongTL > 0)
            {
                MessageBox.Show("Thể loại này đang có tài liệu trong thư viện!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            db.DanhMucTaiLieux.Remove(theLoai);
            db.SaveChanges();
            loadDuLieu();
            MessageBox.Show("Xóa thể loại thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
