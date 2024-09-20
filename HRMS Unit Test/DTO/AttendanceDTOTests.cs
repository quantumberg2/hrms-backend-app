namespace HRMS_Unit_Test.DTO
{
    using System;
    using HRMS_Application.DTO;
    using Xunit;

    public class AttendanceDTOTests
    {
        private readonly AttendanceDTO _testClass;

        public AttendanceDTOTests()
        {
            _testClass = new AttendanceDTO();
        }

        [Fact]
        public void CanSetAndGetTimeIn()
        {
            // Arrange
            var testValue = DateTime.UtcNow;

            // Act
            _testClass.TimeIn = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.TimeIn);
        }

        [Fact]
        public void CanSetAndGetTimeOut()
        {
            // Arrange
            var testValue = DateTime.UtcNow;

            // Act
            _testClass.TimeOut = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.TimeOut);
        }

        [Fact]
        public void CanSetAndGetStatus()
        {
            // Arrange
            var testValue = "TestValue398908296";

            // Act
            _testClass.Status = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Status);
        }
    }
}