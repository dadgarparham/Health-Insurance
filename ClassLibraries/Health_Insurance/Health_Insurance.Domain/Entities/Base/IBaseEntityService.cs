using Health_Insurance.Domain.Entities.File;
using System.Linq.Expressions;

namespace Health_Insurance.Domain.Entities.Base
{
    public interface IBaseEntityService<TEntity> where TEntity : IEntity
    {
        bool PhysicalDelete(TEntity item, bool commit = true);

        bool PhysicalDeleteRange(TEntity[] items, bool commit = true);
        bool PhysicalDeleteRange(IQueryable<TEntity> items, bool commit = true);
        TEntity? Find(params object[] keys);
        Task<TEntity?> FindAsync(params object[] keys);
        IQueryable<TEntity> AllAsNoTracking();
        IQueryable<TEntity> All();
        bool Any(Expression<Func<TEntity, bool>>? predicate = null);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
        bool Create(TEntity item, bool commit = true);
        Task<bool> CreateAsync(TEntity item, bool commit = true, CancellationToken cancellationToken = default);
        void Update(TEntity originalItem, TEntity updatedItem, bool commit = true);
        bool Update(TEntity updatedItem, bool commit = true);
        Task<bool> UpdateAsync(TEntity updatedItem, bool commit = true, CancellationToken cancellationToken = default);
        bool Commit();
        Task<bool> CommitAsync(CancellationToken cancellationToken = default);
        Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

    }
}
