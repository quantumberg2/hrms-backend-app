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

    public class EmployeeLeaveControllerTests
    {
        private EmployeeLeaveController _testClass;
        private Mock<IEmployeeLeave> _employeeLeave;
        private Mock<ILogger<EmployeeLeaveController>> _logger;

        public EmployeeLeaveControllerTests()
        {
            _employeeLeave = new Mock<IEmployeeLeave>();
            _logger = new Mock<ILogger<EmployeeLeaveController>>();
            _testClass = new EmployeeLeaveController(_employeeLeave.Object, _logger.Object);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new EmployeeLeaveController(_employeeLeave.Object, _logger.Object);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanCallGetAllEmpleaves()
        {
            // Arrange
            _employeeLeave.Setup(mock => mock.GetAllEmpLeave()).Returns(new List<EmployeeLeave>());

            // Act
            var result = _testClass.GetAllEmpleaves();

            // Assert
            _employeeLeave.Verify(mock => mock.GetAllEmpLeave());

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetById()
        {
            // Arrange
            var id = 1654449205;

            _employeeLeave.Setup(mock => mock.GetByEmpLeavebyId(It.IsAny<int>())).Returns(new EmployeeLeave
            {
                Id = 802189667,
                EmployeeCredentialId = 893242546,
                LeaveId = 903821702,
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow,
                Session = "TestValue304243944",
                TotalDays = 1314476117,
                Contact = "TestValue745230939",
                ReasonForLeave = "TestValue81439757",
                Files = "TestValue981504193",
                EmployeeCredential = new EmployeeCredential
                {
                    Id = 1186909795,
                    UserName = "TestValue957415238",
                    Password = "TestValue1388286863",
                    Status = (short)30905,
                    RequestedCompanyId = 1165431080,
                    Email = "TestValue1938810467",
                    DefaultPassword = true,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 1717010311,
                        Name = "TestValue658876097",
                        PhoneNumber = "TestValue1242536296",
                        DomainName = "TestValue1125910075",
                        Status = "TestValue980543353",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue500252331",
                        Department = new Department
                        {
                            Id = 635265607,
                            Name = "TestValue489967108",
                            RequestedCompanyId = 575418438,
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
                Leave = new LeaveType
                {
                    Id = 1831025191,
                    LeaveType1 = "TestValue1818664022",
                    Days = 1095634667,
                    CompanyId = 830127365,
                    EmployeecredentialId = 1116120312,
                    Company = new CompanyDetail
                    {
                        Id = 1483085900,
                        Name = "TestValue2127509393",
                        Address = "TestValue474962661",
                        Country = "TestValue2110595462",
                        States = "TestValue1968027256",
                        Industry = "TestValue1098534845",
                        TimeZone = "TestValue960848347",
                        Currency = "TestValue138585520",
                        PfNo = "TestValue2012628302",
                        TanNo = "TestValue136516439",
                        EsiNo = "TestValue1618944517",
                        PanNo = "TestValue618303170",
                        GstNo = "TestValue755760100",
                        RegistrationNo = "TestValue1593985136",
                        Twitter = "TestValue322921568",
                        Facebook = "TestValue1237794393",
                        LinkedIn = "TestValue782183180",
                        CompanyLogo = "TestValue839126255",
                        RequestedCompanyId = 910882455,
                        RequestedCompany = new RequestedCompanyForm
                        {
                            Id = 1276917731,
                            Name = "TestValue1246498126",
                            PhoneNumber = "TestValue1745447871",
                            DomainName = "TestValue150005693",
                            Status = "TestValue415675646",
                            InsertedDate = DateTime.UtcNow,
                            UpdatedDate = DateTime.UtcNow,
                            Email = "TestValue1543403551",
                            Department = new Department
                            {
                                Id = 361209451,
                                Name = "TestValue166924060",
                                RequestedCompanyId = 403275438,
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
                        Id = 328403263,
                        UserName = "TestValue620702400",
                        Password = "TestValue1643295742",
                        Status = (short)27420,
                        RequestedCompanyId = 1398796039,
                        Email = "TestValue2012867528",
                        DefaultPassword = false,
                        RequestedCompany = new RequestedCompanyForm
                        {
                            Id = 977389492,
                            Name = "TestValue913324202",
                            PhoneNumber = "TestValue2062366154",
                            DomainName = "TestValue1344887471",
                            Status = "TestValue840275622",
                            InsertedDate = DateTime.UtcNow,
                            UpdatedDate = DateTime.UtcNow,
                            Email = "TestValue1545121255",
                            Department = new Department
                            {
                                Id = 1578424791,
                                Name = "TestValue793731442",
                                RequestedCompanyId = 1106019857,
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
            _employeeLeave.Verify(mock => mock.GetByEmpLeavebyId(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallInsertEmpLeaves()
        {
            // Arrange
            var employeeLeave = new EmployeeLeave
            {
                Id = 1891975878,
                EmployeeCredentialId = 1188764118,
                LeaveId = 167045540,
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow,
                Session = "TestValue1485107692",
                TotalDays = 1048842011,
                Contact = "TestValue979537767",
                ReasonForLeave = "TestValue184752212",
                Files = "TestValue1700693281",
                EmployeeCredential = new EmployeeCredential
                {
                    Id = 2017105833,
                    UserName = "TestValue1885121676",
                    Password = "TestValue1977503700",
                    Status = (short)904,
                    RequestedCompanyId = 567191911,
                    Email = "TestValue1606817805",
                    DefaultPassword = true,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 557572909,
                        Name = "TestValue1957665903",
                        PhoneNumber = "TestValue1391925902",
                        DomainName = "TestValue640704344",
                        Status = "TestValue1969348245",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue1366990778",
                        Department = new Department
                        {
                            Id = 890376219,
                            Name = "TestValue1890161241",
                            RequestedCompanyId = 1493015723,
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
                Leave = new LeaveType
                {
                    Id = 324470191,
                    LeaveType1 = "TestValue867300673",
                    Days = 1641722431,
                    CompanyId = 70606833,
                    EmployeecredentialId = 1879280123,
                    Company = new CompanyDetail
                    {
                        Id = 1815556982,
                        Name = "TestValue951716429",
                        Address = "TestValue1191469483",
                        Country = "TestValue908710088",
                        States = "TestValue1181163368",
                        Industry = "TestValue616717220",
                        TimeZone = "TestValue1125643589",
                        Currency = "TestValue236229898",
                        PfNo = "TestValue990779219",
                        TanNo = "TestValue1719344036",
                        EsiNo = "TestValue663757975",
                        PanNo = "TestValue1612327707",
                        GstNo = "TestValue1845586405",
                        RegistrationNo = "TestValue2143245342",
                        Twitter = "TestValue2113669513",
                        Facebook = "TestValue1147369439",
                        LinkedIn = "TestValue854037187",
                        CompanyLogo = "TestValue1495174243",
                        RequestedCompanyId = 1885553313,
                        RequestedCompany = new RequestedCompanyForm
                        {
                            Id = 2056148484,
                            Name = "TestValue987548346",
                            PhoneNumber = "TestValue1768242535",
                            DomainName = "TestValue1549289187",
                            Status = "TestValue465315513",
                            InsertedDate = DateTime.UtcNow,
                            UpdatedDate = DateTime.UtcNow,
                            Email = "TestValue1832584607",
                            Department = new Department
                            {
                                Id = 1142733052,
                                Name = "TestValue1001599659",
                                RequestedCompanyId = 1446086524,
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
                        Id = 821513464,
                        UserName = "TestValue1160637501",
                        Password = "TestValue181541338",
                        Status = (short)22663,
                        RequestedCompanyId = 114145379,
                        Email = "TestValue1968896805",
                        DefaultPassword = true,
                        RequestedCompany = new RequestedCompanyForm
                        {
                            Id = 933405247,
                            Name = "TestValue786034217",
                            PhoneNumber = "TestValue1298060574",
                            DomainName = "TestValue1533512190",
                            Status = "TestValue990100585",
                            InsertedDate = DateTime.UtcNow,
                            UpdatedDate = DateTime.UtcNow,
                            Email = "TestValue1953450843",
                            Department = new Department
                            {
                                Id = 321343011,
                                Name = "TestValue966886684",
                                RequestedCompanyId = 1820065513,
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

            _employeeLeave.Setup(mock => mock.InsertEmployeeLeave(It.IsAny<EmployeeLeave>())).ReturnsAsync("TestValue362240183");

            // Act
            var result = await _testClass.InsertEmpLeaves(employeeLeave);

            // Assert
            _employeeLeave.Verify(mock => mock.InsertEmployeeLeave(It.IsAny<EmployeeLeave>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallDeleteEmpDetails()
        {
            // Arrange
            var id = 357020538;

            _employeeLeave.Setup(mock => mock.DeleteEmployeeLeave(It.IsAny<int>())).ReturnsAsync(false);

            // Act
            var result = await _testClass.DeleteEmpDetails(id);

            // Assert
            _employeeLeave.Verify(mock => mock.DeleteEmployeeLeave(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }
    }
}