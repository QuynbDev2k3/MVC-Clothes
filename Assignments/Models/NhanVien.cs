namespace Assignments.Models
{
    public class NhanVien
    {
        public Guid NhanVienID { get; set; }
        public Guid ChucVuID { get; set; }
        public string Ten { get; set; }
        public string MatKhau { get; set; }
        public int TrangThai { get; set; }
        public ICollection<ChucVu> chucVus { get; set; }
    }
}
