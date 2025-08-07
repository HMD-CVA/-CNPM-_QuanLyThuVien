using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVienApp
{
    public partial class frmTaiLieuDG : Form
    {
        public static List<(int, int)> taiLieusMuon = new List<(int, int)>();
        public frmTaiLieuDG()
        {
            InitializeComponent();
        }

        private void frmSach_Load(object sender, EventArgs e)
        {
            QLTVEntities db = new QLTVEntities();
            cbbSDM.DataSource = db.DanhMucTaiLieux.Select(p => p.TenDanhMuc).ToList();
            cbbSNXB.DataSource = db.NhaXuatBans.Select(p => p.TenNXB).ToList();
            cbbSTG.DataSource = db.TacGias.Select(p => p.TenTG).ToList();

            reset();

            btnSUB.Enabled = false;
            loadDuLieu();
        }
        private void themNutDGV()
        {
            // Kiểm tra nếu chưa có thì mới thêm
            if (!dgvTaiLieu.Columns.Contains("btnDangKy"))
            {
                DataGridViewButtonColumn nutDangKy = new DataGridViewButtonColumn();
                nutDangKy.HeaderText = "";
                nutDangKy.Text = "Đăng ký";
                nutDangKy.Name = "btnDangKy";
                nutDangKy.Width = 78;
                nutDangKy.UseColumnTextForButtonValue = true;

                dgvTaiLieu.Columns.Add(nutDangKy);
            }
            // Đảm bảo nút luôn ở cuối cùng
            dgvTaiLieu.Columns["btnDangKy"].DisplayIndex = dgvTaiLieu.Columns.Count - 1;
        }
        private void loadDuLieu()
        {
            QLTVEntities db = new QLTVEntities();
            dgvTaiLieu.DataSource = db.TaiLieux.Select(p => new {
                MaTaiLieu = "TL" + p.MaTaiLieu, 
                p.TenTaiLieu,
                p.DanhMucTaiLieu.TenDanhMuc,
                p.TacGia.TenTG, 
                p.NhaXuatBan.TenNXB, 
                p.TaiBan,
                p.SoLuong, 
                p.SoTaiLieuMuon,
                p.MoTa,
                CoSan = p.SoLuong - p.SoTaiLieuMuon
            }).ToList();
            themNutDGV();
        }
        private void HienThiDuLieu(int RowIndex)
        {
            int soLuongSachCon = int.Parse(dgvTaiLieu.Rows[RowIndex].Cells["SoLuong"].Value.ToString()) - int.Parse(dgvTaiLieu.Rows[RowIndex].Cells["SoTaiLieuMuon"].Value.ToString());

            txtMaTaiLieu.Text = dgvTaiLieu.Rows[RowIndex].Cells["MaTaiLieu"].Value.ToString();
            txtTenTaiLieu.Text = dgvTaiLieu.Rows[RowIndex].Cells["TenTaiLieu"].Value.ToString();
            txtTacGia.Text = dgvTaiLieu.Rows[RowIndex].Cells["TenTG"].Value.ToString();
            txtNXB.Text = dgvTaiLieu.Rows[RowIndex].Cells["TenNXB"].Value.ToString();
            txtDanhMuc.Text = dgvTaiLieu.Rows[RowIndex].Cells["TenDanhMuc"].Value.ToString();
            txtMoTa.Text = dgvTaiLieu.Rows[RowIndex].Cells["MoTa"].Value.ToString();
            txtTLConLai.Text = string.Empty;

            for (int i = 0; i < taiLieusMuon.Count; i++)
            {
                if (taiLieusMuon[i].Item1.ToString() == dgvTaiLieu.Rows[RowIndex].Cells["MaTaiLieu"].Value.ToString().Substring(2))
                {
                    txtDaDK.Text = taiLieusMuon[i].Item2.ToString();
                    
                    if (txtDaDK.Text != string.Empty && int.Parse(txtDaDK.Text.ToString()) > 0)
                    {
                        txtTLConLai.Text = (soLuongSachCon - int.Parse(txtDaDK.Text.ToString())).ToString();
                        btnSUB.Enabled = true;
                    }
                    return;
                }
            }
            txtDaDK.Text = string.Empty;
            btnSUB.Enabled = false;
        }
        private void dgvSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            HienThiDuLieu(e.RowIndex); 

            string maSachFull = dgvTaiLieu.Rows[e.RowIndex].Cells["MaTaiLieu"].Value.ToString();           

            int maSach = int.Parse(maSachFull.Substring(2));
            int tongSach = int.Parse(dgvTaiLieu.Rows[e.RowIndex].Cells["CoSan"].Value.ToString());
            int soLuongConLai =
            !string.IsNullOrEmpty(txtDaDK.Text)
            ? int.Parse(txtTLConLai.Text)
            : Convert.ToInt32(dgvTaiLieu.Rows[e.RowIndex].Cells["CoSan"].Value ?? 0);

            if (dgvTaiLieu.Columns[e.ColumnIndex].Name != "btnDangKy") return;

            if (soLuongConLai == 0)
            {
                MessageBox.Show("Đã hết tài liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (frmNhapSLMuonXoa formNhap = new frmNhapSLMuonXoa(soLuongConLai, true))
            {
                if (formNhap.ShowDialog() != DialogResult.OK) return;

                int soLuongMuon = formNhap.SoLuong;
                bool daCoTrongDS = false;

                // Kiểm tra nếu sách đã có trong danh sách mượn => cộng thêm
                for (int i = 0; i < taiLieusMuon.Count; i++)
                {
                    if (taiLieusMuon[i].Item1 == maSach)
                    {
                        int daMuon = taiLieusMuon[i].Item2;

                        if (daMuon + soLuongMuon > tongSach)
                        {
                            MessageBox.Show($"Tổng số lượng mượn vượt quá số tài liệu còn lại ({soLuongConLai})!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtDaDK.Text = taiLieusMuon[i].Item2.ToString();
                            return;
                        }
                        taiLieusMuon[i] = (taiLieusMuon[i].Item1, daMuon + soLuongMuon);
                        daCoTrongDS = true;
                        break;
                    }
                }

                if (!daCoTrongDS)
                {
                    taiLieusMuon.Add((maSach, soLuongMuon));
                }
                MessageBox.Show("Đã đăng ký mượn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            HienThiDuLieu(e.RowIndex);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {

            string maTL = txtSMaTL.Text.Trim();
            string tenTL = txtSTenTL.Text.Trim();
            string tacGia = string.IsNullOrEmpty(cbbSTG.Text.Trim()) ? string.Empty : cbbSTG.SelectedItem != null ? cbbSTG.SelectedItem.ToString().Trim() : string.Empty;
            string nxb = string.IsNullOrEmpty(cbbSNXB.Text.Trim()) ? string.Empty : cbbSNXB.SelectedItem != null ? cbbSNXB.SelectedItem.ToString().Trim() : string.Empty;
            string theLoai = string.IsNullOrEmpty(cbbSDM.Text.Trim()) ? string.Empty : cbbSDM.SelectedItem != null ? cbbSDM.SelectedItem.ToString().Trim() : string.Empty;


            if (string.IsNullOrEmpty(maTL) && string.IsNullOrEmpty(tenTL) && string.IsNullOrEmpty(tacGia) && string.IsNullOrEmpty(nxb) && string.IsNullOrEmpty(theLoai))
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
                        p.DanhMucTaiLieu.TenDanhMuc,
                        p.TacGia.TenTG,
                        p.NhaXuatBan.TenNXB,
                        p.TaiBan,
                        p.SoLuong,
                        p.SoTaiLieuMuon,
                        p.MoTa,
                        CoSan = p.SoLuong - p.SoTaiLieuMuon
                    }).ToList();
                }
            });

            dgvTaiLieu.DataSource = result;

            if (dgvTaiLieu.Rows.Count > 0)
            {
                HienThiDuLieu(0);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtSMaTL.Text = string.Empty;
            txtSTenTL.Text = string.Empty;
            reset();
            loadDuLieu();
        }

        private void reset()
        {
            txtMaTaiLieu.Clear();
            txtTenTaiLieu.Clear();
            txtTacGia.Clear();
            txtNXB.Clear();
            txtDanhMuc.Clear();
            txtDaDK.Clear();
            txtMoTa.Clear();

            cbbSNXB.SelectedIndex = -1;
            cbbSDM.SelectedIndex = -1;
            cbbSTG.SelectedIndex = -1;
        }
        //private void txtTimKiem_TextChanged(object sender, EventArgs e)
        //{
        //    if (txtTimKiem.Text == string.Empty) loadDuLieu();
        //}

        private void btnSUB_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaTaiLieu.Text.Trim()))
            {
                btnSUB.Enabled = false;
                return;
            }

            string maSachFull = txtMaTaiLieu.Text;
            int maSach = int.Parse(maSachFull.Substring(2));

            int soLuongHienTai = int.Parse(txtDaDK.Text.ToString());

            using (var nhapSoLuongForm = new frmNhapSLMuonXoa(soLuongHienTai, false)) // false = chế độ xóa
            {
                if (nhapSoLuongForm.ShowDialog() == DialogResult.OK)
                {
                    int soLuongXoa = nhapSoLuongForm.SoLuong;

                    for (int i = 0; i < taiLieusMuon.Count; i++)
                    {
                        if (taiLieusMuon[i].Item1 == maSach)
                        {
                            int daMuon = taiLieusMuon[i].Item2;

                            if (daMuon - soLuongXoa <= 0)
                            {
                                taiLieusMuon.RemoveAt(i);                               
                                txtDaDK.Text = string.Empty;
                            }
                            else taiLieusMuon[i] = (taiLieusMuon[i].Item1, daMuon - soLuongXoa);
                            break;
                        }
                    }
                }
                else return;
            }
            MessageBox.Show("Đã xoá thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
  
            for (int i = 0; i < dgvTaiLieu.Rows.Count; i++)
            {
                var ma = dgvTaiLieu.Rows[i].Cells["MaTaiLieu"].Value?.ToString();
                if (ma == "TL" + maSach.ToString())
                {
                    HienThiDuLieu(i);
                    return;
                }
            }
        }
    }
}
