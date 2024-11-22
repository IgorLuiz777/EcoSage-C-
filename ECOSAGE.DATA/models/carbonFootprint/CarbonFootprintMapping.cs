using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECOSAGE.DATA.models.carbonFootprint
{
    public class CarbonFootprintMapping : IEntityTypeConfiguration<CarbonFootprint>
    {
        public void Configure(EntityTypeBuilder<CarbonFootprint> builder)
        {
            builder.ToTable("ECOSAGE_CARBONFOOTPRINT");

            builder.HasKey(c => c.CarbonFootprintId);

            builder.HasOne(c => c.User)
                .WithMany(u => u.CarbonFootprints)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.Activities)
                .WithOne(a => a.CarbonFootprint)
                .HasForeignKey(a => a.CarbonFootprintId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(c => c.TimeStamp).IsRequired();
            builder.Property(c => c.TotalEmission).HasColumnType("decimal(18,2)");
        }
    }
}