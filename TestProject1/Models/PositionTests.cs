namespace TestProject1.Models
{
    using System;
    using System.Collections.Generic;
    using HRMS_Application.Models;
    using Moq;
    using Xunit;

    public partial class PositionTests
    {
        private Position _testClass;

        public PositionTests()
        {
            _testClass = new Position();
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new Position();

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanSetAndGetId()
        {
            // Arrange
            var testValue = 1020972510;

            // Act
            _testClass.Id = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Id);
        }

        [Fact]
        public void CanSetAndGetName()
        {
            // Arrange
            var testValue = "TestValue1166862091";

            // Act
            _testClass.Name = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Name);
        }

        [Fact]
        public void CanSetAndGetRequestedCompanyId()
        {
            // Arrange
            var testValue = 1464207327;

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
                Id = 391888024,
                Name = "TestValue902577119",
                PhoneNumber = "TestValue661758673",
                DomainName = "TestValue1788498409",
                Status = "TestValue2090733554",
                InsertedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                Department = new Department
                {
                    Id = 2146813076,
                    Name = "TestValue36416338",
                    RequestedCompanyId = 1872129978,
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