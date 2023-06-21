using Assignments.Iservices;
using Assignments.Models;

namespace Assignments.Services
{
    public class GioHangServices : IGioHangServices
    {
        ShoppingDBConText ConText;
        public GioHangServices()
        {
            ConText = new ShoppingDBConText();
        }
        public bool CreateGioHang(GioHang gh)
        {
            try
            {
                ConText.gioHangs.Add(gh);
                ConText.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteGioHang(Guid id)
        {
            try
            {
                var gioHang = ConText.gioHangs.Find(id);
                ConText.gioHangs.Remove(gioHang);
                ConText.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<GioHang> GetAllGioHang()
        {
            return ConText.gioHangs.ToList();
        }

        public GioHang GetGioHangById(Guid id)
        {
            return ConText.gioHangs.FirstOrDefault(p => p.UserID == id);
        }

        public bool UpdateGioHang(GioHang gh)
        {
            try
            {
                var giohang = ConText.gioHangs.Find(gh.UserID);
                giohang.GhiChu = gh.GhiChu;
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
