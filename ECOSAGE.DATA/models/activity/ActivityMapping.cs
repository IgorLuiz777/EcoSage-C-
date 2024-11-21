using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECOSAGE.DATA.models.activity
{
    public class ActivityMapping : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {   
            builder.ToTable("ECOSAGE_ACTIVITY");

            builder.HasKey(a => a.ActivityId);

            builder.HasOne(a => a.User)
                .WithMany(u => u.Activities)
                .HasForeignKey(a => a.UserId);

            builder.HasOne(a => a.CarbonFootprint)
                .WithMany(c => c.Activities)
                .HasForeignKey(a => a.CarbonFootprintId);
            
            builder.HasIndex(a => a.UserId);

            builder.HasIndex(a => a.CarbonFootprintId);

            builder.Property(a => a.CarbonFootprintId)
                .IsRequired();
            
            builder.Property(a => a.Name)
                .IsRequired()   
                .HasMaxLength(100);

            builder.Property(a => a.Category)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(a => a.Description)
                .HasMaxLength(500);

            builder.Property(a => a.Emission)
                .HasColumnType("decimal(18,2)");
        }
    }
}