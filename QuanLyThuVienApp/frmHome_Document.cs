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
    public partial class frmHome_Document : Form
    {
        public frmHome_Document()
        {
            InitializeComponent();
        }
        private void loadDuLieu()
        {
            DB_Test db = new DB_Test();
            dgvSach.DataSource = db.Saches.Select(p => new {
                MaSach = "S" + p.ID,
                p.TenSach,
                p.TacGia.TenTG,
                p.NhaXuatBan.TenNXB,
                p.TheLoai.TenTheLoai,
                p.SoLuong,
                p.SoSachMuon,
            }).ToList();

            cbTacGia.DataSource = db.TacGias.ToList().Prepend(new TacGia { MaTG = -1, TenTG = "" }).ToList();
            cbTacGia.DisplayMember = "TenTG";
            cbTacGia.ValueMember = "MaTG";

            cbNXB.DataSource = db.NhaXuatBans.ToList().Prepend(new NhaXuatBan { MaNXB = -1, TenNXB = "" }).ToList();
            cbNXB.DisplayMember = "TenNXB";
            cbNXB.ValueMember = "MaNXB";

            cbTheLoai.DataSource = db.TheLoais.ToList().Prepend(new TheLoai { MaTheLoai = -1, TenTheLoai = "" }).ToList();
            cbTheLoai.DisplayMember = "TenTheLoai";
            cbTheLoai.ValueMember = "MaTheLoai";

            //if (radioThem.Checked) return;

            if (dgvSach.Rows.Count > 0)
            {
                string tenTacGia = dgvSach.Rows[0].Cells[2].Value.ToString();
                string tenNXB = dgvSach.Rows[0].Cells[3].Value.ToString();
                string tenTheLoai = dgvSach.Rows[0].Cells[4].Value.ToString();

                TacGia tacGia = db.TacGias.Where(p => p.TenTG == tenTacGia).FirstOrDefault();
                NhaXuatBan nxb = db.NhaXuatBans.Where(p => p.TenNXB == tenNXB).FirstOrDefault();
                TheLoai theLoai = db.TheLoais.Where(p => p.TenTheLoai == tenTheLoai).FirstOrDefault();

                txtMaSach.Text = dgvSach.Rows[0].Cells[0].Value.ToString();
                txtTenSach.Text = dgvSach.Rows[0].Cells[1].Value.ToString();
                txtSoLuong.Text = dgvSach.Rows[0].Cells[5].Value.ToString();
                txtDangMuon.Text = dgvSach.Rows[0].Cells[6].Value.ToString();
                cbTacGia.SelectedValue = tacGia.MaTG;
                cbNXB.SelectedValue = nxb.MaNXB;
                cbTheLoai.SelectedValue = theLoai.MaTheLoai;
            }
        }
        private void frmHome_Document_Load(object sender, EventArgs e)
        {
            loadDuLieu();
        }

        private void dgvSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            //if (radioThem.Checked) return;

            DB_Test db = new DB_Test();

            string tenTacGia = dgvSach.Rows[e.RowIndex].Cells[2].Value.ToString();
            string tenNXB = dgvSach.Rows[e.RowIndex].Cells[3].Value.ToString();
            string tenTheLoai = dgvSach.Rows[e.RowIndex].Cells[4].Value.ToString();

            TacGia tacGia = db.TacGias.Where(p => p.TenTG == tenTacGia).FirstOrDefault();
            NhaXuatBan nxb = db.NhaXuatBans.Where(p => p.TenNXB == tenNXB).FirstOrDefault();
            TheLoai theLoai = db.TheLoais.Where(p => p.TenTheLoai == tenTheLoai).FirstOrDefault();

            txtMaSach.Text = dgvSach.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtTenSach.Text = dgvSach.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtSoLuong.Text = dgvSach.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtDangMuon.Text = dgvSach.Rows[e.RowIndex].Cells[6].Value.ToString();
            cbTacGia.SelectedValue = tacGia.MaTG;
            cbNXB.SelectedValue = nxb.MaNXB;
            cbTheLoai.SelectedValue = theLoai.MaTheLoai;
        }
    }
}
