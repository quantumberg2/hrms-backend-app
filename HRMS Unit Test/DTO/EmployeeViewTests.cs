namespace HRMS_Unit_Test.DTO
{
    using System;
    using HRMS_Application.DTO;
    using Xunit;

    public class EmployeeViewTests
    {
        private readonly EmployeeView _testClass;

        public EmployeeViewTests()
        {
            _testClass = new EmployeeView();
        }

        [Fact]
        public void CanSetAndGetEmployeeId()
        {
            // Arrange
            var testValue = 18628338;

            // Act
            _testClass.EmployeeId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.EmployeeId);
        }

        [Fact]
        public void CanSetAndGetEmployeeName()
        {
            // Arrange
            var testValue = "TestValue1617778297";

            // Act
            _testClass.EmployeeName = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.EmployeeName);
        }

        [Fact]
        public void CanSetAndGetAddress()
        {
            // Arrange
            var testValue = "TestValue1445555755";

            // Act
            _testClass.Address = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Address);
        }

        [Fact]
        public void CanSetAndGetGender()
        {
            // Arrange
            var testValue = "TestValue1169984526";

            // Act
            _testClass.Gender = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Gender);
        }

        [Fact]
        public void CanSetAndGetDOB()
        {
            // Arrange
            var testValue = "TestValue2040165132";

            // Act
            _testClass.DOB = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.DOB);
        }

        [Fact]
        public void CanSetAndGetDesignation()
        {
            // Arrange
            var testValue = "TestValue108275387";

            // Act
            _testClass.Designation = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Designation);
        }

        [Fact]
        public void CanSetAndGetManager()
        {
            // Arrange
            var testValue = "TestValue1109642688";

            // Act
            _testClass.Manager = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Manager);
        }
    }
}