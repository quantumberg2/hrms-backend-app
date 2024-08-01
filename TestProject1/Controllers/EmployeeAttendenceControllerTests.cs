namespace TestProject1.Controllers
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
            var id = 1528372134;

            _employeeAttendence.Setup(mock => mock.GetById(It.IsAny<int>())).Returns(new EmployeeAttendance
            {
                Id = 106590757,
                EmployeeCredentialId = 1681280270,
                LeaveId = 889119746,
                HolidayId = 764433416,
                TimeIn = DateTime.UtcNow,
                TimeOut = DateTime.UtcNow,
                Remarks = "TestValue540939988",
                EmployeeCredential = new EmployeeCredential
                {
                    Id = 1646391186,
                    UserName = "TestValue2009858518",
                    Password = "TestValue606908435",
                    Status = (short)29309,
                    RequestedCompanyId = 1711790123,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 1389028145,
                        Name = "TestValue1627858103",
                        PhoneNumber = "TestValue287070027",
                        DomainName = "TestValue1396228726",
                        Status = "TestValue898174859",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Department = new Department
                        {
                            Id = 384924638,
                            Name = "TestValue1596319755",
                            RequestedCompanyId = 262333200,
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
                Holiday = new Holiday
                {
                    Id = 1714825555,
                    Occasion = "TestValue1585219283",
                    Date = DateTime.UtcNow,
                    Day = "TestValue637419984",
                    RestrictedHoliday = true,
                    CompanyId = 593924465,
                    Company = new CompanyDetail
                    {
                        Id = 942413864,
                        Name = "TestValue2096358059",
                        Address = "TestValue1235918045",
                        Country = "TestValue1036013698",
                        States = "TestValue1423013791",
                        Industry = "TestValue1886038689",
                        TimeZone = "TestValue1546531403",
                        Currency = "TestValue1325562155",
                        PfNo = "TestValue802445585",
                        TanNo = "TestValue2013462933",
                        EsiNo = "TestValue2052481715",
                        PanNo = "TestValue803195623",
                        GstNo = "TestValue1708035788",
                        RegistrationNo = "TestValue1966243544",
                        Twitter = "TestValue958681139",
                        Facebook = "TestValue77516094",
                        LinkedIn = "TestValue1461072035",
                        CompanyLogo = "TestValue774698972",
                        RequestedCompanyId = 599633607,
                        RequestedCompany = new RequestedCompanyForm
                        {
                            Id = 1088782001,
                            Name = "TestValue1072149932",
                            PhoneNumber = "TestValue1691685023",
                            DomainName = "TestValue1501058167",
                            Status = "TestValue379016231",
                            InsertedDate = DateTime.UtcNow,
                            UpdatedDate = DateTime.UtcNow,
                            Department = new Department
                            {
                                Id = 1655125211,
                                Name = "TestValue861288329",
                                RequestedCompanyId = 993607699,
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
                    EmployeeAttendances = new Mock<ICollection<EmployeeAttendance>>().Object
                },
                Leave = new LeaveType
                {
                    Id = 1764795149,
                    LeaveType1 = "TestValue868094851",
                    Days = 349890197,
                    CompanyId = 353344194,
                    Company = new CompanyDetail
                    {
                        Id = 1140809794,
                        Name = "TestValue848427363",
                        Address = "TestValue1087355805",
                        Country = "TestValue2094189529",
                        States = "TestValue815559004",
                        Industry = "TestValue1452505590",
                        TimeZone = "TestValue610377488",
                        Currency = "TestValue586844727",
                        PfNo = "TestValue868353393",
                        TanNo = "TestValue374329252",
                        EsiNo = "TestValue386227968",
                        PanNo = "TestValue586582560",
                        GstNo = "TestValue1761878817",
                        RegistrationNo = "TestValue382071959",
                        Twitter = "TestValue593033103",
                        Facebook = "TestValue1337622718",
                        LinkedIn = "TestValue566164741",
                        CompanyLogo = "TestValue637638616",
                        RequestedCompanyId = 184817106,
                        RequestedCompany = new RequestedCompanyForm
                        {
                            Id = 253753520,
                            Name = "TestValue810520311",
                            PhoneNumber = "TestValue37786377",
                            DomainName = "TestValue316865040",
                            Status = "TestValue1669258180",
                            InsertedDate = DateTime.UtcNow,
                            UpdatedDate = DateTime.UtcNow,
                            Department = new Department
                            {
                                Id = 1398212488,
                                Name = "TestValue595299892",
                                RequestedCompanyId = 856901814,
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
                Id = 892430990,
                EmployeeCredentialId = 1929219901,
                LeaveId = 457467304,
                HolidayId = 452555388,
                TimeIn = DateTime.UtcNow,
                TimeOut = DateTime.UtcNow,
                Remarks = "TestValue1660118739",
                EmployeeCredential = new EmployeeCredential
                {
                    Id = 911671921,
                    UserName = "TestValue2102251907",
                    Password = "TestValue620679983",
                    Status = (short)30814,
                    RequestedCompanyId = 143122135,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 772494151,
                        Name = "TestValue850694547",
                        PhoneNumber = "TestValue187854245",
                        DomainName = "TestValue1878763861",
                        Status = "TestValue714452749",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Department = new Department
                        {
                            Id = 685921964,
                            Name = "TestValue1105102463",
                            RequestedCompanyId = 1886662997,
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
                Holiday = new Holiday
                {
                    Id = 2144427919,
                    Occasion = "TestValue1062092108",
                    Date = DateTime.UtcNow,
                    Day = "TestValue1671149258",
                    RestrictedHoliday = false,
                    CompanyId = 1127156533,
                    Company = new CompanyDetail
                    {
                        Id = 683277745,
                        Name = "TestValue96136677",
                        Address = "TestValue1690307530",
                        Country = "TestValue1103023417",
                        States = "TestValue531562323",
                        Industry = "TestValue1565581272",
                        TimeZone = "TestValue695977041",
                        Currency = "TestValue220259112",
                        PfNo = "TestValue595603776",
                        TanNo = "TestValue1229489001",
                        EsiNo = "TestValue25119265",
                        PanNo = "TestValue2123406050",
                        GstNo = "TestValue592592998",
                        RegistrationNo = "TestValue2076244311",
                        Twitter = "TestValue134027172",
                        Facebook = "TestValue101760078",
                        LinkedIn = "TestValue1617883685",
                        CompanyLogo = "TestValue638264843",
                        RequestedCompanyId = 716942735,
                        RequestedCompany = new RequestedCompanyForm
                        {
                            Id = 694110726,
                            Name = "TestValue494516481",
                            PhoneNumber = "TestValue1559806602",
                            DomainName = "TestValue1550542620",
                            Status = "TestValue622666066",
                            InsertedDate = DateTime.UtcNow,
                            UpdatedDate = DateTime.UtcNow,
                            Department = new Department
                            {
                                Id = 306506163,
                                Name = "TestValue1749895938",
                                RequestedCompanyId = 983336216,
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
                    EmployeeAttendances = new Mock<ICollection<EmployeeAttendance>>().Object
                },
                Leave = new LeaveType
                {
                    Id = 293110025,
                    LeaveType1 = "TestValue856120542",
                    Days = 859957542,
                    CompanyId = 466280026,
                    Company = new CompanyDetail
                    {
                        Id = 1038059851,
                        Name = "TestValue464988032",
                        Address = "TestValue802063368",
                        Country = "TestValue1921673206",
                        States = "TestValue356418711",
                        Industry = "TestValue2117294856",
                        TimeZone = "TestValue1956132151",
                        Currency = "TestValue1570689584",
                        PfNo = "TestValue1202582358",
                        TanNo = "TestValue1323560621",
                        EsiNo = "TestValue2070346670",
                        PanNo = "TestValue176890375",
                        GstNo = "TestValue1768689193",
                        RegistrationNo = "TestValue162734980",
                        Twitter = "TestValue1902841458",
                        Facebook = "TestValue121859751",
                        LinkedIn = "TestValue757161300",
                        CompanyLogo = "TestValue971075291",
                        RequestedCompanyId = 1784902919,
                        RequestedCompany = new RequestedCompanyForm
                        {
                            Id = 526544234,
                            Name = "TestValue423827265",
                            PhoneNumber = "TestValue954206523",
                            DomainName = "TestValue1880815879",
                            Status = "TestValue632640052",
                            InsertedDate = DateTime.UtcNow,
                            UpdatedDate = DateTime.UtcNow,
                            Department = new Department
                            {
                                Id = 1270954790,
                                Name = "TestValue693077704",
                                RequestedCompanyId = 1067641464,
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
                    EmployeeAttendances = new Mock<ICollection<EmployeeAttendance>>().Object,
                    EmployeeLeaves = new Mock<ICollection<EmployeeLeave>>().Object
                }
            };

            _employeeAttendence.Setup(mock => mock.InsertEmployeeAttendence(It.IsAny<EmployeeAttendance>())).ReturnsAsync("TestValue561725462");

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
            var id = 1616104255;
            var Timein = DateTime.UtcNow;
            var Timeout = DateTime.UtcNow;
            var Remark = "TestValue833684402";
            var empcredentialId = 791490829;

            _employeeAttendence.Setup(mock => mock.UpdateEmployeeAttendence(It.IsAny<int>(), It.IsAny<DateTime?>(), It.IsAny<DateTime?>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new EmployeeAttendance
            {
                Id = 796517254,
                EmployeeCredentialId = 929150032,
                LeaveId = 582245056,
                HolidayId = 402867016,
                TimeIn = DateTime.UtcNow,
                TimeOut = DateTime.UtcNow,
                Remarks = "TestValue1511622217",
                EmployeeCredential = new EmployeeCredential
                {
                    Id = 1883129881,
                    UserName = "TestValue763208975",
                    Password = "TestValue1134543061",
                    Status = (short)25304,
                    RequestedCompanyId = 1938013277,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 154571105,
                        Name = "TestValue1925092108",
                        PhoneNumber = "TestValue131948869",
                        DomainName = "TestValue1809235181",
                        Status = "TestValue1215058906",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Department = new Department
                        {
                            Id = 1661844024,
                            Name = "TestValue1518033752",
                            RequestedCompanyId = 571653458,
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
                Holiday = new Holiday
                {
                    Id = 1382916227,
                    Occasion = "TestValue1929337074",
                    Date = DateTime.UtcNow,
                    Day = "TestValue459931086",
                    RestrictedHoliday = false,
                    CompanyId = 1628036187,
                    Company = new CompanyDetail
                    {
                        Id = 226174916,
                        Name = "TestValue1469518381",
                        Address = "TestValue1218701270",
                        Country = "TestValue333413308",
                        States = "TestValue42452761",
                        Industry = "TestValue83853327",
                        TimeZone = "TestValue731655800",
                        Currency = "TestValue169423316",
                        PfNo = "TestValue650718416",
                        TanNo = "TestValue1810824654",
                        EsiNo = "TestValue1049653392",
                        PanNo = "TestValue1159614897",
                        GstNo = "TestValue641539552",
                        RegistrationNo = "TestValue620337302",
                        Twitter = "TestValue920693605",
                        Facebook = "TestValue558724453",
                        LinkedIn = "TestValue441244141",
                        CompanyLogo = "TestValue1005480218",
                        RequestedCompanyId = 1175675566,
                        RequestedCompany = new RequestedCompanyForm
                        {
                            Id = 244423440,
                            Name = "TestValue331330121",
                            PhoneNumber = "TestValue602590195",
                            DomainName = "TestValue1193466830",
                            Status = "TestValue1652954050",
                            InsertedDate = DateTime.UtcNow,
                            UpdatedDate = DateTime.UtcNow,
                            Department = new Department
                            {
                                Id = 864792700,
                                Name = "TestValue1356252006",
                                RequestedCompanyId = 1439846146,
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
                    EmployeeAttendances = new Mock<ICollection<EmployeeAttendance>>().Object
                },
                Leave = new LeaveType
                {
                    Id = 362782127,
                    LeaveType1 = "TestValue60986594",
                    Days = 2035522210,
                    CompanyId = 911224277,
                    Company = new CompanyDetail
                    {
                        Id = 607710378,
                        Name = "TestValue245368902",
                        Address = "TestValue1448597492",
                        Country = "TestValue356070140",
                        States = "TestValue1080832282",
                        Industry = "TestValue292920947",
                        TimeZone = "TestValue1549716573",
                        Currency = "TestValue720756214",
                        PfNo = "TestValue1050689733",
                        TanNo = "TestValue926762218",
                        EsiNo = "TestValue1768589961",
                        PanNo = "TestValue1651336336",
                        GstNo = "TestValue114267454",
                        RegistrationNo = "TestValue1229779124",
                        Twitter = "TestValue649620284",
                        Facebook = "TestValue573519354",
                        LinkedIn = "TestValue1041506722",
                        CompanyLogo = "TestValue597340147",
                        RequestedCompanyId = 12929005,
                        RequestedCompany = new RequestedCompanyForm
                        {
                            Id = 941672086,
                            Name = "TestValue923856856",
                            PhoneNumber = "TestValue1431739167",
                            DomainName = "TestValue306724912",
                            Status = "TestValue1296706066",
                            InsertedDate = DateTime.UtcNow,
                            UpdatedDate = DateTime.UtcNow,
                            Department = new Department
                            {
                                Id = 1771068368,
                                Name = "TestValue276051551",
                                RequestedCompanyId = 1713230867,
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
            var id = 108436722;

            _employeeAttendence.Setup(mock => mock.DeleteEmployeeAttendance(It.IsAny<int>())).ReturnsAsync(true);

            // Act
            var result = await _testClass.DeleteEmpAttendence(id);

            // Assert
            _employeeAttendence.Verify(mock => mock.DeleteEmployeeAttendance(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }
    }
}