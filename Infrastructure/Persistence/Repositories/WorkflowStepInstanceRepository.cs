using Domain.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Apex.Core.Common.GenericRepository;

namespace Infrastructure.Persistence.Repositories
{
    public class WorkflowStepInstanceRepository : ApexGenericRepository<WorkflowStepInstance>, IWorkflowStepInstanceRepository
    {
        public WorkflowStepInstanceRepository(WorkflowDbContext context) : base(context) { }

        public async Task<List<WorkflowStepInstance>> GetByWorkflowInstanceIdAsync(Guid workflowInstanceId, CancellationToken cancellationToken)
        {
            return await _set
                .Where(s => s.InstanceId == workflowInstanceId)
                .OrderBy(s => s.StepOrder)
                .ToListAsync(cancellationToken);
        }
    }
}
