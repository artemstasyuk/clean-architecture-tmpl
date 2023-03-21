using System.Text;
using CleanArchitectureTemplate.Application.Common.Interfaces.Authentication;
using CleanArchitectureTemplate.Application.Common.Interfaces.Persistence;
using CleanArchitectureTemplate.Application.Common.Interfaces.Services;
using CleanArchitectureTemplate.Infrastructure.Authentication;
using CleanArchitectureTemplate.Infrastructure.Persistence;
using CleanArchitectureTemplate.Infrastructure.Persistence.Repositories;
using CleanArchitectureTemplate.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CleanArchitectureTemplate.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, 
            ConfigurationManager configuration)
        {
            services
                .AddAuth(configuration)
                .AddPersistence(configuration);
        
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            return services;
        }

        private static IServiceCollection AddPersistence(this IServiceCollection services, 
            IConfiguration configuration)
        {
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DbConnection")));
        
            return services;
        }

        private static IServiceCollection AddAuth(this IServiceCollection services,
            IConfiguration configuration)
        {
            var jwtSettings = new JwtSettings();
            configuration.Bind(JwtSettings.SectionName, jwtSettings);

            services.AddSingleton(Options.Create(jwtSettings));
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

            services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtSettings.Secret))
                });

            return services;
        }
    }
}