namespace Assignments.Models
{
    public class ChucVu
    {
        public Guid ChucVuID { get; set; }
        public string Ten { get; set; }
        public string GhiChu { get; set; }
        public int TrangThai { get; set; }
        public virtual NhanVien NhanVien { get; set; }
    }
}
