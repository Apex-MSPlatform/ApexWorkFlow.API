
using Apex.Core.primitives;

namespace Domain.Entities
{
    public class WorkflowStepApprover : ApexEntity
    {
        public Guid StepInstanceId { get; set; }
        public Guid ApproverId { get; set; }
        public string Status { get; set; } = "Pending"; // Approved, Rejected
        public string? Comment { get; set; }
        public DateTime? ActionAt { get; set; }
    }
}
