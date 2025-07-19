using Domain.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Apex.Core.Common.GenericRepository;

namespace Infrastructure.Persistence.Repositories
{
    public class WorkflowRepository : ApexGenericRepository<Workflow>, IWorkflowRepository
    {
        public WorkflowRepository(WorkflowDbContext context) : base(context)
        {

        }


        public async Task<bool> IsWorkflowExistsAsync(string referenceType,CancellationToken cancellationToken) =>
            await _set.AnyAsync(x => x.ReferenceType == referenceType, cancellationToken);

        Task<ICollection<WorkflowTemplate>> IWorkflowRepository.GetWorkflowTemplates(Guid guid, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
