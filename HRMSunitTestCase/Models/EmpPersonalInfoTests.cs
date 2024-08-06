namespace HRMSunitTestCase.Models
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
            var testValue = 1620910274;

            // Act
            _testClass.Id = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Id);
        }

        [Fact]
        public void CanSetAndGetEmployeeCredentialId()
        {
            // Arrange
            var testValue = 366319406;

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
            var testValue = "TestValue800213111";

            // Act
            _testClass.EmpStatus = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.EmpStatus);
        }

        [Fact]
        public void CanSetAndGetEmailId()
        {
            // Arrange
            var testValue = "TestValue1904147355";

            // Act
            _testClass.EmailId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.EmailId);
        }

        [Fact]
        public void CanSetAndGetPersonalEmail()
        {
            // Arrange
            var testValue = "TestValue797595356";

            // Act
            _testClass.PersonalEmail = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.PersonalEmail);
        }

        [Fact]
        public void CanSetAndGetMaritalStatus()
        {
            // Arrange
            var testValue = "TestValue1428102926";

            // Act
            _testClass.MaritalStatus = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.MaritalStatus);
        }

        [Fact]
        public void CanSetAndGetBloodGroup()
        {
            // Arrange
            var testValue = "TestValue516085608";

            // Act
            _testClass.BloodGroup = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.BloodGroup);
        }

        [Fact]
        public void CanSetAndGetSpouseName()
        {
            // Arrange
            var testValue = "TestValue771264699";

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
            var testValue = "TestValue1307967121";

            // Act
            _testClass.EmergencyContact = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.EmergencyContact);
        }

        [Fact]
        public void CanSetAndGetAccountId()
        {
            // Arrange
            var testValue = 655473142;

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
                Id = 1507269784,
                EmployeeCredentialId = 688382458,
                AccountNumber = "TestValue801132594",
                ConfirmAcNo = "TestValue480491332",
                IfscCode = "TestValue1512125632",
                ConfirmIfsc = "TestValue1379822794",
                AccountType = "TestValue1327415028",
                BankName = "TestValue768502441",
                BranchName = "TestValue351673399",
                AadharNumber = "TestValue872321167",
                PfNumber = "TestValue1116464859",
                UanNumber = "TestValue1087119962",
                PfSchema = "TestValue1905532019",
                PfJoiningDate = DateTime.UtcNow,
                EligibleForPf = false,
                EmployeeCredential = new EmployeeCredential
                {
                    Id = 212783713,
                    UserName = "TestValue1030076217",
                    Password = "TestValue521723372",
                    Status = (short)13221,
                    RequestedCompanyId = 1475480310,
                    Email = "TestValue1615043919",
                    DefaultPassword = true,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 1925940895,
                        Name = "TestValue1096668425",
                        PhoneNumber = "TestValue1526868616",
                        DomainName = "TestValue651878998",
                        Status = "TestValue1621979181",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue1294406424",
                        Department = new Department
                        {
                            Id = 105341480,
                            Name = "TestValue621432054",
                            RequestedCompanyId = 729638021,
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
                Id = 1456163552,
                UserName = "TestValue1650052943",
                Password = "TestValue130056963",
                Status = (short)23340,
                RequestedCompanyId = 1505510744,
                Email = "TestValue870436253",
                DefaultPassword = true,
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 745590537,
                    Name = "TestValue35390946",
                    PhoneNumber = "TestValue31159464",
                    DomainName = "TestValue157928077",
                    Status = "TestValue1941493016",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Email = "TestValue1197999415",
                    Department = new Department
                    {
                        Id = 668680354,
                        Name = "TestValue504445415",
                        RequestedCompanyId = 1426683091,
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