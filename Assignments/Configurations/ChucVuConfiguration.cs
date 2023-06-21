using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Assignments.Models;

namespace Assignments.Configurations
{
    public class ChucVuConfiguration : IEntityTypeConfiguration<ChucVu>
    {
        public void Configure(EntityTypeBuilder<ChucVu> builder)
        {
            builder.HasKey(p => p.ChucVuID);
            builder.Property(p => p.Ten).HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(p => p.GhiChu).HasColumnType("nvarchar(500)").IsRequired();
            builder.Property(p => p.TrangThai).HasColumnType("int").IsRequired();
            builder.HasOne(p => p.NhanVien).WithMany(q => q.chucVus).HasForeignKey(p => p.ChucVuID);
        }
    }
}
