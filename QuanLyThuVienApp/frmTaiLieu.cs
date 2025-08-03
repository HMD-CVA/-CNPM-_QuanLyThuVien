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
using System.Runtime.Caching;

namespace QuanLyThuVienApp
{
    public partial class frmTaiLieu : Form
    {
        public frmTaiLieu()
        {
            InitializeComponent();
        }

        private void frmSach_Load(object sender, EventArgs e)
        {
            QLTVEntities db = new QLTVEntities();
            cbbSDM.DataSource = db.DanhMucTaiLieux.Select(p => p.TenDanhMuc).ToList();
            cbbSNXB.DataSource = db.NhaXuatBans.Select(p => p.TenNXB).ToList();
            cbbSTG.DataSource = db.TacGias.Select(p => p.TenTG).ToList();
            resetTXT();
            loadDuLieu();
        }

        private void loadDuLieu()
        {
            QLTVEntities db = new QLTVEntities();
            dgvTaiLieu.DataSource = db.TaiLieux.Select(p => new {
                MaTaiLieu = "TL" + p.MaTaiLieu, 
                p.TenTaiLieu, 
                p.TacGia.TenTG, 
                p.NhaXuatBan.TenNXB, 
                p.DanhMucTaiLieu.TenDanhMuc, 
                p.TaiBan,
                p.SoLuong, 
                p.SoTaiLieuMuon,
                p.MoTa
            }).ToList();
        }
        private void HienThiDuLieu(int RowIndex)
        {
            int soLuongSachCon = int.Parse(dgvTaiLieu.Rows[RowIndex].Cells[6].Value.ToString()) - int.Parse(dgvTaiLieu.Rows[RowIndex].Cells[7].Value.ToString());

            txtMaTaiLieu.Text = dgvTaiLieu.Rows[RowIndex].Cells[0].Value.ToString();
            txtTenTaiLieu.Text = dgvTaiLieu.Rows[RowIndex].Cells[1].Value.ToString();
            txtTacGia.Text = dgvTaiLieu.Rows[RowIndex].Cells[2].Value.ToString();
            txtNXB.Text = dgvTaiLieu.Rows[RowIndex].Cells[3].Value.ToString();
            txtDanhMuc.Text = dgvTaiLieu.Rows[RowIndex].Cells[4].Value.ToString();
            txtMoTa.Text = dgvTaiLieu.Rows[RowIndex].Cells[8].Value.ToString();
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
            string maTL = txtSMaTL.Text.Trim();
            string tenTL = txtSTenTL.Text.Trim();
            string tacGia = string.IsNullOrEmpty(cbbSTG.Text.Trim()) ? string.Empty : cbbSTG.SelectedItem != null ? cbbSTG.SelectedItem.ToString().Trim() : string.Empty;
            string nxb = string.IsNullOrEmpty(cbbSNXB.Text.Trim()) ? string.Empty : cbbSNXB.SelectedItem != null ? cbbSNXB.SelectedItem.ToString().Trim() : string.Empty;
            string theLoai = string.IsNullOrEmpty(cbbSDM.Text.Trim()) ? string.Empty : cbbSDM.SelectedItem != null ? cbbSDM.SelectedItem.ToString().Trim() : string.Empty;


            if (string.IsNullOrEmpty (maTL) && string.IsNullOrEmpty(tenTL) && string.IsNullOrEmpty (tacGia) && string.IsNullOrEmpty(nxb) && string.IsNullOrEmpty (theLoai))
            {
                MessageBox.Show("Vui lòng nhập thông tin để tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string cacheKey = $"TL_{maTL}_{tenTL}_{tacGia}_{nxb}_{theLoai}";

            var result = SearchTool.SearchWithCache(cacheKey, () =>
            {
                using (QLTVEntities db = new QLTVEntities())
                {
                    var query = SearchTool.FilterTaiLieu(db, maTL, tenTL, tacGia, nxb, theLoai);

                    return query.Select(p => new
                    {
                        MaTaiLieu = "TL" + p.MaTaiLieu,
                        p.TenTaiLieu,
                        p.TacGia.TenTG,
                        p.NhaXuatBan.TenNXB,
                        p.DanhMucTaiLieu.TenDanhMuc,
                        p.TaiBan,
                        p.SoLuong,
                        p.SoTaiLieuMuon,
                        p.MoTa
                    }).ToList();
                }
            });

            dgvTaiLieu.DataSource = result;

            if (dgvTaiLieu.Rows.Count > 0)
            {
                HienThiDuLieu(0);
            }
        }
        private void resetTXT()
        {
            txtMaTaiLieu.Clear();
            txtTenTaiLieu.Clear();
            txtTacGia.Clear();
            txtNXB.Clear();
            txtDanhMuc.Clear();
            txtConSan.Clear();
            txtMoTa.Clear();

            cbbSNXB.SelectedIndex = -1;
            cbbSDM.SelectedIndex = -1;
            cbbSTG.SelectedIndex = -1;
        }
        private void btnLamMoi_Click(object sender, EventArgs e)
        {                   
            txtSMaTL.Text = string.Empty;
            txtSTenTL.Text = string.Empty;
            resetTXT();
            loadDuLieu();   
        }
    }
}
