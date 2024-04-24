using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Assignments.Models
{
    public class ShoppingDBConText : DbContext
    {
        public ShoppingDBConText() { }
        public ShoppingDBConText(DbContextOptions options) : base(options) { }
        public DbSet<ChucVu> chucVus { get; set; }
        public DbSet<GioHang> gioHangs { get; set; }
        public DbSet<GioHangChiTiet> gioHangChiTiets { get; set; }
        public DbSet<HoaDon> hoaDons { get; set; }
        public DbSet<HoaDonChiTiet> hoaDonChiTiets { get; set; }
        public DbSet<NhanVien> nhanViens { get; set; }
        public DbSet<SanPham> sanPhams { get; set; }
        public DbSet<User> users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=QUY\\SQLEXPRESS;Initial Catalog=Assignments;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
