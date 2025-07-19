
using Apex.Core.primitives;
using Domain.Entities;

namespace Domain.Abstractions
{
    public interface IWorkflowAuditLogRepository : IApexRepository<WorkflowAuditLog>
    {
        Task<List<WorkflowAuditLog>> GetLogsByStepIdAsync(Guid stepId,CancellationToken cancellationToken);
    }
}
