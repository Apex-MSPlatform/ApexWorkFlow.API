using Domain.primitives;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : ApexEntity
    {
        protected readonly WorkflowDbContext _context;
        protected readonly DbSet<T> _set;

        public GenericRepository(WorkflowDbContext context)
        {
            _context = context;
            _set = context.Set<T>();
        }

        public IQueryable<T> GetQueryableList() => _set.AsQueryable();

        public async Task<IEnumerable<T>> GetAllAsync() =>  await _set.ToListAsync();

        public async Task<T?> GetByIdAsync(Guid id) => await _set.FirstOrDefaultAsync(e => e.Id == id);

        public async Task<T> AddAsync(T entity)
        {
            await _set.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _set.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _set.FirstOrDefaultAsync(e => e.Id == id);
            if (entity == null) return false;
            _set.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> IsExistsAsync(Guid id) =>
            await _set.AnyAsync(x => x.Id == id);
    }
}
