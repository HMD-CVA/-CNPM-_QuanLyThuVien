using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Media3D;

namespace QuanLyThuVienApp
{
    public partial class frmQuanLyTaiLieu : Form
    {
        public frmQuanLyTaiLieu()
        {
            InitializeComponent();
        }

        private void frmQuanLySach_Load(object sender, EventArgs e)
        {
            loadDuLieu();
            QLTVEntities db = new QLTVEntities();
            cbNXB.SelectedIndex = -1;
            cbTheLoai.SelectedIndex = -1;
            cbTacGia.SelectedIndex = -1;

            cbbSDM.DataSource = db.DanhMucTaiLieux.Where(p => p.TrangThaiAnHien == true).Select(p => p.TenDanhMuc).ToList();
            cbbSNXB.DataSource = db.NhaXuatBans.Where(p => p.TrangThaiAnHien == true).Select(p => p.TenNXB).ToList();
            cbbSTG.DataSource = db.TacGias.Where(p => p.TrangThaiAnHien == true).Select(p => p.TenTG).ToList();
            cbbSNXB.SelectedIndex = -1;
            cbbSDM.SelectedIndex = -1;
            cbbSTG.SelectedIndex = -1;

            radioSuaXoa.Checked = true;
        }

        private void loadDuLieu()
        {
            QLTVEntities db = new QLTVEntities();

            cbTacGia.DisplayMember = "TenTG";
            cbTacGia.ValueMember = "MaTG";
            cbTacGia.DataSource = db.TacGias.Where(p => p.TrangThaiAnHien == true).ToList();

            cbNXB.DisplayMember = "TenNXB";
            cbNXB.ValueMember = "MaNXB";
            cbNXB.DataSource = db.NhaXuatBans.Where(p => p.TrangThaiAnHien == true).ToList();

            cbTheLoai.DisplayMember = "TenDanhMuc";
            cbTheLoai.ValueMember = "MaDanhMuc";
            cbTheLoai.DataSource = db.DanhMucTaiLieux.Where(p => p.TrangThaiAnHien == true).ToList();

            dgvSach.DataSource = db.TaiLieux
            .Where(p => p.TrangThai == true && p.TrangThaiAnHien == true)
            .Select(p => new {
                MaTaiLieu = "TL" + p.MaTaiLieu,
                p.TenTaiLieu,
                p.DanhMucTaiLieu.TenDanhMuc,
                p.TacGia.TenTG,
                p.NhaXuatBan.TenNXB,
                p.TaiBan,
                //p.MoTa,
                p.SoLuong,
                p.SoTaiLieuMuon,
            }).ToList();

            HienThiDuLieu(-1);

            if (radioThem.Checked) return;
        }
        private void HienThiDuLieu(int RowIndex)
        {
            if (RowIndex < 0) return;

            QLTVEntities db = new QLTVEntities();

            string tenTheLoai = dgvSach.Rows[RowIndex].Cells[2].Value.ToString();
            string tenTacGia = dgvSach.Rows[RowIndex].Cells[3].Value.ToString();
            string tenNXB = dgvSach.Rows[RowIndex].Cells[4].Value.ToString();
            string maTL = dgvSach.Rows[RowIndex].Cells[0].Value.ToString();

            TacGia tacGia = db.TacGias.Where(p => p.TenTG == tenTacGia).FirstOrDefault();
            NhaXuatBan nxb = db.NhaXuatBans.Where(p => p.TenNXB == tenNXB).FirstOrDefault();
            DanhMucTaiLieu theLoai = db.DanhMucTaiLieux.Where(p => p.TenDanhMuc == tenTheLoai).FirstOrDefault();
            TaiLieu taiLieu = db.TaiLieux.Where(p => "TL" + p.MaTaiLieu.ToString() == maTL).FirstOrDefault();

            txtMaSach.Text = dgvSach.Rows[RowIndex].Cells[0].Value.ToString();
            txtTenSach.Text = dgvSach.Rows[RowIndex].Cells[1].Value.ToString();
            txtTaiBan.Text = dgvSach.Rows[RowIndex].Cells[5].Value.ToString();
            txtSoLuong.Text = dgvSach.Rows[RowIndex].Cells[6].Value.ToString();
            txtDangMuon.Text = dgvSach.Rows[RowIndex].Cells[7].Value.ToString();
            txtMoTa.Text = taiLieu.MoTa.ToString();

            cbTacGia.SelectedValue = tacGia.MaTG;
            cbNXB.SelectedValue = nxb.MaNXB;
            cbTheLoai.SelectedValue = theLoai.MaDanhMuc;
        }
        private void dgvSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (radioThem.Checked) return;

            HienThiDuLieu(e.RowIndex);
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

            string cacheKey = $"TL_{maTL}_{tenTL}_{tenTG}_{tenNXB}_{theLoai}";

            var result = SearchTool.SearchWithCache(cacheKey, () =>
            {
                using (QLTVEntities db = new QLTVEntities())
                {
                    var query = SearchTool.FilterTaiLieu(db, maTL, tenTL, tenTG, tenNXB, theLoai);

                    return query
                    .Where(p => p.TrangThai == true && p.TrangThaiAnHien == true)
                    .Select(p => new
                    {
                        MaTaiLieu = "TL" + p.MaTaiLieu,
                        p.TenTaiLieu,
                        p.DanhMucTaiLieu.TenDanhMuc,
                        p.TacGia.TenTG,
                        p.NhaXuatBan.TenNXB,
                        p.TaiBan,
                        //p.MoTa,
                        p.SoLuong,
                        p.SoTaiLieuMuon,
                    }).ToList();
                }
            });

            dgvSach.DataSource = result;

            if (radioThem.Checked) return;

            if (dgvSach.Rows.Count > 0)
            {
                HienThiDuLieu(0);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            cbbSNXB.SelectedIndex = -1;
            cbbSDM.SelectedIndex = -1;
            cbbSTG.SelectedIndex = -1;

            txtSMaTL.Text = string.Empty;
            txtSTenTL.Text = string.Empty;

            loadDuLieu();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string tenTG = cbTacGia.Text.ToString();
            string tenNXB = cbNXB.Text.ToString();
            string tenTheLoai = cbTheLoai.Text.ToString();
            string moTa = txtMoTa.Text.ToString();
            string taiBan = txtTaiBan.Text.ToString();

            if (txtTenSach.Text == "" || tenTG == "" || tenNXB == "" || tenTheLoai == "" || txtSoLuong.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có muốn thêm tài liệu mới không?",
                "Thông báo!",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No) return;

            
            if (moTa == string.Empty)
            {
                moTa = "Không có mô tả";
            }
            if (taiBan == string.Empty)
            {
                taiBan = "-1";//Take Care
            } 
           
            if (!int.TryParse(txtSoLuong.Text, out int val) || val <= 0)
            {
                MessageBox.Show("Số lượng không hợp lệ!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSoLuong.Focus();
                return;
            }

            QLTVEntities db = new QLTVEntities();

            TacGia tacGia = db.TacGias.Where(p => p.TenTG == tenTG).FirstOrDefault();
            if (tacGia == null)
            {
                MessageBox.Show("Tác giả không tồn tại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbTacGia.Focus();
                return;
            }

            NhaXuatBan nhaXuatBan = db.NhaXuatBans.Where(p => p.TenNXB == tenNXB).FirstOrDefault();
            if (nhaXuatBan == null)
            {
                MessageBox.Show("Nhà xuất bản không tồn tại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbNXB.Focus();
                return;
            }

            DanhMucTaiLieu theLoai = db.DanhMucTaiLieux.Where(p => p.TenDanhMuc == tenTheLoai).FirstOrDefault();
            if (theLoai == null)
            {
                MessageBox.Show("Thể loại không tồn tại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbTheLoai.Focus();
                return;
            }

            int maTG = int.Parse(cbTacGia.SelectedValue.ToString());
            int maNXB = int.Parse(cbNXB.SelectedValue.ToString());
            int maDanhMuc = int.Parse(cbTheLoai.SelectedValue.ToString());
            int taiBanInt = int.Parse(taiBan);

            // Kiểm tra sách đã tồn tại hay chưa (trùng tất cả thông tin trừ mô tả)
            var sachTonTai = db.TaiLieux.FirstOrDefault(s =>
                s.TenTaiLieu == txtTenSach.Text &&
                s.MaTG == maTG &&
                s.MaNXB == maNXB &&
                s.MaDanhMuc == maDanhMuc &&
                s.TaiBan == taiBanInt
            );

            if (sachTonTai != null)
            {
                // Sách đã tồn tại → Cộng dồn số lượng
                sachTonTai.SoLuong += val;
                db.SaveChanges();
                loadDuLieu();
                MessageBox.Show("Tài liệu đã tồn tại. Đã cộng dồn số lượng thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            TaiLieu sach = new TaiLieu();
            sach.TenTaiLieu = txtTenSach.Text;
            sach.MaTG = int.Parse(cbTacGia.SelectedValue.ToString());
            sach.MaNXB = int.Parse(cbNXB.SelectedValue.ToString());
            sach.MaDanhMuc = int.Parse(cbTheLoai.SelectedValue.ToString());
            sach.SoLuong = int.Parse(txtSoLuong.Text);
            sach.SoTaiLieuMuon = 0;
            sach.MoTa = moTa;
            sach.TaiBan = int.Parse(taiBan);
            sach.TrangThai = true;
            sach.TrangThaiAnHien = true;

            tacGia.SoLuongTL += 1;
            nhaXuatBan.SoLuongTL += 1;
            theLoai.SoLuongTL += 1;

            db.TaiLieux.Add(sach);
            db.SaveChanges();
            loadDuLieu();
            txtTenSach.Clear();
            txtSoLuong.Clear();
            MessageBox.Show("Thêm tài liệu thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaSach.Text == "") return;

            string tenTG = cbTacGia.Text.ToString();
            string tenNXB = cbNXB.Text.ToString();
            string tenTheLoai = cbTheLoai.Text.ToString();

            if (txtTenSach.Text == "" || tenTG == "" || tenNXB == "" || tenTheLoai == "" || txtSoLuong.Text == "" || txtMoTa.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có muốn sửa thông tin tài liệu không?",
                "Thông báo!",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No) return;

            if (!int.TryParse(txtSoLuong.Text, out int val))
            {
                MessageBox.Show("Số lượng không hợp lệ!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSoLuong.Focus();
                return;
            }
            else if (val < 1 || val < int.Parse(txtDangMuon.Text))
            {
                MessageBox.Show("Số lượng không hợp lệ!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSoLuong.Focus();
                return;
            }

            QLTVEntities db = new QLTVEntities();
            TacGia tacGiaMoi = db.TacGias.Where(p => p.TenTG == tenTG).FirstOrDefault();
            if (tacGiaMoi == null)
            {
                MessageBox.Show("Tác giả không tồn tại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbTacGia.Focus();
                return;
            }

            NhaXuatBan nhaXuatBanMoi = db.NhaXuatBans.Where(p => p.TenNXB == tenNXB).FirstOrDefault();
            if (nhaXuatBanMoi == null)
            {
                MessageBox.Show("Nhà xuất bản không tồn tại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbNXB.Focus();
                return;
            }

            DanhMucTaiLieu theLoaiMoi = db.DanhMucTaiLieux.Where(p => p.TenDanhMuc == tenTheLoai).FirstOrDefault();
            if (theLoaiMoi == null)
            {
                MessageBox.Show("Thể loại không tồn tại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbTheLoai.Focus();
                return;
            }

            int maSach = int.Parse(txtMaSach.Text.Substring(2));
            TaiLieu sach = db.TaiLieux.Where(p => p.MaTaiLieu == maSach).FirstOrDefault();
           
            if (theLoaiMoi.MaDanhMuc != sach.MaDanhMuc)
            {
                theLoaiMoi.SoLuongTL += 1;
                DanhMucTaiLieu theLoaiCu = db.DanhMucTaiLieux.Where(p => p.MaDanhMuc == sach.MaDanhMuc).FirstOrDefault();
                theLoaiCu.SoLuongTL -= 1;
            }
            sach.MaDanhMuc = int.Parse(cbTheLoai.SelectedValue.ToString());

            if (tacGiaMoi.MaTG != sach.MaTG)
            {
                tacGiaMoi.SoLuongTL += 1;
                TacGia tacGiaCu = db.TacGias.Where(p => p.MaTG == sach.MaTG).FirstOrDefault();
                tacGiaCu.SoLuongTL -= 1;
            }
            sach.MaTG = int.Parse(tacGiaMoi.MaTG.ToString());
          
            if (nhaXuatBanMoi.MaNXB != sach.MaNXB)
            {
                nhaXuatBanMoi.SoLuongTL += 1;
                NhaXuatBan nhaXuatBanCu = db.NhaXuatBans.Where(p => p.MaNXB == sach.MaNXB).FirstOrDefault();
                nhaXuatBanCu.SoLuongTL -= 1;
            }
            sach.MaNXB = int.Parse(cbNXB.SelectedValue.ToString());
            sach.TenTaiLieu = txtTenSach.Text.Trim();   
            sach.SoLuong = int.Parse(txtSoLuong.Text);
            sach.MoTa = txtMoTa.Text.ToString();
            sach.TaiBan = int.Parse(txtTaiBan.Text.ToString());
            sach.MoTa = txtMoTa.Text.Trim();

            db.SaveChanges();
            loadDuLieu();
            MessageBox.Show("Sửa tài liệu thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaSach.Text == "") return;

            DialogResult result = MessageBox.Show(
                "Bạn có muốn xóa tài liệu này không?",
                "Thông báo!",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No) return;

            QLTVEntities db = new QLTVEntities();

            TaiLieu sach = db.TaiLieux.Where(p => "TL" + p.MaTaiLieu == txtMaSach.Text).FirstOrDefault();

            if (sach.SoTaiLieuMuon != 0)
            {
                MessageBox.Show("Không thể xóa tài liệu do đang được mượn!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            TacGia tacGia = db.TacGias.Where(p => p.MaTG == sach.MaTG && p.TrangThaiAnHien == true).FirstOrDefault();
            NhaXuatBan nhaXuatBan = db.NhaXuatBans.Where(p => p.MaNXB == sach.MaNXB && p.TrangThaiAnHien == true).FirstOrDefault();
            DanhMucTaiLieu danhMuc = db.DanhMucTaiLieux.Where(p => p.MaDanhMuc == sach.MaDanhMuc && p.TrangThaiAnHien == true).FirstOrDefault();

            tacGia.SoLuongTL -= 1;
            nhaXuatBan.SoLuongTL -= 1;
            danhMuc.SoLuongTL -= 1;

            sach.TrangThaiAnHien = false;
            db.SaveChanges();
            loadDuLieu();
            MessageBox.Show("Xóa tài liệu thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void radioThem_CheckedChanged(object sender, EventArgs e)
        {
            btnSua.Hide();
            btnXoa.Hide();
            txtMaSach.Hide();
            txtDangMuon.Hide();
            lbMaSach.Hide();
            lbDangMuon.Hide();
            btnThem.Show();

            txtMaSach.Clear();
            txtTenSach.Clear();
            txtSoLuong.Clear();
            txtDangMuon.Clear();
            txtMoTa.Clear();
            txtTaiBan.Clear();
            cbTacGia.SelectedIndex = -1;
            cbNXB.SelectedIndex = -1;
            cbTheLoai.SelectedIndex = -1;
        }

        private void radioSuaXoa_CheckedChanged(object sender, EventArgs e)
        {
            cbTacGia.SelectedIndex = -1;
            cbNXB.SelectedIndex = -1;
            cbTheLoai.SelectedIndex = -1;
            txtMaSach.Clear();
            txtTenSach.Clear();
            txtSoLuong.Clear();
            txtDangMuon.Clear();
            txtMoTa.Clear();
            txtTaiBan.Clear();

            btnSua.Show();
            btnXoa.Show();
            txtMaSach.Show();
            txtDangMuon.Show();
            lbMaSach.Show();
            lbDangMuon.Show();
            btnThem.Hide();

            QLTVEntities db = new QLTVEntities();
            if (dgvSach.Rows.Count > 0)
            {     
                HienThiDuLieu(0);
            }
        }

        private void btnThemTG_Click(object sender, EventArgs e)
        {
            frmQuanLyTacGia frm = new frmQuanLyTacGia();
            frm.FormClosed += (s, args) => {
                loadDuLieu();
            };
            frm.ShowDialog();
        }
        private void btnThemNXB_Click(object sender, EventArgs e)
        {
            frmQuanLyNXB frm = new frmQuanLyNXB();
            frm.FormClosed += (s, args) => {
                loadDuLieu();
            };
            frm.ShowDialog();
        }
        private void btnThemTheLoai_Click(object sender, EventArgs e)
        {
            frmQuanLyDanhMuc frm = new frmQuanLyDanhMuc();
            frm.FormClosed += (s, args) => {
                loadDuLieu();
            };
            frm.ShowDialog();
        }

        private void btnHidden_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
                form.Close();
            frmTaiLieuHidden frm = new frmTaiLieuHidden();
            frm.MdiParent = frmMainUserNV.Instance; 
            frm.FormClosed += (s, args) => {
                loadDuLieu();
            };
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string maTL = txtMaSach.Text.Trim();
            string soNam = txtSoNamHidden.Text.Trim();

            QLTVEntities db = new QLTVEntities();

            if (string.IsNullOrEmpty(soNam))
            {
                if (string.IsNullOrEmpty(maTL))
                {
                    MessageBox.Show("Vui lòng chọn tài liệu để ẩn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show(
                    "Bạn có muốn ẩn tài liệu không?",
                    "Thông báo",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );
                if (result == DialogResult.No) return;

                TaiLieu tl = db.TaiLieux.Where(p => "TL" + p.MaTaiLieu.ToString() == maTL).FirstOrDefault();
                if (tl == null) return;
                tl.TrangThai = false;
                db.SaveChanges();
                loadDuLieu();
                MessageBox.Show("Đã ẩn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }
            if (!int.TryParse(soNam, out int Nam))
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult results = MessageBox.Show(
                   $"Bạn có chắc muốn ẩn những tài liệu quá {Nam} năm này không?",
                   "Thông báo",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question
               );

            if (results == DialogResult.No) return;

            List<TaiLieu> ListTL = db.TaiLieux.Where(p => System.Data.Entity.DbFunctions.DiffYears(p.NgayNhap, DateTime.Now) >= Nam).ToList();
            foreach (TaiLieu TLs in ListTL)
            {
                TLs.TrangThai = false;
            }
            db.SaveChanges();
            loadDuLieu();
            MessageBox.Show("Đã ẩn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtSoNamHidden.Clear();
            return;
        }
    }
}
