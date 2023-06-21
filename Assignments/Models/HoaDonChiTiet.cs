namespace Assignments.Models
{
    public class HoaDonChiTiet
    {
        public Guid HoaDonChiTietID { get; set; }
        public Guid HoaDonID { get; set; }
        public Guid SanPhamID { get; set; }
        public int SoLuong { get; set; }
        public long Gia { get; set; }
        public virtual HoaDon HoaDon { get; set; }
        public virtual SanPham SanPham { get; set; }
    }
}
