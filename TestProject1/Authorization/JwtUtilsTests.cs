namespace TestProject1.Authorization
{
    using System;
    using System.Collections.Generic;
    using HRMS_Application.Authorization;
    using HRMS_Application.DTOs;
    using HRMS_Application.Helpers;
    using Microsoft.Extensions.Options;
    using Moq;
    using Xunit;

    public class JwtUtilsTests
    {
        private JwtUtils _testClass;
        private Mock<IOptions<AppSettings>> _appSettings;

        public JwtUtilsTests()
        {
            _appSettings = new Mock<IOptions<AppSettings>>();
            _testClass = new JwtUtils(_appSettings.Object);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new JwtUtils(_appSettings.Object);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanCallGenerateJwtToken()
        {
            // Arrange
            var user = new UserDto
            {
                UserName = "TestValue1071306669",
                UserId = 135429700,
                Roles = new List<string>()
            };

            // Act
            var result = _testClass.GenerateJwtToken(user);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallValidateJwtToken()
        {
            // Arrange
            var token = "TestValue988770288";

            // Act
            var result = _testClass.ValidateJwtToken(token);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }
    }
}