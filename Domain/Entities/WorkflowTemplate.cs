
using Apex.Core.primitives;

namespace Domain.Entities
{
    public class WorkflowTemplate : ApexEntity
    {
        public Guid WorkflowId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int Version { get; set; } = 1;
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Workflow Workflow { get; set; } = null!;

        public List<WorkflowTemplateStep> Steps { get; set; } = [];
    }
}
