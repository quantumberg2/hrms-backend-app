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
            var id = 1262034741;

            _holiday.Setup(mock => mock.GetHolidayById(It.IsAny<int>())).Returns(new Holiday
            {
                Id = 961971930,
                Occasion = "TestValue2028702171",
                Date = DateTime.UtcNow,
                Day = "TestValue649519812",
                RestrictedHoliday = true,
                CompanyId = 78369641,
                Company = new CompanyDetail
                {
                    Id = 35202936,
                    Name = "TestValue70174203",
                    Address = "TestValue1513411793",
                    Country = "TestValue126902158",
                    States = "TestValue12451048",
                    Industry = "TestValue290932139",
                    TimeZone = "TestValue559386915",
                    Currency = "TestValue1282820356",
                    PfNo = "TestValue1691735467",
                    TanNo = "TestValue969499600",
                    EsiNo = "TestValue1976585703",
                    PanNo = "TestValue1885569606",
                    GstNo = "TestValue702021932",
                    RegistrationNo = "TestValue1249881672",
                    Twitter = "TestValue1221764950",
                    Facebook = "TestValue1095461671",
                    LinkedIn = "TestValue2050452187",
                    CompanyLogo = "TestValue397611998",
                    RequestedCompanyId = 591219740,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 1255272482,
                        Name = "TestValue69671097",
                        PhoneNumber = "TestValue1498246849",
                        DomainName = "TestValue19736599",
                        Status = "TestValue1050760591",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Department = new Department
                        {
                            Id = 1553090159,
                            Name = "TestValue35700863",
                            RequestedCompanyId = 1860184905,
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
                Id = 1686682771,
                Occasion = "TestValue831594760",
                Date = DateTime.UtcNow,
                Day = "TestValue284116846",
                RestrictedHoliday = false,
                CompanyId = 369012659,
                Company = new CompanyDetail
                {
                    Id = 642317948,
                    Name = "TestValue1871050986",
                    Address = "TestValue530469534",
                    Country = "TestValue563838958",
                    States = "TestValue1487663506",
                    Industry = "TestValue1393933376",
                    TimeZone = "TestValue331267385",
                    Currency = "TestValue1066690340",
                    PfNo = "TestValue1285697470",
                    TanNo = "TestValue1650262102",
                    EsiNo = "TestValue10106369",
                    PanNo = "TestValue618923310",
                    GstNo = "TestValue197048946",
                    RegistrationNo = "TestValue1101611391",
                    Twitter = "TestValue1483748562",
                    Facebook = "TestValue415639215",
                    LinkedIn = "TestValue1059003390",
                    CompanyLogo = "TestValue1631090173",
                    RequestedCompanyId = 58300071,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 655658173,
                        Name = "TestValue8698544",
                        PhoneNumber = "TestValue684439734",
                        DomainName = "TestValue50437604",
                        Status = "TestValue462651202",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Department = new Department
                        {
                            Id = 721295646,
                            Name = "TestValue2124233832",
                            RequestedCompanyId = 578230881,
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
            };

            _holiday.Setup(mock => mock.InsertHoliday(It.IsAny<Holiday>())).ReturnsAsync("TestValue1921312792");

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
            var id = 1508991211;

            _holiday.Setup(mock => mock.deleteHoliday(It.IsAny<int>())).ReturnsAsync(true);

            // Act
            var result = await _testClass.DeletecompanyDetails(id);

            // Assert
            _holiday.Verify(mock => mock.deleteHoliday(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }
    }
}