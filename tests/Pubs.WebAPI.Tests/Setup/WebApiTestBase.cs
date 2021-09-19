using Pubs.SharedKernel.Tests.Setup;
using System;

namespace Pubs.WebAPI.Tests.Setup
{
    /// <summary>
    /// Base class for all web api tests. 
    /// All unit tests should inherit from this class or another abstract class in this class's hierarchy.
    /// </summary>
    public class WebApiTestBase : TestBase, IDisposable
    {
        protected WebApiTestBase()
        {
            Setup();
        }
    }
}
