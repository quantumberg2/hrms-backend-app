namespace HRMS_Unit_Test.Authorization
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
        private readonly JwtUtils _testClass;
        private readonly Mock<IOptions<AppSettings>> _appSettings;

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
                UserName = "TestValue1695366951",
                UserId = 200399745,
                Email = "TestValue653674234",
                RequestedCompanyId = 71798334,
                CompanyIds = new List<int>(),
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
            var token = "TestValue206289278";

            // Act
            var result = _testClass.ValidateJwtToken(token);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }
    }
}