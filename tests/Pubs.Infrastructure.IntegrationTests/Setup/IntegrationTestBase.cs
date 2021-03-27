using Microsoft.Extensions.Configuration;
using NLog;
using Pubs.Infrastructure.IntegrationTests.Setup.Factories;
using Pubs.SharedKernel.Tests.Setup;
using System;
using Pubs.Infrastructure.IntegrationTests.Setup.Constants;
using Pubs.Infrastructure.Persistence.DbContexts;

namespace Pubs.Infrastructure.IntegrationTests.Setup
{
    /// <summary>
    /// Base class for all integration tests. 
    /// All integration tests should inherit from this class or another abstract class in this class's hierarchy.
    /// </summary>
    public abstract class IntegrationTestBase : TestBase, IDisposable
    {
        protected ILogger Logger = LogManager.GetCurrentClassLogger();

        protected IConfigurationRoot IntegrationTestConfiguration { get; }

        protected readonly PubsContext Context;

        protected IntegrationTestBase() : this(DbContextTypeEnum.SQLServer)
        {
        }

        protected IntegrationTestBase(DbContextTypeEnum dbContextType)
        {
            IntegrationTestConfiguration = IntegrationTestConfigFactory.GetConfiguration();

            switch (dbContextType)
            {
                case DbContextTypeEnum.InMemory:
                {
                    Context = new InMemoryPubsContextFactory().Create();
                }
                    break;
                case DbContextTypeEnum.SQLServer:
                {
                    Context = new LiveSqlServerPubsContextFactory().Create();
                }
                    break;
            }

        }

        public override void ConcreteDispose()
        {
            Context?.Dispose();
        }

    }
}
