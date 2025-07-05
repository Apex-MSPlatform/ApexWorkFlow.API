
using Domain.Entities;
using Domain.primitives;

namespace Domain.Abstractions
{
    public interface IWorkflowPolicyOverrideRepository : IApexRepository<WorkflowPolicyOverride>
    {
        Task<List<WorkflowPolicyOverride>> GetOverridesForContextAsync
            (string referenceType, Guid? userId, string? role, string? department, string? office, CancellationToken cancellationToken);
    }
}
