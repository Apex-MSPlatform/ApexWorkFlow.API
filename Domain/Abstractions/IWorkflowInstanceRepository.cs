
using Domain.Entities;
using Domain.primitives;

namespace Domain.Abstractions
{
    public interface IWorkflowInstanceRepository : IApexRepository<WorkflowInstance> 
    {
        Task<WorkflowInstance?> GetByReferenceIdAsync(string referenceType, string referenceId);
    }
}
