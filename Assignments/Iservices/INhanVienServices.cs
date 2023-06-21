using Assignments.Models;

namespace Assignments.Iservices
{
    public interface INhanVienServices
    {
        // Các phương thức lấy ra sản phẩm
        public List<NhanVien> GetAllNhanVien();
        public NhanVien GetNhanVienById(Guid id);

        public List<NhanVien> GetNhanVienByName(string name);

        // Phương thức thêm
        public bool CreateNhanVien(NhanVien nv);
        // Phương thức sửa
        public bool UpdateNhanVien(NhanVien nv);
        // Phương thức xóa
        public bool DeleteNhanVien(Guid id);
    }
}
