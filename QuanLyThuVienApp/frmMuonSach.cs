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
    public partial class frmMuonSach : Form
    {
        public frmMuonSach()
        {
            InitializeComponent();
        }
     
        private void frmMuonSach_Load(object sender, EventArgs e)
        {
            loadDuLieu();
            themNutDGV();
        }
        private void themNutDGV()
        {
            // Tạo nút đăng ký
            DataGridViewButtonColumn nutDangKy = new DataGridViewButtonColumn();
            nutDangKy.HeaderText = "";
            nutDangKy.Text = "Đăng ký";
            nutDangKy.Name = "btnDangKy";
            nutDangKy.Width = 78;
            nutDangKy.UseColumnTextForButtonValue = true;

            // Tạo nút xóa
            DataGridViewButtonColumn nutXoa = new DataGridViewButtonColumn();
            nutXoa.HeaderText = "";
            nutXoa.Text = "Xóa";
            nutXoa.Name = "btnXoa";
            nutXoa.Width = 45;
            nutXoa.UseColumnTextForButtonValue = true;

            // Thêm nút
            dgvSach.Columns.Add(nutDangKy);
            dgvSachMuon.Columns.Add(nutXoa);
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
                CoSan = p.SoLuong - p.SoTaiLieuMuon,
                p.SoLuong,
                p.SoTaiLieuMuon,
                p.MoTa
            }).ToList();
        }

        private void dgvSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            txtMoTa.Text = dgvSach.Rows[e.RowIndex].Cells["MoTa"].Value.ToString();
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

            using (var nhapSoLuongForm = new frmNhapSLMuonXoa(soLuongHienTai, false)) // true = chế độ xóa
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
            //string luaChon = cbTimKiem.Text;
            //if (luaChon == "") return;

            //QLTVEntities db = new QLTVEntities();
            //List<Sach> sach = new List<Sach>();

            //if (luaChon == "Mã sách")
            //    sach = db.Saches.Where(p => ("S" + p.ID.ToString()).Contains(txtTimKiem.Text)).ToList();
            //else if (luaChon == "Tên sách")
            //    sach = db.Saches.Where(p => p.TenSach.Contains(txtTimKiem.Text)).ToList();
            //else if (luaChon == "Tác giả")
            //    sach = db.Saches.Where(p => p.TacGia.TenTG.Contains(txtTimKiem.Text)).ToList();
            //else if (luaChon == "Nhà xuất bản")
            //    sach = db.Saches.Where(p => p.NhaXuatBan.TenNXB.Contains(txtTimKiem.Text)).ToList();
            //else if (luaChon == "Thể loại")
            //    sach = db.Saches.Where(p => p.TheLoai.TenTheLoai.Contains(txtTimKiem.Text)).ToList();

            //dgvSach.DataSource = sach.Select(p => new
            //{
            //    MaSach = "S" + p.ID,
            //    p.TenSach,
            //    p.TacGia.TenTG,
            //    p.NhaXuatBan.TenNXB,
            //    p.TheLoai.TenTheLoai,
            //    CoSan = p.SoLuong - p.SoSachMuon
            //}).ToList();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            loadDuLieu();
        }

        private void btnXoaHet_Click(object sender, EventArgs e)
        {
            dgvSachMuon.Rows.Clear();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            if (dgvSachMuon.Rows.Count == 0) return;

            DialogResult result = MessageBox.Show(
               "Bạn có muốn đăng ký mượn sách không?",
               "Thông báo!",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question
           );

            if (result == DialogResult.No) return;

            //QLTVEntities db = new QLTVEntities();
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

            /*
             Lưu phiếu chi tiết, cập nhật số lượng sách
             */

            //foreach(DataGridViewRow row in dgvSachMuon.Rows)
            //{
            //    ChiTietPhieuMuon chiTiet = new ChiTietPhieuMuon();
            //    chiTiet.MaPhieu = phieuMuon.MaPhieu;
            //    chiTiet.IDSach = int.Parse(row.Cells["MaSach2"].Value.ToString().Substring(1));
            //    chiTiet.SoLuong = int.Parse(row.Cells["SoLuong2"].Value.ToString());
            //    db.ChiTietPhieuMuons.Add(chiTiet);

            //    Sach sach = db.Saches.Where(p => p.ID == chiTiet.IDSach).SingleOrDefault();
            //    sach.SoSachMuon += chiTiet.SoLuong;
            //}

            //nguoiDung.SoSachMuon += soLuongMuon;
            //db.SaveChanges();

            // Tạm tắt event CellValidating để clear dgv
            dgvSachMuon.CellValidating -= dgvSachMuon_CellValidating;
            dgvSachMuon.Rows.Clear();
            dgvSachMuon.CellValidating += dgvSachMuon_CellValidating;

            loadDuLieu();
            MessageBox.Show("Đăng ký mượn thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
