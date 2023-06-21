using Assignments.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Assignments.Configurations
{
    public class GioHangConfiguration : IEntityTypeConfiguration<GioHang>
    {
        public void Configure(EntityTypeBuilder<GioHang> builder)
        {
            builder.HasKey(p => p.UserID);
            builder.Property(p => p.GhiChu).HasColumnType("nvarchar(500)").IsRequired();
            builder.HasOne(p => p.User).WithOne(q => q.GioHang);
        }
    }
}
