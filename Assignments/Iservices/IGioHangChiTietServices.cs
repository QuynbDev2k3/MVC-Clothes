using Assignments.Models;

namespace Assignments.Iservices
{
    public interface IGioHangChiTietServices
    {
        // Các phương thức lấy ra sản phẩm
        public List<GioHangChiTiet> GetAllGioHangChiTiet();
        public GioHangChiTiet GetGioHangChiTietById(Guid id);

        //public List<GioHangChiTiet> GetGioHangChiTietByName(string name);

        // Phương thức thêm
        public bool CreateGioHangChiTiet(GioHangChiTiet ghct);
        // Phương thức sửa
        public bool UpdateGioHangChiTiet(GioHangChiTiet ghct);
        // Phương thức xóa
        public bool DeleteGioHangChiTiet(Guid id);
    }
}
