using Pubs.SharedKernel.Tests.Setup;
using System;

namespace Pubs.UnitTests.Persistence.Setup
{
    /// <summary>
    /// Base class for all entity framework data access unit tests. 
    /// All unit tests should inherit from this class or another abstract class in this class's hierarchy.
    /// </summary>
    public abstract class PersistenceUnitTestBase : TestBase, IDisposable
    {
        protected PersistenceUnitTestBase()
        {
            Setup();
        }
    }
}
