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

        [Fact]
        public void CanSetAndGetName()
        {
            // Arrange
            var testValue = "TestValue309985374";

            // Act
            _testClass.Name = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Name);
        }

        [Fact]
        public void CanSetAndGetEmail()
        {
            // Arrange
            var testValue = "TestValue977781207";

            // Act
            _testClass.Email = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Email);
        }

        [Fact]
        public void CanSetAndGetMonthlyPresentDays()
        {
            // Arrange
            var testValue = 1214820218;

            // Act
            _testClass.MonthlyPresentDays = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.MonthlyPresentDays);
        }

        [Fact]
        public void CanSetAndGetTotalWorkingDays()
        {
            // Arrange
            var testValue = 1476483678;

            // Act
            _testClass.TotalWorkingDays = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.TotalWorkingDays);
        }

        [Fact]
        public void CanSetAndGetAttendancePercentage()
        {
            // Arrange
            var testValue = 1083126105.27;

            // Act
            _testClass.AttendancePercentage = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.AttendancePercentage);
        }
    }
}