using Assignments.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Assignments.Configurations
{
    public class GioHangChiTietConfiguration : IEntityTypeConfiguration<GioHangChiTiet>
    {
        public void Configure(EntityTypeBuilder<GioHangChiTiet> builder)
        {
            builder.HasKey(p => p.GioHangChiTietID);
            builder.Property(p => p.SoLuong).HasColumnType("int").IsRequired();
            builder.HasOne(p => p.GioHang).WithMany(q => q.gioHangChiTiets).HasForeignKey(p => p.UserID);
            builder.HasOne(p => p.SanPham).WithMany(q => q.gioHangChiTiets).HasForeignKey(p => p.SanPhamID);
        }
    }
}
