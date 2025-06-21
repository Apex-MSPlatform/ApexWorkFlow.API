using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.EntityConfigurations
{
    public class WorkflowPolicyOverrideConfiguration : IEntityTypeConfiguration<WorkflowPolicyOverride>
    {
        public void Configure(EntityTypeBuilder<WorkflowPolicyOverride> builder)
        {
            builder.ToTable("WorkflowPolicyOverrides");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.ReferenceType)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.TemplateName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Priority)
                .IsRequired();

            builder.Property(p => p.UserId)
                .IsRequired(false);

            builder.Property(p => p.Role)
                .HasMaxLength(100);

            builder.Property(p => p.Department)
                .HasMaxLength(100);

            builder.Property(p => p.Office)
                .HasMaxLength(100);

            builder.Property(p => p.CreatedAt)
                .IsRequired();

            // Optional: Index for faster lookup
            builder.HasIndex(p => new { p.ReferenceType, p.UserId, p.Role, p.Department, p.Office });
        }
    }
}
