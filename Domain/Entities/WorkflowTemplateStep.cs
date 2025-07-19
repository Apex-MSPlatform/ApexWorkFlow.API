
using Apex.Core.primitives;

namespace Domain.Entities
{
    public class WorkflowTemplateStep : ApexEntity
    {
        public Guid TemplateId { get; set; }
        public int StepOrder { get; set; }
        public string ApproverType { get; set; } = null!; // "User", "Role", etc.
        public string ApproverValue { get; set; } = null!; // ID or name
        public string ApprovalType { get; set; } = "Single"; // or "All", "Majority"
        public string? ConditionExpression { get; set; }
        public bool IsOptional { get; set; } = false;
    }
}
