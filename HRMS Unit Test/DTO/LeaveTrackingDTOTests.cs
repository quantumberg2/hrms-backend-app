namespace HRMS_Unit_Test.DTO
{
    using System;
    using HRMS_Application.DTO;
    using Xunit;

    public class LeaveTrackingDTOTests
    {
        private readonly LeaveTrackingDTO _testClass;

        public LeaveTrackingDTOTests()
        {
            _testClass = new LeaveTrackingDTO();
        }

        [Fact]
        public void CanSetAndGetId()
        {
            // Arrange
            var testValue = 88098370;

            // Act
            _testClass.Id = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Id);
        }

        [Fact]
        public void CanSetAndGetStartDate()
        {
            // Arrange
            var testValue = DateTime.UtcNow;

            // Act
            _testClass.StartDate = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.StartDate);
        }

        [Fact]
        public void CanSetAndGetEndDate()
        {
            // Arrange
            var testValue = DateTime.UtcNow;

            // Act
            _testClass.EndDate = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.EndDate);
        }

        [Fact]
        public void CanSetAndGetApplied()
        {
            // Arrange
            var testValue = DateTime.UtcNow;

            // Act
            _testClass.Applied = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Applied);
        }

        [Fact]
        public void CanSetAndGetFiles()
        {
            // Arrange
            var testValue = "TestValue2046749989";

            // Act
            _testClass.Files = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Files);
        }

        [Fact]
        public void CanSetAndGetLeaveTypeId()
        {
            // Arrange
            var testValue = 1255138132;

            // Act
            _testClass.LeaveTypeId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.LeaveTypeId);
        }

        [Fact]
        public void CanSetAndGetSession()
        {
            // Arrange
            var testValue = "TestValue475977654";

            // Act
            _testClass.Session = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Session);
        }

        [Fact]
        public void CanSetAndGetContact()
        {
            // Arrange
            var testValue = "TestValue27553552";

            // Act
            _testClass.Contact = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Contact);
        }

        [Fact]
        public void CanSetAndGetReasonForLeave()
        {
            // Arrange
            var testValue = "TestValue816098063";

            // Act
            _testClass.ReasonForLeave = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.ReasonForLeave);
        }
    }
}