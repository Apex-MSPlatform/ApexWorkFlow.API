using Domain.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class WorkflowAuditLogRepository : GenericRepository<WorkflowAuditLog>, IWorkflowAuditLogRepository
    {
        public WorkflowAuditLogRepository(WorkflowDbContext context) : base(context) { }

        public async Task<List<WorkflowAuditLog>> GetLogsByStepIdAsync(Guid stepId)
        {
            return await _context.WorkflowAuditLog
                .Where(x => x.StepId == stepId)
                .OrderByDescending(x => x.Timestamp)
                .ToListAsync();
        }
    }
}
