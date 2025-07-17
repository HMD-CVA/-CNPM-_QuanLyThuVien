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
    public partial class frmQuanLySach : Form
    {
        public frmQuanLySach()
        {
            InitializeComponent();
        }

        private void frmQuanLySach_Load(object sender, EventArgs e)
        {
            loadDuLieu();
            radioSuaXoa.Checked = true;
        }

        private void loadDuLieu()
        {
            QLTVEntities db = new QLTVEntities();
            dgvSach.DataSource = db.TaiLieux.Select(p => new {
                MaTaiLieu = "S" + p.MaTaiLieu,
                p.TenTaiLieu,
                p.DanhMucTaiLieu.TenDanhMuc,
                p.TacGia.TenTG,
                p.NhaXuatBan.TenNXB,
                p.TaiBan,
                //p.MoTa,
                p.SoLuong,
                p.SoTaiLieuMuon,
            }).ToList();

            cbTacGia.DataSource = db.TacGias.ToList().Prepend(new TacGia {MaTG = -1, TenTG = "" }).ToList();
            cbTacGia.DisplayMember = "TenTG";
            cbTacGia.ValueMember = "MaTG";

            cbNXB.DataSource = db.NhaXuatBans.ToList().Prepend(new NhaXuatBan { MaNXB = -1, TenNXB = "" }).ToList();
            cbNXB.DisplayMember = "TenNXB";
            cbNXB.ValueMember = "MaNXB";

            cbTheLoai.DataSource = db.DanhMucTaiLieux.ToList().Prepend(new DanhMucTaiLieu { MaDanhMuc = -1, TenDanhMuc = "" }).ToList();
            cbTheLoai.DisplayMember = "TenDanhMuc";
            cbTheLoai.ValueMember = "MaDanhMuc";

            if (radioThem.Checked) return;

            if (dgvSach.Rows.Count > 0)
            {               
                HienThiDuLieu(0);
            }
        }
        private void HienThiDuLieu(int RowIndex)
        {
            QLTVEntities db = new QLTVEntities();

            string tenTheLoai = dgvSach.Rows[RowIndex].Cells[2].Value.ToString();
            string tenTacGia = dgvSach.Rows[RowIndex].Cells[3].Value.ToString();
            string tenNXB = dgvSach.Rows[RowIndex].Cells[4].Value.ToString();
            string maTL = dgvSach.Rows[RowIndex].Cells[0].Value.ToString();

            TacGia tacGia = db.TacGias.Where(p => p.TenTG == tenTacGia).FirstOrDefault();
            NhaXuatBan nxb = db.NhaXuatBans.Where(p => p.TenNXB == tenNXB).FirstOrDefault();
            DanhMucTaiLieu theLoai = db.DanhMucTaiLieux.Where(p => p.TenDanhMuc == tenTheLoai).FirstOrDefault();
            TaiLieu taiLieu = db.TaiLieux.Where(p => "S" + p.MaTaiLieu.ToString() == maTL).FirstOrDefault();

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
            if (e.RowIndex == -1) return;

            if (radioThem.Checked) return;

            HienThiDuLieu(e.RowIndex);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string luaChon = cbTimKiem.Text;
            if (luaChon == "") return;

            QLTVEntities db = new QLTVEntities();
            List<TaiLieu> sach = new List<TaiLieu>();

            if (luaChon == "Mã sách")
                sach = db.TaiLieux.Where(p => ("S" + p.MaTaiLieu.ToString()).Contains(txtTimKiem.Text)).ToList();
            else if (luaChon == "Tên sách")
                sach = db.TaiLieux.Where(p => p.TenTaiLieu.Contains(txtTimKiem.Text)).ToList();
            else if (luaChon == "Tác giả")
                sach = db.TaiLieux.Where(p => p.TacGia.TenTG.Contains(txtTimKiem.Text)).ToList();
            else if (luaChon == "Nhà xuất bản")
                sach = db.TaiLieux.Where(p => p.NhaXuatBan.TenNXB.Contains(txtTimKiem.Text)).ToList();
            else if (luaChon == "Thể loại")
                sach = db.TaiLieux.Where(p => p.DanhMucTaiLieu.TenDanhMuc.Contains(txtTimKiem.Text)).ToList();

            dgvSach.DataSource = sach.Select(p => new
            {
                MaSach = "S" + p.MaTaiLieu,
                p.TenTaiLieu,
                p.DanhMucTaiLieu.TenDanhMuc,
                p.TacGia.TenTG,
                p.NhaXuatBan.TenNXB,
                p.TaiBan,
                //p.MoTa,
                p.SoLuong,
                p.SoTaiLieuMuon,
            }).ToList();

            if (radioThem.Checked) return;

            if (dgvSach.Rows.Count > 0)
            {
                HienThiDuLieu(0);
            }
            else
            {
                txtMaSach.Clear();
                txtTenSach.Clear();
                txtSoLuong.Clear();
                txtDangMuon.Clear();
                cbTacGia.SelectedIndex = 0;
                cbNXB.SelectedIndex = 0;
                cbTheLoai.SelectedIndex = 0;
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            loadDuLieu();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có muốn thêm sách mới không?",
                "Thông báo!",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No) return;

            string tenTG = cbTacGia.Text.ToString();
            string tenNXB = cbNXB.Text.ToString();
            string tenTheLoai = cbTheLoai.Text.ToString();
            string moTa = txtMoTa.Text.ToString();
            string taiBan = txtTaiBan.Text.ToString();
            if (moTa == string.Empty)
            {
                moTa = "Không có mô tả";
            }
            if (taiBan == string.Empty)
            {
                taiBan = "-1";//Take Care
            } 
            if (txtTenSach.Text == "" || tenTG == "" || tenNXB == "" || tenTheLoai == "" || txtSoLuong.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
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

            TaiLieu sach = new TaiLieu();
            sach.TenTaiLieu = txtTenSach.Text;
            sach.MaTG = int.Parse(cbTacGia.SelectedValue.ToString());
            sach.MaNXB = int.Parse(cbNXB.SelectedValue.ToString());
            sach.MaDanhMuc = int.Parse(cbTheLoai.SelectedValue.ToString());
            sach.SoLuong = int.Parse(txtSoLuong.Text);
            sach.SoTaiLieuMuon = 0;
            sach.MoTa = moTa;
            sach.TaiBan = int.Parse(taiBan);

            tacGia.SoLuongTL += 1;
            nhaXuatBan.SoLuongTL += 1;

            db.TaiLieux.Add(sach);
            db.SaveChanges();
            loadDuLieu();
            txtTenSach.Clear();
            txtSoLuong.Clear();
            MessageBox.Show("Thêm sách thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaSach.Text == "") return;

                DialogResult result = MessageBox.Show(
                    "Bạn có muốn sửa thông tin sách không?",
                    "Thông báo!",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
            );

            if (result == DialogResult.No) return;

            string tenTG = cbTacGia.Text.ToString();
            string tenNXB = cbNXB.Text.ToString();
            string tenTheLoai = cbTheLoai.Text.ToString();

            if (txtTenSach.Text == "" || tenTG == "" || tenNXB == "" || tenTheLoai == "" || txtSoLuong.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(!int.TryParse(txtSoLuong.Text, out int val))
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

            int maSach = int.Parse(txtMaSach.Text.Substring(1));
            TaiLieu sach = db.TaiLieux.Where(p => p.MaTaiLieu == maSach).FirstOrDefault();
           
            if (theLoaiMoi.MaDanhMuc != sach.MaDanhMuc)
            {
                //theLoaiMoi.SoMaSach += 1;
                DanhMucTaiLieu theLoaiCu = db.DanhMucTaiLieux.Where(p => p.MaDanhMuc == sach.MaDanhMuc).FirstOrDefault();
                //theLoaiCu.SoMaSach -= 1;
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
            sach.TenTaiLieu = txtTenSach.Text;   
            sach.SoLuong = int.Parse(txtSoLuong.Text);
            sach.MoTa = txtMoTa.Text.ToString();
            sach.TaiBan = int.Parse(txtTaiBan.Text.ToString());

            db.SaveChanges();
            loadDuLieu();
            MessageBox.Show("Sửa sách thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaSach.Text == "") return;

            DialogResult result = MessageBox.Show(
                "Bạn có muốn xóa sách này không?",
                "Thông báo!",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No) return;

            QLTVEntities db = new QLTVEntities();

            //ChiTietPhieuMuon chiTietPhieuMuon = db.ChiTietPhieuMuons.Where(p => "S" + p.IDSach == txtMaSach.Text).FirstOrDefault();
            //if (chiTietPhieuMuon != null)
            //{
            //    MessageBox.Show("Không thể xóa sách đã phát sinh dữ liệu!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            TaiLieu sach = db.TaiLieux.Where(p => "S" + p.MaTaiLieu == txtMaSach.Text).FirstOrDefault();

            TacGia tacGia = db.TacGias.Where(p => p.MaTG == sach.MaTG).FirstOrDefault();
            NhaXuatBan nhaXuatBan = db.NhaXuatBans.Where(p => p.MaNXB == sach.MaNXB).FirstOrDefault();
            DanhMucTaiLieu theLoai = db.DanhMucTaiLieux.Where(p => p.MaDanhMuc == sach.MaDanhMuc).FirstOrDefault();

            tacGia.SoLuongTL -= 1;
            nhaXuatBan.SoLuongTL -= 1;
            //theLoai.SoMaSach -= 1;

            db.TaiLieux.Remove(sach);
            db.SaveChanges();
            loadDuLieu();
            MessageBox.Show("Xóa sách thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            cbTacGia.SelectedIndex = 0;
            cbNXB.SelectedIndex = 0;
            cbTheLoai.SelectedIndex = 0;
        }

        private void radioSuaXoa_CheckedChanged(object sender, EventArgs e)
        {
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
            frmTacGia frm = new frmTacGia();
            frm.ShowDialog();
            loadDuLieu();
        }
        private void btnThemNXB_Click(object sender, EventArgs e)
        {
            frmNXB frm = new frmNXB();
            frm.ShowDialog();
            loadDuLieu();
        }
        private void btnThemTheLoai_Click(object sender, EventArgs e)
        {
            frmDanhMuc frm = new frmDanhMuc();
            frm.ShowDialog();
            loadDuLieu();
        }
    }
}
