using Assignments.Models;

namespace Assignments.Iservices
{
    public interface IHoaDonChiTietServices
    {
        // Các phương thức lấy ra sản phẩm
        public List<HoaDonChiTiet> GetAllHoaDonChiTiet();
        public HoaDonChiTiet GetHoaDonChiTietById(Guid id);

        //public List<GioHang> GetGioHangByName(string name);

        // Phương thức thêm
        public bool CreateHoaDonChiTiet(HoaDonChiTiet hdct);
        // Phương thức sửa
        public bool UpdateHoaDonChiTiet(HoaDonChiTiet hdct);
        // Phương thức xóa
        public bool DeleteHoaDonChiTiet(Guid id);
    }
}
