using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVienApp
{
    public static class LibraryHelper
    {
        public static void KiemTraVaKhoaTaiKhoan()
        {
            QLTVEntities db = new QLTVEntities();

            var dgHetHan = db.DocGias.Where(p => p.NgayHetHan < DateTime.Now).ToList();
            foreach ( var dg in dgHetHan )
            {
                dg.BiKhoa = true;
            }

            var phieuMuonTreHan = db.PhieuMuons
                .Where(p => p.DaTra == false && p.HanTra.HasValue).ToList();
            //&& System.Data.Entity.DbFunctions.DiffDays(p.HanTra, DateTime.Now) > 30).ToList();

            foreach (var pm in phieuMuonTreHan)
            {
                int soNgayTre = (DateTime.Now - pm.HanTra.Value).Days;
                int soNgayConLai = (pm.HanTra.Value.Date - DateTime.Now.Date).Days;
                if (soNgayConLai == 5 && pm.DaGuiMail == null)
                {
                    string subject = "THƯ NHẮC NHỞ TRẢ TÀI LIỆU THƯ VIỆN";
                    string body = $"\nXin chào {pm.DocGia.HoTen},\n\n" +
                                    $"Phiếu mượn {"MP" + pm.MaPhieu} của bạn sắp đến hạn trả vào ngày {pm.HanTra.Value.ToString("dd/MM/yyyy")}.\n" +
                                    $"Bạn còn lại {soNgayConLai} ngày để trả trước khi trễ hạn\n" +
                                     "Vui lòng trả tài liệu trước hạn bạn nhé!\n" +
                                     "Xin cảm ơn!";
                    GuiEmail.guiEmail(pm.DocGia.Email, subject + "\n" + body);
                    pm.DaGuiMail = DateTime.Now;
                }
                else
                {
                    if (soNgayTre > 30)
                    {
                        var docGia = db.DocGias.FirstOrDefault(dg => dg.MaDocGia == pm.MaDG);

                        if (docGia != null && docGia.BiKhoa == false)
                        {
                            docGia.BiKhoa = true;
                        }
                    }
                }
            }
            db.SaveChanges();
        }
    }
}
