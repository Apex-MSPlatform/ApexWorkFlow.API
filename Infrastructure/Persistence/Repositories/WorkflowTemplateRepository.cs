using System.Collections.Generic;
using Domain.Abstractions;
using Domain.Entities;
using Infrastructure.Persistence.Common.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class WorkflowTemplateRepository : ApexGenericRepository<WorkflowTemplate>, IWorkflowTemplateRepository
    {
        public WorkflowTemplateRepository(WorkflowDbContext context) : base(context) { }

        public async Task<WorkflowTemplate?> GetActiveTemplateByWorkflowIDAsync(Guid ID)
        {
            return await _context.WorkflowTemplate
                .FirstOrDefaultAsync(t => t.WorkflowId == ID && t.IsActive);
        }

        public async Task<List<WorkflowTemplate>> GetAllActiveTemplatesAsync()
        {
            return await _context.WorkflowTemplate
                .Where(t => t.IsActive)
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();
        }

        public async Task<bool> IsNameExistsAsync(string name) => 
            await _set.AnyAsync(x => x.Name == name);
    }
}
