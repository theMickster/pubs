using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pubs.API.Extensions;
using Pubs.Application.Infrastructure.Extensions;
using System;
using System.Collections.Generic;

namespace Pubs.API
{
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            Configuration = configuration;
            CurrentEnvironment = webHostEnvironment;
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>The configuration.</value>
        public IConfiguration Configuration { get; }

        public IWebHostEnvironment CurrentEnvironment { get; }

        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <remarks>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </remarks>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddApplicationInsightsTelemetry(Configuration);

            services.AddPubsConfig(Configuration, CurrentEnvironment);

            services.AddPubsDbContext(Configuration);

            services.RegisterPubsRepositories(Configuration);

            services.RegisterPubsDataServices(Configuration);

            services.AddAutoMapper(typeof(Startup));

            services.AddPubsCustomMVC(Configuration);

            services.AddSwagger(Configuration);

        }

        /// <summary>
        /// Configures the specified application.
        /// </summary>
        /// <remarks>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </remarks>
        /// <param name="app">The application.</param>
        /// <param name="env">The env.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsOneOfOurDevelopmentEnvironments())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pubs.API v1"));
            }
            else
            {
                app.UseExceptionHandler(appBuilder =>
                {
                    appBuilder.Run(async context =>
                    {
                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync("An unexpected fault happened. Try again later.");
                    });
                });

            }

            var allowedOrigins = this.Configuration.GetValue("CORS:Origins", "*");
            app.UseCors(builder =>
            {
                if (allowedOrigins == "*")
                {
                    builder.AllowAnyOrigin();
                }
                else
                {
                    builder.SetIsOriginAllowedToAllowWildcardSubdomains()
                           .WithOrigins(allowedOrigins.Split(',', StringSplitOptions.RemoveEmptyEntries));
                }
                builder.AllowAnyMethod()
                       .AllowAnyHeader();
            });

            app.UseHttpsRedirection();

            app.UseDefaultFiles(new DefaultFilesOptions
            {
                DefaultFileNames = new List<string> { "index.html" }
            });

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
