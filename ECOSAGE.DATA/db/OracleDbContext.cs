using ECOSAGE.DATA.models;
using ECOSAGE.DATA.models.activity;
using ECOSAGE.DATA.models.carbonFootprint;
using Microsoft.EntityFrameworkCore;

namespace ECOSAGE.DATA.db;

public class OracleDbContext : DbContext
{
    public DbSet<Activity> Activities { get; set; }
    public DbSet<CarbonFootprint> CarbonFootprints { get; set; }
    public DbSet<User> Users { get; set; }
    
    public OracleDbContext(DbContextOptions<OracleDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration((new ActivityMapping()));
        modelBuilder.ApplyConfiguration((new CarbonFootprintMapping()));
        modelBuilder.ApplyConfiguration((new UserMapping()));
    }
}