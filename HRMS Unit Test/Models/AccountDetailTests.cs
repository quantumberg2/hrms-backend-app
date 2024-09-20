namespace HRMS_Unit_Test.Models
{
    using System;
    using System.Collections.Generic;
    using HRMS_Application.Models;
    using Moq;
    using Xunit;

    public partial class AccountDetailTests
    {
        private readonly AccountDetail _testClass;

        public AccountDetailTests()
        {
            _testClass = new AccountDetail();
        }

        [Fact]
        public void CanSetAndGetId()
        {
            // Arrange
            var testValue = 692228272;

            // Act
            _testClass.Id = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Id);
        }

        [Fact]
        public void CanSetAndGetEmployeeCredentialId()
        {
            // Arrange
            var testValue = 1294846348;

            // Act
            _testClass.EmployeeCredentialId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.EmployeeCredentialId);
        }

        [Fact]
        public void CanSetAndGetAccountNumber()
        {
            // Arrange
            var testValue = "TestValue462342530";

            // Act
            _testClass.AccountNumber = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.AccountNumber);
        }

        [Fact]
        public void CanSetAndGetIfscCode()
        {
            // Arrange
            var testValue = "TestValue1414874748";

            // Act
            _testClass.IfscCode = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.IfscCode);
        }

        [Fact]
        public void CanSetAndGetAccountType()
        {
            // Arrange
            var testValue = "TestValue1316116690";

            // Act
            _testClass.AccountType = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.AccountType);
        }

        [Fact]
        public void CanSetAndGetBankName()
        {
            // Arrange
            var testValue = "TestValue888893409";

            // Act
            _testClass.BankName = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.BankName);
        }

        [Fact]
        public void CanSetAndGetBranchName()
        {
            // Arrange
            var testValue = "TestValue166959242";

            // Act
            _testClass.BranchName = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.BranchName);
        }

        [Fact]
        public void CanSetAndGetAadharNumber()
        {
            // Arrange
            var testValue = "TestValue177196952";

            // Act
            _testClass.AadharNumber = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.AadharNumber);
        }

        [Fact]
        public void CanSetAndGetPfNumber()
        {
            // Arrange
            var testValue = "TestValue1240470994";

            // Act
            _testClass.PfNumber = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.PfNumber);
        }

        [Fact]
        public void CanSetAndGetUanNumber()
        {
            // Arrange
            var testValue = "TestValue536490071";

            // Act
            _testClass.UanNumber = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.UanNumber);
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
        public void CanSetAndGetIsActive()
        {
            // Arrange
            var testValue = (short)14699;

            // Act
            _testClass.IsActive = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.IsActive);
        }

        [Fact]
        public void CanSetAndGetCountry()
        {
            // Arrange
            var testValue = "TestValue1355064189";

            // Act
            _testClass.Country = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Country);
        }

        [Fact]
        public void CanSetAndGetState()
        {
            // Arrange
            var testValue = "TestValue1424759555";

            // Act
            _testClass.State = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.State);
        }

        [Fact]
        public void CanSetAndGetCity()
        {
            // Arrange
            var testValue = "TestValue1863505334";

            // Act
            _testClass.City = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.City);
        }

        [Fact]
        public void CanSetAndGetPin()
        {
            // Arrange
            var testValue = 1423630405;

            // Act
            _testClass.Pin = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Pin);
        }

        [Fact]
        public void CanSetAndGetEmployeeCredential()
        {
            // Arrange
            var testValue = new EmployeeCredential
            {
                Id = 1346219472,
                UserName = "TestValue1757808220",
                Password = "TestValue1368949412",
                Status = (short)26450,
                RequestedCompanyId = 2139036737,
                Email = "TestValue788986951",
                DefaultPassword = false,
                GenerateOtp = "TestValue308066264",
                OtpExpiration = DateTime.UtcNow,
                IsActive = (short)5718,
                EmployeeLoginName = "TestValue1925563927",
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 1478021039,
                    Name = "TestValue1008021379",
                    PhoneNumber = "TestValue754202446",
                    DomainName = "TestValue1495671738",
                    Status = "TestValue1140586954",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Email = "TestValue1161168990",
                    IsActive = (short)649,
                    CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                    Departments = new Mock<ICollection<Department>>().Object,
                    EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                    Holidays = new Mock<ICollection<Holiday>>().Object,
                    LeaveTypes = new Mock<ICollection<LeaveType>>().Object,
                    Positions = new Mock<ICollection<Position>>().Object
                },
                AccountDetails = new Mock<ICollection<AccountDetail>>().Object,
                AddressInfos = new Mock<ICollection<AddressInfo>>().Object,
                Attendances = new Mock<ICollection<Attendance>>().Object,
                DeviceTables = new Mock<ICollection<DeviceTable>>().Object,
                EmpPersonalInfos = new Mock<ICollection<EmpPersonalInfo>>().Object,
                EmpSalaries = new Mock<ICollection<EmpSalary>>().Object,
                EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object,
                EmployeeLeaveAllocations = new Mock<ICollection<EmployeeLeaveAllocation>>().Object,
                LeaveTrackings = new Mock<ICollection<LeaveTracking>>().Object,
                UserRolesJs = new Mock<ICollection<UserRolesJ>>().Object
            };

            // Act
            _testClass.EmployeeCredential = testValue;

            // Assert
            Assert.Same(testValue, _testClass.EmployeeCredential);
        }
    }
}