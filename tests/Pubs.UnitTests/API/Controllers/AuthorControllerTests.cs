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
        public async Task get_authors_succeeds()
        {
            _mockAuthorRepository.Setup(s => s.GetAuthorsAsync())
                .ReturnsAsync(new List<Author>() {
                new Author() { Id = 1, AuthorCode = "123-45-6789", FirstName = "Babe", LastName = "Ruth", Contract = false },
                new Author() { Id = 2, AuthorCode = "223-45-6789", FirstName = "Lou", LastName = "Gehrig", Contract = false }
            });

            var sut = CreateAuthorController(_mockAuthorRepository, _mapper, _mockLogger);

            var result = await sut.GetAuthors();
            var okResult =  result.Result as OkObjectResult;
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
