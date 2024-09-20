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

    public class ShiftRosterControllerTests
    {
        private readonly ShiftRosterController _testClass;
        private readonly Mock<IShiftRoster> _shiftRoster;
        private readonly Mock<ILogger<ShiftRosterController>> _logger;

        public ShiftRosterControllerTests()
        {
            _shiftRoster = new Mock<IShiftRoster>();
            _logger = new Mock<ILogger<ShiftRosterController>>();
            _testClass = new ShiftRosterController(_shiftRoster.Object, _logger.Object);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new ShiftRosterController(_shiftRoster.Object, _logger.Object);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanCallGetAllShiftRoster()
        {
            // Arrange
            _shiftRoster.Setup(mock => mock.GetAllShiftRoster()).Returns(new List<ShiftRoster>());

            // Act
            var result = _testClass.GetAllShiftRoster();

            // Assert
            _shiftRoster.Verify(mock => mock.GetAllShiftRoster());

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallInsertShiftRoster()
        {
            // Arrange
            var shiftRoster = new ShiftRoster
            {
                Id = 1388492343,
                EmpCredentialId = 360324002,
                ShiftRosterTypeId = 634625201,
                Startdate = DateTime.UtcNow,
                Enddate = DateTime.UtcNow,
                ShiftRosterType = new ShiftRosterType
                {
                    Id = 451076007,
                    Type = "TestValue802476860",
                    TimeRange = "TestValue1214730792",
                    ShiftRosters = new Mock<ICollection<ShiftRoster>>().Object
                }
            };

            _shiftRoster.Setup(mock => mock.InsertShiftRoster(It.IsAny<ShiftRoster>())).ReturnsAsync("TestValue1410838325");

            // Act
            var result = await _testClass.InsertShiftRoster(shiftRoster);

            // Assert
            _shiftRoster.Verify(mock => mock.InsertShiftRoster(It.IsAny<ShiftRoster>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallDeleteShiftRoster()
        {
            // Arrange
            var id = 1369719711;

            _shiftRoster.Setup(mock => mock.deleteShiftRoster(It.IsAny<int>())).ReturnsAsync(true);

            // Act
            var result = await _testClass.DeleteShiftRoster(id);

            // Assert
            _shiftRoster.Verify(mock => mock.deleteShiftRoster(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }
    }
}