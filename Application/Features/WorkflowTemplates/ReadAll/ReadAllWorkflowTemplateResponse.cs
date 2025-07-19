using Apex.Core.Common.Pagination;
using Domain.Entities;

namespace Application.Features.WorkflowTemplates.ReadAll
{
    public class ReadAllWorkflowTemplateResponse
    {
        public PagedResult<WorkflowTemplate> Templates { get; set; } = new PagedResult<WorkflowTemplate>();
    }
}
