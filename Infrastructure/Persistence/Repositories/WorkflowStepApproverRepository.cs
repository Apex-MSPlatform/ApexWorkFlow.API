using Domain.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class WorkflowStepApproverRepository : GenericRepository<WorkflowStepApprover>, IWorkflowStepApproverRepository
    {
        public WorkflowStepApproverRepository(WorkflowDbContext context) : base(context) { }

        public async Task<List<WorkflowStepApprover>> GetByStepInstanceIdAsync(Guid stepInstanceId)
        {
            return await _context.WorkflowStepApprover
                .Where(a => a.StepInstanceId == stepInstanceId)
                .ToListAsync();
        }
    }
}
