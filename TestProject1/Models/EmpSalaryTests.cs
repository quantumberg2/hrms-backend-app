namespace TestProject1.Models
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
            var testValue = 1415343260;

            // Act
            _testClass.Id = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Id);
        }

        [Fact]
        public void CanSetAndGetEmployeeCredentialId()
        {
            // Arrange
            var testValue = 1925988974;

            // Act
            _testClass.EmployeeCredentialId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.EmployeeCredentialId);
        }

        [Fact]
        public void CanSetAndGetSalaryRange()
        {
            // Arrange
            var testValue = "TestValue1000776572";

            // Act
            _testClass.SalaryRange = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.SalaryRange);
        }

        [Fact]
        public void CanSetAndGetAnnualIncome()
        {
            // Arrange
            var testValue = 2121608972.34M;

            // Act
            _testClass.AnnualIncome = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.AnnualIncome);
        }

        [Fact]
        public void CanSetAndGetLoan()
        {
            // Arrange
            var testValue = 586608709.5M;

            // Act
            _testClass.Loan = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Loan);
        }

        [Fact]
        public void CanSetAndGetInsurance()
        {
            // Arrange
            var testValue = 634736376.45M;

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
                Id = 255425474,
                UserName = "TestValue2077042699",
                Password = "TestValue1751417289",
                Status = (short)3883,
                RequestedCompanyId = 398735082,
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 1225005689,
                    Name = "TestValue1937856306",
                    PhoneNumber = "TestValue1349812829",
                    DomainName = "TestValue16587876",
                    Status = "TestValue2031710763",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Department = new Department
                    {
                        Id = 417931776,
                        Name = "TestValue1734888286",
                        RequestedCompanyId = 910132262,
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
                UserRolesJs = new Mock<ICollection<UserRolesJ>>().Object
            };

            // Act
            _testClass.EmployeeCredential = testValue;

            // Assert
            Assert.Same(testValue, _testClass.EmployeeCredential);
        }
    }
}