using Microsoft.EntityFrameworkCore;

namespace Health_Insurance.Data.EntityFramework.Contexts;

public class MigrationDataContext : HealthInsuranceDbContext
{
    public MigrationDataContext() : base(Options)
    {

    }

    private static DbContextOptions Options
    {
        get
        {
            var builder = new DbContextOptionsBuilder();
            builder.UseSqlServer(migrationConnectionString);
            return builder.Options;
        }
    }

    private static string migrationConnectionString => "Data Source=(localdb)\\ProjectModels;Initial Catalog=Health_InsuranceDB;Integrated Security=SSPI;Persist Security Info=True;Trusted_Connection=True;MultipleActiveResultSets=true;Connection Timeout=60;Max Pool Size=500;";
}

//add-migration -context MigrationDataContext init
//update-database -context MigrationDataContext
//Remove-Migration -context MigrationDataContext
