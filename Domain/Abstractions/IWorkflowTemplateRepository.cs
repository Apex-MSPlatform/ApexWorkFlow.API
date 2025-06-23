
using Domain.Entities;
using Domain.primitives;

namespace Domain.Abstractions
{
    public interface IWorkflowTemplateRepository : IRepository<WorkflowTemplate> 
    {
        Task<WorkflowTemplate?> GetActiveTemplateByReferenceTypeAsync(string referenceType);
        Task<List<WorkflowTemplate>> GetAllActiveTemplatesAsync();
    }
}
