using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;


namespace QuanLyThuVienApp
{
    public partial class frmMuonTaiLieu : Form
    {
        private string emailDG;
        private int maNV;
        private void ShowLoading()
        {
            progressBar1.Visible = true;
            //progressBar1.MarqueeAnimationSpeed = 30;
            this.UseWaitCursor = true;
        }
        private void HideLoading()
        {
            progressBar1.Visible = false;
            // progressBar1.MarqueeAnimationSpeed = 0;
            this.UseWaitCursor = false;
        }
        public frmMuonTaiLieu()
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
            progressBar1.Visible = false;
            LibraryHelper.KiemTraVaKhoaTaiKhoan();
            QLTVEntities db = new QLTVEntities();
            cbbSDM.DataSource = db.DanhMucTaiLieux.Select(p => p.TenDanhMuc).ToList();
            cbbSNXB.DataSource = db.NhaXuatBans.Select(p => p.TenNXB).ToList();
            cbbSTG.DataSource = db.TacGias.Select(p => p.TenTG).ToList();
            cbbSNXB.SelectedIndex = -1;
            cbbSDM.SelectedIndex = -1;
            cbbSTG.SelectedIndex = -1;
            loadDuLieu();
            themNutDGV();
            btnTTDG.Hide();
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

            if (!dgvTLMuon.Columns.Contains("btnXoa"))
            {
                DataGridViewButtonColumn nutXoa = new DataGridViewButtonColumn();
                nutXoa.HeaderText = "";
                nutXoa.Text = "Xóa";
                nutXoa.Name = "btnXoa";
                nutXoa.Width = 45;
                nutXoa.UseColumnTextForButtonValue = true;

                dgvTLMuon.Columns.Add(nutXoa);
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
                CoSan = p.SoLuong - p.SoTaiLieuMuon,
                p.SoLuong,
                p.SoTaiLieuMuon,
                p.MoTa
            }).ToList();
        }
        private void dgvSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvTaiLieu.Columns[e.ColumnIndex].Name != "btnDangKy") return;

            int soLuongConLai = int.Parse(dgvTaiLieu.Rows[e.RowIndex].Cells["CoSan"].Value.ToString());
            if (soLuongConLai == 0)
            {
                MessageBox.Show("Đã hết sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string maSach = dgvTaiLieu.Rows[e.RowIndex].Cells["MaTaiLieu"].Value.ToString();
            string tenSach = dgvTaiLieu.Rows[e.RowIndex].Cells["TenTaiLieu"].Value.ToString();

            using (frmNhapSLMuonXoa formNhap = new frmNhapSLMuonXoa(soLuongConLai, true))
            {
                if (formNhap.ShowDialog() == DialogResult.OK)
                {
                    int soLuongMuon = formNhap.SoLuong;

                    // Kiểm tra nếu sách đã có trong danh sách mượn => cộng thêm
                    foreach (DataGridViewRow row in dgvTLMuon.Rows)
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
                    dgvTLMuon.Rows.Add(maSach, tenSach, soLuongMuon);
                }
            }
        }

        private void dgvSachMuon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (dgvTLMuon.Columns[e.ColumnIndex].Name != "btnXoa") return;

            DataGridViewRow row = dgvTLMuon.Rows[e.RowIndex];
            int soLuongHienTai = int.Parse(row.Cells["SoLuong2"].Value.ToString());

            using (var nhapSoLuongForm = new frmNhapSLMuonXoa(soLuongHienTai, false)) // false = chế độ xóa
            {
                if (nhapSoLuongForm.ShowDialog() == DialogResult.OK)
                {
                    int soLuongMuonXoa = nhapSoLuongForm.SoLuong;

                    int soLuongConLai = soLuongHienTai - soLuongMuonXoa;

                    if (soLuongConLai < 1)
                    {
                        dgvTLMuon.Rows.RemoveAt(e.RowIndex);
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
                        p.TacGia.TenTG,
                        p.NhaXuatBan.TenNXB,
                        p.DanhMucTaiLieu.TenDanhMuc,
                        p.TaiBan,
                        p.SoLuong,
                        p.SoTaiLieuMuon,
                        CoSan = p.SoLuong - p.SoTaiLieuMuon,
                        p.MoTa
                    }).ToList();
                }
            });

            dgvTaiLieu.DataSource = result;
            themNutDGV();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtSMaTL.Text = string.Empty;
            txtSTenTL.Text = string.Empty;
            cbbSNXB.SelectedIndex = -1;
            cbbSDM.SelectedIndex = -1;
            cbbSTG.SelectedIndex = -1;
            dgvTLMuon.Rows.Clear();
            loadDuLieu();
            themNutDGV();
        }

        private void btnXoaHet_Click(object sender, EventArgs e)
        {
            dgvTLMuon.Rows.Clear();
        }

        private async void btnDangKy_Click(object sender, EventArgs e)
        {
            if (dgvTLMuon.Rows.Count == 0)
            {
                MessageBox.Show("Hãy đăng ký tài liệu để mượn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            emailDG = txtEmail.Text.Trim();

            if (string.IsNullOrEmpty(emailDG))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!isEmail(emailDG))
            {
                MessageBox.Show("Email không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            QLTVEntities db = new QLTVEntities();
            DocGia dg = db.DocGias.Where(p => p.Email == emailDG).FirstOrDefault();
            if (dg == null)
            {
                MessageBox.Show("Vui lòng sử dụng Email được nhà trường cung cấp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }
            else
            {
                btnTTDG.Show();
                if (dg.BiKhoa == true)
                {
                    MessageBox.Show("Email của độc giả đã bị khoá!\nVui lòng mở khoá để có thể mượn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            int? slTaiLieuConLai = 0;
            List<PhieuMuon> phieuMoi = db.PhieuMuons
                .Where(p => p.MaDG == dg.MaDocGia && p.DaTra == false)
                .OrderByDescending(p => p.MaPhieu)
                .ToList();

            slTaiLieuConLai = 0;
            foreach (PhieuMuon ph in phieuMoi)
            {
                slTaiLieuConLai += ph.TongSLMuon;
            }


            int slTaiLieu = 0;
            foreach (DataGridViewRow row in dgvTLMuon.Rows)
            {
                if (row.Cells["SoLuong2"].Value != null)
                {
                    slTaiLieu += Convert.ToInt32(row.Cells["SoLuong2"].Value);
                }
            }

            if (dg.LoaiDG == false)
            {
                if (slTaiLieu > 5)
                {
                    MessageBox.Show("Sinh viên không được mượn vượt quá 5 tài liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (slTaiLieuConLai + slTaiLieu > 5)
                {
                    MessageBox.Show("Sinh viên chỉ được mượn tối đa 5 tài liệu.\nVui lòng hoàn trả bớt tài liệu trước khi tiếp tục mượn thêm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                if (slTaiLieu > 10)
                {
                    MessageBox.Show("Giảng viên không được mượn vượt quá 10 tài liệu mỗi lần mượn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            string OTP = new Random().Next(100000, 999999).ToString();
            ShowLoading();
                await Task.Run(() => GuiEmail.guiEmail(emailDG, "Mã xác thực của bạn là: " + OTP));
            HideLoading();

            using (frmXacThucDG frm = new frmXacThucDG(emailDG, OTP, DateTime.Now))
            {
                var dialogResult = frm.ShowDialog();

                if (dialogResult != DialogResult.OK)
                {
                    MessageBox.Show("Xác thực không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            btnTTDG.Show();
            DialogResult result = MessageBox.Show(
               "Bạn có muốn tạo phiếu mượn này không?",
               "Thông báo",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question
            );

            if (result == DialogResult.No) return;

            PhieuMuon phieuMuon = new PhieuMuon();
            phieuMuon.MaDG = dg.MaDocGia;
            phieuMuon.MaNV = maNV;
            phieuMuon.NgayMuon = DateTime.Now;
            phieuMuon.HanTra = (phieuMuon.NgayMuon ?? DateTime.Now).AddDays(7);
            phieuMuon.DaTra = false;
            phieuMuon.NgayTra = null;
            phieuMuon.NgayTao = DateTime.Now;
            phieuMuon.DaGuiMail = null;
            phieuMuon.TongSLMuon = slTaiLieu;
            db.PhieuMuons.Add(phieuMuon);
            db.SaveChanges();

            foreach (DataGridViewRow row in dgvTLMuon.Rows)
            {
                if (row.IsNewRow) continue; // Bỏ qua dòng trống cuối

                string maTLString = row.Cells["MaSach2"].Value.ToString();
                int maTL = int.Parse(maTLString.Substring(2)); 

                int soLuong = int.Parse(row.Cells["SoLuong2"].Value.ToString());

                ChiTietPhieuMuon chiTietPM = new ChiTietPhieuMuon();
                chiTietPM.MaPM = phieuMuon.MaPhieu;
                chiTietPM.MaTL = maTL;
                chiTietPM.SoLuong = soLuong;
                chiTietPM.SoLuongBD = soLuong;
                db.ChiTietPhieuMuons.Add(chiTietPM);

                TaiLieu tl = db.TaiLieux.Where(p => p.MaTaiLieu == chiTietPM.MaTL).SingleOrDefault();
                tl.SoTaiLieuMuon += chiTietPM.SoLuong;
            }
            db.SaveChanges();

            // Tạm tắt event CellValidating để clear dgv
            dgvTLMuon.Rows.Clear();

            loadDuLieu();
            MessageBox.Show("Tạo phiếu mượn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtEmail.Text = string.Empty;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (this.Owner != null && this.Owner is frmQuanLyPhieuMuon)
            {
                ((frmQuanLyPhieuMuon)this.Owner).loadPhieuMuon();
            }
            this.Close();

        }
        private bool isEmail(string inputEmail)
        {
            inputEmail = inputEmail ?? string.Empty;
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputEmail)) return (true);
            else return (false);
        }

        private void btnTTDG_Click(object sender, EventArgs e)
        {
            QLTVEntities db = new QLTVEntities();
            DocGia dg = db.DocGias.Where(p => p.Email == emailDG).FirstOrDefault();

            foreach (Form form in this.MdiChildren)
                form.Close();
            frmThongTinDocGia frm = new frmThongTinDocGia(dg.MaDocGia);
            frm.ShowDialog();
        }
    }
}
