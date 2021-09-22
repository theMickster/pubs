using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Pubs.API.Filter;
using Pubs.Application.Interfaces.Repositories;
using Pubs.CoreDomain.Settings;
using Pubs.Infrastructure.Persistence.DbContexts;
using Pubs.Infrastructure.Persistence.Repositories;
using System;

namespace Pubs.API.Extensions
{
    public static class PubsStartupExtensions
    {
        public static IServiceCollection AddPubsConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EntityFrameworkCoreSettings>(o => configuration.GetSection(EntityFrameworkCoreSettings.SettingsRootName).Bind(o));

            return services;
        }

        public static IServiceCollection AddPubsDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var serviceProvider = services.BuildServiceProvider();
            var eFCoreSettings = serviceProvider.GetRequiredService<IOptions<EntityFrameworkCoreSettings>>().Value;            

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            var commandTimeout = eFCoreSettings.ComamndTimeout;
            var entityFrameworkLevel = eFCoreSettings.CommandLogLevel;

            services.AddDbContext<PubsContext>(o =>
                {
                    o.UseSqlServer(connectionString,
                                    options =>
                                    {
                                        options.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                                        options.CommandTimeout(commandTimeout);
                                    });
                    o.EnableDetailedErrors(true);
                    o.EnableSensitiveDataLogging(true);
                });

            return services;
        }

        public static IServiceCollection RegisterPubsRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IAuthorRepository, AuthorRepository>();

            return services;
        }

        public static IServiceCollection RegisterPubsDataServices(this IServiceCollection services, IConfiguration configuration)
        {

            return services;
        }

        public static IServiceCollection AddPubsCustomMVC(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers(options => {
                options.Filters.Add(typeof(ValidatorActionFilter));
                })
             .AddJsonOptions(options => options.JsonSerializerOptions.WriteIndented = true);

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                    .SetIsOriginAllowed((host) => true)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Pubs - Catalog HTTP API",
                    Version = "v1",
                    Description = "The Pubs HTTP API."
                });
            });

            return services;

        }
    }
}
