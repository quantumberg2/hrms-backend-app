namespace HRMS_Unit_Test.DTO
{
    using System;
    using HRMS_Application.DTO;
    using Xunit;

    public class EmployeeDtoTests
    {
        private readonly EmployeeDto _testClass;

        public EmployeeDtoTests()
        {
            _testClass = new EmployeeDto();
        }

        [Fact]
        public void CanSetAndGetEmployeeNumber()
        {
            // Arrange
            var testValue = "TestValue289568202";

            // Act
            _testClass.EmployeeNumber = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.EmployeeNumber);
        }

        [Fact]
        public void CanSetAndGetEmail()
        {
            // Arrange
            var testValue = "TestValue1108401882";

            // Act
            _testClass.Email = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Email);
        }

        [Fact]
        public void CanSetAndGetDesignation()
        {
            // Arrange
            var testValue = "TestValue754472780";

            // Act
            _testClass.Designation = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Designation);
        }

        [Fact]
        public void CanSetAndGetFirstName()
        {
            // Arrange
            var testValue = "TestValue1317128629";

            // Act
            _testClass.FirstName = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.FirstName);
        }

        [Fact]
        public void CanSetAndGetMiddleName()
        {
            // Arrange
            var testValue = "TestValue793404771";

            // Act
            _testClass.MiddleName = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.MiddleName);
        }

        [Fact]
        public void CanSetAndGetLastName()
        {
            // Arrange
            var testValue = "TestValue559900373";

            // Act
            _testClass.LastName = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.LastName);
        }

        [Fact]
        public void CanSetAndGetDeptId()
        {
            // Arrange
            var testValue = 1156515174;

            // Act
            _testClass.DeptId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.DeptId);
        }

        [Fact]
        public void CanSetAndGetPositionId()
        {
            // Arrange
            var testValue = 1745300382;

            // Act
            _testClass.PositionId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.PositionId);
        }
    }
}