using System.Collections.Generic;
using System.Security.Claims;

namespace Pubs.WebAPI.Tests.Handlers
{
    public class TestClaimsHandler
    {
        public IList<Claim> Claims { get; }

        public TestClaimsHandler(IList<Claim> claims)
        {
            Claims = claims;
        }

    }
}
