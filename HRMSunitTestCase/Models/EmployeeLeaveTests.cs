namespace HRMSunitTestCase.Models
{
    using System;
    using System.Collections.Generic;
    using HRMS_Application.Models;
    using Moq;
    using Xunit;

    public partial class EmployeeLeaveTests
    {
        private EmployeeLeave _testClass;

        public EmployeeLeaveTests()
        {
            _testClass = new EmployeeLeave();
        }

        [Fact]
        public void CanSetAndGetId()
        {
            // Arrange
            var testValue = 140262054;

            // Act
            _testClass.Id = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Id);
        }

        [Fact]
        public void CanSetAndGetEmployeeCredentialId()
        {
            // Arrange
            var testValue = 669643951;

            // Act
            _testClass.EmployeeCredentialId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.EmployeeCredentialId);
        }

        [Fact]
        public void CanSetAndGetLeaveId()
        {
            // Arrange
            var testValue = 268285036;

            // Act
            _testClass.LeaveId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.LeaveId);
        }

        [Fact]
        public void CanSetAndGetStartDate()
        {
            // Arrange
            var testValue = DateTime.UtcNow;

            // Act
            _testClass.StartDate = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.StartDate);
        }

        [Fact]
        public void CanSetAndGetEndDate()
        {
            // Arrange
            var testValue = DateTime.UtcNow;

            // Act
            _testClass.EndDate = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.EndDate);
        }

        [Fact]
        public void CanSetAndGetSession()
        {
            // Arrange
            var testValue = "TestValue1960387700";

            // Act
            _testClass.Session = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Session);
        }

        [Fact]
        public void CanSetAndGetTotalDays()
        {
            // Arrange
            var testValue = 1519437716;

            // Act
            _testClass.TotalDays = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.TotalDays);
        }

        [Fact]
        public void CanSetAndGetContact()
        {
            // Arrange
            var testValue = "TestValue1656147585";

            // Act
            _testClass.Contact = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Contact);
        }

        [Fact]
        public void CanSetAndGetReasonForLeave()
        {
            // Arrange
            var testValue = "TestValue1461507659";

            // Act
            _testClass.ReasonForLeave = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.ReasonForLeave);
        }

        [Fact]
        public void CanSetAndGetFiles()
        {
            // Arrange
            var testValue = "TestValue44158470";

            // Act
            _testClass.Files = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Files);
        }

        [Fact]
        public void CanSetAndGetEmployeeCredential()
        {
            // Arrange
            var testValue = new EmployeeCredential
            {
                Id = 2038428838,
                UserName = "TestValue871662363",
                Password = "TestValue273878242",
                Status = (short)6972,
                RequestedCompanyId = 71219658,
                Email = "TestValue1690672256",
                DefaultPassword = false,
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 21609145,
                    Name = "TestValue828246861",
                    PhoneNumber = "TestValue46876286",
                    DomainName = "TestValue1811630407",
                    Status = "TestValue268325104",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Email = "TestValue1470852829",
                    Department = new Department
                    {
                        Id = 525567492,
                        Name = "TestValue1946475140",
                        RequestedCompanyId = 76993060,
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
        public void CanSetAndGetLeave()
        {
            // Arrange
            var testValue = new LeaveType
            {
                Id = 635736731,
                LeaveType1 = "TestValue1228697141",
                Days = 294016754,
                CompanyId = 343748324,
                EmployeecredentialId = 617447239,
                Company = new CompanyDetail
                {
                    Id = 487017903,
                    Name = "TestValue1464345385",
                    Address = "TestValue868148809",
                    Country = "TestValue2014538701",
                    States = "TestValue339281722",
                    Industry = "TestValue1113384298",
                    TimeZone = "TestValue510003088",
                    Currency = "TestValue474701255",
                    PfNo = "TestValue1407519186",
                    TanNo = "TestValue961294349",
                    EsiNo = "TestValue812044212",
                    PanNo = "TestValue2070025106",
                    GstNo = "TestValue1785810540",
                    RegistrationNo = "TestValue1929071334",
                    Twitter = "TestValue1350531327",
                    Facebook = "TestValue936771216",
                    LinkedIn = "TestValue214022598",
                    CompanyLogo = "TestValue840007899",
                    RequestedCompanyId = 177609552,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 1453417240,
                        Name = "TestValue285886811",
                        PhoneNumber = "TestValue373631052",
                        DomainName = "TestValue2094710737",
                        Status = "TestValue180232610",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue835969944",
                        Department = new Department
                        {
                            Id = 685337532,
                            Name = "TestValue1762178209",
                            RequestedCompanyId = 870652458,
                            RequestedCompany = default(RequestedCompanyForm),
                            EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object
                        },
                        CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                        EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                        Positions = new Mock<ICollection<Position>>().Object
                    },
                    Holidays = new Mock<ICollection<Holiday>>().Object,
                    LeaveTypes = new Mock<ICollection<LeaveType>>().Object
                },
                Employeecredential = new EmployeeCredential
                {
                    Id = 191291976,
                    UserName = "TestValue1324650969",
                    Password = "TestValue290740575",
                    Status = (short)20783,
                    RequestedCompanyId = 1117759335,
                    Email = "TestValue1574194878",
                    DefaultPassword = true,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 1554800625,
                        Name = "TestValue1553213080",
                        PhoneNumber = "TestValue589903821",
                        DomainName = "TestValue1879421583",
                        Status = "TestValue577287958",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue1186867208",
                        Department = new Department
                        {
                            Id = 1694391537,
                            Name = "TestValue1568211322",
                            RequestedCompanyId = 1233065584,
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
                EmployeeAttendances = new Mock<ICollection<EmployeeAttendance>>().Object,
                EmployeeLeaves = new Mock<ICollection<EmployeeLeave>>().Object
            };

            // Act
            _testClass.Leave = testValue;

            // Assert
            Assert.Same(testValue, _testClass.Leave);
        }
    }
}