using Domain.Entities;
using Domain.Shared.Pagination;

namespace Application.Features.WorkflowTemplates.ReadAll
{
    public class ReadAllWorkflowTemplateResponse
    {
        public PagedResult<WorkflowTemplate> Templates { get; set; } = new PagedResult<WorkflowTemplate>();
    }
}
