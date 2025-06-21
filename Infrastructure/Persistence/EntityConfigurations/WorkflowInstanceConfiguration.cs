using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.EntityConfigurations
{
    public class WorkflowInstanceConfiguration : IEntityTypeConfiguration<WorkflowInstance>
    {
        public void Configure(EntityTypeBuilder<WorkflowInstance> builder)
        {
            builder.ToTable("WorkflowInstances");

            builder.HasKey(w => w.Id);

            builder.Property(w => w.TemplateId)
                .IsRequired();

            builder.Property(w => w.ReferenceId)
                .IsRequired();

            builder.Property(w => w.ReferenceType)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(w => w.InitiatorId)
                .IsRequired();

            builder.Property(w => w.Status)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(w => w.StartedAt)
                .IsRequired();

            builder.HasIndex(w => new { w.ReferenceType, w.ReferenceId })
                .HasDatabaseName("IX_WorkflowInstance_Reference")
                .IsUnique(false); // Many instances can exist for same Reference

            // Optional: Navigation config (if you use it later)
            builder.HasMany(w => w.Steps)
                .WithOne()
                .HasForeignKey(s => s.InstanceId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
