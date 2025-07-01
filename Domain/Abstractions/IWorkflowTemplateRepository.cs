
using Domain.Entities;
using Domain.primitives;

namespace Domain.Abstractions
{
    public interface IWorkflowTemplateRepository : IApexRepository<WorkflowTemplate> 
    {
        Task<WorkflowTemplate?> GetActiveTemplateByWorkflowIDAsync(Guid ID);
        Task<List<WorkflowTemplate>> GetAllActiveTemplatesAsync();

        Task<bool> IsNameExistsAsync(string name);
    }
}
