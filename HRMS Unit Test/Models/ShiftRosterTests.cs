namespace HRMS_Unit_Test.Models
{
    using System;
    using System.Collections.Generic;
    using HRMS_Application.Models;
    using Moq;
    using Xunit;

    public partial class ShiftRosterTests
    {
        private readonly ShiftRoster _testClass;

        public ShiftRosterTests()
        {
            _testClass = new ShiftRoster();
        }

        [Fact]
        public void CanSetAndGetId()
        {
            // Arrange
            var testValue = 879117060;

            // Act
            _testClass.Id = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Id);
        }

        [Fact]
        public void CanSetAndGetEmpCredentialId()
        {
            // Arrange
            var testValue = 440248;

            // Act
            _testClass.EmpCredentialId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.EmpCredentialId);
        }

        [Fact]
        public void CanSetAndGetShiftRosterTypeId()
        {
            // Arrange
            var testValue = 916828253;

            // Act
            _testClass.ShiftRosterTypeId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.ShiftRosterTypeId);
        }

        [Fact]
        public void CanSetAndGetStartdate()
        {
            // Arrange
            var testValue = DateTime.UtcNow;

            // Act
            _testClass.Startdate = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Startdate);
        }

        [Fact]
        public void CanSetAndGetEnddate()
        {
            // Arrange
            var testValue = DateTime.UtcNow;

            // Act
            _testClass.Enddate = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Enddate);
        }

        [Fact]
        public void CanSetAndGetShiftRosterType()
        {
            // Arrange
            var testValue = new ShiftRosterType
            {
                Id = 1535676266,
                Type = "TestValue1892546635",
                TimeRange = "TestValue489936907",
                ShiftRosters = new Mock<ICollection<ShiftRoster>>().Object
            };

            // Act
            _testClass.ShiftRosterType = testValue;

            // Assert
            Assert.Same(testValue, _testClass.ShiftRosterType);
        }
    }
}