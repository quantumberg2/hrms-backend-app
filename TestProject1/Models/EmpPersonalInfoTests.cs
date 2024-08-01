namespace TestProject1.Models
{
    using System;
    using System.Collections.Generic;
    using HRMS_Application.Models;
    using Moq;
    using Xunit;

    public partial class EmpPersonalInfoTests
    {
        private EmpPersonalInfo _testClass;

        public EmpPersonalInfoTests()
        {
            _testClass = new EmpPersonalInfo();
        }

        [Fact]
        public void CanSetAndGetId()
        {
            // Arrange
            var testValue = 437762500;

            // Act
            _testClass.Id = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Id);
        }

        [Fact]
        public void CanSetAndGetEmployeeCredentialId()
        {
            // Arrange
            var testValue = 1997905655;

            // Act
            _testClass.EmployeeCredentialId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.EmployeeCredentialId);
        }

        [Fact]
        public void CanSetAndGetDob()
        {
            // Arrange
            var testValue = DateTime.UtcNow;

            // Act
            _testClass.Dob = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Dob);
        }

        [Fact]
        public void CanSetAndGetDateOfJoining()
        {
            // Arrange
            var testValue = DateTime.UtcNow;

            // Act
            _testClass.DateOfJoining = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.DateOfJoining);
        }

        [Fact]
        public void CanSetAndGetConfirmDate()
        {
            // Arrange
            var testValue = DateTime.UtcNow;

            // Act
            _testClass.ConfirmDate = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.ConfirmDate);
        }

        [Fact]
        public void CanSetAndGetEmpStatus()
        {
            // Arrange
            var testValue = "TestValue1010450353";

            // Act
            _testClass.EmpStatus = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.EmpStatus);
        }

        [Fact]
        public void CanSetAndGetEmailId()
        {
            // Arrange
            var testValue = "TestValue1294658297";

            // Act
            _testClass.EmailId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.EmailId);
        }

        [Fact]
        public void CanSetAndGetPersonalEmail()
        {
            // Arrange
            var testValue = "TestValue944814049";

            // Act
            _testClass.PersonalEmail = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.PersonalEmail);
        }

        [Fact]
        public void CanSetAndGetMaritalStatus()
        {
            // Arrange
            var testValue = "TestValue1921213191";

            // Act
            _testClass.MaritalStatus = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.MaritalStatus);
        }

        [Fact]
        public void CanSetAndGetBloodGroup()
        {
            // Arrange
            var testValue = "TestValue1297917741";

            // Act
            _testClass.BloodGroup = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.BloodGroup);
        }

        [Fact]
        public void CanSetAndGetSpouseName()
        {
            // Arrange
            var testValue = "TestValue1541312799";

            // Act
            _testClass.SpouseName = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.SpouseName);
        }

        [Fact]
        public void CanSetAndGetPhysicallyChallenged()
        {
            // Arrange
            var testValue = false;

            // Act
            _testClass.PhysicallyChallenged = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.PhysicallyChallenged);
        }

        [Fact]
        public void CanSetAndGetEmergencyContact()
        {
            // Arrange
            var testValue = "TestValue709792615";

            // Act
            _testClass.EmergencyContact = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.EmergencyContact);
        }

        [Fact]
        public void CanSetAndGetAccountId()
        {
            // Arrange
            var testValue = 2094651351;

            // Act
            _testClass.AccountId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.AccountId);
        }

        [Fact]
        public void CanSetAndGetAccount()
        {
            // Arrange
            var testValue = new AccountDetail
            {
                Id = 168609473,
                EmployeeCredentialId = 602392236,
                AccountNumber = "TestValue2014298746",
                ConfirmAcNo = "TestValue1435617220",
                IfscCode = "TestValue1522918671",
                ConfirmIfsc = "TestValue1875843900",
                AccountType = "TestValue48408353",
                BankName = "TestValue1184117235",
                BranchName = "TestValue1261315869",
                AadharNumber = "TestValue53953255",
                PfNumber = "TestValue1579306926",
                UanNumber = "TestValue476874209",
                PfSchema = "TestValue15911281",
                PfJoiningDate = DateTime.UtcNow,
                EligibleForPf = false,
                EmployeeCredential = new EmployeeCredential
                {
                    Id = 781008795,
                    UserName = "TestValue799574102",
                    Password = "TestValue211671560",
                    Status = (short)4087,
                    RequestedCompanyId = 668454681,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 909458887,
                        Name = "TestValue2020379438",
                        PhoneNumber = "TestValue847602900",
                        DomainName = "TestValue1931072065",
                        Status = "TestValue1673578499",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Department = new Department
                        {
                            Id = 1457844124,
                            Name = "TestValue107575411",
                            RequestedCompanyId = 2097338573,
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
                },
                EmpPersonalInfos = new Mock<ICollection<EmpPersonalInfo>>().Object
            };

            // Act
            _testClass.Account = testValue;

            // Assert
            Assert.Same(testValue, _testClass.Account);
        }

        [Fact]
        public void CanSetAndGetEmployeeCredential()
        {
            // Arrange
            var testValue = new EmployeeCredential
            {
                Id = 1195115428,
                UserName = "TestValue1188561516",
                Password = "TestValue668781819",
                Status = (short)23807,
                RequestedCompanyId = 1323881452,
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 547315157,
                    Name = "TestValue411977640",
                    PhoneNumber = "TestValue126584211",
                    DomainName = "TestValue382273713",
                    Status = "TestValue1722052060",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Department = new Department
                    {
                        Id = 421298901,
                        Name = "TestValue1065548411",
                        RequestedCompanyId = 651866805,
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