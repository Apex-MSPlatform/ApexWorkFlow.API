
using Domain.Entities;
using Domain.primitives;

namespace Domain.Abstractions
{
    public interface IWorkflowStepApproverRepository : IApexRepository<WorkflowStepApprover> 
    {
        Task<List<WorkflowStepApprover>> GetByStepInstanceIdAsync(Guid stepInstanceId);
    }
}
