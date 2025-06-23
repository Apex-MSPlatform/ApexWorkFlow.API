using Domain.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class WorkflowStepInstanceRepository : GenericRepository<WorkflowStepInstance>, IWorkflowStepInstanceRepository
    {
        public WorkflowStepInstanceRepository(WorkflowDbContext context) : base(context) { }

        public async Task<List<WorkflowStepInstance>> GetByWorkflowInstanceIdAsync(Guid workflowInstanceId)
        {
            return await _context.WorkflowStepInstance
                .Where(s => s.InstanceId == workflowInstanceId)
                .OrderBy(s => s.StepOrder)
                .ToListAsync();
        }
    }
}
