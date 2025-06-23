using Domain.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class WorkflowTemplateRepository : GenericRepository<WorkflowTemplate>, IWorkflowTemplateRepository
    {
        public WorkflowTemplateRepository(WorkflowDbContext context) : base(context) { }

        public async Task<WorkflowTemplate?> GetActiveTemplateByReferenceTypeAsync(string referenceType)
        {
            return await _context.WorkflowTemplate
                .FirstOrDefaultAsync(t => t.ReferenceType == referenceType && t.IsActive);
        }

        public async Task<List<WorkflowTemplate>> GetAllActiveTemplatesAsync()
        {
            return await _context.WorkflowTemplate
                .Where(t => t.IsActive)
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();
        }
    }
}
