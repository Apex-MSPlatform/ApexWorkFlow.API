using Domain.primitives;

namespace Domain.Entities
{
    public class Workflow : ApexEntity
    {
        public string ReferenceType { get; set; } = null!; // e.g., "LeaveRequest", "SalaryAdjustment"
        public string DisplayName { get; set; } = null!;   // e.g., "Leave Request Workflow"
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        public List<WorkflowTemplate> WorkflowTemplates { get; set; } = [];
    }

}
