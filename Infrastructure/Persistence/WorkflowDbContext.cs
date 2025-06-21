using Domain.Entities;
using Infrastructure.Persistence.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class WorkflowDbContext(DbContextOptions<WorkflowDbContext> options) : DbContext(options)
    {

        public DbSet<WorkflowTemplate> WorkflowTemplate { get; set; }
        public DbSet<WorkflowTemplateStep> WorkflowTemplateStep { get; set; }
        public DbSet<WorkflowInstance> WorkflowInstance { get; set; }
        public DbSet<WorkflowStepInstance> WorkflowStepInstance { get; set; }
        public DbSet<WorkflowStepApprover> WorkflowStepApprover { get; set; }
        public DbSet<WorkflowPolicyOverride> WorkflowPolicyOverride { get; set; }
        public DbSet<WorkflowAuditLog> WorkflowAuditLog { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new WorkflowTemplateConfiguration());

            modelBuilder.ApplyConfiguration(new WorkflowTemplateStepConfiguration());

            modelBuilder.ApplyConfiguration(new WorkflowInstanceConfiguration());

            modelBuilder.ApplyConfiguration(new WorkflowStepInstanceConfiguration());

            modelBuilder.ApplyConfiguration(new WorkflowStepApproverConfiguration());

            modelBuilder.ApplyConfiguration(new WorkflowPolicyOverrideConfiguration());

            modelBuilder.ApplyConfiguration(new WorkflowAuditLogConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
