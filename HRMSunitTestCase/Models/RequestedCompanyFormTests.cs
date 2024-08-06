namespace HRMSunitTestCase.Models
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
            var testValue = 1311758121;

            // Act
            _testClass.Id = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Id);
        }

        [Fact]
        public void CanSetAndGetName()
        {
            // Arrange
            var testValue = "TestValue2067254357";

            // Act
            _testClass.Name = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Name);
        }

        [Fact]
        public void CanSetAndGetPhoneNumber()
        {
            // Arrange
            var testValue = "TestValue1602092936";

            // Act
            _testClass.PhoneNumber = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.PhoneNumber);
        }

        [Fact]
        public void CanSetAndGetDomainName()
        {
            // Arrange
            var testValue = "TestValue897377866";

            // Act
            _testClass.DomainName = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.DomainName);
        }

        [Fact]
        public void CanSetAndGetStatus()
        {
            // Arrange
            var testValue = "TestValue2080632219";

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
            var testValue = "TestValue666437823";

            // Act
            _testClass.Email = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Email);
        }

        [Fact]
        public void CanSetAndGetDepartment()
        {
            // Arrange
            var testValue = new Department
            {
                Id = 1789031453,
                Name = "TestValue1940716279",
                RequestedCompanyId = 941956460,
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 1890549869,
                    Name = "TestValue1629733554",
                    PhoneNumber = "TestValue1498399018",
                    DomainName = "TestValue1536964992",
                    Status = "TestValue67113844",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Email = "TestValue1364699351",
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