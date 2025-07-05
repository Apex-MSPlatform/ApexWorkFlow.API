namespace Application.Features.Workflow.Read
{
    public class ReadWorkflowResponse
    {
        public Guid Id { get; set; }
        public string ReferenceType { get; set; } = null!; // e.g., "LeaveRequest", "SalaryAdjustment"
        public string DisplayName { get; set; } = null!;   // e.g., "Leave Request Workflow"
        public string? Description { get; set; }
        public bool IsActive { get; set; } 
        public DateTime CreatedAt { get; set; }
    }
}
