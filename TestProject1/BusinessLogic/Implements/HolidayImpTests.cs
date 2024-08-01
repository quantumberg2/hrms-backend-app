namespace TestProject1.BusinessLogic.Implements
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
        private HolidayImp _testClass;
        private HRMSContext _context;
        private Mock<IHttpContextAccessor> _httpContextAccessor;
        private Mock<IJwtUtils> _jwtUtils;

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
            var id = 1521369910;

            _jwtUtils.Setup(mock => mock.ValidateJwtToken(It.IsAny<string>())).Returns(1876224979);

            // Act
            var result = await _testClass.deleteHoliday(id);

            // Assert
            _jwtUtils.Verify(mock => mock.ValidateJwtToken(It.IsAny<string>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetHoliday()
        {
            // Act
            var result = _testClass.GetHoliday();

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetHolidayById()
        {
            // Arrange
            var id = 672049738;

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
                Id = 1058357044,
                Occasion = "TestValue1255603798",
                Date = DateTime.UtcNow,
                Day = "TestValue1278552591",
                RestrictedHoliday = true,
                CompanyId = 750794651,
                Company = new CompanyDetail
                {
                    Id = 2140756200,
                    Name = "TestValue1839936445",
                    Address = "TestValue1476772041",
                    Country = "TestValue649296366",
                    States = "TestValue126557780",
                    Industry = "TestValue1823971096",
                    TimeZone = "TestValue1289691541",
                    Currency = "TestValue840924834",
                    PfNo = "TestValue610266353",
                    TanNo = "TestValue1551049424",
                    EsiNo = "TestValue1488061304",
                    PanNo = "TestValue286693734",
                    GstNo = "TestValue90246938",
                    RegistrationNo = "TestValue184237182",
                    Twitter = "TestValue642289447",
                    Facebook = "TestValue1105043571",
                    LinkedIn = "TestValue1082791235",
                    CompanyLogo = "TestValue1988098350",
                    RequestedCompanyId = 2045913707,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 1882490165,
                        Name = "TestValue1479788632",
                        PhoneNumber = "TestValue1497379854",
                        DomainName = "TestValue280239427",
                        Status = "TestValue1621198229",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Department = new Department
                        {
                            Id = 1804522639,
                            Name = "TestValue1959422315",
                            RequestedCompanyId = 644150330,
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

            _jwtUtils.Setup(mock => mock.ValidateJwtToken(It.IsAny<string>())).Returns(427545239);

            // Act
            var result = await _testClass.InsertHoliday(holiday);

            // Assert
            _jwtUtils.Verify(mock => mock.ValidateJwtToken(It.IsAny<string>()));

            throw new NotImplementedException("Create or modify test");
        }
    }
}