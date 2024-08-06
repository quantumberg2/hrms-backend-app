namespace HRMSunitTestCase.Models
{
    using System;
    using System.Collections.Generic;
    using HRMS_Application.Models;
    using Moq;
    using Xunit;

    public partial class EmpSalaryTests
    {
        private EmpSalary _testClass;

        public EmpSalaryTests()
        {
            _testClass = new EmpSalary();
        }

        [Fact]
        public void CanSetAndGetId()
        {
            // Arrange
            var testValue = 1307717805;

            // Act
            _testClass.Id = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Id);
        }

        [Fact]
        public void CanSetAndGetEmployeeCredentialId()
        {
            // Arrange
            var testValue = 1489831107;

            // Act
            _testClass.EmployeeCredentialId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.EmployeeCredentialId);
        }

        [Fact]
        public void CanSetAndGetSalaryRange()
        {
            // Arrange
            var testValue = "TestValue1753215065";

            // Act
            _testClass.SalaryRange = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.SalaryRange);
        }

        [Fact]
        public void CanSetAndGetAnnualIncome()
        {
            // Arrange
            var testValue = 1904380317.18M;

            // Act
            _testClass.AnnualIncome = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.AnnualIncome);
        }

        [Fact]
        public void CanSetAndGetLoan()
        {
            // Arrange
            var testValue = 822814893.45M;

            // Act
            _testClass.Loan = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Loan);
        }

        [Fact]
        public void CanSetAndGetInsurance()
        {
            // Arrange
            var testValue = 1429877637.54M;

            // Act
            _testClass.Insurance = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Insurance);
        }

        [Fact]
        public void CanSetAndGetEmployeeCredential()
        {
            // Arrange
            var testValue = new EmployeeCredential
            {
                Id = 1457115842,
                UserName = "TestValue505123974",
                Password = "TestValue727941480",
                Status = (short)6530,
                RequestedCompanyId = 1022423201,
                Email = "TestValue1372679554",
                DefaultPassword = false,
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 56003971,
                    Name = "TestValue1668013484",
                    PhoneNumber = "TestValue223405345",
                    DomainName = "TestValue735275785",
                    Status = "TestValue1551415954",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Email = "TestValue1385468099",
                    Department = new Department
                    {
                        Id = 437133761,
                        Name = "TestValue1173353036",
                        RequestedCompanyId = 1924181855,
                        RequestedCompany = default(RequestedCompanyForm),
                        EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object
                    },
                    CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                    EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                    Positions = new Mock<ICollection<Position>>().Object
                },
                AccountDetails = new Mock<ICollection<AccountDetail>>().Object,
                AddressInfos = new Mock<ICollection<AddressInfo>>().Object,
                EmpPersonalInfos = new Mock<ICollection<EmpPersonalInfo>>().Object,
                EmpSalaries = new Mock<ICollection<EmpSalary>>().Object,
                EmployeeAttendances = new Mock<ICollection<EmployeeAttendance>>().Object,
                EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object,
                EmployeeLeaves = new Mock<ICollection<EmployeeLeave>>().Object,
                Holidays = new Mock<ICollection<Holiday>>().Object,
                LeaveTypes = new Mock<ICollection<LeaveType>>().Object,
                UserRolesJs = new Mock<ICollection<UserRolesJ>>().Object
            };

            // Act
            _testClass.EmployeeCredential = testValue;

            // Assert
            Assert.Same(testValue, _testClass.EmployeeCredential);
        }
    }
}