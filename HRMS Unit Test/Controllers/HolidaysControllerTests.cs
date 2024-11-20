namespace HRMS_Unit_Test.Controllers
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
        private readonly HolidaysController _testClass;
        private readonly Mock<IHoliday> _holiday;
        private readonly Mock<ILogger<HolidaysController>> _logger;

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

        /*    [Fact]
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
    */
        [Fact]
        public void CanCallGetHoliday()
        {
            // Arrange
            var id = 695925759;

            _holiday.Setup(mock => mock.GetHolidayById(It.IsAny<int>())).Returns(new Holiday
            {
                Id = 1052273703,
                Date = DateTime.UtcNow,
                Type = "TestValue799608090",
                CompanyId = 2130709086,
                Occasion = "TestValue2140582698",
                IsActive = (short)31819,
                Company = new RequestedCompanyForm
                {
                    Id = 309680794,
                    Name = "TestValue399337307",
                    PhoneNumber = "TestValue1796246838",
                    DomainName = "TestValue477329242",
                    Status = "TestValue1393243648",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Email = "TestValue412475971",
                    IsActive = (short)31384,
                    CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                    Departments = new Mock<ICollection<Department>>().Object,
                    EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                    Holidays = new Mock<ICollection<Holiday>>().Object,
                    LeaveTypes = new Mock<ICollection<LeaveType>>().Object,
                    Positions = new Mock<ICollection<Position>>().Object
                }
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
                Id = 1777208677,
                Date = DateTime.UtcNow,
                Type = "TestValue619503339",
                CompanyId = 1296059576,
                Occasion = "TestValue879996252",
                IsActive = (short)27182,
                Company = new RequestedCompanyForm
                {
                    Id = 737935909,
                    Name = "TestValue60476195",
                    PhoneNumber = "TestValue882720936",
                    DomainName = "TestValue1461331972",
                    Status = "TestValue220895790",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Email = "TestValue288186858",
                    IsActive = (short)12574,
                    CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                    Departments = new Mock<ICollection<Department>>().Object,
                    EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                    Holidays = new Mock<ICollection<Holiday>>().Object,
                    LeaveTypes = new Mock<ICollection<LeaveType>>().Object,
                    Positions = new Mock<ICollection<Position>>().Object
                }
            };

            _holiday.Setup(mock => mock.InsertHoliday(It.IsAny<Holiday>())).ReturnsAsync("TestValue934539945");

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
            var id = 1938278911;

            _holiday.Setup(mock => mock.deleteHoliday(It.IsAny<int>())).ReturnsAsync(true);

            // Act
            var result = await _testClass.DeletecompanyDetails(id);

            // Assert
            _holiday.Verify(mock => mock.deleteHoliday(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallSoftDelete()
        {
            // Arrange
            var id = 2063514903;
            var isActive = (short)4288;

            _holiday.Setup(mock => mock.SoftDelete(It.IsAny<int>(), It.IsAny<short>())).Returns(false);

            // Act
            var result = _testClass.SoftDelete(id, isActive);

            // Assert
            _holiday.Verify(mock => mock.SoftDelete(It.IsAny<int>(), It.IsAny<short>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetAllHolidayDetails()
        {
            // Arrange
            _holiday.Setup(mock => mock.GetHoliday(It.IsAny<int>())).Returns(new List<Holiday>());

            // Act
            var result = _testClass.GetAllHolidayDetails();

            // Assert
            _holiday.Verify(mock => mock.GetHoliday(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallUpdateHolidayType()
        {
            // Arrange
            var id = 107262890;
            var name = "TestValue56429015";
            var date = new DateOnly?();
            var Occation = "TestValue362824472";
            var requestedCompanyId = 1983897448;

            _holiday.Setup(mock => mock.UpdateHolidayType(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<DateOnly?>(), It.IsAny<string>(), It.IsAny<int?>())).Returns(new Holiday
            {
                Id = 937584925,
                Date = DateTime.UtcNow,
                Type = "TestValue1285903314",
                CompanyId = 1503590924,
                Occasion = "TestValue399922959",
                IsActive = (short)22724,
                Company = new RequestedCompanyForm
                {
                    Id = 1254102387,
                    Name = "TestValue1035260877",
                    PhoneNumber = "TestValue87460570",
                    DomainName = "TestValue1454244157",
                    Status = "TestValue2074182313",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Email = "TestValue1349244204",
                    IsActive = (short)15802,
                    CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                    Departments = new Mock<ICollection<Department>>().Object,
                    EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                    Holidays = new Mock<ICollection<Holiday>>().Object,
                    LeaveTypes = new Mock<ICollection<LeaveType>>().Object,
                    Positions = new Mock<ICollection<Position>>().Object
                }
            });

            // Act
            var result = _testClass.UpdateHolidayType(id, name, date, Occation, requestedCompanyId);

            // Assert
            _holiday.Verify(mock => mock.UpdateHolidayType(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<DateOnly?>(), It.IsAny<string>(), It.IsAny<int?>()));

            throw new NotImplementedException("Create or modify test");
        }
    }
}