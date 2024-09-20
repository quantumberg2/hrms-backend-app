namespace HRMS_Unit_Test.Models
{
    using System;
    using System.Collections.Generic;
    using HRMS_Application.Models;
    using Moq;
    using Xunit;

    public partial class RequestedCompanyFormTests
    {
        private readonly RequestedCompanyForm _testClass;

        public RequestedCompanyFormTests()
        {
            _testClass = new RequestedCompanyForm();
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new RequestedCompanyForm();

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanSetAndGetId()
        {
            // Arrange
            var testValue = 286586202;

            // Act
            _testClass.Id = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Id);
        }

        [Fact]
        public void CanSetAndGetName()
        {
            // Arrange
            var testValue = "TestValue120758869";

            // Act
            _testClass.Name = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Name);
        }

        [Fact]
        public void CanSetAndGetPhoneNumber()
        {
            // Arrange
            var testValue = "TestValue1938555348";

            // Act
            _testClass.PhoneNumber = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.PhoneNumber);
        }

        [Fact]
        public void CanSetAndGetDomainName()
        {
            // Arrange
            var testValue = "TestValue1643115842";

            // Act
            _testClass.DomainName = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.DomainName);
        }

        [Fact]
        public void CanSetAndGetStatus()
        {
            // Arrange
            var testValue = "TestValue1645410926";

            // Act
            _testClass.Status = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Status);
        }

        [Fact]
        public void CanSetAndGetInsertedDate()
        {
            // Arrange
            var testValue = DateTime.UtcNow;

            // Act
            _testClass.InsertedDate = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.InsertedDate);
        }

        [Fact]
        public void CanSetAndGetUpdatedDate()
        {
            // Arrange
            var testValue = DateTime.UtcNow;

            // Act
            _testClass.UpdatedDate = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.UpdatedDate);
        }

        [Fact]
        public void CanSetAndGetEmail()
        {
            // Arrange
            var testValue = "TestValue1869214364";

            // Act
            _testClass.Email = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Email);
        }

        [Fact]
        public void CanSetAndGetIsActive()
        {
            // Arrange
            var testValue = (short)16527;

            // Act
            _testClass.IsActive = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.IsActive);
        }

        [Fact]
        public void CanSetAndGetCompanyDetails()
        {
            // Arrange
            var testValue = new Mock<ICollection<CompanyDetail>>().Object;

            // Act
            _testClass.CompanyDetails = testValue;

            // Assert
            Assert.Same(testValue, _testClass.CompanyDetails);
        }

        [Fact]
        public void CanSetAndGetDepartments()
        {
            // Arrange
            var testValue = new Mock<ICollection<Department>>().Object;

            // Act
            _testClass.Departments = testValue;

            // Assert
            Assert.Same(testValue, _testClass.Departments);
        }

        [Fact]
        public void CanSetAndGetEmployeeCredentials()
        {
            // Arrange
            var testValue = new Mock<ICollection<EmployeeCredential>>().Object;

            // Act
            _testClass.EmployeeCredentials = testValue;

            // Assert
            Assert.Same(testValue, _testClass.EmployeeCredentials);
        }

        [Fact]
        public void CanSetAndGetHolidays()
        {
            // Arrange
            var testValue = new Mock<ICollection<Holiday>>().Object;

            // Act
            _testClass.Holidays = testValue;

            // Assert
            Assert.Same(testValue, _testClass.Holidays);
        }

        [Fact]
        public void CanSetAndGetLeaveTypes()
        {
            // Arrange
            var testValue = new Mock<ICollection<LeaveType>>().Object;

            // Act
            _testClass.LeaveTypes = testValue;

            // Assert
            Assert.Same(testValue, _testClass.LeaveTypes);
        }

        [Fact]
        public void CanSetAndGetPositions()
        {
            // Arrange
            var testValue = new Mock<ICollection<Position>>().Object;

            // Act
            _testClass.Positions = testValue;

            // Assert
            Assert.Same(testValue, _testClass.Positions);
        }
    }
}