using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Moq;
using Pubs.UI.Controllers;
using Pubs.UnitTests.Setup;
using System;
using Xunit;

namespace Pubs.UnitTests.UI.Controllers
{
    public class HomeControllerTests : UnitTestBase
    {
        public Type SutType => typeof(HomeController);

        [Fact]
        public void privacy_returns_view_result()
        {
            var controller = CreateHomeController();

            var result = controller.Privacy();

            using (new AssertionScope())
            {
                result.Should().NotBeNull();
                result.Should().BeOfType<ViewResult>();

                var viewResult = (ViewResult)result;
                var viewData = viewResult.ViewData;
            }
        }


        [Fact]
        public void error_returns_view_result()
        {
            var controller = CreateHomeController();

            var result = controller.Error();

            using (new AssertionScope())
            {
                result.Should().NotBeNull();
                result.Should().BeOfType<ViewResult>();

                var viewResult = (ViewResult)result;
                var viewData = viewResult.ViewData;
            }
        }


        #region Private Methods

        private static HomeController CreateHomeController()
        {
            const string locationUrl = "http://fakelocation/";
            var mockUrlHelper = new Mock<IUrlHelper>();
            mockUrlHelper
                .Setup(x => x.RouteUrl(It.IsAny<UrlRouteContext>()))
                .Returns(locationUrl);

            var homeController = new HomeController()
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext
                    {
                        
                    }
                },
                Url = mockUrlHelper.Object
            };

            return homeController;
        }

        #endregion
    }
}
