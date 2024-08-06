namespace HRMSunitTestCase.Models
{
    using System;
    using System.Collections.Generic;
    using HRMS_Application.Models;
    using Moq;
    using Xunit;

    public partial class EmployeeCredentialTests
    {
        private EmployeeCredential _testClass;

        public EmployeeCredentialTests()
        {
            _testClass = new EmployeeCredential();
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new EmployeeCredential();

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanSetAndGetId()
        {
            // Arrange
            var testValue = 578098301;

            // Act
            _testClass.Id = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Id);
        }

        [Fact]
        public void CanSetAndGetUserName()
        {
            // Arrange
            var testValue = "TestValue1359773677";

            // Act
            _testClass.UserName = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.UserName);
        }

        [Fact]
        public void CanSetAndGetPassword()
        {
            // Arrange
            var testValue = "TestValue1247482032";

            // Act
            _testClass.Password = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Password);
        }

        [Fact]
        public void CanSetAndGetStatus()
        {
            // Arrange
            var testValue = (short)26739;

            // Act
            _testClass.Status = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Status);
        }

        [Fact]
        public void CanSetAndGetRequestedCompanyId()
        {
            // Arrange
            var testValue = 1979076557;

            // Act
            _testClass.RequestedCompanyId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.RequestedCompanyId);
        }

        [Fact]
        public void CanSetAndGetEmail()
        {
            // Arrange
            var testValue = "TestValue1099847231";

            // Act
            _testClass.Email = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Email);
        }

        [Fact]
        public void CanSetAndGetDefaultPassword()
        {
            // Arrange
            var testValue = false;

            // Act
            _testClass.DefaultPassword = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.DefaultPassword);
        }

        [Fact]
        public void CanSetAndGetRequestedCompany()
        {
            // Arrange
            var testValue = new RequestedCompanyForm
            {
                Id = 1158464997,
                Name = "TestValue1118798885",
                PhoneNumber = "TestValue1075987403",
                DomainName = "TestValue86231463",
                Status = "TestValue443332486",
                InsertedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                Email = "TestValue1653747868",
                Department = new Department
                {
                    Id = 1713786436,
                    Name = "TestValue914679924",
                    RequestedCompanyId = 1534915646,
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
        public void CanSetAndGetAccountDetails()
        {
            // Arrange
            var testValue = new Mock<ICollection<AccountDetail>>().Object;

            // Act
            _testClass.AccountDetails = testValue;

            // Assert
            Assert.Same(testValue, _testClass.AccountDetails);
        }

        [Fact]
        public void CanSetAndGetAddressInfos()
        {
            // Arrange
            var testValue = new Mock<ICollection<AddressInfo>>().Object;

            // Act
            _testClass.AddressInfos = testValue;

            // Assert
            Assert.Same(testValue, _testClass.AddressInfos);
        }

        [Fact]
        public void CanSetAndGetEmpPersonalInfos()
        {
            // Arrange
            var testValue = new Mock<ICollection<EmpPersonalInfo>>().Object;

            // Act
            _testClass.EmpPersonalInfos = testValue;

            // Assert
            Assert.Same(testValue, _testClass.EmpPersonalInfos);
        }

        [Fact]
        public void CanSetAndGetEmpSalaries()
        {
            // Arrange
            var testValue = new Mock<ICollection<EmpSalary>>().Object;

            // Act
            _testClass.EmpSalaries = testValue;

            // Assert
            Assert.Same(testValue, _testClass.EmpSalaries);
        }

        [Fact]
        public void CanSetAndGetEmployeeAttendances()
        {
            // Arrange
            var testValue = new Mock<ICollection<EmployeeAttendance>>().Object;

            // Act
            _testClass.EmployeeAttendances = testValue;

            // Assert
            Assert.Same(testValue, _testClass.EmployeeAttendances);
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

        [Fact]
        public void CanSetAndGetEmployeeLeaves()
        {
            // Arrange
            var testValue = new Mock<ICollection<EmployeeLeave>>().Object;

            // Act
            _testClass.EmployeeLeaves = testValue;

            // Assert
            Assert.Same(testValue, _testClass.EmployeeLeaves);
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
        public void CanSetAndGetUserRolesJs()
        {
            // Arrange
            var testValue = new Mock<ICollection<UserRolesJ>>().Object;

            // Act
            _testClass.UserRolesJs = testValue;

            // Assert
            Assert.Same(testValue, _testClass.UserRolesJs);
        }
    }
}