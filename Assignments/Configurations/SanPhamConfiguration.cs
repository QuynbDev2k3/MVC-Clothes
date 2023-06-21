using Assignments.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Assignments.Configurations
{
    public class SanPhamConfiguration : IEntityTypeConfiguration<SanPham>
    {
        public void Configure(EntityTypeBuilder<SanPham> builder)
        {
            builder.HasKey(p => p.SanPhamID);
            builder.Property(p => p.Anh).HasColumnType("nvarchar(100)").IsRequired();
            builder.Property(p => p.Ten).HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(p => p.Gia).HasColumnType("int").IsRequired();
            builder.Property(p => p.SoLuongBanDau).HasColumnType("int").IsRequired();
            builder.Property(p => p.NhaCungCap).HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(p => p.GhiChu).HasColumnType("nvarchar(500)").IsRequired();
            builder.Property(p => p.TrangThai).HasColumnType("int").IsRequired();
        }
    }
}
