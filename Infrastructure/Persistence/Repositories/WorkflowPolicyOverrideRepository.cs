using Domain.Abstractions;
using Domain.Entities;
using Infrastructure.Persistence.Common.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class WorkflowPolicyOverrideRepository : ApexGenericRepository<WorkflowPolicyOverride>, IWorkflowPolicyOverrideRepository
    {
        public WorkflowPolicyOverrideRepository(WorkflowDbContext context) : base(context) { }

        public async Task<List<WorkflowPolicyOverride>> GetOverridesForContextAsync(
            string referenceType, Guid? userId, string? role, string? department, string? office,CancellationToken cancellationToken)
        {
            return await _context.WorkflowPolicyOverride
                .Where(p => p.ReferenceType == referenceType &&
                            (p.UserId == null || p.UserId == userId) &&
                            (p.Role == null || p.Role == role) &&
                            (p.Department == null || p.Department == department) &&
                            (p.Office == null || p.Office == office))
                .OrderByDescending(p => p.Priority)
                .ToListAsync(cancellationToken);
        }
    }
}
