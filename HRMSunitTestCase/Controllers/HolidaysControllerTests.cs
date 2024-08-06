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

    public class HolidaysControllerTests
    {
        private HolidaysController _testClass;
        private Mock<IHoliday> _holiday;
        private Mock<ILogger<HolidaysController>> _logger;

        public HolidaysControllerTests()
        {
            _holiday = new Mock<IHoliday>();
            _logger = new Mock<ILogger<HolidaysController>>();
            _testClass = new HolidaysController(_holiday.Object, _logger.Object);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new HolidaysController(_holiday.Object, _logger.Object);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanCallGetAllHolidayDetails()
        {
            // Arrange
            _holiday.Setup(mock => mock.GetHoliday()).Returns(new List<Holiday>());

            // Act
            var result = _testClass.GetAllHolidayDetails();

            // Assert
            _holiday.Verify(mock => mock.GetHoliday());

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetHoliday()
        {
            // Arrange
            var id = 1342233018;

            _holiday.Setup(mock => mock.GetHolidayById(It.IsAny<int>())).Returns(new Holiday
            {
                Id = 1631531728,
                Occasion = "TestValue1421676009",
                Date = DateTime.UtcNow,
                Day = "TestValue1047603540",
                RestrictedHoliday = true,
                CompanyId = 1365301627,
                EmployeecredentialId = 737401986,
                Company = new CompanyDetail
                {
                    Id = 1373000540,
                    Name = "TestValue190167689",
                    Address = "TestValue224437766",
                    Country = "TestValue178308010",
                    States = "TestValue2102290289",
                    Industry = "TestValue749820568",
                    TimeZone = "TestValue581236961",
                    Currency = "TestValue1155429377",
                    PfNo = "TestValue1350980180",
                    TanNo = "TestValue1277812444",
                    EsiNo = "TestValue1260316962",
                    PanNo = "TestValue1686627580",
                    GstNo = "TestValue75633550",
                    RegistrationNo = "TestValue526662602",
                    Twitter = "TestValue766060924",
                    Facebook = "TestValue333156875",
                    LinkedIn = "TestValue2059695895",
                    CompanyLogo = "TestValue417387194",
                    RequestedCompanyId = 1751514967,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 807905109,
                        Name = "TestValue1547587037",
                        PhoneNumber = "TestValue1933560399",
                        DomainName = "TestValue1463823174",
                        Status = "TestValue1021854573",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue1790167098",
                        Department = new Department
                        {
                            Id = 1843017734,
                            Name = "TestValue1857162378",
                            RequestedCompanyId = 1699741829,
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
                    Id = 454947390,
                    UserName = "TestValue1205167192",
                    Password = "TestValue254998887",
                    Status = (short)24962,
                    RequestedCompanyId = 583284773,
                    Email = "TestValue1417404956",
                    DefaultPassword = true,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 772602745,
                        Name = "TestValue1816131715",
                        PhoneNumber = "TestValue457382801",
                        DomainName = "TestValue1054092658",
                        Status = "TestValue381603137",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue1259890548",
                        Department = new Department
                        {
                            Id = 823513109,
                            Name = "TestValue1605203498",
                            RequestedCompanyId = 65004438,
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
            });

            // Act
            var result = _testClass.GetHoliday(id);

            // Assert
            _holiday.Verify(mock => mock.GetHolidayById(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallInsertcompanyDetails()
        {
            // Arrange
            var holiday = new Holiday
            {
                Id = 1881852280,
                Occasion = "TestValue2006511947",
                Date = DateTime.UtcNow,
                Day = "TestValue560867173",
                RestrictedHoliday = true,
                CompanyId = 1509463761,
                EmployeecredentialId = 630216346,
                Company = new CompanyDetail
                {
                    Id = 591010245,
                    Name = "TestValue557396518",
                    Address = "TestValue1337298596",
                    Country = "TestValue1586923788",
                    States = "TestValue873828162",
                    Industry = "TestValue1350066840",
                    TimeZone = "TestValue535624559",
                    Currency = "TestValue259272555",
                    PfNo = "TestValue1040141837",
                    TanNo = "TestValue1028978779",
                    EsiNo = "TestValue700481987",
                    PanNo = "TestValue145812988",
                    GstNo = "TestValue1022813557",
                    RegistrationNo = "TestValue1771791291",
                    Twitter = "TestValue1103342807",
                    Facebook = "TestValue805712241",
                    LinkedIn = "TestValue1960378060",
                    CompanyLogo = "TestValue2140941826",
                    RequestedCompanyId = 664508807,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 1602313094,
                        Name = "TestValue1510778183",
                        PhoneNumber = "TestValue1369911830",
                        DomainName = "TestValue1695498208",
                        Status = "TestValue724073928",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue328356901",
                        Department = new Department
                        {
                            Id = 1398818736,
                            Name = "TestValue1827105202",
                            RequestedCompanyId = 2096111536,
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
                    Id = 2108649101,
                    UserName = "TestValue1998134078",
                    Password = "TestValue1138874656",
                    Status = (short)19897,
                    RequestedCompanyId = 1843187078,
                    Email = "TestValue1772266188",
                    DefaultPassword = true,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 25888255,
                        Name = "TestValue80106360",
                        PhoneNumber = "TestValue1274328048",
                        DomainName = "TestValue2046258230",
                        Status = "TestValue466064875",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue2069241889",
                        Department = new Department
                        {
                            Id = 794820103,
                            Name = "TestValue1488944947",
                            RequestedCompanyId = 230911769,
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

            _holiday.Setup(mock => mock.InsertHoliday(It.IsAny<Holiday>())).ReturnsAsync("TestValue1841539209");

            // Act
            var result = await _testClass.InsertcompanyDetails(holiday);

            // Assert
            _holiday.Verify(mock => mock.InsertHoliday(It.IsAny<Holiday>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallDeletecompanyDetails()
        {
            // Arrange
            var id = 1459390510;

            _holiday.Setup(mock => mock.deleteHoliday(It.IsAny<int>())).ReturnsAsync(false);

            // Act
            var result = await _testClass.DeletecompanyDetails(id);

            // Assert
            _holiday.Verify(mock => mock.deleteHoliday(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }
    }
}