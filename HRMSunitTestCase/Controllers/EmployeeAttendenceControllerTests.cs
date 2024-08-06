namespace HRMSunitTestCase.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using HRMS_Application.BusinessLogic.Interface;
    using HRMS_Application.Controllers;
    using HRMS_Application.Models;
    using Microsoft.Extensions.Logging;
    using Moq;
    using Xunit;

    public class EmployeeAttendenceControllerTests
    {
        private EmployeeAttendenceController _testClass;
        private Mock<IEmployeeAttendance> _employeeAttendence;
        private Mock<ILogger<EmployeeAttendenceController>> _logger;

        public EmployeeAttendenceControllerTests()
        {
            _employeeAttendence = new Mock<IEmployeeAttendance>();
            _logger = new Mock<ILogger<EmployeeAttendenceController>>();
            _testClass = new EmployeeAttendenceController(_employeeAttendence.Object, _logger.Object);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new EmployeeAttendenceController(_employeeAttendence.Object, _logger.Object);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanCallGetAllEmpDetails()
        {
            // Arrange
            _employeeAttendence.Setup(mock => mock.GetAllEmpAttendence()).Returns(new List<EmployeeAttendance>());

            // Act
            var result = _testClass.GetAllEmpDetails();

            // Assert
            _employeeAttendence.Verify(mock => mock.GetAllEmpAttendence());

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetById()
        {
            // Arrange
            var id = 1579319630;

            _employeeAttendence.Setup(mock => mock.GetById(It.IsAny<int>())).Returns(new EmployeeAttendance
            {
                Id = 819346380,
                EmployeeCredentialId = 349542746,
                LeaveId = 2088759961,
                HolidayId = 1119513920,
                TimeIn = DateTime.UtcNow,
                TimeOut = DateTime.UtcNow,
                Remarks = "TestValue1261353907",
                EmployeeCredential = new EmployeeCredential
                {
                    Id = 507991916,
                    UserName = "TestValue689552819",
                    Password = "TestValue159560518",
                    Status = (short)28578,
                    RequestedCompanyId = 2135791853,
                    Email = "TestValue1909389351",
                    DefaultPassword = false,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 1205382964,
                        Name = "TestValue459077263",
                        PhoneNumber = "TestValue225367064",
                        DomainName = "TestValue951636036",
                        Status = "TestValue214009275",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue752185307",
                        Department = new Department
                        {
                            Id = 848916173,
                            Name = "TestValue1636043411",
                            RequestedCompanyId = 88793322,
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
                Holiday = new Holiday
                {
                    Id = 1534637623,
                    Occasion = "TestValue1501711001",
                    Date = DateTime.UtcNow,
                    Day = "TestValue1718546693",
                    RestrictedHoliday = true,
                    CompanyId = 942539919,
                    EmployeecredentialId = 591362130,
                    Company = new CompanyDetail
                    {
                        Id = 879549752,
                        Name = "TestValue207168001",
                        Address = "TestValue1720849878",
                        Country = "TestValue1744230476",
                        States = "TestValue1194841482",
                        Industry = "TestValue1943442361",
                        TimeZone = "TestValue642583985",
                        Currency = "TestValue1703129463",
                        PfNo = "TestValue894721870",
                        TanNo = "TestValue1789313685",
                        EsiNo = "TestValue1593662144",
                        PanNo = "TestValue764615885",
                        GstNo = "TestValue1541754605",
                        RegistrationNo = "TestValue979198169",
                        Twitter = "TestValue1691552860",
                        Facebook = "TestValue1559056457",
                        LinkedIn = "TestValue76072918",
                        CompanyLogo = "TestValue1961749614",
                        RequestedCompanyId = 1310565117,
                        RequestedCompany = new RequestedCompanyForm
                        {
                            Id = 1264797707,
                            Name = "TestValue1240255003",
                            PhoneNumber = "TestValue1267607098",
                            DomainName = "TestValue834408389",
                            Status = "TestValue431718800",
                            InsertedDate = DateTime.UtcNow,
                            UpdatedDate = DateTime.UtcNow,
                            Email = "TestValue1935457077",
                            Department = new Department
                            {
                                Id = 2059613243,
                                Name = "TestValue1520156151",
                                RequestedCompanyId = 1297156609,
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
                        Id = 1432192404,
                        UserName = "TestValue995315392",
                        Password = "TestValue370213268",
                        Status = (short)7582,
                        RequestedCompanyId = 318813988,
                        Email = "TestValue2064113433",
                        DefaultPassword = false,
                        RequestedCompany = new RequestedCompanyForm
                        {
                            Id = 2099876164,
                            Name = "TestValue152157665",
                            PhoneNumber = "TestValue391561377",
                            DomainName = "TestValue714547869",
                            Status = "TestValue1229227886",
                            InsertedDate = DateTime.UtcNow,
                            UpdatedDate = DateTime.UtcNow,
                            Email = "TestValue562798979",
                            Department = new Department
                            {
                                Id = 903431447,
                                Name = "TestValue1478128841",
                                RequestedCompanyId = 1309805998,
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
                },
                Leave = new LeaveType
                {
                    Id = 767830778,
                    LeaveType1 = "TestValue2135053069",
                    Days = 1454645215,
                    CompanyId = 656845242,
                    EmployeecredentialId = 544724109,
                    Company = new CompanyDetail
                    {
                        Id = 2123064813,
                        Name = "TestValue1425638083",
                        Address = "TestValue1904280726",
                        Country = "TestValue1459490001",
                        States = "TestValue1825225859",
                        Industry = "TestValue1498590774",
                        TimeZone = "TestValue1759426301",
                        Currency = "TestValue1520243259",
                        PfNo = "TestValue1289131078",
                        TanNo = "TestValue1956257046",
                        EsiNo = "TestValue1282711886",
                        PanNo = "TestValue423286210",
                        GstNo = "TestValue1492911023",
                        RegistrationNo = "TestValue270937059",
                        Twitter = "TestValue2046890125",
                        Facebook = "TestValue1419100417",
                        LinkedIn = "TestValue1096719695",
                        CompanyLogo = "TestValue445801897",
                        RequestedCompanyId = 1625124819,
                        RequestedCompany = new RequestedCompanyForm
                        {
                            Id = 1169195102,
                            Name = "TestValue1739160343",
                            PhoneNumber = "TestValue1406898792",
                            DomainName = "TestValue1831995188",
                            Status = "TestValue1247201745",
                            InsertedDate = DateTime.UtcNow,
                            UpdatedDate = DateTime.UtcNow,
                            Email = "TestValue81337231",
                            Department = new Department
                            {
                                Id = 701998728,
                                Name = "TestValue336823556",
                                RequestedCompanyId = 1936961904,
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
                        Id = 1672086038,
                        UserName = "TestValue1811371669",
                        Password = "TestValue1947887655",
                        Status = (short)9230,
                        RequestedCompanyId = 863310909,
                        Email = "TestValue752432500",
                        DefaultPassword = false,
                        RequestedCompany = new RequestedCompanyForm
                        {
                            Id = 1717160956,
                            Name = "TestValue613416189",
                            PhoneNumber = "TestValue1184936095",
                            DomainName = "TestValue641071776",
                            Status = "TestValue565522659",
                            InsertedDate = DateTime.UtcNow,
                            UpdatedDate = DateTime.UtcNow,
                            Email = "TestValue198060413",
                            Department = new Department
                            {
                                Id = 579632905,
                                Name = "TestValue1010510234",
                                RequestedCompanyId = 582787978,
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
                }
            });

            // Act
            var result = _testClass.GetById(id);

            // Assert
            _employeeAttendence.Verify(mock => mock.GetById(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallInsertEmpAttendence()
        {
            // Arrange
            var employeeAttendance = new EmployeeAttendance
            {
                Id = 1217371603,
                EmployeeCredentialId = 632494388,
                LeaveId = 1578722363,
                HolidayId = 2038189228,
                TimeIn = DateTime.UtcNow,
                TimeOut = DateTime.UtcNow,
                Remarks = "TestValue1818594730",
                EmployeeCredential = new EmployeeCredential
                {
                    Id = 1689251172,
                    UserName = "TestValue1977004043",
                    Password = "TestValue1635133787",
                    Status = (short)14541,
                    RequestedCompanyId = 716166021,
                    Email = "TestValue1741126542",
                    DefaultPassword = true,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 1378152770,
                        Name = "TestValue1123227131",
                        PhoneNumber = "TestValue1161767218",
                        DomainName = "TestValue1969948044",
                        Status = "TestValue1995640868",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue1625243056",
                        Department = new Department
                        {
                            Id = 8369391,
                            Name = "TestValue677743858",
                            RequestedCompanyId = 1707458948,
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
                Holiday = new Holiday
                {
                    Id = 740478523,
                    Occasion = "TestValue961809468",
                    Date = DateTime.UtcNow,
                    Day = "TestValue329729169",
                    RestrictedHoliday = false,
                    CompanyId = 2059267247,
                    EmployeecredentialId = 1952213768,
                    Company = new CompanyDetail
                    {
                        Id = 1059602160,
                        Name = "TestValue971134689",
                        Address = "TestValue1159527438",
                        Country = "TestValue396388558",
                        States = "TestValue1249207210",
                        Industry = "TestValue1815365762",
                        TimeZone = "TestValue1422879202",
                        Currency = "TestValue1632110772",
                        PfNo = "TestValue1851812815",
                        TanNo = "TestValue358239541",
                        EsiNo = "TestValue1781380457",
                        PanNo = "TestValue2140260586",
                        GstNo = "TestValue258636483",
                        RegistrationNo = "TestValue775447632",
                        Twitter = "TestValue1375660769",
                        Facebook = "TestValue1946868734",
                        LinkedIn = "TestValue740445217",
                        CompanyLogo = "TestValue2123518061",
                        RequestedCompanyId = 2103820855,
                        RequestedCompany = new RequestedCompanyForm
                        {
                            Id = 1954266972,
                            Name = "TestValue1665328292",
                            PhoneNumber = "TestValue1551239088",
                            DomainName = "TestValue375596016",
                            Status = "TestValue731475684",
                            InsertedDate = DateTime.UtcNow,
                            UpdatedDate = DateTime.UtcNow,
                            Email = "TestValue1532750825",
                            Department = new Department
                            {
                                Id = 574418587,
                                Name = "TestValue901575772",
                                RequestedCompanyId = 1245966375,
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
                        Id = 476893080,
                        UserName = "TestValue1818168567",
                        Password = "TestValue1248993194",
                        Status = (short)18805,
                        RequestedCompanyId = 1906811130,
                        Email = "TestValue1884521051",
                        DefaultPassword = true,
                        RequestedCompany = new RequestedCompanyForm
                        {
                            Id = 663999098,
                            Name = "TestValue1941003622",
                            PhoneNumber = "TestValue319777463",
                            DomainName = "TestValue491919332",
                            Status = "TestValue989196866",
                            InsertedDate = DateTime.UtcNow,
                            UpdatedDate = DateTime.UtcNow,
                            Email = "TestValue2102757215",
                            Department = new Department
                            {
                                Id = 1638600006,
                                Name = "TestValue1457438050",
                                RequestedCompanyId = 1611708503,
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
                },
                Leave = new LeaveType
                {
                    Id = 214260411,
                    LeaveType1 = "TestValue1632466117",
                    Days = 1897216555,
                    CompanyId = 2049779873,
                    EmployeecredentialId = 331798179,
                    Company = new CompanyDetail
                    {
                        Id = 941093436,
                        Name = "TestValue221364251",
                        Address = "TestValue353694755",
                        Country = "TestValue849347020",
                        States = "TestValue105000275",
                        Industry = "TestValue286885476",
                        TimeZone = "TestValue1655846719",
                        Currency = "TestValue595538673",
                        PfNo = "TestValue428051754",
                        TanNo = "TestValue1011121380",
                        EsiNo = "TestValue674788623",
                        PanNo = "TestValue913789990",
                        GstNo = "TestValue176912827",
                        RegistrationNo = "TestValue1155217692",
                        Twitter = "TestValue33644248",
                        Facebook = "TestValue1256729994",
                        LinkedIn = "TestValue548875457",
                        CompanyLogo = "TestValue233449456",
                        RequestedCompanyId = 521599079,
                        RequestedCompany = new RequestedCompanyForm
                        {
                            Id = 2005529396,
                            Name = "TestValue711661671",
                            PhoneNumber = "TestValue5865112",
                            DomainName = "TestValue420667754",
                            Status = "TestValue1631598729",
                            InsertedDate = DateTime.UtcNow,
                            UpdatedDate = DateTime.UtcNow,
                            Email = "TestValue1114623989",
                            Department = new Department
                            {
                                Id = 1998993404,
                                Name = "TestValue26728286",
                                RequestedCompanyId = 93801038,
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
                        Id = 911371160,
                        UserName = "TestValue517215273",
                        Password = "TestValue2047768355",
                        Status = (short)12583,
                        RequestedCompanyId = 999279546,
                        Email = "TestValue914168196",
                        DefaultPassword = true,
                        RequestedCompany = new RequestedCompanyForm
                        {
                            Id = 1596804316,
                            Name = "TestValue895298439",
                            PhoneNumber = "TestValue383157980",
                            DomainName = "TestValue1801810855",
                            Status = "TestValue1597635575",
                            InsertedDate = DateTime.UtcNow,
                            UpdatedDate = DateTime.UtcNow,
                            Email = "TestValue1409038811",
                            Department = new Department
                            {
                                Id = 68460425,
                                Name = "TestValue1512951868",
                                RequestedCompanyId = 1456139730,
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
                }
            };

            _employeeAttendence.Setup(mock => mock.InsertEmployeeAttendence(It.IsAny<EmployeeAttendance>())).ReturnsAsync("TestValue805941676");

            // Act
            var result = await _testClass.InsertEmpAttendence(employeeAttendance);

            // Assert
            _employeeAttendence.Verify(mock => mock.InsertEmployeeAttendence(It.IsAny<EmployeeAttendance>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallUpdateEmpDetails()
        {
            // Arrange
            var id = 865510575;
            var Timein = DateTime.UtcNow;
            var Timeout = DateTime.UtcNow;
            var Remark = "TestValue1256549929";
            var empcredentialId = 69459860;

            _employeeAttendence.Setup(mock => mock.UpdateEmployeeAttendence(It.IsAny<int>(), It.IsAny<DateTime?>(), It.IsAny<DateTime?>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EmployeeAttendance
            {
                Id = 1964614356,
                EmployeeCredentialId = 75406876,
                LeaveId = 1925844388,
                HolidayId = 483382314,
                TimeIn = DateTime.UtcNow,
                TimeOut = DateTime.UtcNow,
                Remarks = "TestValue1423793802",
                EmployeeCredential = new EmployeeCredential
                {
                    Id = 354978509,
                    UserName = "TestValue1812868601",
                    Password = "TestValue1399016661",
                    Status = (short)20989,
                    RequestedCompanyId = 44250477,
                    Email = "TestValue1767620155",
                    DefaultPassword = false,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 1948180144,
                        Name = "TestValue869579673",
                        PhoneNumber = "TestValue1882206678",
                        DomainName = "TestValue253490518",
                        Status = "TestValue260157190",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue1562045681",
                        Department = new Department
                        {
                            Id = 1831651160,
                            Name = "TestValue2058320127",
                            RequestedCompanyId = 1110836672,
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
                Holiday = new Holiday
                {
                    Id = 1997586591,
                    Occasion = "TestValue2061994091",
                    Date = DateTime.UtcNow,
                    Day = "TestValue1410228278",
                    RestrictedHoliday = false,
                    CompanyId = 584323579,
                    EmployeecredentialId = 361431555,
                    Company = new CompanyDetail
                    {
                        Id = 165717477,
                        Name = "TestValue579122248",
                        Address = "TestValue1071447151",
                        Country = "TestValue596490585",
                        States = "TestValue643201246",
                        Industry = "TestValue640396891",
                        TimeZone = "TestValue1112011671",
                        Currency = "TestValue1814468020",
                        PfNo = "TestValue1039217113",
                        TanNo = "TestValue73149016",
                        EsiNo = "TestValue1690829619",
                        PanNo = "TestValue817490883",
                        GstNo = "TestValue556392651",
                        RegistrationNo = "TestValue851830319",
                        Twitter = "TestValue648751694",
                        Facebook = "TestValue1596551850",
                        LinkedIn = "TestValue955029069",
                        CompanyLogo = "TestValue1294031688",
                        RequestedCompanyId = 748054967,
                        RequestedCompany = new RequestedCompanyForm
                        {
                            Id = 1796107819,
                            Name = "TestValue25718766",
                            PhoneNumber = "TestValue648434949",
                            DomainName = "TestValue1548320337",
                            Status = "TestValue1337478385",
                            InsertedDate = DateTime.UtcNow,
                            UpdatedDate = DateTime.UtcNow,
                            Email = "TestValue1994476777",
                            Department = new Department
                            {
                                Id = 384292912,
                                Name = "TestValue1602115387",
                                RequestedCompanyId = 345303058,
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
                        Id = 2114511412,
                        UserName = "TestValue160896432",
                        Password = "TestValue515616110",
                        Status = (short)15432,
                        RequestedCompanyId = 839470223,
                        Email = "TestValue2141030601",
                        DefaultPassword = false,
                        RequestedCompany = new RequestedCompanyForm
                        {
                            Id = 819894413,
                            Name = "TestValue304170325",
                            PhoneNumber = "TestValue1595243539",
                            DomainName = "TestValue1124418909",
                            Status = "TestValue294831433",
                            InsertedDate = DateTime.UtcNow,
                            UpdatedDate = DateTime.UtcNow,
                            Email = "TestValue836168473",
                            Department = new Department
                            {
                                Id = 1202595300,
                                Name = "TestValue842989565",
                                RequestedCompanyId = 180341502,
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
                },
                Leave = new LeaveType
                {
                    Id = 716811218,
                    LeaveType1 = "TestValue744554798",
                    Days = 1275258509,
                    CompanyId = 1206489809,
                    EmployeecredentialId = 462084978,
                    Company = new CompanyDetail
                    {
                        Id = 401034741,
                        Name = "TestValue1106965022",
                        Address = "TestValue116196590",
                        Country = "TestValue871363081",
                        States = "TestValue935699407",
                        Industry = "TestValue335712789",
                        TimeZone = "TestValue1664766175",
                        Currency = "TestValue1178285558",
                        PfNo = "TestValue1881452413",
                        TanNo = "TestValue749497455",
                        EsiNo = "TestValue258908334",
                        PanNo = "TestValue1185765151",
                        GstNo = "TestValue766708613",
                        RegistrationNo = "TestValue1847440255",
                        Twitter = "TestValue878320681",
                        Facebook = "TestValue1705016553",
                        LinkedIn = "TestValue679381706",
                        CompanyLogo = "TestValue2125504307",
                        RequestedCompanyId = 562845697,
                        RequestedCompany = new RequestedCompanyForm
                        {
                            Id = 1352162842,
                            Name = "TestValue1976340928",
                            PhoneNumber = "TestValue1292381525",
                            DomainName = "TestValue1507269177",
                            Status = "TestValue169612779",
                            InsertedDate = DateTime.UtcNow,
                            UpdatedDate = DateTime.UtcNow,
                            Email = "TestValue453223534",
                            Department = new Department
                            {
                                Id = 959939346,
                                Name = "TestValue970607113",
                                RequestedCompanyId = 1952929031,
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
                        Id = 1367978835,
                        UserName = "TestValue620667167",
                        Password = "TestValue1249921979",
                        Status = (short)19172,
                        RequestedCompanyId = 395625578,
                        Email = "TestValue2030701727",
                        DefaultPassword = true,
                        RequestedCompany = new RequestedCompanyForm
                        {
                            Id = 1201415057,
                            Name = "TestValue399419520",
                            PhoneNumber = "TestValue140084832",
                            DomainName = "TestValue2051254463",
                            Status = "TestValue1805317812",
                            InsertedDate = DateTime.UtcNow,
                            UpdatedDate = DateTime.UtcNow,
                            Email = "TestValue2129868596",
                            Department = new Department
                            {
                                Id = 1789092502,
                                Name = "TestValue570201559",
                                RequestedCompanyId = 845746084,
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
                }
            });

            // Act
            var result = await _testClass.UpdateEmpDetails(id, Timein, Timeout, Remark, empcredentialId);

            // Assert
            _employeeAttendence.Verify(mock => mock.UpdateEmployeeAttendence(It.IsAny<int>(), It.IsAny<DateTime?>(), It.IsAny<DateTime?>(), It.IsAny<string>(), It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallDeleteEmpAttendence()
        {
            // Arrange
            var id = 2112152531;

            _employeeAttendence.Setup(mock => mock.DeleteEmployeeAttendance(It.IsAny<int>())).ReturnsAsync(false);

            // Act
            var result = await _testClass.DeleteEmpAttendence(id);

            // Assert
            _employeeAttendence.Verify(mock => mock.DeleteEmployeeAttendance(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }
    }
}