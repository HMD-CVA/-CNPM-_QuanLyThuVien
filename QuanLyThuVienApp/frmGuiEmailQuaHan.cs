using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;


namespace QuanLyThuVienApp
{
    public partial class frmGuiEmailQuaHan : Form
    {
        private void ShowLoading()
        {
            progressBar1.Visible = true;
            progressBar1.BringToFront();
            this.UseWaitCursor = true;
            Application.DoEvents();
        }

        private void HideLoading()
        {
            progressBar1.Visible = false;
            this.UseWaitCursor = false;
        }
        public frmGuiEmailQuaHan()
        {
            InitializeComponent();
        }
        private void frmQuanLyBanDoc_Load(object sender, EventArgs e)
        {
            LibraryHelper.KiemTraVaKhoaTaiKhoan();
            progressBar1.Visible = false;
            loadDuLieu();
        }
        private void loadDuLieu()
        {
            QLTVEntities db = new QLTVEntities();
            var dsQuaHan = db.PhieuMuons
            .Where(p => p.DaTra == false && p.HanTra.HasValue &&
                    (
                        (p.NgayTra == null && DbFunctions.TruncateTime(p.HanTra) < DbFunctions.TruncateTime(DateTime.Now)) ||
                        (p.NgayTra != null && DbFunctions.TruncateTime(p.HanTra) < DbFunctions.TruncateTime(p.NgayTra))
                    )
            )
            .ToList()
            .Select(p => new
            {
                MaPhieu = "MP" + p.MaPhieu,
                TenDocGia = p.DocGia.HoTen,
                EmailDG = p.DocGia.Email,
                HanTra = p.HanTra.Value,
                SoNgayTre = (DateTime.Now.Date - p.HanTra.Value.Date).Days
            }).ToList();

            dgvQuaHan.DataSource = dsQuaHan;

            // Thêm nút "Gửi Mail" nếu chưa có
            if (!dgvQuaHan.Columns.Contains("btnGuiMail"))
            {
                DataGridViewButtonColumn btnGui = new DataGridViewButtonColumn();
                btnGui.Name = "btnGuiMail";
                btnGui.HeaderText = "";
                btnGui.Text = "Gửi Mail";
                btnGui.UseColumnTextForButtonValue = true;
                dgvQuaHan.Columns.Add(btnGui);
            }
        }    
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtSoNgayTre.Clear();
            txtMaPhieu.Clear();
            txtEmail.Clear();
            txtTen.Clear();
            txtHanTra.Clear();
            txtTimKiem.Clear();
            loadDuLieu();
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string luaChon = cbTimKiem.Text;
            if (luaChon == "") return;

            QLTVEntities db = new QLTVEntities();
            List<PhieuMuon> phieuMuons = new List<PhieuMuon>();

            if (luaChon == "Mã phiếu")
                phieuMuons = db.PhieuMuons.Where(p => p.DaTra == false && p.HanTra.HasValue &&
                       (
                           (p.NgayTra == null && DbFunctions.TruncateTime(p.HanTra) < DbFunctions.TruncateTime(DateTime.Now)) ||
                           (p.NgayTra != null && DbFunctions.TruncateTime(p.HanTra) < DbFunctions.TruncateTime(p.NgayTra))
                       ) && ("MP" + p.MaPhieu.ToString()).Contains(txtTimKiem.Text)
                ).ToList();

            else if (luaChon == "Họ tên độc giả")
                phieuMuons = db.PhieuMuons.Where(p => p.DaTra == false && p.HanTra.HasValue &&
                       (
                           (p.NgayTra == null && DbFunctions.TruncateTime(p.HanTra) < DbFunctions.TruncateTime(DateTime.Now)) ||
                           (p.NgayTra != null && DbFunctions.TruncateTime(p.HanTra) < DbFunctions.TruncateTime(p.NgayTra))
                       ) && (p.DocGia.HoTen.Contains(txtTimKiem.Text))
                ).ToList();

            else if (luaChon == "Email")
                phieuMuons = db.PhieuMuons.Where(p => p.DaTra == false && p.HanTra.HasValue &&
                       (
                           (p.NgayTra == null && DbFunctions.TruncateTime(p.HanTra) < DbFunctions.TruncateTime(DateTime.Now)) ||
                           (p.NgayTra != null && DbFunctions.TruncateTime(p.HanTra) < DbFunctions.TruncateTime(p.NgayTra))
                       ) && (p.DocGia.Email.Contains(txtTimKiem.Text))
                ).ToList();

            else if (luaChon == "Hạn trả")
            {
                DateTime ngayTim;
                if (DateTime.TryParseExact(txtTimKiem.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out ngayTim))
                {
                    phieuMuons = db.PhieuMuons
                        .Where(p => p.DaTra == false && p.HanTra.HasValue &&
                            (
                                (p.NgayTra == null && DbFunctions.TruncateTime(p.HanTra) < DbFunctions.TruncateTime(DateTime.Now)) ||
                                (p.NgayTra != null && DbFunctions.TruncateTime(p.HanTra) < DbFunctions.TruncateTime(p.NgayTra))
                            ) &&
                            DbFunctions.TruncateTime(p.HanTra) == DbFunctions.TruncateTime(ngayTim)
                        )
                        .ToList();
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập ngày hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else return;

            dgvQuaHan.DataSource = phieuMuons.Select(p => new
            {
                MaPhieu = "MP" + p.MaPhieu,
                TenDocGia = p.DocGia.HoTen,
                EmailDG = p.DocGia.Email,
                HanTra = p.HanTra.Value
            }).ToList();

            if (dgvQuaHan.Rows.Count > 0)
            {
                HienThiDuLieu(0);
            }
            else
            {
                txtMaPhieu.Clear();
                txtEmail.Clear();
                txtTen.Clear();
                txtHanTra.Clear();
            }
        }
        private void HienThiDuLieu(int index)
        {
            if (index == -1) return;

            txtMaPhieu.Text = dgvQuaHan.Rows[index].Cells["MaPhieu"].Value.ToString();
            txtEmail.Text = dgvQuaHan.Rows[index].Cells["EmailDG"].Value.ToString();
            txtTen.Text = dgvQuaHan.Rows[index].Cells["TenDocGia"].Value.ToString();
            txtHanTra.Text = ((DateTime)dgvQuaHan.Rows[index].Cells["HanTra"].Value).ToString("dd/MM/yyyy");
            txtSoNgayTre.Text = dgvQuaHan.Rows[index].Cells["SoNgayTre"].Value.ToString();
        }
        private async Task guiEmail(string email, string tenDocGia, string maPhieu, string hanTra)
        {
            int maPhieus = int.Parse(maPhieu.Substring(2));
            frmQuanLyPhieuMuonTreHan frm = new frmQuanLyPhieuMuonTreHan(maPhieus);
            int tienPhat = frm.TienPhat;
            int soNgayTre = frm.SoNgayTre;
            string subject = "THƯ NHẮC NHỞ TRẢ TÀI LIỆU THƯ VIỆN";
            string body =   $"\nXin chào {tenDocGia},\n\n" +
                            $"Phiếu mượn {maPhieu} của bạn đã quá hạn vào ngày {hanTra}.\n" +
                            $"Hiện tại tiền phạt của bạn là: {tienPhat} VNĐ\n";
            if (30 - soNgayTre >= 0)
            {
                body += $"Vui lòng trả tài liệu trong thời gian sớm nhất để tránh phát sinh thêm tiền phạt.\n\n" +
                        $"Xin cảm ơn!\n\n" +
                        $"Chú ý: Nếu trong vòng {30 - soNgayTre} ngày tiếp theo bạn không trả tài liệu thì sẽ bị khoá Email và không thể mượn tài liệu nữa!";
            }
            else
            {
                body += $"Bạn đã bị khoá Email do trễ hạn quá 30 ngày kể từ lúc mượn!\n\n" +
                        $"Vui lòng liên hệ thủ thư để hoàn tất việc trả tài liệu và nộp phí phạt.\nEmail sẽ được mở khoá ngay sau khi thủ tục hoàn tất!\n\n" +
                        $"Xin cảm ơn!";
            }
            await Task.Run(() =>
            {
                GuiEmail.guiEmail(email, subject + "\n" + body);
            });
        }
        private async void dgvBanDoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            if (dgvQuaHan.Rows.Count > 0)
            {
                if (e.RowIndex >= 0 && dgvQuaHan.Columns[e.ColumnIndex].Name != "btnGuiMail")
                {
                    HienThiDuLieu(e.RowIndex);
                    return;
                }
               
                string email = dgvQuaHan.Rows[e.RowIndex].Cells["EmailDG"].Value?.ToString();
                string tenDocGia = dgvQuaHan.Rows[e.RowIndex].Cells["TenDocGia"].Value?.ToString();
                string maPhieu = dgvQuaHan.Rows[e.RowIndex].Cells["MaPhieu"].Value?.ToString();
                string hanTra = dgvQuaHan.Rows[e.RowIndex].Cells["HanTra"].Value?.ToString();

                // (Optional) Đánh dấu đã gửi mail tại đây.
                QLTVEntities db = new QLTVEntities();
                int maPhieus = int.Parse(maPhieu.Substring(2));  // Bỏ "MP" phía trước

                var phieu = db.PhieuMuons.FirstOrDefault(p => p.MaPhieu == maPhieus);
                if (phieu.DaGuiMail != null && (DateTime.Now - phieu.DaGuiMail.Value).TotalDays <= 3)
                {
                    MessageBox.Show("Hệ thống đã ghi nhận việc gửi email tới độc giả này cách đây chưa đầy 3 ngày.\nĐể tránh gửi lặp, vui lòng thử lại sau.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                if (string.IsNullOrEmpty(email))
                {
                    MessageBox.Show("Không có email để gửi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    ShowLoading();
                        await guiEmail(email, tenDocGia, maPhieu, hanTra);
                    HideLoading();

                    phieu.DaGuiMail = DateTime.Now;
                    db.SaveChanges();
                    MessageBox.Show($"Đã gửi email tới {email} thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Gửi email thất bại.\nChi tiết: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                txtMaPhieu.Clear();
                txtEmail.Clear();
                txtTen.Clear();
                txtHanTra.Clear();
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void btnGuiEmailAll_Click(object sender, EventArgs e)
        {
            bool ok = true;

            ShowLoading();

            QLTVEntities db = new QLTVEntities();

            //Gom nhóm theo Email
            var emailGroups = dgvQuaHan.Rows
                .Cast<DataGridViewRow>()
                .Where(row => row.Cells["EmailDG"].Value != null)
                .GroupBy(row => row.Cells["EmailDG"].Value.ToString())
                .ToList();

            foreach (var group in emailGroups)
            {
                string email = group.Key;
                string tenDocGia = group.First().Cells["TenDocGia"].Value.ToString();

                //Gom các mã phiếu chưa gửi mail (theo điều kiện 3 days)
                List<(string MaPhieu, string HanTra)> danhSachTreHan = new List<(string, string)>();

                foreach (var row in group)
                {
                    string maPhieu = row.Cells["MaPhieu"].Value.ToString();
                    string hanTra = row.Cells["HanTra"].Value.ToString();

                    int maPhieuInt = int.Parse(maPhieu.Substring(2)); // Bỏ 'MP'
                    var phieu = db.PhieuMuons.FirstOrDefault(p => p.MaPhieu == maPhieuInt);

                    if (phieu != null && phieu.DaGuiMail.HasValue && (DateTime.Now - phieu.DaGuiMail.Value).TotalDays <= 3)
                    {
                        ok = false;
                        continue; // Bỏ qua gửi mail cho phiếu này
                    }

                    danhSachTreHan.Add((maPhieu, hanTra));
                }

                if (danhSachTreHan.Count > 0)
                {
                    string noiDung = $"Xin chào {tenDocGia},\n\nBạn đang có các phiếu mượn quá hạn sau:\n";

                    int tongCP = 0;
                    string cacPhieuQuaHan = string.Empty;

                    foreach (var item in danhSachTreHan)
                    {
                        int maPhieus = int.Parse(item.MaPhieu.Substring(2));
                        frmQuanLyPhieuMuonTreHan frm = new frmQuanLyPhieuMuonTreHan(maPhieus);
                        int tienPhat = frm.TienPhat;
                        int soNgayTre = frm.SoNgayTre;
                        noiDung += $"- Mã Phiếu: {item.MaPhieu} | Hạn trả: {item.HanTra} | Tiền phạt: {tienPhat} VNĐ"; 
                        if (30 - soNgayTre >= 0)
                        {
                            noiDung += $" | Số ngày còn lại: {30 - soNgayTre} ngày\n";
                        }
                        else
                        {
                            noiDung += $" | Số ngày còn lại: {0}\n";
                            cacPhieuQuaHan += item.MaPhieu + " ";
                        }
                        tongCP += tienPhat;
                    }

                    if (string.IsNullOrEmpty(cacPhieuQuaHan))
                    {
                        noiDung += $"\nTổng chi phí là: {tongCP} VNĐ" +
                                   $"\nVui lòng sớm trả tài liệu sớm hơn \"Số ngày còn lại\"\n" +
                                    "Chú ý: Nếu không trả tài liệu sớm hơn \"Số ngày còn lại\" tài liệu thì bạn sẽ bị khoá Email và không thể mượn tài liệu nữa!";
                    }
                    else
                    {
                        noiDung += $"\nTổng chi phí là: {tongCP} VNĐ" +
                                   $"\nBạn đã bị khoá Email do đã quá hạn trả 30 ngày cho phiếu mượn: {cacPhieuQuaHan}\n\n" +
                                   "Vui lòng liên hệ thủ thư để hoàn tất việc trả tài liệu và nộp phí phạt.\nEmail sẽ được mở khoá ngay sau khi thủ tục hoàn tất!\n\n" +
                                   "Xin cảm ơn!";
                    }
                    
                    string subject = "THƯ NHẮC NHỞ TRẢ TÀI LIỆU THƯ VIỆN";
                    string body = noiDung;

                    
                    // Gửi Email 1 lần
                    await Task.Run(() =>
                    {
                        GuiEmail.guiEmail(email, subject + "\n" + body);
                    });

                    // Cập nhật DaGuiMail cho các phiếu đã gửi
                    foreach (var item in danhSachTreHan)
                    {
                        int maPhieuInt = int.Parse(item.MaPhieu.Substring(2));
                        var phieu = db.PhieuMuons.FirstOrDefault(p => p.MaPhieu == maPhieuInt);
                        if (phieu != null)
                        {
                            phieu.DaGuiMail = DateTime.Now;
                        }
                    }
                    db.SaveChanges();
                }
            }

            HideLoading();
            if (ok) MessageBox.Show($"Đã gửi email tới tất cả độc giả thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Hệ thống chỉ gửi email nhắc nhở tới những độc giả có phiếu mượn trễ hạn mà lần gửi gần nhất đã cách đây hơn 3 ngày.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
