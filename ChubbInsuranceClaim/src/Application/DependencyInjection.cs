using ChubbInsuranceClaim.src.Application.Interfaces.Service;
using ChubbInsuranceClaim.src.Application.Services;

namespace ChubbInsuranceClaim.src.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IClaimService, ClaimService>();
            services.AddScoped<IClaimWorkflowService, ClaimWorkflowService>();
            services.AddScoped<IIncidentService, IncidentService>();
            services.AddScoped<IDashboardService, DashboardService>();

            return services;
        }
    }
}
