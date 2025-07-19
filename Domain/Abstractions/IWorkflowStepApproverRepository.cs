
using Domain.Entities;
using Apex.Core.primitives;

namespace Domain.Abstractions
{
    public interface IWorkflowStepApproverRepository : IApexRepository<WorkflowStepApprover> 
    {
        Task<List<WorkflowStepApprover>> GetByStepInstanceIdAsync(Guid stepInstanceId, CancellationToken cancellationToken);
    }
}
