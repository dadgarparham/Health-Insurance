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

    private static string migrationConnectionString => "Data Source=192.168.11.6,3823;Initial Catalog=Health_InsuranceDB;Persist Security Info=True;User ID=m.ghasemzadeh;password=m@123456;Connection Timeout=60;Max Pool Size=500;";

}

//add-migration -context MigrationDataContext init
//update-database -context MigrationDataContext
//Remove-Migration -context MigrationDataContext
