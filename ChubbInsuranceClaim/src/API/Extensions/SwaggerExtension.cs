using Microsoft.OpenApi.Models;

namespace ChubbInsuranceClaim.src.API.Extensions
{
    public static class SwaggerExtension
    {
        public static IServiceCollection AddSwaggerConfiguration(
            this IServiceCollection services)
        {

            services.AddSwaggerGen(options =>
            {

                options.SwaggerDoc(
                    "v1",
                    new OpenApiInfo
                    {
                        Title =
                            "Insurance Claims API",

                        Version =
                            "v1",

                        Description =
                            "Insurance Claims Management System API"
                    });



                options.AddSecurityDefinition(
                    "Bearer",
                    new OpenApiSecurityScheme
                    {
                        Name = "Authorization",

                        Type =
                            SecuritySchemeType.Http,

                        Scheme =
                            "Bearer",

                        BearerFormat =
                            "JWT",

                        In =
                            ParameterLocation.Header,

                        Description =
                            "Enter JWT token: Bearer {token}"
                    });



                options.AddSecurityRequirement(
                    new OpenApiSecurityRequirement
                    {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference =
                                new OpenApiReference
                                {
                                    Type =
                                    ReferenceType.SecurityScheme,

                                    Id =
                                    "Bearer"
                                }
                        },

                        Array.Empty<string>()
                    }
                    });
            });


            return services;
        }
    }
}
