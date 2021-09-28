using AutoMapper;
using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Logging;
using Moq;
using Pubs.API.Controllers;
using Pubs.API.Profiles;
using Pubs.Application.DTOs;
using Pubs.Application.Interfaces.Repositories;
using Pubs.CoreDomain.Entities;
using Pubs.SharedKernel.Tests.Extensions;
using Pubs.UnitTests.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Xunit;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpHeadAttribute = Microsoft.AspNetCore.Mvc.HttpHeadAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Pubs.UnitTests.API.Controllers
{
    public class AuthorControllerTests : UnitTestBase
    {
        #region Private Fields & Mock Members

        private readonly IMapper _mapper;
        private readonly Mock<IAuthorRepository> _mockAuthorRepository;
        private readonly Mock<ILogger<AuthorController>> _mockLogger;

        #endregion Private Fields & Mock Members

        public AuthorControllerTests()
        {
            var mappingConfig = new MapperConfiguration(
                m =>
                {
                    m.AddProfile(new AuthorsProfile());
                });
            _mapper = mappingConfig.CreateMapper();

            _mockAuthorRepository = new Mock<IAuthorRepository>();
            _mockLogger = new Mock<ILogger<AuthorController>>();
        }

        [Fact]
        public void controller_has_correct_attributes()
        {
            var controllerAttribute = (ApiControllerAttribute)typeof(AuthorController).GetCustomAttributes(typeof(ApiControllerAttribute), true).SingleOrDefault();
            var producesAttribute = (ProducesAttribute)typeof(AuthorController).GetCustomAttributes(typeof(ProducesAttribute), true).SingleOrDefault();
            var routeAttribute = (RouteAttribute)typeof(AuthorController).GetCustomAttributes(typeof(RouteAttribute), true).SingleOrDefault();

            using (new AssertionScope())
            {
                controllerAttribute.Should().NotBeNull();
                producesAttribute.Should().NotBeNull();
                routeAttribute.Should().NotBeNull();

                producesAttribute.ContentTypes.Count(x => x == "application/json").Should().Be(1);
                producesAttribute.ContentTypes.Count(x => x == "application/xml").Should().Be(1);

                routeAttribute.Name.Should().Be("authorRoute");
                routeAttribute.Template.Should().Be("api/authors");
            }
        }

        [Fact]
        public void constructor_throws_correct_exceptions()
        {
            using (new AssertionScope())
            {
                ((Action)(() => new AuthorController(null, _mapper, _mockLogger.Object)))
                    .Should().Throw<ArgumentNullException>()
                    .And.ParamName.Should().Be("authorRepository");

                ((Action)(() => new AuthorController(_mockAuthorRepository.Object, null, _mockLogger.Object)))
                    .Should().Throw<ArgumentNullException>()
                    .And.ParamName.Should().Be("mapper");

                ((Action)(() => new AuthorController(_mockAuthorRepository.Object, _mapper, null)))
                    .Should().Throw<ArgumentNullException>()
                    .And.ParamName.Should().Be("logger");
            }
        }
        
        [Fact]
        public void get_authors_has_correct_attributes()
        {
            var sut = typeof(AuthorController)
                        .GetMethods(BindingFlags.Public | BindingFlags.Instance)
                        .SingleOrDefault(p => p.Name == nameof(AuthorController.GetAuthors));

            var httpHead = (HttpHeadAttribute)Attribute.GetCustomAttribute(sut, typeof(HttpHeadAttribute));
            var httpGet = (HttpGetAttribute)Attribute.GetCustomAttribute(sut, typeof(HttpGetAttribute));
            var responseTypeList = ((ProducesResponseTypeAttribute[])Attribute.GetCustomAttributes(sut, typeof(ProducesResponseTypeAttribute))).ToList();

            using (new AssertionScope())
            {
                httpHead.Should().NotBeNull();
                httpGet.Should().NotBeNull();
                responseTypeList.Should().NotBeNull();

                httpGet.Name.Should().Be("GetAuthors");

                responseTypeList.Count(x => x.StatusCode == StatusCodes.Status200OK).Should().Be(1);
            }
        }

        [Fact]
        public void get_author_has_correct_attributes()
        {
            var sut = typeof(AuthorController)
                        .GetMethods(BindingFlags.Public | BindingFlags.Instance)
                        .SingleOrDefault(p => p.Name == nameof(AuthorController.GetAuthor));
            
            var httpGet = (HttpGetAttribute)Attribute.GetCustomAttribute(sut, typeof(HttpGetAttribute));
            var responseTypeList = ((ProducesResponseTypeAttribute[])Attribute.GetCustomAttributes(sut, typeof(ProducesResponseTypeAttribute))).ToList();

            using (new AssertionScope())
            {
                httpGet.Should().NotBeNull();
                responseTypeList.Should().NotBeNull();

                httpGet.Name.Should().Be("GetAuthor");

                responseTypeList.Count(x => x.StatusCode == StatusCodes.Status200OK).Should().Be(1);
                responseTypeList.Count(x => x.StatusCode == StatusCodes.Status404NotFound).Should().Be(1);
            }
        }

        [Fact]
        public void get_authors_options_has_correct_attributes()
        {
            var sut = typeof(AuthorController)
                        .GetMethods(BindingFlags.Public | BindingFlags.Instance)
                        .SingleOrDefault(p => p.Name == nameof(AuthorController.GetAuthorsOptions));

            var httpAttribute= (HttpOptionsAttribute)Attribute.GetCustomAttribute(sut, typeof(HttpOptionsAttribute));

            using (new AssertionScope())
            {
                httpAttribute.Should().NotBeNull();
            }
        }

        [Fact]
        public void create_author_has_correct_attributes()
        {
            var sut = typeof(AuthorController)
                        .GetMethods(BindingFlags.Public | BindingFlags.Instance)
                        .SingleOrDefault(p => p.Name == nameof(AuthorController.CreateAuthor));

            var httpPost = (HttpPostAttribute)Attribute.GetCustomAttribute(sut, typeof(HttpPostAttribute));
            var responseTypeList = ((ProducesResponseTypeAttribute[])Attribute.GetCustomAttributes(sut, typeof(ProducesResponseTypeAttribute))).ToList();

            using (new AssertionScope())
            {
                httpPost.Should().NotBeNull();
                responseTypeList.Should().NotBeNull();

                httpPost.Name.Should().Be("CreateAuthor");

                responseTypeList.Count(x => x.StatusCode == StatusCodes.Status201Created).Should().Be(1);
                responseTypeList.Count(x => x.StatusCode == StatusCodes.Status400BadRequest).Should().Be(1);
            }
        }

        [Fact]
        public void delete_author_has_correct_attributes()
        {
            var sut = typeof(AuthorController)
                        .GetMethods(BindingFlags.Public | BindingFlags.Instance)
                        .SingleOrDefault(p => p.Name == nameof(AuthorController.DeleteAuthor));

            var httpDelete = (HttpDeleteAttribute)Attribute.GetCustomAttribute(sut, typeof(HttpDeleteAttribute));
            var responseTypeList = ((ProducesResponseTypeAttribute[])Attribute.GetCustomAttributes(sut, typeof(ProducesResponseTypeAttribute))).ToList();

            using (new AssertionScope())
            {
                httpDelete.Should().NotBeNull();
                responseTypeList.Should().NotBeNull();

                httpDelete.Name.Should().Be("DeleteAuthor");

                responseTypeList.Count(x => x.StatusCode == StatusCodes.Status204NoContent).Should().Be(1);
                responseTypeList.Count(x => x.StatusCode == StatusCodes.Status404NotFound).Should().Be(1);
            }
        }

        [Fact]
        public void update_author_has_correct_attributes()
        {
            var sut = typeof(AuthorController)
                        .GetMethods(BindingFlags.Public | BindingFlags.Instance)
                        .SingleOrDefault(p => p.Name == nameof(AuthorController.UpdateAuthor));

            var httpPut = (HttpPutAttribute)Attribute.GetCustomAttribute(sut, typeof(HttpPutAttribute));
            var responseTypeList = ((ProducesResponseTypeAttribute[])Attribute.GetCustomAttributes(sut, typeof(ProducesResponseTypeAttribute))).ToList();

            using (new AssertionScope())
            {
                httpPut.Should().NotBeNull();
                responseTypeList.Should().NotBeNull();

                httpPut.Name.Should().Be("UpdateAuthor");

                responseTypeList.Count(x => x.StatusCode == StatusCodes.Status200OK).Should().Be(1);
                responseTypeList.Count(x => x.StatusCode == StatusCodes.Status400BadRequest).Should().Be(1);
                responseTypeList.Count(x => x.StatusCode == StatusCodes.Status404NotFound).Should().Be(1);
            }
        }

        [Fact]
        public void patch_author_code_has_correct_attributes()
        {
            var sut = typeof(AuthorController)
                        .GetMethods(BindingFlags.Public | BindingFlags.Instance)
                        .SingleOrDefault(p => p.Name == nameof(AuthorController.PatchUpdateAuthorCode));

            var httpPatch = (HttpPatchAttribute)Attribute.GetCustomAttribute(sut, typeof(HttpPatchAttribute));
            var responseTypeList = ((ProducesResponseTypeAttribute[])Attribute.GetCustomAttributes(sut, typeof(ProducesResponseTypeAttribute))).ToList();

            using (new AssertionScope())
            {
                httpPatch.Should().NotBeNull();
                responseTypeList.Should().NotBeNull();

                httpPatch.Name.Should().Be("PatchUpdateAuthorCode");

                responseTypeList.Count(x => x.StatusCode == StatusCodes.Status200OK).Should().Be(1);
                responseTypeList.Count(x => x.StatusCode == StatusCodes.Status400BadRequest).Should().Be(1);
                responseTypeList.Count(x => x.StatusCode == StatusCodes.Status404NotFound).Should().Be(1);
            }
        }

        [Fact]
        public void patch_author_contract_has_correct_attributes()
        {
            var sut = typeof(AuthorController)
                        .GetMethods(BindingFlags.Public | BindingFlags.Instance)
                        .SingleOrDefault(p => p.Name == nameof(AuthorController.PatchUpdateAuthorContract));

            var httpPatch = (HttpPatchAttribute)Attribute.GetCustomAttribute(sut, typeof(HttpPatchAttribute));
            var responseTypeList = ((ProducesResponseTypeAttribute[])Attribute.GetCustomAttributes(sut, typeof(ProducesResponseTypeAttribute))).ToList();

            using (new AssertionScope())
            {
                httpPatch.Should().NotBeNull();
                responseTypeList.Should().NotBeNull();

                httpPatch.Name.Should().Be("PatchUpdateAuthorContract");

                responseTypeList.Count(x => x.StatusCode == StatusCodes.Status200OK).Should().Be(1);
                responseTypeList.Count(x => x.StatusCode == StatusCodes.Status400BadRequest).Should().Be(1);
                responseTypeList.Count(x => x.StatusCode == StatusCodes.Status404NotFound).Should().Be(1);
            }
        }

        [Fact]
        public void get_author_options_succeeds()
        {
            var sut = CreateAuthorController(_mockAuthorRepository, _mapper, _mockLogger);
            _ = sut.GetAuthorsOptions();

            var headers = sut.Response.Headers.ToList();
            headers.Count(x => x.Value == "GET, OPTIONS, POST, HEAD, DELETE" && x.Key.ToLower() == "allow").Should().Be(1);
        }

        [Fact]
        public async Task get_authors_succeeds()
        {
            _mockAuthorRepository.Setup(s => s.GetAuthorsAsync())
                .ReturnsAsync(new List<Author>() {
                new Author() { Id = 1, AuthorCode = "123-45-6789", FirstName = "Babe", LastName = "Ruth", Contract = false },
                new Author() { Id = 2, AuthorCode = "223-45-6789", FirstName = "Lou", LastName = "Gehrig", Contract = false }
            });

            var sut = CreateAuthorController(_mockAuthorRepository, _mapper, _mockLogger);

            var result = await sut.GetAuthors();
            var okResult = result.Result as OkObjectResult;
            var authorList = okResult.Value as List<AuthorDto>;

            using (new AssertionScope())
            {
                result.Should().BeOfType<ActionResult<List<AuthorDto>>>();
                authorList.Count.Should().Be(2);
                authorList.Count(x => x.AuthorId == 1).Should().Be(1);
                authorList.Count(x => x.AuthorId == 2).Should().Be(1);
                authorList.Count(x => x.AuthorId == 7).Should().Be(0);
            }
        }

        [Theory]
        [MemberData(nameof(GetAuthorsData))]
        public async Task get_author_async_succeeds(int authorId, int expectedStatusCode, Author author = null)
        {
            _mockAuthorRepository.Setup(s => s.GetAuthorAsync(It.IsAny<int>())).ReturnsAsync(author);

            var sut = CreateAuthorController(_mockAuthorRepository, _mapper, _mockLogger);

            var result = await sut.GetAuthor(authorId);

            using (new AssertionScope())
            {
                if (expectedStatusCode == StatusCodes.Status200OK)
                {
                    result.Should().BeOfType<ActionResult<Author>>();
                    result.GetObjectResult().Should().BeOfType<Author>();
                    result.GetObjectResult().Id.Should().Be(authorId);
                    result.GetObjectResult().Id.Should().Be(author.Id);
                }
                else
                {
                    result.Result.Should().BeOfType<NotFoundResult>();
                }
            }
        }

        [Fact]
        public async Task create_author_bad_request_succeeds()
        {
            var sut = CreateAuthorController(_mockAuthorRepository, _mapper, _mockLogger);
            var result = await sut.CreateAuthor(null);
            
            using (new AssertionScope())
            {
                (result.Result as BadRequestObjectResult)?.StatusCode?.Should().Be(StatusCodes.Status400BadRequest);
            }
        }

        [Fact]
        public async Task create_author_succeeds()
        {
            _mockAuthorRepository.Setup(s => s.AddAsync(It.IsAny<Author>())).ReturnsAsync(
                new Author() { Id = 99, AuthorCode = "111-22-3333", FirstName = "A", LastName = "B", PhoneNumber = "1", Contract = false });
            
            var newAuthor = new AuthorCreateDto() { AuthorCode = "111-22-3333", FirstName = "A", LastName = "B", PhoneNumber = "1" };
            var sut = CreateAuthorController(_mockAuthorRepository, _mapper, _mockLogger);
            var result = await sut.CreateAuthor(newAuthor);

            using (new AssertionScope())
            {
                result.GetObjectResult().Should().BeOfType<Author>();
                result.GetObjectResult().AuthorCode.Should().Be(newAuthor.AuthorCode);
                result.GetObjectResult().Id.Should().Be(99);
            }
        }

        [Fact]
        public async Task delete_author_not_found_succeeds()
        {
            _mockAuthorRepository.Setup(s => s.GetAuthorAsync(It.IsAny<int>())).ReturnsAsync((Author)null);

            var sut = CreateAuthorController(_mockAuthorRepository, _mapper, _mockLogger);

            var result = await sut.DeleteAuthor(787);

            using (new AssertionScope())
            {
                (result as NotFoundObjectResult)?.StatusCode?.Should().Be(StatusCodes.Status404NotFound);
            }
        }

        [Fact]
        public async Task delete_author_succeeds()
        {
            var author = new Author() { Id = 99, AuthorCode = "111-22-3333", FirstName = "A", LastName = "B", PhoneNumber = "1", Contract = false };
            _mockAuthorRepository.Setup(s => s.GetAuthorAsync(It.IsAny<int>())).ReturnsAsync(author);

            var sut = CreateAuthorController(_mockAuthorRepository, _mapper, _mockLogger);

            var result = await sut.DeleteAuthor(author.Id);

            using (new AssertionScope())
            {
                (result as NoContentResult)?.StatusCode.Should().Be(StatusCodes.Status204NoContent);
            }
        }

        [Fact]
        public async Task update_author_null_author_bad_request_succeeds()
        {
            var sut = CreateAuthorController(_mockAuthorRepository, _mapper, _mockLogger);
            var result = await sut.UpdateAuthor(12, null);

            using (new AssertionScope())
            {
                (result.Result as BadRequestObjectResult)?.StatusCode?.Should().Be(StatusCodes.Status400BadRequest);
            }
        }

        [Fact]
        public async Task update_author_mismatched_author_bad_request_succeeds()
        {
            var sut = CreateAuthorController(_mockAuthorRepository, _mapper, _mockLogger);
            var result = await sut.UpdateAuthor(12, new AuthorUpdateDto() { AuthorId = 77 });

            using (new AssertionScope())
            {
                (result.Result as BadRequestObjectResult)?.StatusCode?.Should().Be(StatusCodes.Status400BadRequest);
            }
        }

        [Fact]
        public async Task update_author_not_found_succeeds()
        {
            _mockAuthorRepository.Setup(s => s.GetAuthorAsync(It.IsAny<int>())).ReturnsAsync((Author)null);

            var sut = CreateAuthorController(_mockAuthorRepository, _mapper, _mockLogger);

            var result = await sut.UpdateAuthor(787, new AuthorUpdateDto() { AuthorId = 787 });

            using (new AssertionScope())
            {
                (result.Result as NotFoundObjectResult)?.StatusCode?.Should().Be(StatusCodes.Status404NotFound);
            }
        }

        [Fact]
        public async Task update_author_succeeds()
        {
            var author = new Author() { Id = 99, AuthorCode = "111-22-3333", FirstName = "A", LastName = "B", PhoneNumber = "1", Contract = false };
            var authorUpdated = new Author() { Id = 99, AuthorCode = "111-22-3333", FirstName = "Unit", LastName = "Test", PhoneNumber = "1", Contract = false };
            var authorDto = new AuthorUpdateDto() { AuthorId = 99, FirstName = "Unit", LastName = "Test", PhoneNumber = "1" };
            _mockAuthorRepository.Setup(s => s.GetAuthorAsync(It.IsAny<int>())).ReturnsAsync(author);
            _mockAuthorRepository.Setup(s => s.UpdateAsync(It.IsAny<Author>()));

            var sut = CreateAuthorController(_mockAuthorRepository, _mapper, _mockLogger);

            var result = await sut.UpdateAuthor(99, authorDto);

            using (new AssertionScope())
            {
                result.GetObjectResult().Should().BeOfType<Author>();
                result.GetObjectResult().FirstName.Should().Be(authorUpdated.FirstName);
                result.GetObjectResult().LastName.Should().Be(authorUpdated.LastName);
                result.GetObjectResult().Id.Should().Be(99);
            }
        }

        [Fact]
        public async Task patch_author_code_null_author_bad_request_succeeds()
        {
            var sut = CreateAuthorController(_mockAuthorRepository, _mapper, _mockLogger);
            var result = await sut.PatchUpdateAuthorCode(12, null);

            using (new AssertionScope())
            {
                (result.Result as BadRequestObjectResult)?.StatusCode?.Should().Be(StatusCodes.Status400BadRequest);
            }
        }

        [Fact]
        public async Task patch_author_code_mismatched_author_bad_request_succeeds()
        {
            var sut = CreateAuthorController(_mockAuthorRepository, _mapper, _mockLogger);
            var result = await sut.PatchUpdateAuthorCode(12, new AuthorUpdateAuthorCodeDto() { AuthorId = 77 });

            using (new AssertionScope())
            {
                (result.Result as BadRequestObjectResult)?.StatusCode?.Should().Be(StatusCodes.Status400BadRequest);
            }
        }

        [Fact]
        public async Task patch_author_code_not_found_succeeds()
        {
            _mockAuthorRepository.Setup(s => s.GetAuthorAsync(It.IsAny<int>())).ReturnsAsync((Author)null);

            var sut = CreateAuthorController(_mockAuthorRepository, _mapper, _mockLogger);

            var result = await sut.PatchUpdateAuthorCode(99, new AuthorUpdateAuthorCodeDto() { AuthorId = 99 });

            using (new AssertionScope())
            {
                (result.Result as NotFoundObjectResult)?.StatusCode?.Should().Be(StatusCodes.Status404NotFound);
            }
        }

        [Fact]
        public async Task patch_author_code_author_succeeds()
        {
            var author = new Author() { Id = 737, AuthorCode = "111-22-3333", FirstName = "A", LastName = "B", PhoneNumber = "1", Contract = false };
            var authorUpdated = new Author() { Id = 737, AuthorCode = "444-55-6666", FirstName = "Unit", LastName = "Test", PhoneNumber = "1", Contract = false };
            var authorDto = new AuthorUpdateAuthorCodeDto() { AuthorId = 737, AuthorCode = "444-55-6666" };
            _mockAuthorRepository.Setup(s => s.GetAuthorAsync(It.IsAny<int>())).ReturnsAsync(author);
            _mockAuthorRepository.Setup(s => s.UpdateAsync(It.IsAny<Author>()));

            var sut = CreateAuthorController(_mockAuthorRepository, _mapper, _mockLogger);

            var result = await sut.PatchUpdateAuthorCode(737, authorDto);
            using (new AssertionScope())
            {
                result.GetObjectResult().Should().BeOfType<Author>();
                result.GetObjectResult().AuthorCode.Should().Be(authorUpdated.AuthorCode);
                result.GetObjectResult().Id.Should().Be(737);
            }
        }

        [Fact]
        public async Task patch_author_contract_null_author_bad_request_succeeds()
        {
            var sut = CreateAuthorController(_mockAuthorRepository, _mapper, _mockLogger);
            var result = await sut.PatchUpdateAuthorContract(12, null);

            using (new AssertionScope())
            {
                (result.Result as BadRequestObjectResult)?.StatusCode?.Should().Be(StatusCodes.Status400BadRequest);
            }
        }

        [Fact]
        public async Task patch_author_contract_mismatched_author_bad_request_succeeds()
        {
            var sut = CreateAuthorController(_mockAuthorRepository, _mapper, _mockLogger);
            var result = await sut.PatchUpdateAuthorContract(12, new AuthorUpdateContractDto() { AuthorId = 77 });

            using (new AssertionScope())
            {
                (result.Result as BadRequestObjectResult)?.StatusCode?.Should().Be(StatusCodes.Status400BadRequest);
            }
        }

        [Fact]
        public async Task patch_author_contract_not_found_succeeds()
        {
            _mockAuthorRepository.Setup(s => s.GetAuthorAsync(It.IsAny<int>())).ReturnsAsync((Author)null);

            var sut = CreateAuthorController(_mockAuthorRepository, _mapper, _mockLogger);

            var result = await sut.PatchUpdateAuthorContract(18, new AuthorUpdateContractDto() { AuthorId = 18 });

            using (new AssertionScope())
            {
                (result.Result as NotFoundObjectResult)?.StatusCode?.Should().Be(StatusCodes.Status404NotFound);
            }
        }

        [Fact]
        public async Task patch_author_contract_author_succeeds()
        {
            var author = new Author() { Id = 747, AuthorCode = "111-22-3333", FirstName = "A", LastName = "B", PhoneNumber = "1", Contract = false };
            var authorUpdated = new Author() { Id = 747, AuthorCode = "444-55-6666", FirstName = "Unit", LastName = "Test", PhoneNumber = "1", Contract = true };
            var authorDto = new AuthorUpdateContractDto() { AuthorId = 747, Contract = true };
            _mockAuthorRepository.Setup(s => s.GetAuthorAsync(It.IsAny<int>())).ReturnsAsync(author);
            _mockAuthorRepository.Setup(s => s.UpdateAsync(It.IsAny<Author>()));

            var sut = CreateAuthorController(_mockAuthorRepository, _mapper, _mockLogger);

            var result = await sut.PatchUpdateAuthorContract(747, authorDto);

            using (new AssertionScope())
            {
                result.GetObjectResult().Should().BeOfType<Author>();
                result.GetObjectResult().Contract.Should().Be(authorUpdated.Contract);
                result.GetObjectResult().Id.Should().Be(747);
            }
        }




        #region Public Static Test Data Members

        public static IEnumerable<object[]> GetAuthorsData =>
            new List<object[]>
            {
                new object[] { 1, StatusCodes.Status200OK, new Author() {Id = 1, AuthorCode = "1" } },
                new object[] { 2, StatusCodes.Status200OK, new Author() {Id = 2, AuthorCode = "2" } },
                new object[] { 3, StatusCodes.Status200OK, new Author() {Id = 3, AuthorCode = "3" } },
                new object[] { 777, StatusCodes.Status404NotFound },
                new object[] { 787, StatusCodes.Status404NotFound},
                new object[] { 797, StatusCodes.Status404NotFound}
            };


        #endregion Public Static Test Data Members

        #region Private Methods

        private static AuthorController CreateAuthorController(
            IMock<IAuthorRepository> mockAuthorRepository,
            IMapper mapper,
            IMock<ILogger<AuthorController>> mockLogger
            )
        {
            const string locationUrl = "http://fakelocation/";
            var mockUrlHelper = new Mock<IUrlHelper>();
            mockUrlHelper
                .Setup(x => x.RouteUrl(It.IsAny<UrlRouteContext>()))
                .Returns(locationUrl);

            var authorController = new AuthorController(
                mockAuthorRepository.Object,
                mapper,
                mockLogger.Object)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext()

                },
                Url = mockUrlHelper.Object
            };


            return authorController;
        }

        #endregion Private Methods

    }
}
