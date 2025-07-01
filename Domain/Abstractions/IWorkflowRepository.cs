using Domain.Entities;
using Domain.primitives;

namespace Domain.Abstractions
{
    public interface IWorkflowRepository : IApexRepository<Workflow>
    {
        public Task<ICollection<WorkflowTemplate>> GetWorkflowTemplates(Guid guid);
    }
}
