using Domain.primitives;
using Domain.Shared.Pagination;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Common.GenericRepository
{
    public class ApexGenericRepository<T> : IApexRepository<T> where T : ApexEntity
    {
        protected readonly WorkflowDbContext _context;
        protected readonly DbSet<T> _set;

        public ApexGenericRepository(WorkflowDbContext context)
        {
            _context = context;
            _set = context.Set<T>();
        }

        public Task<PagedResult<T>> GetQueryableList(
            QueryParameters parameters,
            CancellationToken cancellationToken = default,
            Func<IQueryable<T>, string?, IQueryable<T>>? searchFunc = null,
            Func<IQueryable<T>, string?, bool, IQueryable<T>>? sortFunc = null
            ) => _set.ApexQueryAsync(parameters, searchFunc);

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default) => await _set.ToListAsync(cancellationToken);

        public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken) => await _set.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken)
        {
            await _set.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task<T> UpdateAsync(T entity, CancellationToken cancellationToken)
        {
            _set.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _set.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
            if (entity == null) return false;
            _set.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<bool> IsExistsAsync(Guid id, CancellationToken cancellationToken) =>
            await _set.AnyAsync(x => x.Id == id, cancellationToken);
    }
}
