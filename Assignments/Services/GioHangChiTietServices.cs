using Assignments.Iservices;
using Assignments.Models;

namespace Assignments.Services
{
    public class GioHangChiTietServices : IGioHangChiTietServices
    {
        ShoppingDBConText ConText;
        public GioHangChiTietServices()
        {
            ConText = new ShoppingDBConText();
        }
        public bool CreateGioHangChiTiet(GioHangChiTiet ghct)
        {
            try
            {
                ConText.gioHangChiTiets.Add(ghct);
                ConText.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteGioHangChiTiet(Guid id)
        {
            try
            {
                var gioHangChiTiet = ConText.gioHangChiTiets.Find(id);
                ConText.gioHangChiTiets.Remove(gioHangChiTiet);
                ConText.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<GioHangChiTiet> GetAllGioHangChiTiet()
        {
            return ConText.gioHangChiTiets.ToList();
        }

        public GioHangChiTiet GetGioHangChiTietById(Guid id)
        {
            return ConText.gioHangChiTiets.FirstOrDefault(p => p.GioHangChiTietID == id);
        }

        public bool UpdateGioHangChiTiet(GioHangChiTiet ghct)
        {
            try
            {
                var giohangchitiet = ConText.gioHangChiTiets.Find(ghct.GioHangChiTietID);
                giohangchitiet.SoLuong = ghct.SoLuong;
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
