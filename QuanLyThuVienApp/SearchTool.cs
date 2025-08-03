using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;

namespace QuanLyThuVienApp
{
    public static class SearchTool
    {
        private static MemoryCache _cache = MemoryCache.Default;
        
        // Generic Search Method for any Entity
        public static List<T> SearchWithCache<T>(string cacheKey, Func<List<T>> queryFunc, int cacheMinutes = 5)
        {
            if (_cache.Contains(cacheKey))
                return (List<T>)_cache.Get(cacheKey);

            var result = queryFunc();

            CacheItemPolicy policy = new CacheItemPolicy
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(cacheMinutes)
            };

            _cache.Add(cacheKey, result, policy);

            return result;
        }
        public static IQueryable<DanhMucTaiLieu> FilterDanhMucTaiLieu(QLTVEntities db, string maDanhMuc, string tenDanhMuc)
        {
            var query = db.DanhMucTaiLieux.AsQueryable();

            // Tìm theo Mã Danh Mục (có thể nhập DM123 hoặc chỉ số 123)
            if (!string.IsNullOrEmpty(maDanhMuc))
            {
                string maDMNumericPart = maDanhMuc.Replace("DM", "").Trim();
                if (int.TryParse(maDMNumericPart, out int maDMInt))
                {
                    query = query.Where(p => p.MaDanhMuc == maDMInt);
                }
            }

            // Tìm theo Tên Danh Mục
            if (!string.IsNullOrEmpty(tenDanhMuc))
                query = query.Where(p => p.TenDanhMuc.Contains(tenDanhMuc));

            return query;
        }

        public static IQueryable<TacGia> FilterDocGia(QLTVEntities db, string maTacGia, string TenTG)
        {
            var query = db.TacGias.AsQueryable();

            // Lọc theo Mã Độc Giả (có thể nhập dạng DG123 hoặc số 123)
            if (!string.IsNullOrEmpty(maTacGia))
            {
                string maTGNumericPart = maTacGia.Replace("TG", "").Trim();
                if (int.TryParse(maTGNumericPart, out int maTGInt))
                {
                    query = query.Where(p => p.MaTG == maTGInt);
                }
            }

            // Lọc theo Họ Tên
            if (!string.IsNullOrEmpty(TenTG))
                query = query.Where(p => p.TenTG.Contains(TenTG));

            return query;
        }
        public static IQueryable<NhaXuatBan> FilterNhaXuatBan(QLTVEntities db, string maNXB, string tenNXB)
        {
            var query = db.NhaXuatBans.AsQueryable();

            // Tìm theo Mã NXB (có thể nhập NXB123 hoặc chỉ số 123)
            if (!string.IsNullOrEmpty(maNXB))
            {
                string maNXBNumericPart = maNXB.Replace("NXB", "").Trim();
                if (int.TryParse(maNXBNumericPart, out int maNXBInt))
                {
                    query = query.Where(p => p.MaNXB == maNXBInt);
                }
            }

            // Tìm theo Tên NXB
            if (!string.IsNullOrEmpty(tenNXB))
                query = query.Where(p => p.TenNXB.Contains(tenNXB));

            return query;
        }

        // Dynamic Filter for TaiLieu
        public static IQueryable<TaiLieu> FilterTaiLieu(QLTVEntities db, string maTaiLieu, string tenTaiLieu, string tenTG, string tenNXB, string theLoai)
        {
            var query = db.TaiLieux.AsQueryable();

            if (!string.IsNullOrEmpty(maTaiLieu))
            {
                string maTLNumericPart = maTaiLieu.Replace("TL", "").Trim();
                if (int.TryParse(maTLNumericPart, out int maTLInt))
                {
                    query = query.Where(p => p.MaTaiLieu == maTLInt);
                }
            }

            if (!string.IsNullOrEmpty(tenTaiLieu))
                query = query.Where(p => p.TenTaiLieu.Contains(tenTaiLieu));

            if (!string.IsNullOrEmpty(tenTG))
                query = query.Where(p => p.TacGia.TenTG.Contains(tenTG));

            if (!string.IsNullOrEmpty(tenNXB))
                query = query.Where(p => p.NhaXuatBan.TenNXB.Contains(tenNXB));

            if (!string.IsNullOrEmpty(theLoai))
                query = query.Where(p => p.DanhMucTaiLieu.TenDanhMuc.Contains(theLoai));

            return query;
        }

    }
}
