namespace Pubs.Console.Demo
{
    using System;
    using Autofac;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Pubs.Application.Common.Helpers;
    using Pubs.Application.Common.Interfaces;
    using Pubs.Infrastructure.Persistence.DbContexts;

    internal class Program
    {
        private static IContainer Container { get; set; }

        private static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Pubs Demo Console");

            Container = ContainerConfiguration.ConfigureContainer();

            using (var scope = Container.BeginLifetimeScope())
            {
                var serviceProvider = new ServiceCollection()
                                        .AddEntityFrameworkSqlServer()
                                        .BuildServiceProvider();

                var configuration = new ConfigurationBuilder()
                                        .AddJsonFile("appsettings.json")
                                        .Build();

                var defaultSchema = new DbContextSchemaHelper(configuration["DefaultSchema"]);

                var connectionString = configuration.GetConnectionString("DefaultConnection");

                var builder = new DbContextOptionsBuilder<PubsContext>();

                builder.UseSqlServer(connectionString)
                    .UseInternalServiceProvider(serviceProvider);
                
                //var context = scope.Resolve<IPubsContext>(
                //     new NamedParameter("options", builder), new NamedParameter("schema", defaultSchema)
                //    );
                //var employeeRepository = scope.Resolve<IEmployeeRepository>(new NamedParameter(nameof(PubsContext), context));
                

            }


             Console.ReadKey();
        }
    }
}
