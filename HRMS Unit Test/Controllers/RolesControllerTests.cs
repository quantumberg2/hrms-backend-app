namespace HRMS_Unit_Test.Controllers
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
        private readonly RolesController _testClass;
        private readonly Mock<IRoles> _roles;
        private readonly Mock<ILogger<RolesController>> _logger;

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
                Id = 1201624934,
                Name = "TestValue1348110667",
                IsActive = (short)7687,
                UserRolesJs = new Mock<ICollection<UserRolesJ>>().Object
            };

            _roles.Setup(mock => mock.InsertRole(It.IsAny<Role>())).ReturnsAsync("TestValue1200230203");

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
            var id = 16432163;

            _roles.Setup(mock => mock.deleteRole(It.IsAny<int>())).ReturnsAsync(true);

            // Act
            var result = await _testClass.DeleteRole(id);

            // Assert
            _roles.Verify(mock => mock.deleteRole(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallSoftDelete()
        {
            // Arrange
            var id = 2043983025;
            var isActive = (short)8494;

            _roles.Setup(mock => mock.SoftDelete(It.IsAny<int>(), It.IsAny<short>())).Returns(true);

            // Act
            var result = _testClass.SoftDelete(id, isActive);

            // Assert
            _roles.Verify(mock => mock.SoftDelete(It.IsAny<int>(), It.IsAny<short>()));

            throw new NotImplementedException("Create or modify test");
        }
    }
}