using ChubbInsuranceClaim.src.Application.Interfaces.Repository;
using ChubbInsuranceClaim.src.Infrastructure.Context;
using ChubbInsuranceClaim.src.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ChubbInsuranceClaim.src.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IIncidentRepository, IncidentRepository>();
            services.AddScoped<IClaimRepository, ClaimRepository>();
            services.AddScoped<IClaimAssignmentRepository, ClaimAssignmentRepository>();
            services.AddScoped<IClaimDocumentRepository, ClaimDocumentRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
