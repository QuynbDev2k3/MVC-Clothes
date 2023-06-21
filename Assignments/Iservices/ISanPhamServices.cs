using Assignments.Models;

namespace Assignments.Iservices
{
    public interface ISanPhamServices
    {
        // Các phương thức lấy ra sản phẩm
        public List<SanPham> GetAllSanPham();
        public SanPham GetSanPhamById(Guid id);

        public List<SanPham> GetSanPhamByName(string name);

        // Phương thức thêm
        public bool CreateSanPham(SanPham sp);
        // Phương thức sửa
        public bool UpdateSanPham(SanPham sp);
        // Phương thức xóa
        public bool DeleteSanPham(Guid id);
    }
}
