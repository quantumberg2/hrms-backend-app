namespace HRMS_Unit_Test.DTO
{
    using System;
    using HRMS_Application.DTO;
    using Xunit;

    public class LeaveApprovalDTOTests
    {
        private readonly LeaveApprovalDTO _testClass;

        public LeaveApprovalDTOTests()
        {
            _testClass = new LeaveApprovalDTO();
        }

        [Fact]
        public void CanSetAndGetId()
        {
            // Arrange
            var testValue = 2011474673;

            // Act
            _testClass.Id = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Id);
        }

        [Fact]
        public void CanSetAndGetEmployeeNumber()
        {
            // Arrange
            var testValue = "TestValue2141689482";

            // Act
            _testClass.EmployeeNumber = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.EmployeeNumber);
        }

        [Fact]
        public void CanSetAndGetName()
        {
            // Arrange
            var testValue = "TestValue336227701";

            // Act
            _testClass.Name = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Name);
        }

        [Fact]
        public void CanSetAndGetLeaveType()
        {
            // Arrange
            var testValue = "TestValue1068405414";

            // Act
            _testClass.LeaveType = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.LeaveType);
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
        public void CanSetAndGetNoofDays()
        {
            // Arrange
            var testValue = 510561981;

            // Act
            _testClass.NoofDays = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.NoofDays);
        }
    }
}