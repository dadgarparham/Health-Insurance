using Microsoft.EntityFrameworkCore;

namespace Health_Insurance.Data.EntityFramework.Contexts;

public class MigrationDataContext : DataContext
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

    //To Do
    private static string migrationConnectionString => "Data Source=192.168.11.110,3823;Initial Catalog=G2ManualScoringDB;Persist Security Info=True;User ID=ApplicationLogin;password=LFC7UQLjodeW734s4;Connection Timeout=60;Max Pool Size=500;";

}

//add-migration -context MigrationDataContext Financial
//update-database -context MigrationDataContext
//Remove-Migration -context MigrationDataContext
