using Assignments.Models;

namespace Assignments.Iservices
{
    public interface IHoaDonServices
    {
        // Các phương thức lấy ra sản phẩm
        public List<HoaDon> GetAllHoaDon();
        public HoaDon GetHoaDonById(Guid id);

        //public List<GioHang> GetGioHangByName(string name);

        // Phương thức thêm
        public bool CreateHoaDon(HoaDon hd);
        // Phương thức sửa
        public bool UpdateHoaDon(HoaDon hd);
        // Phương thức xóa
        public bool DeleteHoaDon(Guid id);
    }
}
