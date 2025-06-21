
using Domain.primitives;

namespace Domain.Entities
{
    public class WorkflowTemplate : ApexEntity
    {
        public string Name { get; set; } = null!;
        public string ReferenceType { get; set; } = null!; // e.g. "TimeOffRequest"
        public string? Description { get; set; }
        public int Version { get; set; } = 1;
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public List<WorkflowTemplateStep> Steps { get; set; } = [];
    }
}
