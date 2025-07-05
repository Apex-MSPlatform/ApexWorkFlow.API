using Domain.Abstractions;
using Domain.Entities;
using Infrastructure.Persistence.Common.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class WorkflowInstanceRepository : ApexGenericRepository<WorkflowInstance>, IWorkflowInstanceRepository
    {
        public WorkflowInstanceRepository(WorkflowDbContext context) : base(context) { }

        public async Task<WorkflowInstance?> GetByReferenceIdAsync(string referenceType, string referenceId,CancellationToken cancellationToken)
        {
            return await _context.WorkflowInstance
                .FirstOrDefaultAsync(w => w.ReferenceType == referenceType && w.ReferenceId == referenceId, cancellationToken);
        }
    }
}
