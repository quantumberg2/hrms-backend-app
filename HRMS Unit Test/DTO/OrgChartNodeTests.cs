namespace HRMS_Unit_Test.DTO
{
    using System;
    using System.Collections.Generic;
    using HRMS_Application.DTO;
    using Xunit;

    public class OrgChartNodeTests
    {
        private readonly OrgChartNode _testClass;

        public OrgChartNodeTests()
        {
            _testClass = new OrgChartNode();
        }

        [Fact]
        public void CanSetAndGetManagerId()
        {
            // Arrange
            var testValue = 404041417;

            // Act
            _testClass.ManagerId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.ManagerId);
        }

        [Fact]
        public void CanSetAndGetManagerName()
        {
            // Arrange
            var testValue = "TestValue973018496";

            // Act
            _testClass.ManagerName = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.ManagerName);
        }

        [Fact]
        public void CanSetAndGetDesignation()
        {
            // Arrange
            var testValue = "TestValue1380783977";

            // Act
            _testClass.Designation = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Designation);
        }

        [Fact]
        public void CanSetAndGetEmployees()
        {
            // Arrange
            var testValue = new List<EmployeeDetailDto>();

            // Act
            _testClass.Employees = testValue;

            // Assert
            Assert.Same(testValue, _testClass.Employees);
        }
    }

    public class EmployeeDetailDtoTests
    {
        private readonly EmployeeDetailDto _testClass;

        public EmployeeDetailDtoTests()
        {
            _testClass = new EmployeeDetailDto();
        }

        [Fact]
        public void CanSetAndGetEmployeeId()
        {
            // Arrange
            var testValue = 1223071789;

            // Act
            _testClass.EmployeeId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.EmployeeId);
        }

        [Fact]
        public void CanSetAndGetEmployeeName()
        {
            // Arrange
            var testValue = "TestValue1443364871";

            // Act
            _testClass.EmployeeName = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.EmployeeName);
        }

        [Fact]
        public void CanSetAndGetEmail()
        {
            // Arrange
            var testValue = "TestValue2035902399";

            // Act
            _testClass.Email = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Email);
        }

        [Fact]
        public void CanSetAndGetDesignation()
        {
            // Arrange
            var testValue = "TestValue551987972";

            // Act
            _testClass.Designation = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Designation);
        }
    }
}