using Apex.Core.Abstractions.Messaging;

namespace Application.Features.Workflow.Read
{
    public class ReadWorkflowQurey : IQuery<ReadWorkflowResponse>
    {
        public Guid Id { get; set; }
    }
}
