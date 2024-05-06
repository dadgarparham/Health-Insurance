using Health_Insurance.Domain.Entities.File;
using Microsoft.EntityFrameworkCore;
namespace Health_Insurance.Data.EntityFramework.Contexts;
public class BaseDbContext : DbContext
{
    public BaseDbContext(DbContextOptions options) : base(options)
    {

    }

    public override int SaveChanges()
    {
        var baseEntries = ChangeTracker
            .Entries()
            .Where(x => x.Entity is IEntity && x.State is EntityState.Added or EntityState.Modified);

        foreach (var entry in baseEntries)
        {
            if (entry.Entity is IEntity entity)
            {
                if (entry.State == EntityState.Added)
                {
                    //entity.CreatedTime = DateTime.Now;
                    //entity.IsDeleted = false;
                }

                if (entry.State == EntityState.Modified) { }
            }
        }
        return base.SaveChanges();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
        var baseEntries = ChangeTracker
            .Entries()
            .Where(x => x.Entity is IEntity && x.State is EntityState.Added or EntityState.Modified);

        foreach (var entry in baseEntries)
        {
            if (entry.Entity is IEntity entity)
            {
                if (entry.State == EntityState.Added)
                {
                    //entity.CreatedTime = DateTime.Now;
                    //entity.IsDeleted = false;
                }

                if (entry.State == EntityState.Modified) { }
            }
        }
        return await base.SaveChangesAsync(cancellationToken);
    }

    public void SetModified<TEntity>(TEntity item) where TEntity : IEntity
    {
        var entityInDb = Find(typeof(TEntity), item.Id);
        if (entityInDb != null)
        {
            Entry(entityInDb).CurrentValues.SetValues(item);
            Entry(entityInDb).State = EntityState.Modified;
        }
    }
    public async Task SetModifiedAsync<TEntity>(TEntity item) where TEntity : IEntity
    {
        var entityInDb = await FindAsync(typeof(TEntity), item.Id);
        if (entityInDb != null)
        {
            Entry(entityInDb).CurrentValues.SetValues(item);
            Entry(entityInDb).State = EntityState.Modified;
        }
    }
}