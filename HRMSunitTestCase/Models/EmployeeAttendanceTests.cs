namespace HRMSunitTestCase.Models
{
    using System;
    using System.Collections.Generic;
    using HRMS_Application.Models;
    using Moq;
    using Xunit;

    public partial class EmployeeAttendanceTests
    {
        private EmployeeAttendance _testClass;

        public EmployeeAttendanceTests()
        {
            _testClass = new EmployeeAttendance();
        }

        [Fact]
        public void CanSetAndGetId()
        {
            // Arrange
            var testValue = 721506093;

            // Act
            _testClass.Id = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Id);
        }

        [Fact]
        public void CanSetAndGetEmployeeCredentialId()
        {
            // Arrange
            var testValue = 534497904;

            // Act
            _testClass.EmployeeCredentialId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.EmployeeCredentialId);
        }

        [Fact]
        public void CanSetAndGetLeaveId()
        {
            // Arrange
            var testValue = 989991463;

            // Act
            _testClass.LeaveId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.LeaveId);
        }

        [Fact]
        public void CanSetAndGetHolidayId()
        {
            // Arrange
            var testValue = 1030182912;

            // Act
            _testClass.HolidayId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.HolidayId);
        }

        [Fact]
        public void CanSetAndGetTimeIn()
        {
            // Arrange
            var testValue = DateTime.UtcNow;

            // Act
            _testClass.TimeIn = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.TimeIn);
        }

        [Fact]
        public void CanSetAndGetTimeOut()
        {
            // Arrange
            var testValue = DateTime.UtcNow;

            // Act
            _testClass.TimeOut = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.TimeOut);
        }

        [Fact]
        public void CanSetAndGetRemarks()
        {
            // Arrange
            var testValue = "TestValue138738197";

            // Act
            _testClass.Remarks = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Remarks);
        }

        [Fact]
        public void CanSetAndGetEmployeeCredential()
        {
            // Arrange
            var testValue = new EmployeeCredential
            {
                Id = 68559113,
                UserName = "TestValue1057474872",
                Password = "TestValue1059878227",
                Status = (short)19610,
                RequestedCompanyId = 516879658,
                Email = "TestValue945466672",
                DefaultPassword = false,
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 1698991302,
                    Name = "TestValue537097159",
                    PhoneNumber = "TestValue1945285948",
                    DomainName = "TestValue1122649401",
                    Status = "TestValue1262021740",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Email = "TestValue1695881912",
                    Department = new Department
                    {
                        Id = 1306425722,
                        Name = "TestValue1309388782",
                        RequestedCompanyId = 969803752,
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
        public void CanSetAndGetHoliday()
        {
            // Arrange
            var testValue = new Holiday
            {
                Id = 473597969,
                Occasion = "TestValue1995789010",
                Date = DateTime.UtcNow,
                Day = "TestValue938297011",
                RestrictedHoliday = false,
                CompanyId = 803534405,
                EmployeecredentialId = 1492475099,
                Company = new CompanyDetail
                {
                    Id = 1979262642,
                    Name = "TestValue405684799",
                    Address = "TestValue1805226271",
                    Country = "TestValue20727168",
                    States = "TestValue1230309673",
                    Industry = "TestValue1737966981",
                    TimeZone = "TestValue1593878204",
                    Currency = "TestValue2018482237",
                    PfNo = "TestValue1707694119",
                    TanNo = "TestValue972077394",
                    EsiNo = "TestValue2115610221",
                    PanNo = "TestValue917318582",
                    GstNo = "TestValue1384942519",
                    RegistrationNo = "TestValue1815349433",
                    Twitter = "TestValue1018263264",
                    Facebook = "TestValue877465073",
                    LinkedIn = "TestValue1255110644",
                    CompanyLogo = "TestValue1720754038",
                    RequestedCompanyId = 742877398,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 1396697535,
                        Name = "TestValue1863979507",
                        PhoneNumber = "TestValue428540397",
                        DomainName = "TestValue728129211",
                        Status = "TestValue673348006",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue483848794",
                        Department = new Department
                        {
                            Id = 1099714646,
                            Name = "TestValue550918976",
                            RequestedCompanyId = 1267218671,
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
                    Id = 247908124,
                    UserName = "TestValue686192541",
                    Password = "TestValue51694452",
                    Status = (short)31811,
                    RequestedCompanyId = 1482687439,
                    Email = "TestValue723567661",
                    DefaultPassword = true,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 654193427,
                        Name = "TestValue1627476378",
                        PhoneNumber = "TestValue496152490",
                        DomainName = "TestValue1862640646",
                        Status = "TestValue1573413630",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue105113098",
                        Department = new Department
                        {
                            Id = 666098569,
                            Name = "TestValue237591829",
                            RequestedCompanyId = 150572007,
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
                EmployeeAttendances = new Mock<ICollection<EmployeeAttendance>>().Object
            };

            // Act
            _testClass.Holiday = testValue;

            // Assert
            Assert.Same(testValue, _testClass.Holiday);
        }

        [Fact]
        public void CanSetAndGetLeave()
        {
            // Arrange
            var testValue = new LeaveType
            {
                Id = 1293895166,
                LeaveType1 = "TestValue778563330",
                Days = 2068966850,
                CompanyId = 1641522996,
                EmployeecredentialId = 2099024135,
                Company = new CompanyDetail
                {
                    Id = 1743616543,
                    Name = "TestValue740678366",
                    Address = "TestValue1365026620",
                    Country = "TestValue349938980",
                    States = "TestValue1554320517",
                    Industry = "TestValue1775979239",
                    TimeZone = "TestValue1550722245",
                    Currency = "TestValue1825039236",
                    PfNo = "TestValue1131878265",
                    TanNo = "TestValue1684362021",
                    EsiNo = "TestValue130595027",
                    PanNo = "TestValue1187048005",
                    GstNo = "TestValue326659533",
                    RegistrationNo = "TestValue1770574113",
                    Twitter = "TestValue1021501578",
                    Facebook = "TestValue920382942",
                    LinkedIn = "TestValue30760040",
                    CompanyLogo = "TestValue1582114790",
                    RequestedCompanyId = 661374858,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 589653556,
                        Name = "TestValue364069837",
                        PhoneNumber = "TestValue1397472342",
                        DomainName = "TestValue758958154",
                        Status = "TestValue2005597039",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue1316947415",
                        Department = new Department
                        {
                            Id = 1291584437,
                            Name = "TestValue1197880938",
                            RequestedCompanyId = 190948568,
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
                    Id = 577557204,
                    UserName = "TestValue1526936487",
                    Password = "TestValue1852769111",
                    Status = (short)17977,
                    RequestedCompanyId = 1056879627,
                    Email = "TestValue1315678183",
                    DefaultPassword = false,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 2092997822,
                        Name = "TestValue834151479",
                        PhoneNumber = "TestValue1734911201",
                        DomainName = "TestValue2075850569",
                        Status = "TestValue1095072069",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue1822457279",
                        Department = new Department
                        {
                            Id = 976637838,
                            Name = "TestValue495598113",
                            RequestedCompanyId = 959274116,
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