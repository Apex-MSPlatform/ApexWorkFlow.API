
using Domain.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Apex.Core.Common.GenericRepository;

namespace Infrastructure.Persistence.Repositories
{
    public class WorkflowTemplateRepository : ApexGenericRepository<WorkflowTemplate>, IWorkflowTemplateRepository
    {
        public WorkflowTemplateRepository(WorkflowDbContext context) : base(context) { }

        public async Task<WorkflowTemplate?> GetActiveTemplateByWorkflowIDAsync(Guid ID, CancellationToken cancellationToken)
        {
            return await _set
                .FirstOrDefaultAsync(t => t.WorkflowId == ID && t.IsActive, cancellationToken);
        }

        public async Task<List<WorkflowTemplate>> GetAllActiveTemplatesAsync(CancellationToken cancellationToken)
        {
            return await _set
                .Where(t => t.IsActive)
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync(cancellationToken);
        }

        public async Task<bool> IsNameExistsAsync(string name, CancellationToken cancellationToken) => 
            await _set.AnyAsync(x => x.Name == name, cancellationToken);
    }
}
