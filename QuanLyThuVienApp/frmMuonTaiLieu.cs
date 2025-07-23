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
    public partial class frmMuonTaiLieu : Form
    {
        private int maNV;
        private frmMuonTaiLieu()
        {
            InitializeComponent();
        }
        public frmMuonTaiLieu(int _maNV)
        {
            InitializeComponent();
            maNV = _maNV;
        }

        private void frmMuonSach_Load(object sender, EventArgs e)
        {
            loadDuLieuDG();
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

            if (!dgvSachMuon.Columns.Contains("btnXoa"))
            {
                DataGridViewButtonColumn nutXoa = new DataGridViewButtonColumn();
                nutXoa.HeaderText = "";
                nutXoa.Text = "Xóa";
                nutXoa.Name = "btnXoa";
                nutXoa.Width = 45;
                nutXoa.UseColumnTextForButtonValue = true;

                dgvSachMuon.Columns.Add(nutXoa);
            }

            // Đảm bảo nút luôn ở cuối cùng
            dgvSach.Columns["btnDangKy"].DisplayIndex = dgvSach.Columns.Count - 1;
        }

        private void loadDuLieuDG()
        {
            //QLTVEntities db = new QLTVEntities();
            //dgvDocGia.DataSource = db.DocGias.Select(p => new
            //{
            //    MaDocGia = "DG" + p.MaDocGia,
            //    p.HoTen,
            //    p.SDT,
            //    p.Email,
            //    BiKhoa = (p.BiKhoa == true) ? "Bị khoá" : "Hoạt động"
            //}).ToList();
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
                CoSan = p.SoLuong - p.SoTaiLieuMuon,
                p.SoLuong,
                p.SoTaiLieuMuon,
                p.MoTa
            }).ToList();
        }
        private void dgvSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvSach.Columns[e.ColumnIndex].Name != "btnDangKy") return;

            int soLuongConLai = int.Parse(dgvSach.Rows[e.RowIndex].Cells["CoSan"].Value.ToString());
            if (soLuongConLai == 0)
            {
                MessageBox.Show("Đã hết sách!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string maSach = dgvSach.Rows[e.RowIndex].Cells["MaTaiLieu"].Value.ToString();
            string tenSach = dgvSach.Rows[e.RowIndex].Cells["TenTaiLieu"].Value.ToString();

            using (frmNhapSLMuonXoa formNhap = new frmNhapSLMuonXoa(soLuongConLai, true))
            {
                if (formNhap.ShowDialog() == DialogResult.OK)
                {
                    int soLuongMuon = formNhap.SoLuong;

                    // Kiểm tra nếu sách đã có trong danh sách mượn => cộng thêm
                    foreach (DataGridViewRow row in dgvSachMuon.Rows)
                    {
                        if (row.Cells["MaSach2"].Value.ToString() == maSach)
                        {
                            int daMuon = int.Parse(row.Cells["SoLuong2"].Value.ToString());

                            // Kiểm tra tổng không vượt quá còn lại
                            if (daMuon + soLuongMuon > soLuongConLai)
                            {
                                MessageBox.Show($"Tổng số lượng mượn vượt quá số sách còn lại ({soLuongConLai})!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            row.Cells["SoLuong2"].Value = daMuon + soLuongMuon;
                            return;
                        }
                    }

                    // Nếu chưa có => thêm mới
                    dgvSachMuon.Rows.Add(maSach, tenSach, soLuongMuon);
                }
            }
        }

        private void dgvSachMuon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (dgvSachMuon.Columns[e.ColumnIndex].Name != "btnXoa") return;

            DataGridViewRow row = dgvSachMuon.Rows[e.RowIndex];
            int soLuongHienTai = int.Parse(row.Cells["SoLuong2"].Value.ToString());

            using (var nhapSoLuongForm = new frmNhapSLMuonXoa(soLuongHienTai, false)) // false = chế độ xóa
            {
                if (nhapSoLuongForm.ShowDialog() == DialogResult.OK)
                {
                    int soLuongMuonXoa = nhapSoLuongForm.SoLuong;

                    int soLuongConLai = soLuongHienTai - soLuongMuonXoa;

                    if (soLuongConLai < 1)
                    {
                        dgvSachMuon.Rows.RemoveAt(e.RowIndex);
                    }
                    else
                    {
                        row.Cells["SoLuong2"].Value = soLuongConLai;
                    }
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string luaChon = cbTimKiem.Text;
            if (string.IsNullOrWhiteSpace(luaChon)) return;

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

            dgvSach.DataSource = sach.Select(p => new {
                MaTaiLieu = "TL" + p.MaTaiLieu,
                p.TenTaiLieu,
                p.DanhMucTaiLieu.TenDanhMuc,
                p.TacGia.TenTG,
                p.NhaXuatBan.TenNXB,
                p.TaiBan,
                CoSan = p.SoLuong - p.SoTaiLieuMuon,
                p.SoLuong,
                p.SoTaiLieuMuon,
                p.MoTa
            }).ToList();

            themNutDGV();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            loadDuLieu();
            themNutDGV();
        }

        private void btnXoaHet_Click(object sender, EventArgs e)
        {
            dgvSachMuon.Rows.Clear();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            string hotenDG = txtHoTen.Text.Trim();
            string emailDG = txtEmail.Text.Trim();
            string sdtDG = txtSDT.Text.Trim();

            if (string.IsNullOrEmpty(hotenDG) || string.IsNullOrEmpty(emailDG))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin độc giả!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvSachMuon.Rows.Count == 0)
            {
                MessageBox.Show("Hãy đăng ký tài liệu để mượn!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
               "Bạn có muốn đăng ký mượn sách không?",
               "Thông báo!",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question
            );

            if (result == DialogResult.No) return;

            QLTVEntities db = new QLTVEntities();
            DocGia docGia = new DocGia();
            docGia.HoTen = hotenDG;
            docGia.Email = emailDG;
            docGia.SDT = sdtDG;
            db.DocGias.Add(docGia);
            db.SaveChanges();

            PhieuMuon phieuMuon = new PhieuMuon();
            phieuMuon.MaDG = docGia.MaDocGia;
            phieuMuon.MaNV = maNV; // ???????????????
            phieuMuon.NgayMuon = DateTime.Now;
            phieuMuon.HanTra = (phieuMuon.NgayMuon ?? DateTime.Now).AddDays(7);
            phieuMuon.DaTra = false;
            phieuMuon.NgayTra = null;
            db.PhieuMuons.Add(phieuMuon);
            db.SaveChanges();

            foreach (DataGridViewRow row in dgvSachMuon.Rows)
            {
                if (row.IsNewRow) continue; // Bỏ qua dòng trống cuối

                string maTLString = row.Cells["MaSach2"].Value.ToString(); // "S5" => bỏ "S"
                int maTL = int.Parse(maTLString.Substring(2)); // Giả sử mã là dạng "S5"

                int soLuong = int.Parse(row.Cells["SoLuong2"].Value.ToString());

                ChiTietPhieuMuon chiTietPM = new ChiTietPhieuMuon();
                chiTietPM.MaPM = phieuMuon.MaPhieu;
                chiTietPM.MaTL = maTL;
                chiTietPM.SoLuong = soLuong;
                db.ChiTietPhieuMuons.Add(chiTietPM);

                TaiLieu tl = db.TaiLieux.Where(p => p.MaTaiLieu == chiTietPM.MaTL).SingleOrDefault();
                tl.SoTaiLieuMuon += chiTietPM.SoLuong;
            }
            db.SaveChanges();

            //db.SaveChanges();
            //NguoiDung nguoiDung = db.NguoiDungs.Where(p => p.ID == frmMainUser.ID).SingleOrDefault();
            //int soLuongMuon = 0;

            //foreach (DataGridViewRow row in dgvSachMuon.Rows)
            //    soLuongMuon += int.Parse(row.Cells["SoLuong2"].Value.ToString());

            //if(soLuongMuon + nguoiDung.SoSachMuon > 10)
            //{
            //    MessageBox.Show("Quá giới hạn sách có thể mượn! (" + soLuongMuon + "/" + (10 - nguoiDung.SoSachMuon.Value) + ")", "Thông báo!"
            //        , MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}


            /*
             Lưu phiếu mượn
             */
            //PhieuMuon phieuMuon = new PhieuMuon();

            //phieuMuon.IDBanDoc = nguoiDung.ID;
            //phieuMuon.NgayDangKyMuon = DateTime.Now;
            //////////////////////////////////
            //// 0: chờ đến thư viện lấy sách
            //// 1: đang mượn
            //// 2: đã trả
            //// -1: quá hạn
            //////////////////////////////////
            //phieuMuon.TrangThai = 0;  
            //db.PhieuMuons.Add(phieuMuon);


            // Tạm tắt event CellValidating để clear dgv
            dgvSachMuon.CellValidating -= dgvSachMuon_CellValidating;
            dgvSachMuon.Rows.Clear();
            dgvSachMuon.CellValidating += dgvSachMuon_CellValidating;

            loadDuLieu();
            MessageBox.Show("Đăng ký mượn thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtEmail.Text = string.Empty;
            txtHoTen.Text = string.Empty;
            txtSDT.Text = string.Empty;
        }

        private void dgvSachMuon_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //if (e.ColumnIndex != 2) return;
            //string soLuong = e.FormattedValue.ToString();
            //if (int.TryParse(soLuong, out int result) && result > 0)
            //{
            //    QLTVEntities db = new QLTVEntities();
            //    int maSach = int.Parse(dgvSachMuon.Rows[e.RowIndex].Cells["MaSach2"].Value.ToString().Substring(1));
            //    Sach sach = db.Saches.Where(p => p.ID == maSach).SingleOrDefault();
            //    if (sach != null && (sach.SoLuong - sach.SoSachMuon) < result)
            //    {
            //        MessageBox.Show("Không đủ số lượng sách!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        e.Cancel = true;
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Số lượng không hợp lệ!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    e.Cancel = true;
            //}
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (this.Owner != null && this.Owner is frmQuanLyPhieuMuon)
            {
                ((frmQuanLyPhieuMuon)this.Owner).loadPhieuMuon();
            }
            this.Close();

        }

        
        private void frmDangKy_FormClosed(object sender, FormClosedEventArgs e)
        {
            loadDuLieuDG();
        }
    }
}
