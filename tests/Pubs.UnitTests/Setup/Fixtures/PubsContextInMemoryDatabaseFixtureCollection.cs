using Pubs.SharedKernel.Tests.Constants;
using Xunit;

namespace Pubs.UnitTests.Setup.Fixtures
{
    /// <summary>
    /// Class used by xUnit to do it's magic with test collections that utilize the specified fixture of type 'T'
    /// </summary>
    /// <remarks>
    /// This class has no code, and is never created. 
    /// Its purpose is simply to be the place to apply[CollectionDefinition] and all the ICollectionFixture<> interfaces.
    /// </remarks>]
    [CollectionDefinition(FixtureCollections.PubsInMemoryRepositoryCollection)]
    public class PubsContextInMemoryDatabaseFixtureCollection : ICollectionFixture<PubsContextInMemoryDatabaseFixture>
    {
    }
}
