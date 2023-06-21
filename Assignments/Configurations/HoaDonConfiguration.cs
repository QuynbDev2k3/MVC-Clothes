using Assignments.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Assignments.Configurations
{
    public class HoaDonConfiguration : IEntityTypeConfiguration<HoaDon>
    {
        public void Configure(EntityTypeBuilder<HoaDon> builder)
        {
            builder.HasKey(p => p.HoaDonID);
            builder.Property(p => p.NgayTao).HasColumnType("DateTime").IsRequired();
            builder.Property(p => p.TrangThai).HasColumnType("int").IsRequired();
            builder.HasOne(p => p.User).WithMany(q => q.hoaDons).HasForeignKey(p => p.UserID);
        }
    }
}
