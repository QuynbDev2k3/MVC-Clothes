using Assignments.Iservices;
using Assignments.Models;

namespace Assignments.Services
{
    public class SanPhamServices : ISanPhamServices
    {
        ShoppingDBConText ConText;
        public SanPhamServices()
        {
            ConText = new ShoppingDBConText();
        }
        public bool CreateSanPham(SanPham sp)
        {
            try
            {
                ConText.sanPhams.Add(sp);
                ConText.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteSanPham(Guid id)
        {
            try
            {
                var sanpham = ConText.sanPhams.Find(id);
                ConText.sanPhams.Remove(sanpham);
                ConText.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<SanPham> GetAllSanPham()
        {
            return ConText.sanPhams.ToList();
        }

        public SanPham GetSanPhamById(Guid id)
        {
            return ConText.sanPhams.FirstOrDefault(p => p.SanPhamID == id);
        }

        public List<SanPham> GetSanPhamByName(string name)
        {
            return ConText.sanPhams.Where(p => p.Ten.Contains(name)).ToList();
        }

        public bool UpdateSanPham(SanPham sp)
        {
            try
            {
                var sanpham = ConText.sanPhams.Find(sp.SanPhamID);
                sanpham.Anh = sp.Anh;
                sanpham.Ten = sp.Ten;
                sanpham.Gia = sp.Gia;
                sanpham.SoLuongBanDau = sp.SoLuongBanDau;
                sanpham.NhaCungCap = sp.NhaCungCap;
                sanpham.GhiChu = sp.GhiChu;
                sanpham.TrangThai = sp.TrangThai;
                ConText.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
