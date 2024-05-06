using Health_Insurance.Data.EntityFramework.Contexts;
using Health_Insurance.Domain.Entities.Base;
using Health_Insurance.Domain.Entities.File;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Health_Insurance.Data;
public abstract class BaseEntityService<TEntity> : IBaseEntityService<TEntity> where TEntity : class, IEntity
{
    private readonly BaseDbContext _context;

    protected BaseEntityService(BaseDbContext context)
    {
        _context = context;
    }

    private DbSet<TEntity> EntitySet()
    {
        return _context.Set<TEntity>();
    }

    public TEntity? Find(params object[] keys)
    {
        var foundedItem = EntitySet().Find(keys);

        return foundedItem;
    }
    public async Task<TEntity?> FindAsync(params object[] keys)
    {
        var foundedItem = await EntitySet().FindAsync(keys);
        return foundedItem;
    }

    public IQueryable<TEntity> AllAsNoTracking()
    {
        return EntitySet().AsNoTracking();
    }

    public IQueryable<TEntity> All()
    {
        return _context.Set<TEntity>();
    }

    public bool Any(Expression<Func<TEntity, bool>>? predicate = null)
    {
        return predicate == null ? EntitySet().Any() : EntitySet().Any(predicate);
    }

    public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return predicate == null ? await EntitySet().AnyAsync(cancellationToken) : await EntitySet().AnyAsync(predicate, cancellationToken);
    }

    public bool PhysicalDelete(TEntity item, bool commit = true)
    {
        EntitySet().Remove(item);
        if (commit) return Commit();
        return true;
    }

    public bool PhysicalDeleteRange(TEntity[] items, bool commit = true)
    {
        EntitySet().RemoveRange(items);
        if (commit) return Commit();
        return true;
    }

    public bool PhysicalDeleteRange(IQueryable<TEntity> items, bool commit = true)
    {
        EntitySet().RemoveRange(items);
        if (commit) return Commit();
        return true;
    }


    public bool Create(TEntity item, bool commit = true)
    {
        EntitySet().Add(item);
        if (commit) return Commit();
        return true;
    }

    public async Task<bool> CreateAsync(TEntity item, bool commit = true, CancellationToken cancellationToken = default)
    {
        await EntitySet().AddAsync(item, cancellationToken);
        if (commit) return await CommitAsync(cancellationToken);
        return true;
    }

    public void Update(TEntity originalItem, TEntity updatedItem, bool commit = true)
    {
        throw new NotImplementedException();
    }

    public bool Update(TEntity updatedItem, bool commit = true)
    {
        _context.SetModified(updatedItem);
        if (commit) return Commit();
        return true;
    }
    public async Task<bool> UpdateAsync(TEntity updatedItem, bool commit = true, CancellationToken cancellationToken = default)
    {
        await _context.SetModifiedAsync(updatedItem);
        if (commit) return await CommitAsync(cancellationToken);
        return true;
    }

    public async Task<bool> CommitAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken) > 0;
    }

    public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        await EntitySet().AddRangeAsync(entities, cancellationToken);
    }

    public bool Commit()
    {
        return _context.SaveChanges() > 0;
    }
}

