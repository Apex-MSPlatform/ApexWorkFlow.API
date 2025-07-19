using Apex.Core.Abstractions.Messaging;
using Apex.Core.Common.Pagination;


namespace Application.Features.WorkflowTemplates.ReadAll
{
    public class ReadAllWorkflowTemplateQuery : IQuery<ReadAllWorkflowTemplateResponse>
    {
        public QueryParameters QueryParameters { get; set; } = new QueryParameters();
    }
}
