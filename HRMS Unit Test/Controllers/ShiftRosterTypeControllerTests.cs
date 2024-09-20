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

    public class ShiftRosterTypeControllerTests
    {
        private readonly ShiftRosterTypeController _testClass;
        private readonly Mock<IShiftRostertype> _shiftRostetype;
        private readonly Mock<ILogger<ShiftRosterTypeController>> _logger;

        public ShiftRosterTypeControllerTests()
        {
            _shiftRostetype = new Mock<IShiftRostertype>();
            _logger = new Mock<ILogger<ShiftRosterTypeController>>();
            _testClass = new ShiftRosterTypeController(_shiftRostetype.Object, _logger.Object);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new ShiftRosterTypeController(_shiftRostetype.Object, _logger.Object);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanCallGetAllShiftRosterType()
        {
            // Arrange
            _shiftRostetype.Setup(mock => mock.GetAllShiftRosterType()).Returns(new List<ShiftRosterType>());

            // Act
            var result = _testClass.GetAllShiftRosterType();

            // Assert
            _shiftRostetype.Verify(mock => mock.GetAllShiftRosterType());

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallInsertPositions()
        {
            // Arrange
            var shiftRosterType = new ShiftRosterType
            {
                Id = 970035281,
                Type = "TestValue943023523",
                TimeRange = "TestValue888588227",
                ShiftRosters = new Mock<ICollection<ShiftRoster>>().Object
            };

            _shiftRostetype.Setup(mock => mock.InsertShiftRosterType(It.IsAny<ShiftRosterType>())).ReturnsAsync("TestValue647623448");

            // Act
            var result = await _testClass.InsertPositions(shiftRosterType);

            // Assert
            _shiftRostetype.Verify(mock => mock.InsertShiftRosterType(It.IsAny<ShiftRosterType>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallUpdatePosition()
        {
            // Arrange
            var id = 1747570573;
            var Type = "TestValue1076915682";
            var TimeRange = "TestValue1706529583";

            _shiftRostetype.Setup(mock => mock.updateShiftRosterType(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(new ShiftRosterType
            {
                Id = 402744524,
                Type = "TestValue2024337644",
                TimeRange = "TestValue1139896086",
                ShiftRosters = new Mock<ICollection<ShiftRoster>>().Object
            });

            // Act
            var result = await _testClass.UpdatePosition(id, Type, TimeRange);

            // Assert
            _shiftRostetype.Verify(mock => mock.updateShiftRosterType(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallDeletePosition()
        {
            // Arrange
            var id = 660154360;

            _shiftRostetype.Setup(mock => mock.deleteShiftRosterType(It.IsAny<int>())).ReturnsAsync(true);

            // Act
            var result = await _testClass.DeletePosition(id);

            // Assert
            _shiftRostetype.Verify(mock => mock.deleteShiftRosterType(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }
    }
}