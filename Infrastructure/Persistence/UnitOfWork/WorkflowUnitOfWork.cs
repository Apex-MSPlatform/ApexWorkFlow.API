using Domain.primitives;

namespace Infrastructure.Persistence.UnitOfWork
{
    public class WorkflowUnitOfWork : IUnitOfWork
    {
        private readonly WorkflowDbContext _context;

        public WorkflowUnitOfWork(WorkflowDbContext context)
        {
            _context = context;
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
    }
}
