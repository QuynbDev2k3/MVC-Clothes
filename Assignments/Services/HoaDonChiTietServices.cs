using Assignments.Iservices;
using Assignments.Models;

namespace Assignments.Services
{
    public class HoaDonChiTietServices : IHoaDonChiTietServices
    {
        ShoppingDBConText ConText;
        public HoaDonChiTietServices()
        {
            ConText = new ShoppingDBConText();
        }
        public bool CreateHoaDonChiTiet(HoaDonChiTiet hdct)
        {
            try
            {
                ConText.hoaDonChiTiets.Add(hdct);
                ConText.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteHoaDonChiTiet(Guid id)
        {
            try
            {
                var hoadonchitiet = ConText.hoaDonChiTiets.Find(id);
                ConText.hoaDonChiTiets.Remove(hoadonchitiet);
                ConText.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<HoaDonChiTiet> GetAllHoaDonChiTiet()
        {
            return ConText.hoaDonChiTiets.ToList();
        }

        public HoaDonChiTiet GetHoaDonChiTietById(Guid id)
        {
            return ConText.hoaDonChiTiets.FirstOrDefault(p => p.HoaDonChiTietID == id);
        }

        public bool UpdateHoaDonChiTiet(HoaDonChiTiet hdct)
        {
            try
            {
                var hoadonchitiet = ConText.hoaDonChiTiets.Find(hdct.HoaDonChiTietID);
                hoadonchitiet.SoLuong = hdct.SoLuong;
                hoadonchitiet.Gia = hdct.Gia;
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
