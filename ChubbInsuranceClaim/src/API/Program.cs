using ChubbInsuranceClaim.src.API.Middleware;
using ChubbInsuranceClaim.src.Application.Interfaces.Repository;
using ChubbInsuranceClaim.src.Application.Interfaces.Service;
using ChubbInsuranceClaim.src.Application.Services;
using ChubbInsuranceClaim.src.Infrastructure;
using ChubbInsuranceClaim.src.Infrastructure.Context;
using ChubbInsuranceClaim.src.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using ChubbInsuranceClaim.src.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<JwtService>();

//builder.Services.AddScoped<IAuthService, AuthService>();

//builder.Services.AddScoped<IClaimService, ClaimService>();

//builder.Services.AddScoped<IClaimWorkflowService, ClaimWorkflowService>();

//builder.Services.AddScoped<IIncidentService, IncidentService>();

//builder.Services.AddScoped<IDashboardService, DashboardService>();

//builder.Services.AddScoped<IUserRepository, UserRepository>();
//builder.Services.AddScoped<IRoleRepository, RoleRepository>();
//builder.Services.AddScoped<IIncidentRepository, IncidentRepository>();
//builder.Services.AddScoped<IClaimRepository, ClaimRepository>();
//builder.Services.AddScoped<IClaimAssignmentRepository, ClaimAssignmentRepository>();
//builder.Services.AddScoped<IClaimDocumentRepository, ClaimDocumentRepository>();

//builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddApplication();

builder.Services.AddInfrastructure();

// JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],

            IssuerSigningKey =
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

// SQLite DB (In-Memory Database)
var dbPath = Path.Combine(builder.Environment.ContentRootPath, "chubbInsurance.db");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite($"Data Source={dbPath}"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter your JWT token here"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
            },
            Array.Empty<string>()
        }
    });
});

//builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Create database automatically (Development only)
//using (var scope = app.Services.CreateScope())
//{
//    var dbContext = scope.ServiceProvider
//        .GetRequiredService<ChubbInsuranceClaim.src.Infrastructure.Context.ApplicationDbContext>();

//    dbContext.Database.Migrate();
//}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
