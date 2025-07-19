
using Domain.Entities;
using Apex.Core.primitives;

namespace Domain.Abstractions
{
    public interface IWorkflowStepInstanceRepository : IApexRepository<WorkflowStepInstance> 
    {
        Task<List<WorkflowStepInstance>> GetByWorkflowInstanceIdAsync(Guid workflowInstanceId, CancellationToken cancellationToken);
    }
}
