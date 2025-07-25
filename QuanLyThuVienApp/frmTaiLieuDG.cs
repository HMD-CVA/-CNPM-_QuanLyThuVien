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
            btnSUB.Enabled = false;
            loadDuLieu();
            themNutDGV();
        }
        private void themNutDGV()
        {
            // Kiểm tra nếu chưa có thì mới thêm
            if (!dgvSach.Columns.Contains("btnDangKy"))
            {
                DataGridViewButtonColumn nutDangKy = new DataGridViewButtonColumn();
                nutDangKy.HeaderText = "";
                nutDangKy.Text = "Đăng ký";
                nutDangKy.Name = "btnDangKy";
                nutDangKy.Width = 78;
                nutDangKy.UseColumnTextForButtonValue = true;

                dgvSach.Columns.Add(nutDangKy);
            }

            //if (!dgvSachMuon.Columns.Contains("btnXoa"))
            //{
            //    DataGridViewButtonColumn nutXoa = new DataGridViewButtonColumn();
            //    nutXoa.HeaderText = "";
            //    nutXoa.Text = "Xóa";
            //    nutXoa.Name = "btnXoa";
            //    nutXoa.Width = 45;
            //    nutXoa.UseColumnTextForButtonValue = true;

            //    dgvSachMuon.Columns.Add(nutXoa);
            //}

            // Đảm bảo nút luôn ở cuối cùng
            dgvSach.Columns["btnDangKy"].DisplayIndex = dgvSach.Columns.Count - 1;
        }
        private void loadDuLieu()
        {
            QLTVEntities db = new QLTVEntities();
            dgvSach.DataSource = db.TaiLieux.Select(p => new {
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

            if (dgvSach.Rows.Count > 0)
            {
                HienThiDuLieu(0);
            }
        }
        private void HienThiDuLieu(int RowIndex)
        {
            int soLuongSachCon = int.Parse(dgvSach.Rows[RowIndex].Cells["SoLuong"].Value.ToString()) - int.Parse(dgvSach.Rows[RowIndex].Cells["SoTaiLieuMuon"].Value.ToString());

            txtMaSach.Text = dgvSach.Rows[RowIndex].Cells["MaTaiLieu"].Value.ToString();
            txtTenSach.Text = dgvSach.Rows[RowIndex].Cells["TenTaiLieu"].Value.ToString();
            txtTacGia.Text = dgvSach.Rows[RowIndex].Cells["TenTG"].Value.ToString();
            txtNXB.Text = dgvSach.Rows[RowIndex].Cells["TenNXB"].Value.ToString();
            txtTheLoai.Text = dgvSach.Rows[RowIndex].Cells["TenDanhMuc"].Value.ToString();
            txtMoTa.Text = dgvSach.Rows[RowIndex].Cells["MoTa"].Value.ToString();
            txtTLConLai.Text = string.Empty;

            for (int i = 0; i < taiLieusMuon.Count; i++)
            {
                if (taiLieusMuon[i].Item1.ToString() == dgvSach.Rows[RowIndex].Cells["MaTaiLieu"].Value.ToString().Substring(2))
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

            string maSachFull = dgvSach.Rows[e.RowIndex].Cells["MaTaiLieu"].Value.ToString();           

            int maSach = int.Parse(maSachFull.Substring(2));
            int tongSach = int.Parse(dgvSach.Rows[e.RowIndex].Cells["CoSan"].Value.ToString());
            int soLuongConLai =
            !string.IsNullOrEmpty(txtDaDK.Text)
            ? int.Parse(txtTLConLai.Text)
            : Convert.ToInt32(dgvSach.Rows[e.RowIndex].Cells["CoSan"].Value ?? 0);

            if (dgvSach.Columns[e.ColumnIndex].Name != "btnDangKy") return;

            if (soLuongConLai == 0)
            {
                MessageBox.Show("Đã hết sách!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            MessageBox.Show($"Tổng số lượng mượn vượt quá số sách còn lại ({soLuongConLai})!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                string inKQ = string.Empty;
                for (int i = 0; i < taiLieusMuon.Count; i++)
                {
                    inKQ += taiLieusMuon[i].Item1.ToString() + " " + taiLieusMuon[i].Item2.ToString() + "\n";
                }
                MessageBox.Show(inKQ, "Thông ", MessageBoxButtons.OK);
            }
            
            HienThiDuLieu(e.RowIndex);
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
            else if (luaChon == "Danh mục")
                sach = db.TaiLieux.Where(p => p.DanhMucTaiLieu.TenDanhMuc.Contains(txtTimKiem.Text)).ToList();

            dgvSach.DataSource = sach.Select(p => new
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

        private void btnSUB_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaSach.Text.Trim()))
            {
                btnSUB.Enabled = false;
                return;
            }

            string maSachFull = txtMaSach.Text;
            int maSach = int.Parse(maSachFull.Substring(2));

            int soLuongHienTai = int.Parse(txtDaDK.Text.ToString());

            using (var nhapSoLuongForm = new frmNhapSLMuonXoa(soLuongHienTai, false)) // false = chế độ xóa
            {
                if (nhapSoLuongForm.ShowDialog() == DialogResult.OK)
                {
                    int soLuongXoa = nhapSoLuongForm.SoLuong;

                    //int soLuongConLai = soLuongHienTai - soLuongMuonXoa;

                    //if (soLuongConLai < 1)
                    //{
                    //    btnSUB.Enabled = false;
                    //}
                    //else
                    //{
                    //    row.Cells["SoLuong2"].Value = soLuongConLai;
                    //}

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
            }
            MessageBox.Show("Đã xoá thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            string inKQ = string.Empty;
            for (int i = 0; i < taiLieusMuon.Count; i++)
            {
                inKQ += taiLieusMuon[i].Item1.ToString() + " " + taiLieusMuon[i].Item2.ToString() + "\n";
            }
            MessageBox.Show(inKQ, "Thông ", MessageBoxButtons.OK);
            for (int i = 0; i < dgvSach.Rows.Count; i++)
            {
                var ma = dgvSach.Rows[i].Cells["MaTaiLieu"].Value?.ToString();
                if (ma == "TL" + maSach.ToString())
                {
                    HienThiDuLieu(i);
                    return;
                }
            }
        }
    }
}
