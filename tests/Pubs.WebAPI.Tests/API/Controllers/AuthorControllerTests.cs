using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Pubs.WebAPI.Tests.Fixtures;
using Pubs.WebAPI.Tests.Setup;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Pubs.WebAPI.Tests.API.Controllers
{
    [Collection("Pubs Web Api Collection")]
    public class AuthorControllerTests : WebApiTestBase, IClassFixture<PubsWebApiApplicationFixture<Pubs.API.Startup>>
    {
        private readonly HttpClient _client;

        public AuthorControllerTests(PubsWebApiApplicationFixture<Pubs.API.Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task get_authors_async_succeeds()
        {
            var request = "api/authors";
            
            var response = await _client.GetAsync(request);

            response.EnsureSuccessStatusCode();
        }


        [Theory]
        [MemberData(nameof(GetAuthorsData))]
        public async Task get_author_async_succeeds(int authorId, int expectedStatusCode)
        {
            var request = $"api/authors/{authorId}";

            var response = await _client.GetAsync(request);
            
            ((int)response.StatusCode).Should().Be(expectedStatusCode, $"because we expected the HTTP status code to be {expectedStatusCode}");
        }


        #region Public Static Test Data Members

        public static IEnumerable<object[]> GetAuthorsData =>
            new List<object[]>
            {
                new object[] { 1, StatusCodes.Status200OK },
                new object[] { 2, StatusCodes.Status200OK },
                new object[] { 3, StatusCodes.Status200OK },
                new object[] { 777, StatusCodes.Status404NotFound },
                new object[] { 787, StatusCodes.Status404NotFound },
                new object[] { 797, StatusCodes.Status404NotFound }
            };


        #endregion Public Static Test Data Members
    }
}
