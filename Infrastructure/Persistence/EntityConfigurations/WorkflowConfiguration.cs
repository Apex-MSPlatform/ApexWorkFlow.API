using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityConfigurations
{
    public class WorkflowConfiguration : IEntityTypeConfiguration<Workflow>
    {
        public void Configure(EntityTypeBuilder<Workflow> builder)
        {
            builder.ToTable("WorkflowInstances");

            builder.HasKey(w => w.Id);

            builder.Property(w => w.ReferenceType)
               .IsRequired()
               .HasMaxLength(100);

            builder.HasIndex(x => x.ReferenceType)
                .IsUnique();

            builder.Property(w => w.DisplayName)
               .IsRequired()
               .HasMaxLength(100);

            builder.Property(w => w.IsActive)
                .IsRequired();

            builder.Property(w => w.CreatedAt)
                .IsRequired();

            builder
                .HasMany(Workflow => Workflow.WorkflowTemplates)
                .WithOne(WorkflowTemplate => WorkflowTemplate.Workflow)
                .HasForeignKey(WorkflowTemplate => WorkflowTemplate.WorkflowId);
        }
    }
}
