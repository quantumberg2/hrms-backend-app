namespace HRMS_Unit_Test.DTO
{
    using System;
    using HRMS_Application.DTO;
    using Xunit;

    public class LeaveTrackingEmployeeDTOTests
    {
        private readonly LeaveTrackingEmployeeDTO _testClass;

        public LeaveTrackingEmployeeDTOTests()
        {
            _testClass = new LeaveTrackingEmployeeDTO();
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
        public void CanSetAndGetStatus()
        {
            // Arrange
            var testValue = "TestValue10486411";

            // Act
            _testClass.Status = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Status);
        }

        [Fact]
        public void CanSetAndGetName()
        {
            // Arrange
            var testValue = "TestValue607424395";

            // Act
            _testClass.Name = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Name);
        }

        [Fact]
        public void CanSetAndGetEmail()
        {
            // Arrange
            var testValue = "TestValue1482995229";

            // Act
            _testClass.Email = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Email);
        }
    }
}