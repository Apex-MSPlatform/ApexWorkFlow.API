

using Domain.primitives;

namespace Domain.Entities
{
    public class WorkflowPolicyOverride : ApexEntity
    {
        public Guid? UserId { get; set; }
        public string? Role { get; set; }
        public string? Department { get; set; }
        public string? Office { get; set; }
        public string ReferenceType { get; set; } = null!;
        public string TemplateName { get; set; } = null!;
        public int Priority { get; set; } = 0;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
