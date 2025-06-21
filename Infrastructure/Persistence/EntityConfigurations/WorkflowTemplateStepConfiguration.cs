using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityConfigurations
{
    internal class WorkflowTemplateStepConfiguration : IEntityTypeConfiguration<WorkflowTemplateStep>
    {
        public void Configure(EntityTypeBuilder<WorkflowTemplateStep> builder)
        {
            builder.ToTable("WorkflowTemplateSteps");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.TemplateId)
                .IsRequired();

            builder.Property(s => s.StepOrder)
                .IsRequired();

            builder.Property(s => s.ApproverType)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(s => s.ApproverValue)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.ApprovalType)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(s => s.ConditionExpression)
                .HasMaxLength(500); // Optional but constrained to avoid storing large expressions

            builder.Property(s => s.IsOptional)
                .IsRequired();

            builder.HasIndex(s => new { s.TemplateId, s.StepOrder })
                .IsUnique(); // Ensure no duplicate step orders within a template
        }
    }
}
