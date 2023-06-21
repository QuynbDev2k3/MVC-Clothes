using Assignments.Iservices;
using Assignments.Models;

namespace Assignments.Services
{
    public class HoaDonServices : IHoaDonServices
    {
        ShoppingDBConText ConText;
        public HoaDonServices()
        {
            ConText = new ShoppingDBConText();
        }
        public bool CreateHoaDon(HoaDon hd)
        {
            try
            {
                ConText.hoaDons.Add(hd);
                ConText.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteHoaDon(Guid id)
        {
            try
            {
                var hoadon = ConText.hoaDons.Find(id);
                ConText.hoaDons.Remove(hoadon);
                ConText.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<HoaDon> GetAllHoaDon()
        {
            return ConText.hoaDons.ToList();
        }

        public HoaDon GetHoaDonById(Guid id)
        {
            return ConText.hoaDons.FirstOrDefault(p => p.HoaDonID == id);
        }

        public bool UpdateHoaDon(HoaDon hd)
        {
            try
            {
                var hoadon = ConText.hoaDons.Find(hd.HoaDonID);
                hoadon.NgayTao = hd.NgayTao;
                hoadon.TrangThai = hd.TrangThai;
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
