namespace HRMS_Unit_Test.Middleware
{
    using System;
    using System.Threading.Tasks;
    using HRMS_Application.Middleware;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;
    using Moq;
    using Xunit;

    public class ExceptionMiddlewareTests
    {
        private readonly ExceptionMiddleware _testClass;
        private readonly Mock<ILogger<ExceptionMiddleware>> _log;

        public ExceptionMiddlewareTests()
        {
            _log = new Mock<ILogger<ExceptionMiddleware>>();
            _testClass = new ExceptionMiddleware(_log.Object);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new ExceptionMiddleware(_log.Object);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public async Task CanCallInvokeAsync()
        {
            // Arrange
            var context = new DefaultHttpContext();
            RequestDelegate next = x => Task.CompletedTask;

            // Act
            await _testClass.InvokeAsync(context, next);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }
    }

    public static class ExceptionMiddlewareExtensionTests
    {
        [Fact]
        public static void CanCallConfigureExceptionMiddleware()
        {
            // Arrange
            var app = new Mock<IApplicationBuilder>().Object;

            // Act
            app.ConfigureExceptionMiddleware();

            // Assert
            throw new NotImplementedException("Create or modify test");
        }
    }
}