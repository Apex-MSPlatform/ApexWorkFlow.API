
using Domain.Entities;
using Domain.primitives;

namespace Domain.Abstractions
{
    public interface IWorkflowAuditLogRepository : IRepository<WorkflowAuditLog>
    {
        Task<List<WorkflowAuditLog>> GetLogsByStepIdAsync(Guid stepId);
    }
}
