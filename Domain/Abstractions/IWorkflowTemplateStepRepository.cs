
using Domain.Entities;
using Apex.Core.primitives;

namespace Domain.Abstractions
{
    public interface IWorkflowTemplateStepRepository : IApexRepository<WorkflowTemplateStep> 
    {
        Task<List<WorkflowTemplateStep>> GetStepsByTemplateIdAsync(Guid templateId, CancellationToken cancellationToken);
    }
}
