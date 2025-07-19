

using Apex.Core.primitives;

namespace Domain.Entities
{
    public class WorkflowStepInstance : ApexEntity
    {
        public Guid InstanceId { get; set; }
        public Guid TemplateStepId { get; set; }
        public int StepOrder { get; set; }
        public string Status { get; set; } = "Pending";
        public DateTime? StartedAt { get; set; }
        public DateTime? CompletedAt { get; set; }

        public List<WorkflowStepApprover> Approvers { get; set; } = new();
    }
}
