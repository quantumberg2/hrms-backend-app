namespace TestProject1.Models
{
    using System;
    using System.Collections.Generic;
    using HRMS_Application.Models;
    using Moq;
    using Xunit;

    public partial class AccountDetailTests
    {
        private AccountDetail _testClass;

        public AccountDetailTests()
        {
            _testClass = new AccountDetail();
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new AccountDetail();

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanSetAndGetId()
        {
            // Arrange
            var testValue = 1076154366;

            // Act
            _testClass.Id = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Id);
        }

        [Fact]
        public void CanSetAndGetEmployeeCredentialId()
        {
            // Arrange
            var testValue = 1630349912;

            // Act
            _testClass.EmployeeCredentialId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.EmployeeCredentialId);
        }

        [Fact]
        public void CanSetAndGetAccountNumber()
        {
            // Arrange
            var testValue = "TestValue827363866";

            // Act
            _testClass.AccountNumber = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.AccountNumber);
        }

        [Fact]
        public void CanSetAndGetConfirmAcNo()
        {
            // Arrange
            var testValue = "TestValue1175865946";

            // Act
            _testClass.ConfirmAcNo = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.ConfirmAcNo);
        }

        [Fact]
        public void CanSetAndGetIfscCode()
        {
            // Arrange
            var testValue = "TestValue2011531430";

            // Act
            _testClass.IfscCode = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.IfscCode);
        }

        [Fact]
        public void CanSetAndGetConfirmIfsc()
        {
            // Arrange
            var testValue = "TestValue1465846565";

            // Act
            _testClass.ConfirmIfsc = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.ConfirmIfsc);
        }

        [Fact]
        public void CanSetAndGetAccountType()
        {
            // Arrange
            var testValue = "TestValue94108943";

            // Act
            _testClass.AccountType = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.AccountType);
        }

        [Fact]
        public void CanSetAndGetBankName()
        {
            // Arrange
            var testValue = "TestValue1523337185";

            // Act
            _testClass.BankName = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.BankName);
        }

        [Fact]
        public void CanSetAndGetBranchName()
        {
            // Arrange
            var testValue = "TestValue1423027174";

            // Act
            _testClass.BranchName = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.BranchName);
        }

        [Fact]
        public void CanSetAndGetAadharNumber()
        {
            // Arrange
            var testValue = "TestValue1860372556";

            // Act
            _testClass.AadharNumber = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.AadharNumber);
        }

        [Fact]
        public void CanSetAndGetPfNumber()
        {
            // Arrange
            var testValue = "TestValue1219422471";

            // Act
            _testClass.PfNumber = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.PfNumber);
        }

        [Fact]
        public void CanSetAndGetUanNumber()
        {
            // Arrange
            var testValue = "TestValue2021140898";

            // Act
            _testClass.UanNumber = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.UanNumber);
        }

        [Fact]
        public void CanSetAndGetPfSchema()
        {
            // Arrange
            var testValue = "TestValue722660956";

            // Act
            _testClass.PfSchema = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.PfSchema);
        }

        [Fact]
        public void CanSetAndGetPfJoiningDate()
        {
            // Arrange
            var testValue = DateTime.UtcNow;

            // Act
            _testClass.PfJoiningDate = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.PfJoiningDate);
        }

        [Fact]
        public void CanSetAndGetEligibleForPf()
        {
            // Arrange
            var testValue = true;

            // Act
            _testClass.EligibleForPf = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.EligibleForPf);
        }

        [Fact]
        public void CanSetAndGetEmployeeCredential()
        {
            // Arrange
            var testValue = new EmployeeCredential
            {
                Id = 1919633115,
                UserName = "TestValue823994089",
                Password = "TestValue2016568621",
                Status = (short)17530,
                RequestedCompanyId = 921833002,
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 158230804,
                    Name = "TestValue602538249",
                    PhoneNumber = "TestValue2109763469",
                    DomainName = "TestValue1467049251",
                    Status = "TestValue1685430478",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Department = new Department
                    {
                        Id = 1263496007,
                        Name = "TestValue550597089",
                        RequestedCompanyId = 1699849112,
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
    }
}