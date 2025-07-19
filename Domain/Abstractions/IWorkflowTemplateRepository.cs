
using Domain.Entities;
using Apex.Core.primitives;

namespace Domain.Abstractions
{
    public interface IWorkflowTemplateRepository : IApexRepository<WorkflowTemplate> 
    {
        Task<WorkflowTemplate?> GetActiveTemplateByWorkflowIDAsync(Guid ID, CancellationToken cancellationToken);
        Task<List<WorkflowTemplate>> GetAllActiveTemplatesAsync(CancellationToken cancellationToken);

        Task<bool> IsNameExistsAsync(string name, CancellationToken cancellationToken);
    }
}
