namespace HRMS_Unit_Test.DTO
{
    using System;
    using HRMS_Application.DTO;
    using Xunit;

    public class EmployeeShiftAndLeaveStatsDtoTests
    {
        private readonly EmployeeShiftAndLeaveStatsDto _testClass;

        public EmployeeShiftAndLeaveStatsDtoTests()
        {
            _testClass = new EmployeeShiftAndLeaveStatsDto();
        }

        [Fact]
        public void CanSetAndGetShiftType()
        {
            // Arrange
            var testValue = "TestValue1471963424";

            // Act
            _testClass.ShiftType = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.ShiftType);
        }

        [Fact]
        public void CanSetAndGetShiftTimeRange()
        {
            // Arrange
            var testValue = "TestValue1427580838";

            // Act
            _testClass.ShiftTimeRange = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.ShiftTimeRange);
        }

        [Fact]
        public void CanSetAndGetTotalLeaveCount()
        {
            // Arrange
            var testValue = 465696730;

            // Act
            _testClass.TotalLeaveCount = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.TotalLeaveCount);
        }

        [Fact]
        public void CanSetAndGetRemainingLeaveCount()
        {
            // Arrange
            var testValue = 363563207;

            // Act
            _testClass.RemainingLeaveCount = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.RemainingLeaveCount);
        }

        [Fact]
        public void CanSetAndGetLeavePercentage()
        {
            // Arrange
            var testValue = 1276717740.21;

            // Act
            _testClass.LeavePercentage = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.LeavePercentage);
        }
    }
}