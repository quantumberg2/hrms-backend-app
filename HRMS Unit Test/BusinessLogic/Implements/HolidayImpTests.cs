namespace HRMS_Unit_Test.BusinessLogic.Implements
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using HRMS_Application.Authorization;
    using HRMS_Application.BusinessLogic.Implements;
    using HRMS_Application.Models;
    using Microsoft.AspNetCore.Http;
    using Moq;
    using Xunit;

    public class HolidayImpTests
    {
        private readonly HolidayImp _testClass;
        private HRMSContext _context;
        private readonly Mock<IHttpContextAccessor> _httpContextAccessor;
        private readonly Mock<IJwtUtils> _jwtUtils;

        public HolidayImpTests()
        {
            _context = new HRMSContext();
            _httpContextAccessor = new Mock<IHttpContextAccessor>();
            _jwtUtils = new Mock<IJwtUtils>();
            _testClass = new HolidayImp(_context, _httpContextAccessor.Object, _jwtUtils.Object);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new HolidayImp(_context, _httpContextAccessor.Object, _jwtUtils.Object);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public async Task CanCalldeleteHoliday()
        {
            // Arrange
            var id = 809510154;

            _jwtUtils.Setup(mock => mock.ValidateJwtToken(It.IsAny<string>())).Returns(1885764628);

            // Act
            var result = await _testClass.deleteHoliday(id);

            // Assert
            _jwtUtils.Verify(mock => mock.ValidateJwtToken(It.IsAny<string>()));

            throw new NotImplementedException("Create or modify test");
        }

        /*  [Fact]
          public void CanCallGetHoliday()
          {
              // Act
              var result = _testClass.GetHoliday();

              // Assert
              throw new NotImplementedException("Create or modify test");
          }*/

        [Fact]
        public void CanCallGetHolidayById()
        {
            // Arrange
            var id = 1986397526;

            // Act
            var result = _testClass.GetHolidayById(id);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallInsertHoliday()
        {
            // Arrange
            var holiday = new Holiday
            {
                Id = 1465478278,
                Date = DateTime.UtcNow,
                Type = "TestValue980729764",
                CompanyId = 1782622757,
                Occasion = "TestValue1266887987",
                IsActive = (short)1055,
                Company = new RequestedCompanyForm
                {
                    Id = 62045596,
                    Name = "TestValue1991257234",
                    PhoneNumber = "TestValue688731213",
                    DomainName = "TestValue91036164",
                    Status = "TestValue156296462",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Email = "TestValue1028125245",
                    IsActive = (short)15830,
                    CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                    Departments = new Mock<ICollection<Department>>().Object,
                    EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                    Holidays = new Mock<ICollection<Holiday>>().Object,
                    LeaveTypes = new Mock<ICollection<LeaveType>>().Object,
                    Positions = new Mock<ICollection<Position>>().Object
                }
            };

            _jwtUtils.Setup(mock => mock.ValidateJwtToken(It.IsAny<string>())).Returns(488074802);

            // Act
            var result = await _testClass.InsertHoliday(holiday);

            // Assert
            _jwtUtils.Verify(mock => mock.ValidateJwtToken(It.IsAny<string>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallSoftDelete()
        {
            // Arrange
            var id = 414652977;
            var isActive = (short)11683;

            // Act
            var result = _testClass.SoftDelete(id, isActive);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetHoliday()
        {
            // Arrange
            var companyId = 1041395408;

            // Act
            var result = _testClass.GetHoliday(companyId);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallUpdateHolidayType()
        {
            // Arrange
            var id = 1739115864;
            var name = "TestValue1766734704";
            var date = new DateOnly?();
            var occasion = "TestValue1604113605";
            var requestedCompanyId = 6374819;

            // Act
            var result = _testClass.UpdateHolidayType(id, name, date, occasion, requestedCompanyId);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }
    }
}