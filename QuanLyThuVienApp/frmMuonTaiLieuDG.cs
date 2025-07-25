using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        private List<(int, int)> listTL = new List<(int, int)>();
        public frmMuonTaiLieuDG()
        {
            InitializeComponent();
        }
     
        private void frmMuonSach_Load(object sender, EventArgs e)
        {
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
            //int soLuongSachCon = int.Parse(dgvSachMuon.Rows[RowIndex].Cells["SoLuong"].Value.ToString()) - int.Parse(dgvSachMuon.Rows[RowIndex].Cells["SoTaiLieuMuon"].Value.ToString());
            if (listTL.Count == 0) { return; }

            txtMaSach.Text = dgvSachMuon.Rows[RowIndex].Cells["MaTaiLieu"].Value.ToString();
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
                    MessageBox.Show("Đã hết sách!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        //private void dgvSachMuon_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if(e.RowIndex == -1) return;

        //    if (e.ColumnIndex == 2)
        //        dgvSachMuon.BeginEdit(true);
        //    else if (e.ColumnIndex == 3)
        //        dgvSachMuon.Rows.RemoveAt(e.RowIndex);
        //}

        //private void btnTimKiem_Click(object sender, EventArgs e)
        //{
        //    string luaChon = cbTimKiem.Text;
        //    if (luaChon == "") return;

        //    QLTVEntities db = new QLTVEntities();
        //    List<Sach> sach = new List<Sach>();

        //    if (luaChon == "Mã sách")
        //        sach = db.Saches.Where(p => ("S" + p.ID.ToString()).Contains(txtTimKiem.Text)).ToList();
        //    else if (luaChon == "Tên sách")
        //        sach = db.Saches.Where(p => p.TenSach.Contains(txtTimKiem.Text)).ToList();
        //    else if (luaChon == "Tác giả")
        //        sach = db.Saches.Where(p => p.TacGia.TenTG.Contains(txtTimKiem.Text)).ToList();
        //    else if (luaChon == "Nhà xuất bản")
        //        sach = db.Saches.Where(p => p.NhaXuatBan.TenNXB.Contains(txtTimKiem.Text)).ToList();
        //    else if (luaChon == "Thể loại")
        //        sach = db.Saches.Where(p => p.TheLoai.TenTheLoai.Contains(txtTimKiem.Text)).ToList();

        //    dgvSachMuon.DataSource = sach.Select(p => new
        //    {
        //        MaSach = "S" + p.ID,
        //        p.TenSach,
        //        p.TacGia.TenTG,
        //        p.NhaXuatBan.TenNXB,
        //        p.TheLoai.TenTheLoai,
        //        CoSan = p.SoLuong - p.SoSachMuon
        //    }).ToList();
        //}

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            loadDuLieu();
        }

        private void btnXoaHet_Click(object sender, EventArgs e)
        {
            frmTaiLieuDG.taiLieusMuon.Clear();
            listTL.Clear();
            dgvSachMuon.Rows.Clear();
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
        private void btnDangKy_Click(object sender, EventArgs e)
        {
            if (dgvSachMuon.Rows.Count == 0)
            {
                MessageBox.Show("Hãy đăng ký tài liệu để mượn!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string emailDG = txtEmail.Text.Trim();

            if (string.IsNullOrEmpty(emailDG))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!isEmail(emailDG))
            {
                MessageBox.Show("Email không hợp lệ!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            QLTVEntities db = new QLTVEntities();
            DocGia dg = db.DocGias.Where(p => p.Email == emailDG).FirstOrDefault();
            if (dg == null)
            {
                using (frmDangKy frm = new frmDangKy(emailDG))
                {
                    DialogResult resultB = frm.ShowDialog(this);

                    if (!frm.checkDK)
                    {
                        MessageBox.Show("Đăng ký thất bại hoặc đã bị hủy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtEmail.Focus();
                        return;
                    }
                }
            }

            DialogResult result = MessageBox.Show(
               "Bạn có muốn đăng ký mượn sách không?",
               "Thông báo!",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question
           );

            if (result == DialogResult.No) return;

            DocGia DG = db.DocGias.Where(p => p.Email == emailDG).FirstOrDefault();
            PhieuMuon phieuMuon = new PhieuMuon();
            phieuMuon.MaDG = DG.MaDocGia;
            phieuMuon.MaNV = null; // ???????????????
            phieuMuon.NgayMuon = null;
            phieuMuon.HanTra = null;
            phieuMuon.DaTra = false;
            phieuMuon.NgayTra = null;
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
                db.ChiTietPhieuMuons.Add(chiTietPM);

                TaiLieu tl = db.TaiLieux.Where(p => p.MaTaiLieu == chiTietPM.MaTL).SingleOrDefault();
                tl.SoTaiLieuMuon += chiTietPM.SoLuong;
            }
            db.SaveChanges();

            frmTaiLieuDG.taiLieusMuon.Clear();
            listTL.Clear(); 
            //dgvSachMuon.DataSource = listTL; // Ngắt binding
            //dgvSachMuon.Rows.Clear();      // Giờ mới được xóa

            // QLTVEntities db = new QLTVEntities();
            // NguoiDung nguoiDung = db.NguoiDungs.Where(p => p.ID == frmMainUser.ID).SingleOrDefault();
            // int soLuongMuon = 0;

            // foreach (DataGridViewRow row in dgvSachMuon.Rows)
            //     soLuongMuon += int.Parse(row.Cells["SoLuong2"].Value.ToString());

            // if(soLuongMuon + nguoiDung.SoSachMuon > 10)
            // {
            //     MessageBox.Show("Quá giới hạn sách có thể mượn! (" + soLuongMuon + "/" + (10 - nguoiDung.SoSachMuon.Value) + ")", "Thông báo!"
            //         , MessageBoxButtons.OK, MessageBoxIcon.Error);
            //     return;
            // }
            // /*
            //  Lưu phiếu mượn
            //  */
            // PhieuMuon phieuMuon = new PhieuMuon();

            // phieuMuon.IDBanDoc = nguoiDung.ID;
            // phieuMuon.NgayDangKyMuon = DateTime.Now;
            // ////////////////////////////////
            // // 0: chờ đến thư viện lấy sách
            // // 1: đang mượn
            // // 2: đã trả
            // // -1: quá hạn
            // ////////////////////////////////
            // phieuMuon.TrangThai = 0;  
            // db.PhieuMuons.Add(phieuMuon);

            // /*
            //  Lưu phiếu chi tiết, cập nhật số lượng sách
            //  */

            // foreach(DataGridViewRow row in dgvSachMuon.Rows)
            // {
            //     ChiTietPhieuMuon chiTiet = new ChiTietPhieuMuon();
            //     chiTiet.MaPhieu = phieuMuon.MaPhieu;
            //     chiTiet.IDSach = int.Parse(row.Cells["MaSach2"].Value.ToString().Substring(1));
            //     chiTiet.SoLuong = int.Parse(row.Cells["SoLuong2"].Value.ToString());
            //     db.ChiTietPhieuMuons.Add(chiTiet);

            //     Sach sach = db.Saches.Where(p => p.ID == chiTiet.IDSach).SingleOrDefault();
            //     sach.SoSachMuon += chiTiet.SoLuong;
            // }

            // nguoiDung.SoSachMuon += soLuongMuon;
            // db.SaveChanges();

            // // Tạm tắt event CellValidating để clear dgv
            // dgvSachMuon.CellValidating -= dgvSachMuon_CellValidating;
            // dgvSachMuon.Rows.Clear();
            // dgvSachMuon.CellValidating += dgvSachMuon_CellValidating;

            //dgvSachMuon.CellValidating -= dgvSachMuon_CellValidating;
            //dgvSachMuon.Rows.Clear();
            //dgvSachMuon.CellValidating += dgvSachMuon_CellValidating;

            txtEmail.Text = string.Empty;

            loadDuLieu();
            MessageBox.Show("Đăng ký mượn thành công!\nVui lòng đến gặp thủ thư trong vòng 15' để nhận được phiếu mượn," +
                " nếu quá thời gian thì phiếu mượn sẽ tự động bị huỷ!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
