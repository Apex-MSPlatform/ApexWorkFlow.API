using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.EntityConfigurations
{
    public class WorkflowStepInstanceConfiguration : IEntityTypeConfiguration<WorkflowStepInstance>
    {
        public void Configure(EntityTypeBuilder<WorkflowStepInstance> builder)
        {
            builder.ToTable("WorkflowStepInstances");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.InstanceId)
                .IsRequired();

            builder.Property(s => s.TemplateStepId)
               .IsRequired();


            builder.Property(s => s.StepOrder)
                .IsRequired();


            builder.Property(s => s.Status)
                .IsRequired()
                .HasMaxLength(20); // e.g., "Pending", "Approved", "Rejected"

            builder.Property(w => w.StartedAt)
                .IsRequired();


            builder.HasIndex(s => new { s.InstanceId, s.StepOrder })
                .IsUnique(); // Enforce only one step per position in each instance


            // Optional: Navigation config (if you use it later)
            builder.HasMany(w => w.Approvers)
                .WithOne()
                .HasForeignKey(s => s.StepInstanceId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
