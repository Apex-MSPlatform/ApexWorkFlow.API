using Domain.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Apex.Core.Common.GenericRepository;

namespace Infrastructure.Persistence.Repositories
{
    public class WorkflowTemplateStepRepository : ApexGenericRepository<WorkflowTemplateStep>, IWorkflowTemplateStepRepository
    {
        public WorkflowTemplateStepRepository(WorkflowDbContext context) : base(context) { }

        public async Task<List<WorkflowTemplateStep>> GetStepsByTemplateIdAsync(Guid templateId,CancellationToken cancellationToken)
        {
            return await _set
                .Where(x => x.Id == templateId)
                .OrderBy(e => e.StepOrder)
                .ToListAsync(cancellationToken);
        }
    }
}
