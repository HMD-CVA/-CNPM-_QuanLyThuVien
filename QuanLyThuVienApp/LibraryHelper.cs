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

            var phieuMuonTreHan = db.PhieuMuons
                .Where(p => p.DaTra == false && p.HanTra.HasValue &&
                            System.Data.Entity.DbFunctions.DiffDays(p.HanTra, DateTime.Now) > 30)
                .ToList();

            foreach (var pm in phieuMuonTreHan)
            {
                var docGia = db.DocGias.FirstOrDefault(dg => dg.MaDocGia == pm.MaDG);

                if (docGia != null && docGia.BiKhoa == false)
                {
                    docGia.BiKhoa = true;
                }
            }
            db.SaveChanges();
        }
    }
}
