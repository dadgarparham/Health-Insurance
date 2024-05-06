using Health_Insurance.Domain.Entities.InsuranceTreatment;
using Microsoft.EntityFrameworkCore;

namespace Health_Insurance.Data.EntityFramework.Contexts
{
    public class DataContext : BaseDbContext
    {
        public DataContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<InsuranceEntity> Files { get; set; }
    }
}
