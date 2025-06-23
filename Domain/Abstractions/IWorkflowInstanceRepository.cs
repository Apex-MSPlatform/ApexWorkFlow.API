
using Domain.Entities;
using Domain.primitives;

namespace Domain.Abstractions
{
    public interface IWorkflowInstanceRepository : IRepository<WorkflowInstance> 
    {
        Task<WorkflowInstance?> GetByReferenceIdAsync(string referenceType, string referenceId);
    }
}
