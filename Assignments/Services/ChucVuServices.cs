using Assignments.Iservices;
using Assignments.Models;

namespace Assignments.Services
{
    public class ChucVuServices : IChucVuServices
    {
        ShoppingDBConText ConText;
        public ChucVuServices() 
        { 
            ConText = new ShoppingDBConText();
        }

        public bool CreateChucVu(ChucVu cv)
        {
            try
            {
                ConText.chucVus.Add(cv);
                ConText.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteChucVu(Guid id)
        {
            try
            {
                var chucvu = ConText.chucVus.Find(id);
                ConText.chucVus.Remove(chucvu);
                ConText.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<ChucVu> GetAllChucVu()
        {
            return ConText.chucVus.ToList();
        }

        public ChucVu GetChucVuById(Guid id)
        {
            return ConText.chucVus.FirstOrDefault(p => p.ChucVuID == id);
        }

        public List<ChucVu> GetChucVuByName(string name)
        {
            return ConText.chucVus.Where(p => p.Ten.Contains(name)).ToList();
        }

        public bool UpdateChucVu(ChucVu cv)
        {
            try
            {
                var chucvu = ConText.chucVus.Find(cv.ChucVuID);
                chucvu.Ten = cv.Ten;
                chucvu.GhiChu = cv.GhiChu;
                chucvu.TrangThai = cv.TrangThai;
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
