namespace HRMSunitTestCase.BusinessLogic.Implements
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
            var id = 467313867;

            _jwtUtils.Setup(mock => mock.ValidateJwtToken(It.IsAny<string>())).Returns(2093702627);

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
            var id = 1733953354;

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
                Id = 2003829558,
                Occasion = "TestValue431866536",
                Date = DateTime.UtcNow,
                Day = "TestValue346627575",
                RestrictedHoliday = true,
                CompanyId = 1401421079,
                EmployeecredentialId = 1410855674,
                Company = new CompanyDetail
                {
                    Id = 904098585,
                    Name = "TestValue933865542",
                    Address = "TestValue126464887",
                    Country = "TestValue1776046483",
                    States = "TestValue1381957215",
                    Industry = "TestValue289611922",
                    TimeZone = "TestValue321806220",
                    Currency = "TestValue1954808354",
                    PfNo = "TestValue1616820219",
                    TanNo = "TestValue1933453518",
                    EsiNo = "TestValue65559729",
                    PanNo = "TestValue1052730641",
                    GstNo = "TestValue1584770187",
                    RegistrationNo = "TestValue2044292585",
                    Twitter = "TestValue821330654",
                    Facebook = "TestValue46143814",
                    LinkedIn = "TestValue1650563553",
                    CompanyLogo = "TestValue198592133",
                    RequestedCompanyId = 1377780545,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 923596188,
                        Name = "TestValue232277757",
                        PhoneNumber = "TestValue1270631828",
                        DomainName = "TestValue984032022",
                        Status = "TestValue2028831081",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue1011372419",
                        Department = new Department
                        {
                            Id = 853117216,
                            Name = "TestValue157806167",
                            RequestedCompanyId = 814146387,
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
                    Id = 948106705,
                    UserName = "TestValue1459366203",
                    Password = "TestValue1930143516",
                    Status = (short)23317,
                    RequestedCompanyId = 1321246543,
                    Email = "TestValue1236026300",
                    DefaultPassword = true,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 228763328,
                        Name = "TestValue902725222",
                        PhoneNumber = "TestValue2073851081",
                        DomainName = "TestValue1964056174",
                        Status = "TestValue684194177",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue359532072",
                        Department = new Department
                        {
                            Id = 86162409,
                            Name = "TestValue1757098964",
                            RequestedCompanyId = 378068339,
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

            _jwtUtils.Setup(mock => mock.ValidateJwtToken(It.IsAny<string>())).Returns(160397478);

            // Act
            var result = await _testClass.InsertHoliday(holiday);

            // Assert
            _jwtUtils.Verify(mock => mock.ValidateJwtToken(It.IsAny<string>()));

            throw new NotImplementedException("Create or modify test");
        }
    }
}