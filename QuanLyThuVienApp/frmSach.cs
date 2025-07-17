using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVienApp
{
    public partial class frmSach : Form
    {
        public frmSach()
        {
            InitializeComponent();
        }

        private void frmSach_Load(object sender, EventArgs e)
        {
            loadDuLieu();
        }

        private void loadDuLieu()
        {
            QLTVEntities db = new QLTVEntities();
            dgvSach.DataSource = db.TaiLieux.Select(p => new {
                MaTaiLieu = "S" + p.MaTaiLieu, 
                p.TenTaiLieu, 
                p.TacGia.TenTG, 
                p.NhaXuatBan.TenNXB, 
                p.DanhMucTaiLieu.TenDanhMuc, 
                p.TaiBan,
                p.SoLuong, 
                p.SoTaiLieuMuon,
                p.MoTa
            }).ToList();

            if (dgvSach.Rows.Count > 0)
            {
                HienThiDuLieu(0);
            }
        }
        private void HienThiDuLieu(int RowIndex)
        {
            int soLuongSachCon = int.Parse(dgvSach.Rows[RowIndex].Cells[6].Value.ToString()) - int.Parse(dgvSach.Rows[RowIndex].Cells[7].Value.ToString());

            txtMaSach.Text = dgvSach.Rows[RowIndex].Cells[0].Value.ToString();
            txtTenSach.Text = dgvSach.Rows[RowIndex].Cells[1].Value.ToString();
            txtTacGia.Text = dgvSach.Rows[RowIndex].Cells[2].Value.ToString();
            txtNXB.Text = dgvSach.Rows[RowIndex].Cells[3].Value.ToString();
            txtTheLoai.Text = dgvSach.Rows[RowIndex].Cells[4].Value.ToString();
            txtMoTa.Text = dgvSach.Rows[RowIndex].Cells[8].Value.ToString();
            txtConSan.Text = soLuongSachCon.ToString();
        }
        private void dgvSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                HienThiDuLieu(e.RowIndex);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string luaChon = cbTimKiem.Text;
            if (luaChon == "")
            {
                MessageBox.Show("Vui lòng chọn lựa chọn để tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbTimKiem.Focus();
                return;
            }

            QLTVEntities db = new QLTVEntities();
            List<TaiLieu> sach = new List<TaiLieu>();

            if (luaChon == "Mã tài liệu")
                sach = db.TaiLieux.Where(p => ("S" + p.MaTaiLieu.ToString()).Contains(txtTimKiem.Text)).ToList();
            else if (luaChon == "Tên tài liệu")
                sach = db.TaiLieux.Where(p => p.TenTaiLieu.Contains(txtTimKiem.Text)).ToList();
            else if (luaChon == "Tác giả")
                sach = db.TaiLieux.Where(p => p.TacGia.TenTG.Contains(txtTimKiem.Text)).ToList();
            else if (luaChon == "Nhà xuất bản")
                sach = db.TaiLieux.Where(p => p.NhaXuatBan.TenNXB.Contains(txtTimKiem.Text)).ToList();
            else if (luaChon == "Thể loại")
                sach = db.TaiLieux.Where(p => p.DanhMucTaiLieu.TenDanhMuc.Contains(txtTimKiem.Text)).ToList();

            dgvSach.DataSource = sach.Select(p => new
            {
                MaTaiLieu = "S" + p.MaTaiLieu,
                p.TenTaiLieu,
                p.TacGia.TenTG,
                p.NhaXuatBan.TenNXB,
                p.DanhMucTaiLieu.TenDanhMuc,
                p.TaiBan,
                p.SoLuong,
                p.SoTaiLieuMuon,
                p.MoTa
            }).ToList();

            if (dgvSach.Rows.Count > 0)
            {
                HienThiDuLieu(0);
            }
            else
            {
                txtMaSach.Clear();
                txtTenSach.Clear();
                txtTacGia.Clear();
                txtNXB.Clear();
                txtTheLoai.Clear();
                txtConSan.Clear();
                txtMoTa.Clear();
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            loadDuLieu();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == string.Empty) loadDuLieu();
        }
    }
}
