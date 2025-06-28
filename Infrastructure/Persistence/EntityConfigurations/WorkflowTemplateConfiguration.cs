using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityConfigurations
{
    internal class WorkflowTemplateConfiguration : IEntityTypeConfiguration<WorkflowTemplate>
    {
        public void Configure(EntityTypeBuilder<WorkflowTemplate> builder)
        {
            builder.ToTable("WorkflowTemplates");

            builder.HasKey(w => w.Id);

            builder.Property(w => w.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(x => x.Name)
                .IsUnique();

            builder.Property(w => w.ReferenceType)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(w => w.Description)
                .HasMaxLength(500);

            builder.Property(w => w.Version)
                .IsRequired();

            builder.Property(w => w.IsActive)
                .IsRequired();

            builder.Property(w => w.CreatedAt)
                .IsRequired();

            // Optional: one-to-many config if navigation properties added
            builder.HasMany(w => w.Steps)
                .WithOne()
                .HasForeignKey(s => s.TemplateId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
