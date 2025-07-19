
using Apex.Core.primitives;

namespace Domain.Entities
{
    public class WorkflowAuditLog : ApexEntity
    {
        public Guid StepId { get; set; }
        public Guid UserId { get; set; }
        public string Action { get; set; } = null!; // Approved, Rejected
        public string? Comment { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
