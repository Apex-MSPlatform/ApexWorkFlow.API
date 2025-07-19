using Domain.Abstractions;
using Domain.Entities;
using Apex.Core.primitives;
using Microsoft.EntityFrameworkCore;
using Apex.Core.Common.GenericRepository;

namespace Infrastructure.Persistence.Repositories
{
    public class WorkflowPolicyOverrideRepository : ApexGenericRepository<WorkflowPolicyOverride>, IWorkflowPolicyOverrideRepository
    {
        public WorkflowPolicyOverrideRepository(WorkflowDbContext context) : base(context) { }

        public async Task<List<WorkflowPolicyOverride>> GetOverridesForContextAsync(
            string referenceType, Guid? userId, string? role, string? department, string? office,CancellationToken cancellationToken)
        {
            return await _set
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
