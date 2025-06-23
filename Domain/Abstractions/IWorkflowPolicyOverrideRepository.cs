
using Domain.Entities;
using Domain.primitives;

namespace Domain.Abstractions
{
    public interface IWorkflowPolicyOverrideRepository : IRepository<WorkflowPolicyOverride>
    {
        Task<List<WorkflowPolicyOverride>> GetOverridesForContextAsync
            (string referenceType, Guid? userId, string? role, string? department, string? office);
    }
}
