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
    public class AuthorTitlesControllerTests : UnitTestBase
    {
        #region Private Fields & Mock Members

        private readonly IMapper _mapper;
        private readonly Mock<IAuthorRepository> _mockAuthorRepository;
        private readonly Mock<ILogger<AuthorTitlesController>> _mockLogger;

        #endregion Private Fields & Mock Members

        public AuthorTitlesControllerTests()
        {
            var mappingConfig = new MapperConfiguration(
                m =>
                {
                    m.AddProfile(new AuthorTitleProfile());
                });
            _mapper = mappingConfig.CreateMapper();

            _mockAuthorRepository = new Mock<IAuthorRepository>();
            _mockLogger = new Mock<ILogger<AuthorTitlesController>>();
        }

        [Fact]
        public void controller_has_correct_attributes()
        {
            var controllerAttribute = (ApiControllerAttribute)typeof(AuthorTitlesController).GetCustomAttributes(typeof(ApiControllerAttribute), true).SingleOrDefault();
            var producesAttribute = (ProducesAttribute)typeof(AuthorTitlesController).GetCustomAttributes(typeof(ProducesAttribute), true).SingleOrDefault();
            var routeAttribute = (RouteAttribute)typeof(AuthorTitlesController).GetCustomAttributes(typeof(RouteAttribute), true).SingleOrDefault();

            using (new AssertionScope())
            {
                controllerAttribute.Should().NotBeNull();
                producesAttribute.Should().NotBeNull();
                routeAttribute.Should().NotBeNull();

                producesAttribute.ContentTypes.Count(x => x == "application/json").Should().Be(1);
                producesAttribute.ContentTypes.Count(x => x == "application/xml").Should().Be(1);

                routeAttribute.Name.Should().Be("authorTitlesRoute");
                routeAttribute.Template.Should().Be("api/authors/{authorId}/titles");
            }
        }

        [Fact]
        public void constructor_throws_correct_exceptions()
        {
            using (new AssertionScope())
            {
                ((Action)(() => new AuthorTitlesController(null, _mapper, _mockLogger.Object)))
                    .Should().Throw<ArgumentNullException>()
                    .And.ParamName.Should().Be("authorRepository");

                ((Action)(() => new AuthorTitlesController(_mockAuthorRepository.Object, null, _mockLogger.Object)))
                    .Should().Throw<ArgumentNullException>()
                    .And.ParamName.Should().Be("mapper");

                ((Action)(() => new AuthorTitlesController(_mockAuthorRepository.Object, _mapper, null)))
                    .Should().Throw<ArgumentNullException>()
                    .And.ParamName.Should().Be("logger");
            }
        }

        [Fact]
        public void get_titles_for_author_has_correct_attributes()
        {
            var sut = typeof(AuthorTitlesController)
                        .GetMethods(BindingFlags.Public | BindingFlags.Instance)
                        .SingleOrDefault(p => p.Name == nameof(AuthorTitlesController.GetTitlesForAuthor));

            var httpHead = (HttpHeadAttribute)Attribute.GetCustomAttribute(sut, typeof(HttpHeadAttribute));
            var httpGet = (HttpGetAttribute)Attribute.GetCustomAttribute(sut, typeof(HttpGetAttribute));
            var responseTypeList = ((ProducesResponseTypeAttribute[])Attribute.GetCustomAttributes(sut, typeof(ProducesResponseTypeAttribute))).ToList();

            using (new AssertionScope())
            {
                httpHead.Should().NotBeNull();
                httpGet.Should().NotBeNull();
                responseTypeList.Should().NotBeNull();

                httpGet.Name.Should().Be("GetTitlesForAuthor");

                responseTypeList.Count(x => x.StatusCode == StatusCodes.Status200OK).Should().Be(1);
                responseTypeList.Count(x => x.StatusCode == StatusCodes.Status404NotFound).Should().Be(1);
            }
        }

        [Fact]
        public async Task get_titles_for_authors_succeeds()
        {
            _mockAuthorRepository.Setup(s => s.IsAuthorValid(It.IsAny<int>())).Returns(true);
            _mockAuthorRepository.Setup(s => s.GetTitlesForAuthorAsync(It.IsAny<int>()))
                .ReturnsAsync(new List<AuthorTitle>() {
                    new AuthorTitle()
                    {
                        Id = 1,
                        AuthorId = 1,
                        Author = new Author() { Id = 1, AuthorCode = "123-45-6789", FirstName = "Babe", LastName = "Ruth", Contract = false },
                        TitleCode = "ABC",
                        TitleId = 765,
                        Title = new Title() { Id = 765, TitleName = "Unit Test", TitleCode = "ABC", TitleType = "XYZ-1234" }
                    },
                    new AuthorTitle()
                    {
                        Id = 2,
                        AuthorId = 1,
                        Author = new Author() { Id = 1, AuthorCode = "123-45-6789", FirstName = "Babe", LastName = "Ruth", Contract = false },
                        TitleCode = "ASDFKLJHASLDHF",
                        TitleId = 8745,
                        Title = new Title() { Id = 8745, TitleName = "Unit Test 1456", TitleCode = "ASDFKLJHASLDHF", TitleType = "XYZ-1234" }
                    },
                    new AuthorTitle()
                    {
                        Id = 3,
                        AuthorId = 1,
                        Author = new Author() { Id = 1, AuthorCode = "123-45-6789", FirstName = "Babe", LastName = "Ruth", Contract = false },
                        TitleCode = "654654",
                        TitleId = 8745,
                        Title = new Title() { Id = 8745, TitleName = "Unit Test 65414", TitleCode = "654654", TitleType = "XYZ-1234" }
                    }
            });

            var sut = CreateAuthorTitlesController(_mockAuthorRepository, _mapper, _mockLogger);

            var result = await sut.GetTitlesForAuthor(1);
            var okResult = result.Result as OkObjectResult;
            var authorTitleList = okResult.Value as List<AuthorTitleDto>;

            using (new AssertionScope())
            {
                result.Should().BeOfType<ActionResult<List<AuthorTitleDto>>>();
                authorTitleList.Count.Should().Be(3);
                authorTitleList.Count(x => x.AuthorTitleId == 1).Should().Be(1);
                authorTitleList.Count(x => x.AuthorTitleId == 2).Should().Be(1);
                authorTitleList.Count(x => x.AuthorTitleId == 3).Should().Be(1);
                authorTitleList.Count(x => x.AuthorTitleId == 4).Should().Be(0);
            }
        }

        [Fact]
        public async Task get_titles_for_author_not_found_author_succeeds()
        {
            // Arrange 
            _mockAuthorRepository.Setup(s => s.IsAuthorValid(It.IsAny<int>())).Returns(false);            
            var sut = CreateAuthorTitlesController(_mockAuthorRepository, _mapper, _mockLogger);
            
            // Act
            var result = await sut.GetTitlesForAuthor(1);
            
            // Assert 
            result.Result.Should().BeOfType<NotFoundResult>();

        }



        #region Private Methods

        private static AuthorTitlesController CreateAuthorTitlesController(
            IMock<IAuthorRepository> mockAuthorRepository,
            IMapper mapper,
            IMock<ILogger<AuthorTitlesController>> mockLogger
            )
        {
            const string locationUrl = "http://fakelocation/";
            var mockUrlHelper = new Mock<IUrlHelper>();
            mockUrlHelper
                .Setup(x => x.RouteUrl(It.IsAny<UrlRouteContext>()))
                .Returns(locationUrl);

            var authorController = new AuthorTitlesController(
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
