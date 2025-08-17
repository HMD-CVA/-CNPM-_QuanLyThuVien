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
    public partial class frmTaiLieuHidden : Form
    {
        public frmTaiLieuHidden()
        {
            InitializeComponent();
        }

        private void frmSach_Load(object sender, EventArgs e)
        {
            QLTVEntities db = new QLTVEntities();
            cbbSDM.DataSource = db.DanhMucTaiLieux.Select(p => p.TenDanhMuc).ToList();
            cbbSNXB.DataSource = db.NhaXuatBans.Select(p => p.TenNXB).ToList();
            cbbSTG.DataSource = db.TacGias.Select(p => p.TenTG).ToList();
            cbbSNXB.SelectedIndex = -1;
            cbbSDM.SelectedIndex = -1;
            cbbSTG.SelectedIndex = -1;

            loadDuLieu();

        }

        private void loadDuLieu()
        {
            QLTVEntities db = new QLTVEntities();
            dgvSach.DataSource = db.TaiLieux
                .Where(p => p.TrangThai == false)
                .Select(p => new {
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

            string maTL = txtSMaTL.Text.Trim();
            string tenTL = txtSTenTL.Text.Trim();
            string tenTG = string.IsNullOrEmpty(cbbSTG.Text.Trim()) ? string.Empty : cbbSTG.SelectedItem != null ? cbbSTG.SelectedItem.ToString().Trim() : string.Empty;
            string tenNXB = string.IsNullOrEmpty(cbbSNXB.Text.Trim()) ? string.Empty : cbbSNXB.SelectedItem != null ? cbbSNXB.SelectedItem.ToString().Trim() : string.Empty;
            string theLoai = string.IsNullOrEmpty(cbbSDM.Text.Trim()) ? string.Empty : cbbSDM.SelectedItem != null ? cbbSDM.SelectedItem.ToString().Trim() : string.Empty;
            // Nếu tất cả đều trống thì cảnh báo.
            if (string.IsNullOrEmpty(maTL) && string.IsNullOrEmpty(tenTL) &&
                string.IsNullOrEmpty(tenTG) && string.IsNullOrEmpty(tenNXB) && string.IsNullOrEmpty(theLoai))
            {
                MessageBox.Show("Vui lòng nhập thông tin để tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //QLTVEntities db = new QLTVEntities();

            string cacheKey = $"TL_{maTL}_{tenTL}_{tenTG}_{tenNXB}_{theLoai}";

            var result = SearchTool.SearchWithCache(cacheKey, () =>
            {
                using (QLTVEntities db = new QLTVEntities())
                {
                    var query = SearchTool.FilterTaiLieu(db, maTL, tenTL, tenTG, tenNXB, theLoai);

                    return query
                    .Where(p => p.TrangThai == false)
                    .Select(p => new
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

            dgvSach.DataSource = result;

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
            cbbSNXB.SelectedIndex = -1;
            cbbSDM.SelectedIndex = -1;
            cbbSTG.SelectedIndex = -1;

            txtSMaTL.Text = string.Empty;
            txtSTenTL.Text = string.Empty;
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            //if (txtTimKiem.Text == string.Empty) loadDuLieu();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAnTL_Click(object sender, EventArgs e)
        {
            string maTL = txtMaSach.Text.Trim();
            string soNam = txtSoNamHidden.Text.Trim();

            QLTVEntities db = new QLTVEntities();

            if (string.IsNullOrEmpty(soNam))
            {
                if (string.IsNullOrEmpty(maTL))
                {
                    MessageBox.Show("Vui lòng chọn tài liệu để hiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show(
                    "Bạn có muốn hiện tài liệu không?",
                    "Thông báo",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );
                if (result == DialogResult.No) return;

                TaiLieu tl = db.TaiLieux.Where(p => "TL" + p.MaTaiLieu.ToString() == maTL).FirstOrDefault();
                if (tl == null) return;
                tl.TrangThai = true;
                db.SaveChanges();
                loadDuLieu();
                MessageBox.Show("Đã hiện thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }
            if (!int.TryParse(soNam, out int Nam))
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult results = MessageBox.Show(
                   $"Bạn có chắc muốn hiện những tài liệu quá {Nam} năm này không?",
                   "Thông báo",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question
               );

            if (results == DialogResult.No) return;

            List<TaiLieu> ListTL = db.TaiLieux.Where(p => System.Data.Entity.DbFunctions.DiffYears(p.NgayNhap, DateTime.Now) >= Nam).ToList();
            foreach (TaiLieu TLs in ListTL)
            {
                TLs.TrangThai = true;
            }
            db.SaveChanges();
            loadDuLieu();
            txtSoNamHidden.Clear();
            MessageBox.Show("Đã hiện thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
    }
}
