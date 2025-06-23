using Domain.primitives;
using Infrastructure.Persistence;
using Infrastructure.Persistence.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<WorkflowDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            services.Scan(
                selector => selector
                .FromAssemblies(
                    Application.AssemblyReference.Assemply,
                    AssemblyReference.Assemply)
                .AddClasses(false)
                .AsImplementedInterfaces()
                .WithScopedLifetime()
            );


            // Add Security HTTP Client if needed

            return services;
        }
    }
}
