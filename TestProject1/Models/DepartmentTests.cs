namespace TestProject1.Models
{
    using System;
    using System.Collections.Generic;
    using HRMS_Application.Models;
    using Moq;
    using Xunit;

    public partial class DepartmentTests
    {
        private Department _testClass;

        public DepartmentTests()
        {
            _testClass = new Department();
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new Department();

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanSetAndGetId()
        {
            // Arrange
            var testValue = 313345285;

            // Act
            _testClass.Id = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Id);
        }

        [Fact]
        public void CanSetAndGetName()
        {
            // Arrange
            var testValue = "TestValue89769448";

            // Act
            _testClass.Name = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Name);
        }

        [Fact]
        public void CanSetAndGetRequestedCompanyId()
        {
            // Arrange
            var testValue = 518262366;

            // Act
            _testClass.RequestedCompanyId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.RequestedCompanyId);
        }

        [Fact]
        public void CanSetAndGetRequestedCompany()
        {
            // Arrange
            var testValue = new RequestedCompanyForm
            {
                Id = 2065397000,
                Name = "TestValue1883315152",
                PhoneNumber = "TestValue917299828",
                DomainName = "TestValue275559857",
                Status = "TestValue814056811",
                InsertedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                Department = new Department
                {
                    Id = 1729592939,
                    Name = "TestValue1514577304",
                    RequestedCompanyId = 1968671440,
                    RequestedCompany = default(RequestedCompanyForm),
                    EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object
                },
                CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                Positions = new Mock<ICollection<Position>>().Object
            };

            // Act
            _testClass.RequestedCompany = testValue;

            // Assert
            Assert.Same(testValue, _testClass.RequestedCompany);
        }

        [Fact]
        public void CanSetAndGetEmployeeDetails()
        {
            // Arrange
            var testValue = new Mock<ICollection<EmployeeDetail>>().Object;

            // Act
            _testClass.EmployeeDetails = testValue;

            // Assert
            Assert.Same(testValue, _testClass.EmployeeDetails);
        }
    }
}