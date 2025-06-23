using Domain.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class WorkflowInstanceRepository : GenericRepository<WorkflowInstance>, IWorkflowInstanceRepository
    {
        public WorkflowInstanceRepository(WorkflowDbContext context) : base(context) { }

        public async Task<WorkflowInstance?> GetByReferenceIdAsync(string referenceType, string referenceId)
        {
            return await _context.WorkflowInstance
                .FirstOrDefaultAsync(w => w.ReferenceType == referenceType && w.ReferenceId == referenceId);
        }
    }
}
