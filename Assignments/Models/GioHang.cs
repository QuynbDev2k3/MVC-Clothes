namespace Assignments.Models
{
    public class GioHang
    {
        public Guid UserID { get; set; }
        public string GhiChu { get; set; }
        public virtual User User { get; set; }
        public ICollection<GioHangChiTiet> gioHangChiTiets { get; set; }
    }
}
