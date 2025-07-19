using Domain.Abstractions;
using Domain.Entities;
using Apex.Core.primitives;
using Microsoft.EntityFrameworkCore;
using Apex.Core.Common.GenericRepository;

namespace Infrastructure.Persistence.Repositories
{
    public class WorkflowStepApproverRepository : ApexGenericRepository<WorkflowStepApprover>, IWorkflowStepApproverRepository
    {
        public WorkflowStepApproverRepository(WorkflowDbContext context) : base(context) { }

        public async Task<List<WorkflowStepApprover>> GetByStepInstanceIdAsync(Guid stepInstanceId, CancellationToken cancellationToken)
        {
            return await _set
                .Where(a => a.StepInstanceId == stepInstanceId)
                .ToListAsync(cancellationToken);
        }
    }
}
