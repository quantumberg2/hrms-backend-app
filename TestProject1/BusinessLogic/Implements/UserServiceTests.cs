namespace TestProject1.BusinessLogics.Implements
{
    using System;
    using HRMS_Application.Authorization;
    using HRMS_Application.BusinessLogics.Implements;
    using HRMS_Application.DTOs;
    using HRMS_Application.Helpers;
    using HRMS_Application.Models;
    using HRMS_Application.Models.Users;
    using Microsoft.Extensions.Options;
    using Moq;
    using Xunit;

    public class UserServiceTests
    {
        private UserService _testClass;
        private HRMSContext _hrmsContext;
        private Mock<IJwtUtils> _jwtUtils;
        private Mock<IOptions<AppSettings>> _appSettings;

        public UserServiceTests()
        {
            _hrmsContext = new HRMSContext();
            _jwtUtils = new Mock<IJwtUtils>();
            _appSettings = new Mock<IOptions<AppSettings>>();
            _testClass = new UserService(_hrmsContext, _jwtUtils.Object, _appSettings.Object);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new UserService(_hrmsContext, _jwtUtils.Object, _appSettings.Object);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanCallAuthenticate()
        {
            // Arrange
            var model = new AuthenticateRequest
            {
                Username = "TestValue1607263721",
                Password = "TestValue1578250639"
            };

            _jwtUtils.Setup(mock => mock.GenerateJwtToken(It.IsAny<UserDto>())).Returns("TestValue905492507");

            // Act
            var result = _testClass.Authenticate(model);

            // Assert
            _jwtUtils.Verify(mock => mock.GenerateJwtToken(It.IsAny<UserDto>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetAll()
        {
            // Act
            var result = _testClass.GetAll();

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetById()
        {
            // Arrange
            var id = 763123304;

            // Act
            var result = _testClass.GetById(id);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }
    }
}