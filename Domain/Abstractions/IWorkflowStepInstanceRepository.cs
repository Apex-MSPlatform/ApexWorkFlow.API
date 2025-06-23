
using Domain.Entities;
using Domain.primitives;

namespace Domain.Abstractions
{
    public interface IWorkflowStepInstanceRepository : IRepository<WorkflowStepInstance> 
    {
        Task<List<WorkflowStepInstance>> GetByWorkflowInstanceIdAsync(Guid workflowInstanceId);
    }
}
