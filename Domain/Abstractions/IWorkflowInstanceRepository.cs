
using Domain.Entities;
using Apex.Core.primitives;

namespace Domain.Abstractions
{
    public interface IWorkflowInstanceRepository : IApexRepository<WorkflowInstance> 
    {
        Task<WorkflowInstance?> GetByReferenceIdAsync(string referenceType, string referenceId, CancellationToken cancellationToken);
    }
}
