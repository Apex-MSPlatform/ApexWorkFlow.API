using Domain.Abstractions;
using Domain.Entities;
using Infrastructure.Persistence.Common.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class WorkflowStepApproverRepository : ApexGenericRepository<WorkflowStepApprover>, IWorkflowStepApproverRepository
    {
        public WorkflowStepApproverRepository(WorkflowDbContext context) : base(context) { }

        public async Task<List<WorkflowStepApprover>> GetByStepInstanceIdAsync(Guid stepInstanceId, CancellationToken cancellationToken)
        {
            return await _context.WorkflowStepApprover
                .Where(a => a.StepInstanceId == stepInstanceId)
                .ToListAsync(cancellationToken);
        }
    }
}
