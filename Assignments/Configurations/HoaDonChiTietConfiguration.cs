using Assignments.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Assignments.Configurations
{
    public class HoaDonChiTietConfiguration : IEntityTypeConfiguration<HoaDonChiTiet>
    {
        public void Configure(EntityTypeBuilder<HoaDonChiTiet> builder)
        {
            builder.HasKey(p => p.HoaDonChiTietID);
            builder.Property(p => p.SoLuong).HasColumnType("int").IsRequired();
            builder.Property(p => p.Gia).HasColumnType("int").IsRequired();
            builder.HasOne(p => p.HoaDon).WithMany(q => q.hoaDonChiTiets).HasForeignKey(p => p.HoaDonID);
            builder.HasOne(p => p.SanPham).WithMany(q => q.hoaDonChiTiets).HasForeignKey(p => p.SanPhamID);
        }
    }
}
