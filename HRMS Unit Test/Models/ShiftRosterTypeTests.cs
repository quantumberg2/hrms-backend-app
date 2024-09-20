namespace HRMS_Unit_Test.Models
{
    using System;
    using System.Collections.Generic;
    using HRMS_Application.Models;
    using Moq;
    using Xunit;

    public partial class ShiftRosterTypeTests
    {
        private readonly ShiftRosterType _testClass;

        public ShiftRosterTypeTests()
        {
            _testClass = new ShiftRosterType();
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new ShiftRosterType();

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanSetAndGetId()
        {
            // Arrange
            var testValue = 192779282;

            // Act
            _testClass.Id = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Id);
        }

        [Fact]
        public void CanSetAndGetType()
        {
            // Arrange
            var testValue = "TestValue139762141";

            // Act
            _testClass.Type = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Type);
        }

        [Fact]
        public void CanSetAndGetTimeRange()
        {
            // Arrange
            var testValue = "TestValue1122451098";

            // Act
            _testClass.TimeRange = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.TimeRange);
        }

        [Fact]
        public void CanSetAndGetShiftRosters()
        {
            // Arrange
            var testValue = new Mock<ICollection<ShiftRoster>>().Object;

            // Act
            _testClass.ShiftRosters = testValue;

            // Assert
            Assert.Same(testValue, _testClass.ShiftRosters);
        }
    }
}