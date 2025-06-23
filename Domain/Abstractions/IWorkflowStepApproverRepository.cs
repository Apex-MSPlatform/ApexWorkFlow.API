
using Domain.Entities;
using Domain.primitives;

namespace Domain.Abstractions
{
    public interface IWorkflowStepApproverRepository : IRepository<WorkflowStepApprover> 
    {
        Task<List<WorkflowStepApprover>> GetByStepInstanceIdAsync(Guid stepInstanceId);
    }
}
