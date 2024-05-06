using Health_Insurance.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace Health_Insurance.Data;

public class HealthInsuranceDbContext : DbContext
{
    public HealthInsuranceDbContext(DbContextOptions<HealthInsuranceDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<Coverage> Coverages { get; set; }
    public DbSet<RequestInsurance> RequestsInsurance { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Coverage>()
            .HasKey(c => c.Id);

        modelBuilder.Entity<RequestInsurance>()
            .HasKey(r => r.Id);
         // .HasOne(r => r.Coverage);
         // .WithMany(c => c.RequestsInsurance);
    }
    
}