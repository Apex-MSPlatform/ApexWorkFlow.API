using Apex.Core.Common.GenericRepository;
using Domain.Abstractions;
using Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class WorkflowAuditLogRepository : ApexGenericRepository<WorkflowAuditLog>, IWorkflowAuditLogRepository
    {
        public WorkflowAuditLogRepository(WorkflowDbContext context) : base(context) { }

        public async Task<List<WorkflowAuditLog>> GetLogsByStepIdAsync(Guid stepId, CancellationToken cancellationToken)
        {
            return await _set
                .Where(x => x.StepId == stepId)
                .OrderByDescending(x => x.Timestamp)
                .ToListAsync(cancellationToken);
        }
    }
}
