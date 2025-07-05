using Domain.Abstractions;
using Domain.Entities;
using Infrastructure.Persistence.Common.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class WorkflowStepInstanceRepository : ApexGenericRepository<WorkflowStepInstance>, IWorkflowStepInstanceRepository
    {
        public WorkflowStepInstanceRepository(WorkflowDbContext context) : base(context) { }

        public async Task<List<WorkflowStepInstance>> GetByWorkflowInstanceIdAsync(Guid workflowInstanceId, CancellationToken cancellationToken)
        {
            return await _context.WorkflowStepInstance
                .Where(s => s.InstanceId == workflowInstanceId)
                .OrderBy(s => s.StepOrder)
                .ToListAsync(cancellationToken);
        }
    }
}
