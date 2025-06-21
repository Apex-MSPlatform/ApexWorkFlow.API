using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.EntityConfigurations
{
    public class WorkflowAuditLogConfiguration : IEntityTypeConfiguration<WorkflowAuditLog>
    {
        public void Configure(EntityTypeBuilder<WorkflowAuditLog> builder)
        {
            builder.ToTable("WorkflowAuditLogs");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.StepId)
                .IsRequired();

            builder.Property(a => a.UserId)
                .IsRequired();

            builder.Property(a => a.Action)
                .IsRequired()
                .HasMaxLength(50); // e.g., "Approved", "Rejected"

            builder.Property(a => a.Comment)
                .HasMaxLength(1000);

            builder.Property(a => a.Timestamp)
                .IsRequired();

            // Optional: Index for faster log lookup
            builder.HasIndex(a => a.StepId);
            builder.HasIndex(a => a.UserId);
        }
    }
}
