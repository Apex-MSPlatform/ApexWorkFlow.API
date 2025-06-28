using Application.Abstractions.Messaging;
using Domain.Shared;

namespace Application.Features.WorkflowTemplates.Create
{
    public class CreateWorkflowTemplateCommand : ICommand<CreateWorkflowTemplateResponse>
    {
        public string Name { get; set; } = null!;
        public string ReferenceType { get; set; } = null!; // e.g. "TimeOffRequest"
        public string? Description { get; set; } = null!; 
        public int Version { get; set; } = 1;
        public bool IsActive { get; set; } = true;
    }
}
