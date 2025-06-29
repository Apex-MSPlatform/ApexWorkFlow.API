using Application.Abstractions.Messaging;
using Domain.Shared.Pagination;

namespace Application.Features.WorkflowTemplates.ReadAll
{
    public class ReadAllWorkflowTemplateQuery : IQuery<ReadAllWorkflowTemplateResponse>
    {
        public QueryParameters QueryParameters { get; set; } = new QueryParameters();
    }
}
