using Domain.Abstractions;
using Domain.Entities;
using Infrastructure.Persistence.Common.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class WorkflowTemplateStepRepository : ApexGenericRepository<WorkflowTemplateStep>, IWorkflowTemplateStepRepository
    {
        public WorkflowTemplateStepRepository(WorkflowDbContext context) : base(context) { }

        public async Task<List<WorkflowTemplateStep>> GetStepsByTemplateIdAsync(Guid templateId)
        {
            return await _context.WorkflowTemplateStep
                .Where(x => x.Id == templateId)
                .OrderBy(e => e.StepOrder)
                .ToListAsync();
        }
    }
}
