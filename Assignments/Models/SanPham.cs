namespace Assignments.Models
{
    public class SanPham
    {
        public Guid SanPhamID { get; set; }
        public string Anh { get; set; }
        public string Ten { get; set; }
        public long Gia { get; set; }
        public int SoLuongBanDau { get; set; }
        public string NhaCungCap { get; set; }
        public string GhiChu { get; set; }
        public int TrangThai { get; set; }
        public ICollection<HoaDonChiTiet> hoaDonChiTiets { get; set; }
        public ICollection<GioHangChiTiet> gioHangChiTiets { get; set; }
    }
}
