namespace HRMS_Unit_Test.Authorization
{
    using System;
    using System.Threading.Tasks;
    using HRMS_Application.Authorization;
    using HRMS_Application.BusinessLogics.Interface;
    using HRMS_Application.Helpers;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Options;
    using Moq;
    using Xunit;

    public class JwtMiddlewareTests
    {
        private readonly JwtMiddleware _testClass;
        private RequestDelegate _next;
        private readonly Mock<IOptions<AppSettings>> _appSettings;

        public JwtMiddlewareTests()
        {
            _next = x => Task.CompletedTask;
            _appSettings = new Mock<IOptions<AppSettings>>();
            _testClass = new JwtMiddleware(_next, _appSettings.Object);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new JwtMiddleware(_next, _appSettings.Object);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public async Task CanCallInvoke()
        {
            // Arrange
            var context = new DefaultHttpContext();
            var UserImp = new Mock<IUser>().Object;
            var jwtUtils = new Mock<IJwtUtils>().Object;

            // Act
            await _testClass.Invoke(context, UserImp, jwtUtils);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }
    }
}