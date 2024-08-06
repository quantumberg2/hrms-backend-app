namespace HRMSunitTestCase.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using HRMS_Application.BusinessLogic.Interface;
    using HRMS_Application.Controllers;
    using HRMS_Application.Models;
    using Microsoft.Extensions.Logging;
    using Moq;
    using Xunit;

    public class RolesControllerTests
    {
        private RolesController _testClass;
        private Mock<IRoles> _roles;
        private Mock<ILogger<RolesController>> _logger;

        public RolesControllerTests()
        {
            _roles = new Mock<IRoles>();
            _logger = new Mock<ILogger<RolesController>>();
            _testClass = new RolesController(_roles.Object, _logger.Object);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new RolesController(_roles.Object, _logger.Object);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanCallGetAllRole()
        {
            // Arrange
            _roles.Setup(mock => mock.GetAllRoles()).Returns(new List<Role>());

            // Act
            var result = _testClass.GetAllRole();

            // Assert
            _roles.Verify(mock => mock.GetAllRoles());

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallInsertRoles()
        {
            // Arrange
            var role = new Role
            {
                Id = 78052871,
                Name = "TestValue1416130903",
                UserRolesJs = new Mock<ICollection<UserRolesJ>>().Object
            };

            _roles.Setup(mock => mock.InsertRole(It.IsAny<Role>())).ReturnsAsync("TestValue1169218105");

            // Act
            var result = await _testClass.InsertRoles(role);

            // Assert
            _roles.Verify(mock => mock.InsertRole(It.IsAny<Role>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallDeleteRole()
        {
            // Arrange
            var id = 235964395;

            _roles.Setup(mock => mock.deleteRole(It.IsAny<int>())).ReturnsAsync(true);

            // Act
            var result = await _testClass.DeleteRole(id);

            // Assert
            _roles.Verify(mock => mock.deleteRole(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }
    }
}