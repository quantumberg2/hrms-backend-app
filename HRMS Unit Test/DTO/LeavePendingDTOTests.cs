namespace HRMS_Unit_Test.DTO
{
    using System;
    using HRMS_Application.DTO;
    using Xunit;

    public class LeavePendingDTOTests
    {
        private readonly LeavePendingDTO _testClass;

        public LeavePendingDTOTests()
        {
            _testClass = new LeavePendingDTO();
        }

        [Fact]
        public void CanSetAndGetid()
        {
            // Arrange
            var testValue = 1080130809;

            // Act
            _testClass.id = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.id);
        }

        [Fact]
        public void CanSetAndGetemployeecredentialId()
        {
            // Arrange
            var testValue = 1080030310;

            // Act
            _testClass.employeecredentialId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.employeecredentialId);
        }

        [Fact]
        public void CanSetAndGetName()
        {
            // Arrange
            var testValue = "TestValue814722933";

            // Act
            _testClass.Name = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Name);
        }

        [Fact]
        public void CanSetAndGetLeaveType()
        {
            // Arrange
            var testValue = "TestValue1027729903";

            // Act
            _testClass.LeaveType = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.LeaveType);
        }

        [Fact]
        public void CanSetAndGetmanagername()
        {
            // Arrange
            var testValue = "TestValue762703739";

            // Act
            _testClass.managername = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.managername);
        }

        [Fact]
        public void CanSetAndGetReason()
        {
            // Arrange
            var testValue = "TestValue1773621147";

            // Act
            _testClass.Reason = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Reason);
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
        public void CanSetAndGetApplieddate()
        {
            // Arrange
            var testValue = DateTime.UtcNow;

            // Act
            _testClass.Applieddate = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Applieddate);
        }

        [Fact]
        public void CanSetAndGetNoofDays()
        {
            // Arrange
            var testValue = 1475000459;

            // Act
            _testClass.NoofDays = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.NoofDays);
        }

        [Fact]
        public void CanSetAndGetstatus()
        {
            // Arrange
            var testValue = "TestValue1099237470";

            // Act
            _testClass.status = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.status);
        }
    }
}