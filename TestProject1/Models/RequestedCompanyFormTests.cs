namespace TestProject1.Models
{
    using System;
    using System.Collections.Generic;
    using HRMS_Application.Models;
    using Moq;
    using Xunit;

    public partial class RequestedCompanyFormTests
    {
        private RequestedCompanyForm _testClass;

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
            var testValue = 648472796;

            // Act
            _testClass.Id = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Id);
        }

        [Fact]
        public void CanSetAndGetName()
        {
            // Arrange
            var testValue = "TestValue776719195";

            // Act
            _testClass.Name = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Name);
        }

        [Fact]
        public void CanSetAndGetPhoneNumber()
        {
            // Arrange
            var testValue = "TestValue292129586";

            // Act
            _testClass.PhoneNumber = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.PhoneNumber);
        }

        [Fact]
        public void CanSetAndGetDomainName()
        {
            // Arrange
            var testValue = "TestValue347276658";

            // Act
            _testClass.DomainName = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.DomainName);
        }

        [Fact]
        public void CanSetAndGetStatus()
        {
            // Arrange
            var testValue = "TestValue1922824835";

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
        public void CanSetAndGetDepartment()
        {
            // Arrange
            var testValue = new Department
            {
                Id = 1824460573,
                Name = "TestValue1003362584",
                RequestedCompanyId = 522988543,
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 418513458,
                    Name = "TestValue853810968",
                    PhoneNumber = "TestValue1402978234",
                    DomainName = "TestValue785433315",
                    Status = "TestValue1537705220",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Department = default(Department),
                    CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                    EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                    Positions = new Mock<ICollection<Position>>().Object
                },
                EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object
            };

            // Act
            _testClass.Department = testValue;

            // Assert
            Assert.Same(testValue, _testClass.Department);
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