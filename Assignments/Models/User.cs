namespace Assignments.Models
{
    public class User
    {
        public Guid UserID { get; set; }
        public string Ten { get; set; }
        public string MatKhau { get; set; }
        public int TrangThai { get; set; }
        public virtual GioHang GioHang { get; set; }
        public ICollection<HoaDon> hoaDons { get; set; }
    }
}
