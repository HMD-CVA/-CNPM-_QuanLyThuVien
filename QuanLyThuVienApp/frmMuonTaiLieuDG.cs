using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVienApp
{
    public partial class frmMuonTaiLieuDG : Form
    {
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
        private List<(int, int)> listTL = new List<(int, int)>();
        public frmMuonTaiLieuDG()
        {
            InitializeComponent();
        }
     
        private void frmMuonSach_Load(object sender, EventArgs e)
        {
            progressBar1.Visible = false;
            LibraryHelper.KiemTraVaKhoaTaiKhoan();
            listTL = frmTaiLieuDG.taiLieusMuon;
            loadDuLieu();
        }
        
        private void loadDuLieu()
        {
            QLTVEntities db = new QLTVEntities();
            var data = db.TaiLieux
            .ToList() // chuyển về bộ nhớ để LINQ to Objects xử lý join
            .Join(
                listTL,
                taiLieu => taiLieu.MaTaiLieu,
                muon => muon.Item1,
                (taiLieu, muon) => new
                {
                    MaTaiLieu = "TL" + taiLieu.MaTaiLieu,
                    taiLieu.TenTaiLieu,
                    taiLieu.DanhMucTaiLieu.TenDanhMuc,
                    taiLieu.TacGia.TenTG,
                    taiLieu.NhaXuatBan.TenNXB,
                    taiLieu.TaiBan,
                    SoLuong = muon.Item2,
                    taiLieu.MoTa,
                }
            ).ToList();

            dgvSachMuon.DataSource = data;
            HienThiDuLieu(0);
        }
        private void HienThiDuLieu(int RowIndex)
        {
            if (listTL.Count == 0) 
            { 
                return; 
            }

            txtMaTL.Text = dgvSachMuon.Rows[RowIndex].Cells["MaTaiLieu"].Value.ToString();
            txtTenSach.Text = dgvSachMuon.Rows[RowIndex].Cells["TenTaiLieu"].Value.ToString();
            txtTacGia.Text = dgvSachMuon.Rows[RowIndex].Cells["TenTG"].Value.ToString();
            txtNXB.Text = dgvSachMuon.Rows[RowIndex].Cells["TenNXB"].Value.ToString();
            txtTheLoai.Text = dgvSachMuon.Rows[RowIndex].Cells["TenDanhMuc"].Value.ToString();
            txtMoTa.Text = dgvSachMuon.Rows[RowIndex].Cells["MoTa"].Value.ToString();
        }
        private void dgvSachMuon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            HienThiDuLieu(e.RowIndex);
            if(e.RowIndex != -1 && dgvSachMuon.Columns[e.ColumnIndex].Name.ToString() == "btnDangKy")
            {
                if(int.Parse(dgvSachMuon.Rows[e.RowIndex].Cells["CoSan"].Value.ToString()) == 0)
                {
                    MessageBox.Show("Đã hết sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string maSach = dgvSachMuon.Rows[e.RowIndex].Cells["MaSach"].Value.ToString();
                string tenSach = dgvSachMuon.Rows[e.RowIndex].Cells["TenSach"].Value.ToString();

                foreach (DataGridViewRow row in dgvSachMuon.Rows)
                {
                    if (row.Cells["MaSach2"].Value.ToString() == maSach)
                    {
                        int soLuong = int.Parse(row.Cells["SoLuong2"].Value.ToString());
                        row.Cells["SoLuong2"].Value = soLuong + 1;
                        return;
                    }
                }

                dgvSachMuon.Rows.Add(maSach, tenSach, 1);
            }
        }
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            loadDuLieu();
        }

        private void btnXoaHet_Click(object sender, EventArgs e)
        {
            frmTaiLieuDG.taiLieusMuon.Clear();
            listTL.Clear();
            loadDuLieu();
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
        private async void btnDangKy_Click(object sender, EventArgs e)
        {
            if (dgvSachMuon.Rows.Count == 0)
            {
                MessageBox.Show("Hãy đăng ký tài liệu để mượn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string emailDG = txtEmail.Text.Trim();

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
            else if (dg.BiKhoa == true)
            {
                MessageBox.Show("Email của bạn đã bị khoá!\nVui lòng liên hệ thủ thư để biết thêm chi tiết!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PhieuMuon pm = db.PhieuMuons
            .Where(p => p.MaDG == dg.MaDocGia &&
                        p.DaTra == false &&
                        p.NgayTra == null &&
                        DbFunctions.TruncateTime(p.HanTra) < DbFunctions.TruncateTime(DateTime.Now))
            .FirstOrDefault();
            if (pm != null)
            {
                MessageBox.Show($"Bạn có phiếu mượn: {"MP" + pm.MaPhieu} trễ hạn chưa trả!\nVui lòng nhắc trả lại để có thể mượn tiếp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
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
            foreach (var item in listTL)
            {
                slTaiLieu += item.Item2;
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

            DialogResult result = MessageBox.Show(
                "Bạn có muốn đăng ký mượn sách không?",
                "Thông báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No) return;

            PhieuMuon phieuMuon = new PhieuMuon();
            phieuMuon.MaDG = dg.MaDocGia;
            phieuMuon.MaNV = null;
            phieuMuon.NgayMuon = null;
            phieuMuon.HanTra = null;
            phieuMuon.DaTra = false;
            phieuMuon.NgayTra = null;
            phieuMuon.NgayTao = DateTime.Now;
            phieuMuon.DaGuiMail = null;
            phieuMuon.TongSLMuon = slTaiLieu;
            db.PhieuMuons.Add(phieuMuon);
            db.SaveChanges();

            // Chưa Add chi tiết phiếu mượn nhe
            foreach (DataGridViewRow row in dgvSachMuon.Rows)
            {
                if (row.IsNewRow) continue; // Bỏ qua dòng trống cuối

                string maTLString = row.Cells["MaTaiLieu"].Value.ToString();
                int maTL = int.Parse(maTLString.Substring(2));

                int soLuong = int.Parse(row.Cells["SoLuong"].Value.ToString());

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

            frmTaiLieuDG.taiLieusMuon.Clear();
            listTL.Clear(); 
            
            txtEmail.Text = string.Empty;

            loadDuLieu();
            MessageBox.Show("Đăng ký mượn thành công!\nVui lòng đến gặp thủ thư trong vòng 15 phút để nhận được phiếu mượn," +
                " nếu quá thời gian thì phiếu mượn sẽ tự động bị huỷ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnXoaSLM_Click(object sender, EventArgs e)
        {
            if (dgvSachMuon.RowCount < 1) return;

            string maSachFull = txtMaTL.Text;
            int maSach = int.Parse(maSachFull.Substring(2));

            int soLuongHienTai = 0;

            foreach (var i in listTL)
            {
                if (i.Item1 == maSach)
                {
                    soLuongHienTai = i.Item2;
                    break;
                }
            }

            QLTVEntities db = new QLTVEntities();
            soLuongHienTai = db.TaiLieux.Where(p => p.MaTaiLieu == maSach).Select(p => p.SoLuong).FirstOrDefault().GetValueOrDefault() - 
                             db.TaiLieux.Where(p => p.MaTaiLieu == maSach).Select(p => p.SoTaiLieuMuon).FirstOrDefault().GetValueOrDefault();

            using (var nhapSoLuongForm = new frmNhapSLMuonXoa(soLuongHienTai)) // false = chế độ xóa
            {
                if (nhapSoLuongForm.ShowDialog() == DialogResult.OK)
                {
                    int soLuong = nhapSoLuongForm.SoLuong;

                    for (int i = 0; i < listTL.Count; i++)
                    {
                        if (listTL[i].Item1 == maSach)
                        {

                            if (soLuong <= 0)
                            {
                                listTL.RemoveAt(i);
                            }
                            else listTL[i] = (listTL[i].Item1, soLuong);
                            break;
                        }
                    }
                }
                else return;
            }
            MessageBox.Show("Đã điều chỉnh thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
           
            loadDuLieu();
            for (int i = 0; i < dgvSachMuon.Rows.Count; i++)
            {
                var ma = dgvSachMuon.Rows[i].Cells["MaTaiLieu"].Value?.ToString();
                if (ma == "TL" + maSach.ToString())
                {
                    frmTaiLieuDG.taiLieusMuon = listTL;
                    HienThiDuLieu(i);
                    return;
                }
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
