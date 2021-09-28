using Xunit;

namespace Pubs.WebAPI.Tests.Fixtures
{
    /// <summary>
    /// Class used by xUnit to do it's magic with test collections that utilize the autofac container.
    /// </summary>
    /// <remarks>
    /// This class has no code, and is never created. 
    /// Its purpose is simply to be the place to apply[CollectionDefinition] and all the ICollectionFixture<> interfaces.
    /// </remarks>]
    [CollectionDefinition("Pubs Web Api Collection")]
    public class PubsWebApiApplicationFixtureCollection : ICollectionFixture<PubsWebApiApplicationFixture<Pubs.API.Startup>>
    {
    }
}
