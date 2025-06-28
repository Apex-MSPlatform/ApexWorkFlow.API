
using Domain.Entities;
using Domain.primitives;

namespace Domain.Abstractions
{
    public interface IWorkflowTemplateRepository : IApexRepository<WorkflowTemplate> 
    {
        Task<WorkflowTemplate?> GetActiveTemplateByReferenceTypeAsync(string referenceType);
        Task<List<WorkflowTemplate>> GetAllActiveTemplatesAsync();

        Task<bool> IsNameExistsAsync(string name);
    }
}
