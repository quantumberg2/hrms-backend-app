namespace HRMS_Unit_Test.BusinessLogics.Implements
{
    using System;
    using HRMS_Application.Authorization;
    using HRMS_Application.BusinessLogics.Implements;
    using HRMS_Application.DTO;
    using HRMS_Application.DTOs;
    using HRMS_Application.Helpers;
    using HRMS_Application.Models;
    using HRMS_Application.Models.Users;
    using Microsoft.Extensions.Options;
    using Moq;
    using Xunit;

    public class UserServiceTests
    {
        private readonly UserService _testClass;
        private HRMSContext _hrmsContext;
        private readonly Mock<IJwtUtils> _jwtUtils;
        private readonly Mock<IOptions<AppSettings>> _appSettings;

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
                Username = "TestValue1822580608",
                Password = "TestValue1408824786"
            };

            _jwtUtils.Setup(mock => mock.GenerateJwtToken(It.IsAny<UserDto>())).Returns("TestValue1996317196");

            // Act
            var result = _testClass.Authenticate(model);

            // Assert
            _jwtUtils.Verify(mock => mock.GenerateJwtToken(It.IsAny<UserDto>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallSelectCompany()
        {
            // Arrange
            var model = new SelectCompanyRequest { CompanyId = 1464199589 };
            var Userid = 2065783220;

            _jwtUtils.Setup(mock => mock.GenerateJwtToken(It.IsAny<UserDto>())).Returns("TestValue682944920");

            // Act
            var result = _testClass.SelectCompany(model, Userid);

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
            var id = 1288879463;

            // Act
            var result = _testClass.GetById(id);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }
    }
}