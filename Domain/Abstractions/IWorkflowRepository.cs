using Domain.Entities;
using Apex.Core.primitives;

namespace Domain.Abstractions
{
    public interface IWorkflowRepository : IApexRepository<Workflow>
    {
        public Task<ICollection<WorkflowTemplate>> GetWorkflowTemplates(Guid guid, CancellationToken cancellationToken);
        public Task<bool> IsWorkflowExistsAsync(string referenceType, CancellationToken cancellationToken);
    }
}
