namespace HRMS_Unit_Test.DTO
{
    using System;
    using HRMS_Application.DTO;
    using Xunit;

    public class EmployeeLeaveAllocationRequestTests
    {
        private readonly EmployeeLeaveAllocationRequest _testClass;

        public EmployeeLeaveAllocationRequestTests()
        {
            _testClass = new EmployeeLeaveAllocationRequest();
        }

        [Fact]
        public void CanSetAndGetYear()
        {
            // Arrange
            var testValue = 1578670111;

            // Act
            _testClass.Year = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Year);
        }

        [Fact]
        public void CanSetAndGetEmpCredentialId()
        {
            // Arrange
            var testValue = 1693482680;

            // Act
            _testClass.EmpCredentialId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.EmpCredentialId);
        }

        [Fact]
        public void CanSetAndGetNumberOfLeaves()
        {
            // Arrange
            var testValue = 1140625532;

            // Act
            _testClass.NumberOfLeaves = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.NumberOfLeaves);
        }

        [Fact]
        public void CanSetAndGetRemainingLeave()
        {
            // Arrange
            var testValue = 1801499393;

            // Act
            _testClass.RemainingLeave = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.RemainingLeave);
        }

        [Fact]
        public void CanSetAndGetLeaveType()
        {
            // Arrange
            var testValue = 1516237006;

            // Act
            _testClass.LeaveType = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.LeaveType);
        }
    }
}