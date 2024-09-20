namespace HRMS_Unit_Test.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using HRMS_Application.BusinessLogic.Interface;
    using HRMS_Application.Controllers;
    using HRMS_Application.DTO;
    using HRMS_Application.Models;
    using Microsoft.Extensions.Logging;
    using Moq;
    using Xunit;

    public class LeaveTrackingControllerTests
    {
        private readonly LeaveTrackingController _testClass;
        private readonly Mock<ILeaveTracking> _leaveTracking;
        private readonly Mock<ILogger<LeaveTrackingController>> _logger;

        public LeaveTrackingControllerTests()
        {
            _leaveTracking = new Mock<ILeaveTracking>();
            _logger = new Mock<ILogger<LeaveTrackingController>>();
            _testClass = new LeaveTrackingController(_leaveTracking.Object, _logger.Object);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new LeaveTrackingController(_leaveTracking.Object, _logger.Object);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public async Task CanCallGetAll()
        {
            // Arrange
            _leaveTracking.Setup(mock => mock.GetAllAsync()).ReturnsAsync(new[] {
                new LeaveTracking
                {
                    Id = 35949859,
                    EmpCredentialId = 1706426429,
                    Startdate = DateTime.UtcNow,
                    Enddate = DateTime.UtcNow,
                    AppliedDate = DateTime.UtcNow,
                    Status = "TestValue1597652162",
                    Files = "TestValue10316302",
                    LeaveTypeId = 1988800324,
                    Session = "TestValue22518323",
                    Contact = "TestValue37253109",
                    ReasonForLeave = "TestValue2028045794",
                    IsActive = (short)26174,
                    EmpCredential = new EmployeeCredential
                    {
                        Id = 523278476,
                        UserName = "TestValue1961532340",
                        Password = "TestValue1038134481",
                        Status = (short)2119,
                        RequestedCompanyId = 803022714,
                        Email = "TestValue970379630",
                        DefaultPassword = false,
                        GenerateOtp = "TestValue2107472442",
                        OtpExpiration = DateTime.UtcNow,
                        IsActive = (short)14725,
                        EmployeeLoginName = "TestValue2078672294",
                        RequestedCompany = new RequestedCompanyForm
                        {
                            Id = 449725580,
                            Name = "TestValue121907229",
                            PhoneNumber = "TestValue855573934",
                            DomainName = "TestValue1623184057",
                            Status = "TestValue1461420410",
                            InsertedDate = DateTime.UtcNow,
                            UpdatedDate = DateTime.UtcNow,
                            Email = "TestValue1969531480",
                            IsActive = (short)32176,
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
                    },
                    LeaveType = new LeaveType
                    {
                        Id = 1371872462,
                        Type = "TestValue639647524",
                        Days = 82351357,
                        CompanyId = 1585275071,
                        Year = 743306549,
                        IsActive = (short)7295,
                        Company = new RequestedCompanyForm
                        {
                            Id = 758766580,
                            Name = "TestValue312135763",
                            PhoneNumber = "TestValue91429334",
                            DomainName = "TestValue722879050",
                            Status = "TestValue145149836",
                            InsertedDate = DateTime.UtcNow,
                            UpdatedDate = DateTime.UtcNow,
                            Email = "TestValue1116109225",
                            IsActive = (short)11588,
                            CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                            Departments = new Mock<ICollection<Department>>().Object,
                            EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                            Holidays = new Mock<ICollection<Holiday>>().Object,
                            LeaveTypes = new Mock<ICollection<LeaveType>>().Object,
                            Positions = new Mock<ICollection<Position>>().Object
                        },
                        EmployeeLeaveAllocations = new Mock<ICollection<EmployeeLeaveAllocation>>().Object,
                        LeaveTrackings = new Mock<ICollection<LeaveTracking>>().Object
                    }
                },
                new LeaveTracking
                {
                    Id = 1912888491,
                    EmpCredentialId = 277074170,
                    Startdate = DateTime.UtcNow,
                    Enddate = DateTime.UtcNow,
                    AppliedDate = DateTime.UtcNow,
                    Status = "TestValue212328898",
                    Files = "TestValue1096754071",
                    LeaveTypeId = 1509517706,
                    Session = "TestValue1370161568",
                    Contact = "TestValue198077151",
                    ReasonForLeave = "TestValue1475701735",
                    IsActive = (short)6104,
                    EmpCredential = new EmployeeCredential
                    {
                        Id = 1643751127,
                        UserName = "TestValue652447592",
                        Password = "TestValue2093565194",
                        Status = (short)16281,
                        RequestedCompanyId = 686355554,
                        Email = "TestValue945028404",
                        DefaultPassword = true,
                        GenerateOtp = "TestValue1327859572",
                        OtpExpiration = DateTime.UtcNow,
                        IsActive = (short)1270,
                        EmployeeLoginName = "TestValue136231752",
                        RequestedCompany = new RequestedCompanyForm
                        {
                            Id = 188268469,
                            Name = "TestValue2027467808",
                            PhoneNumber = "TestValue798129508",
                            DomainName = "TestValue1545089232",
                            Status = "TestValue1945694437",
                            InsertedDate = DateTime.UtcNow,
                            UpdatedDate = DateTime.UtcNow,
                            Email = "TestValue130153771",
                            IsActive = (short)29409,
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
                    },
                    LeaveType = new LeaveType
                    {
                        Id = 1483381318,
                        Type = "TestValue279367901",
                        Days = 1974287123,
                        CompanyId = 711593380,
                        Year = 247500580,
                        IsActive = (short)17103,
                        Company = new RequestedCompanyForm
                        {
                            Id = 991363217,
                            Name = "TestValue205591034",
                            PhoneNumber = "TestValue165783803",
                            DomainName = "TestValue172651410",
                            Status = "TestValue2057061978",
                            InsertedDate = DateTime.UtcNow,
                            UpdatedDate = DateTime.UtcNow,
                            Email = "TestValue1906303510",
                            IsActive = (short)1734,
                            CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                            Departments = new Mock<ICollection<Department>>().Object,
                            EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                            Holidays = new Mock<ICollection<Holiday>>().Object,
                            LeaveTypes = new Mock<ICollection<LeaveType>>().Object,
                            Positions = new Mock<ICollection<Position>>().Object
                        },
                        EmployeeLeaveAllocations = new Mock<ICollection<EmployeeLeaveAllocation>>().Object,
                        LeaveTrackings = new Mock<ICollection<LeaveTracking>>().Object
                    }
                },
                new LeaveTracking
                {
                    Id = 91258842,
                    EmpCredentialId = 1771454329,
                    Startdate = DateTime.UtcNow,
                    Enddate = DateTime.UtcNow,
                    AppliedDate = DateTime.UtcNow,
                    Status = "TestValue633114428",
                    Files = "TestValue971810800",
                    LeaveTypeId = 1143380044,
                    Session = "TestValue1577387412",
                    Contact = "TestValue1639193524",
                    ReasonForLeave = "TestValue1823702606",
                    IsActive = (short)29590,
                    EmpCredential = new EmployeeCredential
                    {
                        Id = 1961221823,
                        UserName = "TestValue1659360493",
                        Password = "TestValue911053409",
                        Status = (short)9759,
                        RequestedCompanyId = 8918084,
                        Email = "TestValue927840756",
                        DefaultPassword = false,
                        GenerateOtp = "TestValue1114758983",
                        OtpExpiration = DateTime.UtcNow,
                        IsActive = (short)13419,
                        EmployeeLoginName = "TestValue414118108",
                        RequestedCompany = new RequestedCompanyForm
                        {
                            Id = 966600300,
                            Name = "TestValue1729545779",
                            PhoneNumber = "TestValue2034263897",
                            DomainName = "TestValue2066192897",
                            Status = "TestValue1648898259",
                            InsertedDate = DateTime.UtcNow,
                            UpdatedDate = DateTime.UtcNow,
                            Email = "TestValue1835951929",
                            IsActive = (short)21304,
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
                    },
                    LeaveType = new LeaveType
                    {
                        Id = 1679014755,
                        Type = "TestValue1102201977",
                        Days = 861496556,
                        CompanyId = 520571751,
                        Year = 772376994,
                        IsActive = (short)13590,
                        Company = new RequestedCompanyForm
                        {
                            Id = 1569039709,
                            Name = "TestValue2117059668",
                            PhoneNumber = "TestValue44972910",
                            DomainName = "TestValue564297787",
                            Status = "TestValue1394353380",
                            InsertedDate = DateTime.UtcNow,
                            UpdatedDate = DateTime.UtcNow,
                            Email = "TestValue1973802355",
                            IsActive = (short)6129,
                            CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                            Departments = new Mock<ICollection<Department>>().Object,
                            EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                            Holidays = new Mock<ICollection<Holiday>>().Object,
                            LeaveTypes = new Mock<ICollection<LeaveType>>().Object,
                            Positions = new Mock<ICollection<Position>>().Object
                        },
                        EmployeeLeaveAllocations = new Mock<ICollection<EmployeeLeaveAllocation>>().Object,
                        LeaveTrackings = new Mock<ICollection<LeaveTracking>>().Object
                    }
                }
            });

            // Act
            var result = await _testClass.GetAll();

            // Assert
            _leaveTracking.Verify(mock => mock.GetAllAsync());

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallGetById()
        {
            // Arrange
            var id = 1333971629;

            _leaveTracking.Setup(mock => mock.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(new LeaveTracking
            {
                Id = 368307025,
                EmpCredentialId = 638443894,
                Startdate = DateTime.UtcNow,
                Enddate = DateTime.UtcNow,
                AppliedDate = DateTime.UtcNow,
                Status = "TestValue103752968",
                Files = "TestValue1691585850",
                LeaveTypeId = 465629725,
                Session = "TestValue314926630",
                Contact = "TestValue1948023618",
                ReasonForLeave = "TestValue1755347549",
                IsActive = (short)16967,
                EmpCredential = new EmployeeCredential
                {
                    Id = 63522461,
                    UserName = "TestValue1473587275",
                    Password = "TestValue1198508467",
                    Status = (short)21982,
                    RequestedCompanyId = 1642943870,
                    Email = "TestValue939703210",
                    DefaultPassword = true,
                    GenerateOtp = "TestValue204478592",
                    OtpExpiration = DateTime.UtcNow,
                    IsActive = (short)28269,
                    EmployeeLoginName = "TestValue1131699816",
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 1283342518,
                        Name = "TestValue1894613144",
                        PhoneNumber = "TestValue2045856304",
                        DomainName = "TestValue536991547",
                        Status = "TestValue962206050",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue1418707364",
                        IsActive = (short)18139,
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
                },
                LeaveType = new LeaveType
                {
                    Id = 768679907,
                    Type = "TestValue1489497347",
                    Days = 670060657,
                    CompanyId = 2111428821,
                    Year = 363542969,
                    IsActive = (short)24911,
                    Company = new RequestedCompanyForm
                    {
                        Id = 1288440275,
                        Name = "TestValue477759397",
                        PhoneNumber = "TestValue45811083",
                        DomainName = "TestValue328156406",
                        Status = "TestValue1625792811",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue342678047",
                        IsActive = (short)24421,
                        CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                        Departments = new Mock<ICollection<Department>>().Object,
                        EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                        Holidays = new Mock<ICollection<Holiday>>().Object,
                        LeaveTypes = new Mock<ICollection<LeaveType>>().Object,
                        Positions = new Mock<ICollection<Position>>().Object
                    },
                    EmployeeLeaveAllocations = new Mock<ICollection<EmployeeLeaveAllocation>>().Object,
                    LeaveTrackings = new Mock<ICollection<LeaveTracking>>().Object
                }
            });

            // Act
            var result = await _testClass.GetById(id);

            // Assert
            _leaveTracking.Verify(mock => mock.GetByIdAsync(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallCreateLeaveTracking()
        {
            // Arrange
            var leaveTrackingDto = new LeaveTrackingDTO
            {
                Id = 2096644080,
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow,
                Applied = DateTime.UtcNow,
                Files = "TestValue1857134307",
                LeaveTypeId = 1520943191,
                Session = "TestValue860160848",
                Contact = "TestValue1232088855",
                ReasonForLeave = "TestValue123450856"
            };

            _leaveTracking.Setup(mock => mock.CreateAsync(It.IsAny<LeaveTracking>(), It.IsAny<int>())).ReturnsAsync(new LeaveTracking
            {
                Id = 2035411958,
                EmpCredentialId = 1788386645,
                Startdate = DateTime.UtcNow,
                Enddate = DateTime.UtcNow,
                AppliedDate = DateTime.UtcNow,
                Status = "TestValue567016355",
                Files = "TestValue1038679516",
                LeaveTypeId = 1535392928,
                Session = "TestValue1469546931",
                Contact = "TestValue1479194169",
                ReasonForLeave = "TestValue1395220363",
                IsActive = (short)9602,
                EmpCredential = new EmployeeCredential
                {
                    Id = 1585455449,
                    UserName = "TestValue1987977965",
                    Password = "TestValue859036355",
                    Status = (short)4007,
                    RequestedCompanyId = 690459837,
                    Email = "TestValue654579691",
                    DefaultPassword = false,
                    GenerateOtp = "TestValue101452347",
                    OtpExpiration = DateTime.UtcNow,
                    IsActive = (short)19668,
                    EmployeeLoginName = "TestValue272878486",
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 1424268543,
                        Name = "TestValue1693730370",
                        PhoneNumber = "TestValue458526271",
                        DomainName = "TestValue1085286892",
                        Status = "TestValue1148053226",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue1847463139",
                        IsActive = (short)30340,
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
                },
                LeaveType = new LeaveType
                {
                    Id = 2057551839,
                    Type = "TestValue962907075",
                    Days = 1597132787,
                    CompanyId = 611546804,
                    Year = 1053295055,
                    IsActive = (short)30658,
                    Company = new RequestedCompanyForm
                    {
                        Id = 252181907,
                        Name = "TestValue1945211834",
                        PhoneNumber = "TestValue1395414207",
                        DomainName = "TestValue106226499",
                        Status = "TestValue1478839949",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue1645795678",
                        IsActive = (short)24021,
                        CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                        Departments = new Mock<ICollection<Department>>().Object,
                        EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                        Holidays = new Mock<ICollection<Holiday>>().Object,
                        LeaveTypes = new Mock<ICollection<LeaveType>>().Object,
                        Positions = new Mock<ICollection<Position>>().Object
                    },
                    EmployeeLeaveAllocations = new Mock<ICollection<EmployeeLeaveAllocation>>().Object,
                    LeaveTrackings = new Mock<ICollection<LeaveTracking>>().Object
                }
            });

            // Act
            var result = await _testClass.CreateLeaveTracking(leaveTrackingDto);

            // Assert
            _leaveTracking.Verify(mock => mock.CreateAsync(It.IsAny<LeaveTracking>(), It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallApllyLeaveBehalf()
        {
            // Arrange
            var leaveTrackingDto = new LeaveTrackingDTO
            {
                Id = 384842745,
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow,
                Applied = DateTime.UtcNow,
                Files = "TestValue716532809",
                LeaveTypeId = 1939484631,
                Session = "TestValue75887278",
                Contact = "TestValue157486928",
                ReasonForLeave = "TestValue1966012167"
            };
            var empCredentialId = 1550610393;

            _leaveTracking.Setup(mock => mock.ApllyLeaveBehalf(It.IsAny<LeaveTracking>(), It.IsAny<int>())).ReturnsAsync(new LeaveTracking
            {
                Id = 1651990261,
                EmpCredentialId = 1369964109,
                Startdate = DateTime.UtcNow,
                Enddate = DateTime.UtcNow,
                AppliedDate = DateTime.UtcNow,
                Status = "TestValue597980438",
                Files = "TestValue1970663353",
                LeaveTypeId = 1723360362,
                Session = "TestValue226704059",
                Contact = "TestValue336762246",
                ReasonForLeave = "TestValue69799561",
                IsActive = (short)2689,
                EmpCredential = new EmployeeCredential
                {
                    Id = 1787724906,
                    UserName = "TestValue1576885687",
                    Password = "TestValue703099753",
                    Status = (short)23901,
                    RequestedCompanyId = 1338700024,
                    Email = "TestValue1694423326",
                    DefaultPassword = true,
                    GenerateOtp = "TestValue516287094",
                    OtpExpiration = DateTime.UtcNow,
                    IsActive = (short)29686,
                    EmployeeLoginName = "TestValue17789695",
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 532160394,
                        Name = "TestValue2126177420",
                        PhoneNumber = "TestValue606854448",
                        DomainName = "TestValue464925377",
                        Status = "TestValue1442529277",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue548353192",
                        IsActive = (short)17372,
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
                },
                LeaveType = new LeaveType
                {
                    Id = 603140316,
                    Type = "TestValue1862217443",
                    Days = 323718053,
                    CompanyId = 1714617883,
                    Year = 172787179,
                    IsActive = (short)26638,
                    Company = new RequestedCompanyForm
                    {
                        Id = 2000681684,
                        Name = "TestValue1024602370",
                        PhoneNumber = "TestValue195472878",
                        DomainName = "TestValue618489140",
                        Status = "TestValue1459571401",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue1139727369",
                        IsActive = (short)30840,
                        CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                        Departments = new Mock<ICollection<Department>>().Object,
                        EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                        Holidays = new Mock<ICollection<Holiday>>().Object,
                        LeaveTypes = new Mock<ICollection<LeaveType>>().Object,
                        Positions = new Mock<ICollection<Position>>().Object
                    },
                    EmployeeLeaveAllocations = new Mock<ICollection<EmployeeLeaveAllocation>>().Object,
                    LeaveTrackings = new Mock<ICollection<LeaveTracking>>().Object
                }
            });

            // Act
            var result = await _testClass.ApllyLeaveBehalf(leaveTrackingDto, empCredentialId);

            // Assert
            _leaveTracking.Verify(mock => mock.ApllyLeaveBehalf(It.IsAny<LeaveTracking>(), It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallUpdate()
        {
            // Arrange
            var id = 597415211;
            var leaveTracking = new LeaveTracking
            {
                Id = 903477917,
                EmpCredentialId = 1300753223,
                Startdate = DateTime.UtcNow,
                Enddate = DateTime.UtcNow,
                AppliedDate = DateTime.UtcNow,
                Status = "TestValue879845287",
                Files = "TestValue1297820712",
                LeaveTypeId = 1860934055,
                Session = "TestValue156636593",
                Contact = "TestValue1864900855",
                ReasonForLeave = "TestValue1436473776",
                IsActive = (short)11615,
                EmpCredential = new EmployeeCredential
                {
                    Id = 94504359,
                    UserName = "TestValue45919476",
                    Password = "TestValue1614210532",
                    Status = (short)10528,
                    RequestedCompanyId = 2134975550,
                    Email = "TestValue700708677",
                    DefaultPassword = false,
                    GenerateOtp = "TestValue1311352155",
                    OtpExpiration = DateTime.UtcNow,
                    IsActive = (short)14517,
                    EmployeeLoginName = "TestValue437258003",
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 1964287488,
                        Name = "TestValue1798540464",
                        PhoneNumber = "TestValue1209424203",
                        DomainName = "TestValue884300876",
                        Status = "TestValue2105547941",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue514168643",
                        IsActive = (short)9118,
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
                },
                LeaveType = new LeaveType
                {
                    Id = 1826417698,
                    Type = "TestValue277083715",
                    Days = 1506081050,
                    CompanyId = 1475002728,
                    Year = 787168097,
                    IsActive = (short)32149,
                    Company = new RequestedCompanyForm
                    {
                        Id = 235389723,
                        Name = "TestValue1017522516",
                        PhoneNumber = "TestValue1075042347",
                        DomainName = "TestValue1696632140",
                        Status = "TestValue1809482766",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue1992890081",
                        IsActive = (short)20789,
                        CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                        Departments = new Mock<ICollection<Department>>().Object,
                        EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                        Holidays = new Mock<ICollection<Holiday>>().Object,
                        LeaveTypes = new Mock<ICollection<LeaveType>>().Object,
                        Positions = new Mock<ICollection<Position>>().Object
                    },
                    EmployeeLeaveAllocations = new Mock<ICollection<EmployeeLeaveAllocation>>().Object,
                    LeaveTrackings = new Mock<ICollection<LeaveTracking>>().Object
                }
            };

            _leaveTracking.Setup(mock => mock.UpdateAsync(It.IsAny<LeaveTracking>())).ReturnsAsync(new LeaveTracking
            {
                Id = 2059876820,
                EmpCredentialId = 307095654,
                Startdate = DateTime.UtcNow,
                Enddate = DateTime.UtcNow,
                AppliedDate = DateTime.UtcNow,
                Status = "TestValue2027357090",
                Files = "TestValue537165341",
                LeaveTypeId = 1340847213,
                Session = "TestValue1722855615",
                Contact = "TestValue842371153",
                ReasonForLeave = "TestValue699928461",
                IsActive = (short)2208,
                EmpCredential = new EmployeeCredential
                {
                    Id = 1045135813,
                    UserName = "TestValue905038732",
                    Password = "TestValue1302934808",
                    Status = (short)21702,
                    RequestedCompanyId = 584782296,
                    Email = "TestValue1771047390",
                    DefaultPassword = false,
                    GenerateOtp = "TestValue1893565155",
                    OtpExpiration = DateTime.UtcNow,
                    IsActive = (short)9294,
                    EmployeeLoginName = "TestValue1614937727",
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 1978520264,
                        Name = "TestValue849901716",
                        PhoneNumber = "TestValue541844406",
                        DomainName = "TestValue1143227146",
                        Status = "TestValue1075934186",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue99907338",
                        IsActive = (short)23254,
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
                },
                LeaveType = new LeaveType
                {
                    Id = 2071798798,
                    Type = "TestValue1780430597",
                    Days = 1963111232,
                    CompanyId = 186692789,
                    Year = 530967170,
                    IsActive = (short)4690,
                    Company = new RequestedCompanyForm
                    {
                        Id = 1624000757,
                        Name = "TestValue1145226446",
                        PhoneNumber = "TestValue1226184893",
                        DomainName = "TestValue296044662",
                        Status = "TestValue1982344000",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue1934036359",
                        IsActive = (short)5703,
                        CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                        Departments = new Mock<ICollection<Department>>().Object,
                        EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                        Holidays = new Mock<ICollection<Holiday>>().Object,
                        LeaveTypes = new Mock<ICollection<LeaveType>>().Object,
                        Positions = new Mock<ICollection<Position>>().Object
                    },
                    EmployeeLeaveAllocations = new Mock<ICollection<EmployeeLeaveAllocation>>().Object,
                    LeaveTrackings = new Mock<ICollection<LeaveTracking>>().Object
                }
            });

            // Act
            var result = await _testClass.Update(id, leaveTracking);

            // Assert
            _leaveTracking.Verify(mock => mock.UpdateAsync(It.IsAny<LeaveTracking>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallUpdateLeaveAsync()
        {
            // Arrange
            var id = 1964774628;
            var newStatus = "TestValue1597412005";

            _leaveTracking.Setup(mock => mock.UpdateLeaveAsync(It.IsAny<int>(), It.IsAny<string>())).ReturnsAsync(new LeaveTracking
            {
                Id = 2090754392,
                EmpCredentialId = 1806626164,
                Startdate = DateTime.UtcNow,
                Enddate = DateTime.UtcNow,
                AppliedDate = DateTime.UtcNow,
                Status = "TestValue635325022",
                Files = "TestValue1019151595",
                LeaveTypeId = 1868606873,
                Session = "TestValue140773313",
                Contact = "TestValue1064240285",
                ReasonForLeave = "TestValue1764889248",
                IsActive = (short)24970,
                EmpCredential = new EmployeeCredential
                {
                    Id = 444517769,
                    UserName = "TestValue1855636126",
                    Password = "TestValue1132176154",
                    Status = (short)15730,
                    RequestedCompanyId = 1496778356,
                    Email = "TestValue556966829",
                    DefaultPassword = false,
                    GenerateOtp = "TestValue1841537361",
                    OtpExpiration = DateTime.UtcNow,
                    IsActive = (short)6354,
                    EmployeeLoginName = "TestValue921780993",
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 783652069,
                        Name = "TestValue1263333772",
                        PhoneNumber = "TestValue477702542",
                        DomainName = "TestValue1587817140",
                        Status = "TestValue2077876373",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue1433759921",
                        IsActive = (short)22198,
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
                },
                LeaveType = new LeaveType
                {
                    Id = 86390680,
                    Type = "TestValue1378820809",
                    Days = 1819993979,
                    CompanyId = 1059933203,
                    Year = 1151560184,
                    IsActive = (short)28319,
                    Company = new RequestedCompanyForm
                    {
                        Id = 1465945721,
                        Name = "TestValue1736422773",
                        PhoneNumber = "TestValue493987258",
                        DomainName = "TestValue157661324",
                        Status = "TestValue1163215442",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue190272608",
                        IsActive = (short)17748,
                        CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                        Departments = new Mock<ICollection<Department>>().Object,
                        EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                        Holidays = new Mock<ICollection<Holiday>>().Object,
                        LeaveTypes = new Mock<ICollection<LeaveType>>().Object,
                        Positions = new Mock<ICollection<Position>>().Object
                    },
                    EmployeeLeaveAllocations = new Mock<ICollection<EmployeeLeaveAllocation>>().Object,
                    LeaveTrackings = new Mock<ICollection<LeaveTracking>>().Object
                }
            });

            // Act
            var result = await _testClass.UpdateLeaveAsync(id, newStatus);

            // Assert
            _leaveTracking.Verify(mock => mock.UpdateLeaveAsync(It.IsAny<int>(), It.IsAny<string>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallDelete()
        {
            // Arrange
            var id = 189908844;

            _leaveTracking.Setup(mock => mock.DeleteAsync(It.IsAny<int>())).ReturnsAsync(false);

            // Act
            var result = await _testClass.Delete(id);

            // Assert
            _leaveTracking.Verify(mock => mock.DeleteAsync(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallGetLeavesByStatus()
        {
            // Arrange
            var status = "TestValue1980049593";

            _leaveTracking.Setup(mock => mock.GetLeavesByStatusAsync(It.IsAny<string>())).ReturnsAsync(new List<LeaveApprovalDTO>());

            // Act
            var result = await _testClass.GetLeavesByStatus(status);

            // Assert
            _leaveTracking.Verify(mock => mock.GetLeavesByStatusAsync(It.IsAny<string>()));

            throw new NotImplementedException("Create or modify test");
        }

       /* [Fact]
        public async Task CanCallGetLeaveSummary()
        {
            // Arrange
            _leaveTracking.Setup(mock => mock.GetEmployeeLeaveSummaryAsync(It.IsAny<int>())).ReturnsAsync(new LeaveSummaryDTO
            {
                TotalAllocatedLeaves = 1797928571,
                ApprovedLeaves = 342826574,
                PendingLeaves = 1903730648,
                RejectedLeaves = 610234087,
                RemainingLeaves = 1825906541,
                LeaveType = "TestValue71164122",
                ApprovedCount = 1380988633,
                PendingCount = 1280179793,
                RejectedCount = 887701773,
                LeaveSummaries = new List<LeaveSummaryDTO>()
            });

            // Act
            var result = await _testClass.GetLeaveSummary();

            // Assert
            _leaveTracking.Verify(mock => mock.GetEmployeeLeaveSummaryAsync(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }*/

        [Fact]
        public void CanCallSoftDelete()
        {
            // Arrange
            var id = 99150006;
            var isActive = (short)24612;

            _leaveTracking.Setup(mock => mock.SoftDelete(It.IsAny<int>(), It.IsAny<short>())).Returns(false);

            // Act
            var result = _testClass.SoftDelete(id, isActive);

            // Assert
            _leaveTracking.Verify(mock => mock.SoftDelete(It.IsAny<int>(), It.IsAny<short>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetPendingLeaves()
        {
            // Arrange
            _leaveTracking.Setup(mock => mock.GetPendingLeaves(It.IsAny<int>())).Returns(new List<LeavePendingDTO>());

            // Act
            var result = _testClass.GetPendingLeaves();

            // Assert
            _leaveTracking.Verify(mock => mock.GetPendingLeaves(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallHistoryleaves()
        {
            // Arrange
            _leaveTracking.Setup(mock => mock.GetHistoryLeaves(It.IsAny<int>())).Returns(new List<LeavePendingDTO>());

            // Act
            var result = _testClass.Historyleaves();

            // Assert
            _leaveTracking.Verify(mock => mock.GetHistoryLeaves(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallUpdateLeaveStatus()
        {
            // Arrange
            var id = 1911992529;
            var newStatus = "TestValue1035299413";

            _leaveTracking.Setup(mock => mock.UpdateLeaveAsyncchanges(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).ReturnsAsync(new LeaveTracking
            {
                Id = 218809024,
                EmpCredentialId = 704932296,
                Startdate = DateTime.UtcNow,
                Enddate = DateTime.UtcNow,
                AppliedDate = DateTime.UtcNow,
                Status = "TestValue1732875321",
                Files = "TestValue413786964",
                LeaveTypeId = 54382633,
                Session = "TestValue1832903123",
                Contact = "TestValue2092378916",
                ReasonForLeave = "TestValue576575651",
                IsActive = (short)21978,
                EmpCredential = new EmployeeCredential
                {
                    Id = 2147086478,
                    UserName = "TestValue1813714080",
                    Password = "TestValue1441981970",
                    Status = (short)15300,
                    RequestedCompanyId = 399305505,
                    Email = "TestValue1930626599",
                    DefaultPassword = true,
                    GenerateOtp = "TestValue1400758344",
                    OtpExpiration = DateTime.UtcNow,
                    IsActive = (short)16852,
                    EmployeeLoginName = "TestValue1333723711",
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 283139090,
                        Name = "TestValue287793698",
                        PhoneNumber = "TestValue1755251194",
                        DomainName = "TestValue279947802",
                        Status = "TestValue1090933347",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue1698572908",
                        IsActive = (short)24774,
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
                },
                LeaveType = new LeaveType
                {
                    Id = 1700397915,
                    Type = "TestValue1748829857",
                    Days = 1826428217,
                    CompanyId = 2018864038,
                    Year = 968331522,
                    IsActive = (short)3916,
                    Company = new RequestedCompanyForm
                    {
                        Id = 1637272767,
                        Name = "TestValue1028419055",
                        PhoneNumber = "TestValue2086335947",
                        DomainName = "TestValue458283146",
                        Status = "TestValue604880934",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue749390686",
                        IsActive = (short)29149,
                        CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                        Departments = new Mock<ICollection<Department>>().Object,
                        EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                        Holidays = new Mock<ICollection<Holiday>>().Object,
                        LeaveTypes = new Mock<ICollection<LeaveType>>().Object,
                        Positions = new Mock<ICollection<Position>>().Object
                    },
                    EmployeeLeaveAllocations = new Mock<ICollection<EmployeeLeaveAllocation>>().Object,
                    LeaveTrackings = new Mock<ICollection<LeaveTracking>>().Object
                }
            });

            // Act
            var result = await _testClass.UpdateLeaveStatus(id, newStatus);

            // Assert
            _leaveTracking.Verify(mock => mock.UpdateLeaveAsyncchanges(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));

            throw new NotImplementedException("Create or modify test");
        }
    }
}