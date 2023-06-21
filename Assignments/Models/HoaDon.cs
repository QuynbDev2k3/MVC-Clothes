namespace Assignments.Models
{
    public class HoaDon
    {
        public Guid HoaDonID { get; set; }
        public Guid UserID { get; set; }
        public DateTime NgayTao { get; set; }
        public int TrangThai { get; set; }
        public virtual User User { get; set; }
        public ICollection<HoaDonChiTiet> hoaDonChiTiets { get; set; }
    }
}
