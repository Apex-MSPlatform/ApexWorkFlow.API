using Apex.Core.Abstractions.Messaging;


namespace Application.Features.Workflow.Create
{
    public class CreateWorkflowCommand : ICommand<CreateWorkflowResponse>
    {
        public string ReferenceType { get; set; } = null!; // e.g., "LeaveRequest", "SalaryAdjustment"
        public string DisplayName { get; set; } = null!;   // e.g., "Leave Request Workflow"
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
