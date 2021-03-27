using Autofac;
using Pubs.Application.Common.Interfaces;
using Pubs.Infrastructure.Persistence.DbContexts;
using Pubs.Infrastructure.Persistence.Repositories;

namespace Pubs.Console.Demo
{
    internal static class ContainerConfiguration
    {
        public static IContainer ConfigureContainer ()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<PubsContext>().As<IPubsContext>();

            builder.RegisterType<EmployeeRepository>().As<IEmployeeRepository>();

            return builder.Build();
        }
    }
}
