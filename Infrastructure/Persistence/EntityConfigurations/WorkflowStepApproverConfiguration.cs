using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityConfigurations
{
    public class WorkflowStepApproverConfiguration : IEntityTypeConfiguration<WorkflowStepApprover>
    {
        public void Configure(EntityTypeBuilder<WorkflowStepApprover> builder)
        {
            builder.ToTable("WorkflowStepApprovers");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.StepInstanceId)
                .IsRequired();

            builder.Property(a => a.ApproverId)
                .IsRequired()
                .HasMaxLength(100); // Could be user ID, email, or external ID

            builder.Property(a => a.Status)
                .IsRequired()
                .HasMaxLength(20); // e.g., "Pending", "Approved", "Rejected"

            builder.Property(a => a.Comment)
                .HasMaxLength(1000);

            builder.Property(a => a.ActionAt)
                .IsRequired();

            // Ensure no duplicate approver for the same step
            builder.HasIndex(a => new { a.StepInstanceId, a.ApproverId })
                .IsUnique();
        }
    }
}
