namespace HRMSunitTestCase.Models
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
            var testValue = 1632440900;

            // Act
            _testClass.Id = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Id);
        }

        [Fact]
        public void CanSetAndGetEmployeeCredentialId()
        {
            // Arrange
            var testValue = 1496596136;

            // Act
            _testClass.EmployeeCredentialId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.EmployeeCredentialId);
        }

        [Fact]
        public void CanSetAndGetAccountNumber()
        {
            // Arrange
            var testValue = "TestValue322899286";

            // Act
            _testClass.AccountNumber = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.AccountNumber);
        }

        [Fact]
        public void CanSetAndGetConfirmAcNo()
        {
            // Arrange
            var testValue = "TestValue572561947";

            // Act
            _testClass.ConfirmAcNo = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.ConfirmAcNo);
        }

        [Fact]
        public void CanSetAndGetIfscCode()
        {
            // Arrange
            var testValue = "TestValue1243896950";

            // Act
            _testClass.IfscCode = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.IfscCode);
        }

        [Fact]
        public void CanSetAndGetConfirmIfsc()
        {
            // Arrange
            var testValue = "TestValue1137287832";

            // Act
            _testClass.ConfirmIfsc = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.ConfirmIfsc);
        }

        [Fact]
        public void CanSetAndGetAccountType()
        {
            // Arrange
            var testValue = "TestValue219809749";

            // Act
            _testClass.AccountType = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.AccountType);
        }

        [Fact]
        public void CanSetAndGetBankName()
        {
            // Arrange
            var testValue = "TestValue124349227";

            // Act
            _testClass.BankName = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.BankName);
        }

        [Fact]
        public void CanSetAndGetBranchName()
        {
            // Arrange
            var testValue = "TestValue503085575";

            // Act
            _testClass.BranchName = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.BranchName);
        }

        [Fact]
        public void CanSetAndGetAadharNumber()
        {
            // Arrange
            var testValue = "TestValue779379739";

            // Act
            _testClass.AadharNumber = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.AadharNumber);
        }

        [Fact]
        public void CanSetAndGetPfNumber()
        {
            // Arrange
            var testValue = "TestValue44158411";

            // Act
            _testClass.PfNumber = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.PfNumber);
        }

        [Fact]
        public void CanSetAndGetUanNumber()
        {
            // Arrange
            var testValue = "TestValue1799727171";

            // Act
            _testClass.UanNumber = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.UanNumber);
        }

        [Fact]
        public void CanSetAndGetPfSchema()
        {
            // Arrange
            var testValue = "TestValue270732553";

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
                Id = 1663279774,
                UserName = "TestValue1224258012",
                Password = "TestValue1734453592",
                Status = (short)25682,
                RequestedCompanyId = 2060074858,
                Email = "TestValue2074978308",
                DefaultPassword = false,
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 1949432640,
                    Name = "TestValue1017401251",
                    PhoneNumber = "TestValue1755569771",
                    DomainName = "TestValue857716602",
                    Status = "TestValue2117661439",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Email = "TestValue1795261372",
                    Department = new Department
                    {
                        Id = 715872336,
                        Name = "TestValue19648746",
                        RequestedCompanyId = 910269774,
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