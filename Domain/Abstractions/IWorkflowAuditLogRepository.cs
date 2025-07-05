
using Domain.Entities;
using Domain.primitives;

namespace Domain.Abstractions
{
    public interface IWorkflowAuditLogRepository : IApexRepository<WorkflowAuditLog>
    {
        Task<List<WorkflowAuditLog>> GetLogsByStepIdAsync(Guid stepId,CancellationToken cancellationToken);
    }
}
