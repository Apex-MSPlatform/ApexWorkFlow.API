using Domain.Abstractions;
using Domain.Entities;
using Infrastructure.Persistence.Common.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class WorkflowRepository : ApexGenericRepository<Workflow>, IWorkflowRepository
    {
        public WorkflowRepository(WorkflowDbContext context) : base(context)
        {

        }

        public async Task<ICollection<WorkflowTemplate>> GetWorkflowTemplates(Guid guid, CancellationToken cancellationToken)
        {
            return await _context.WorkflowTemplate.Where(entity => entity.WorkflowId == guid).ToListAsync(cancellationToken);
        }

        public async Task<bool> IsWorkflowExistsAsync(string referenceType,CancellationToken cancellationToken) =>
            await _set.AnyAsync(x => x.ReferenceType == referenceType, cancellationToken);
    }
}
