
using Domain.Entities;
using Domain.primitives;

namespace Domain.Abstractions
{
    public interface IWorkflowTemplateStepRepository : IApexRepository<WorkflowTemplateStep> 
    {
        Task<List<WorkflowTemplateStep>> GetStepsByTemplateIdAsync(Guid templateId);
    }
}
