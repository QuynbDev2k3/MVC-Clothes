namespace Assignments.Models
{
    public class GioHangChiTiet
    {
        public Guid GioHangChiTietID { get; set; }
        public Guid UserID { get; set; }
        public Guid SanPhamID { get; set; }
        public int SoLuong { get; set; }
        public virtual SanPham SanPham { get; set; }
        public virtual GioHang GioHang { get; set; }
    }
}
