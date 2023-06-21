using Assignments.Models;

namespace Assignments.Iservices
{
    public interface IGioHangServices
    {
        // Các phương thức lấy ra sản phẩm
        public List<GioHang> GetAllGioHang();
        public GioHang GetGioHangById(Guid id);

        //public List<GioHang> GetGioHangByName(string name);

        // Phương thức thêm
        public bool CreateGioHang(GioHang gh);
        // Phương thức sửa
        public bool UpdateGioHang(GioHang gh);
        // Phương thức xóa
        public bool DeleteGioHang(Guid id);
    }
}
