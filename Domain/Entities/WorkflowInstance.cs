
using Domain.primitives;

namespace Domain.Entities
{
    public class WorkflowInstance : ApexEntity
    {
        public Guid TemplateId { get; set; }
        public string ReferenceType { get; set; } = null!;
        public string ReferenceId { get; set; } = null!;
        public Guid InitiatorId { get; set; }
        public string Status { get; set; } = "Pending";
        public DateTime StartedAt { get; set; } = DateTime.UtcNow;
        public DateTime? CompletedAt { get; set; }

        public List<WorkflowStepInstance> Steps { get; set; } = new();
    }
}
