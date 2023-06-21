using Assignments.Iservices;
using Assignments.Models;

namespace Assignments.Services
{
    public class NhanVienServices : INhanVienServices
    {
        ShoppingDBConText ConText;
        public NhanVienServices()
        {
            ConText = new ShoppingDBConText();
        }
        public bool CreateNhanVien(NhanVien nv)
        {
            try
            {
                ConText.nhanViens.Add(nv);
                ConText.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteNhanVien(Guid id)
        {
            try
            {
                var nhanvien = ConText.nhanViens.Find(id);
                ConText.nhanViens.Remove(nhanvien);
                ConText.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<NhanVien> GetAllNhanVien()
        {
            return ConText.nhanViens.ToList();
        }

        public NhanVien GetNhanVienById(Guid id)
        {
            return ConText.nhanViens.FirstOrDefault(p => p.NhanVienID == id);
        }

        public List<NhanVien> GetNhanVienByName(string name)
        {
            return ConText.nhanViens.Where(p => p.Ten.Contains(name)).ToList();
        }

        public bool UpdateNhanVien(NhanVien nv)
        {
            try
            {
                var nhanvien = ConText.nhanViens.Find(nv.ChucVuID);
                nhanvien.Ten = nv.Ten;
                nhanvien.MatKhau = nv.MatKhau;
                nhanvien.TrangThai = nv.TrangThai;
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
