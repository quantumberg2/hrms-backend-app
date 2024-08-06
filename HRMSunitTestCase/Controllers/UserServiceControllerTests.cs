namespace HRMSunitTestCase.Controllers
{
    using System;
    using System.Collections.Generic;
    using HRMS_Application.BusinessLogics.Implements;
    using HRMS_Application.Controllers;
    using HRMS_Application.DTOs;
    using HRMS_Application.Models;
    using HRMS_Application.Models.Users;
    using Microsoft.Extensions.Logging;
    using Moq;
    using Xunit;

    public class UserServiceControllerTests
    {
        private UserServiceController _testClass;
        private Mock<IUserService> _userService;
        private Mock<ILogger<UserServiceController>> _logger;

        public UserServiceControllerTests()
        {
            _userService = new Mock<IUserService>();
            _logger = new Mock<ILogger<UserServiceController>>();
            _testClass = new UserServiceController(_userService.Object, _logger.Object);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new UserServiceController(_userService.Object, _logger.Object);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanCallAuthenticate()
        {
            // Arrange
            var model = new AuthenticateRequest
            {
                Username = "TestValue2103899440",
                Password = "TestValue1055271608"
            };

            _userService.Setup(mock => mock.Authenticate(It.IsAny<AuthenticateRequest>())).Returns(new AuthenticateResponse(new UserDto
            {
                UserName = "TestValue1333238469",
                UserId = 595754749,
                Roles = new List<string>()
            }, "TestValue1233546620", new List<string>()));

            // Act
            var result = _testClass.Authenticate(model);

            // Assert
            _userService.Verify(mock => mock.Authenticate(It.IsAny<AuthenticateRequest>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetAll()
        {
            // Arrange
            _userService.Setup(mock => mock.GetAll()).Returns(new[] {
                new EmployeeCredential
                {
                    Id = 433601787,
                    UserName = "TestValue2080189826",
                    Password = "TestValue2048715509",
                    Status = (short)8597,
                    RequestedCompanyId = 1907195243,
                    Email = "TestValue710772751",
                    DefaultPassword = true,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 1375239442,
                        Name = "TestValue1850588244",
                        PhoneNumber = "TestValue386758248",
                        DomainName = "TestValue1328538378",
                        Status = "TestValue1870678956",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue1944554845",
                        Department = new Department
                        {
                            Id = 1011019636,
                            Name = "TestValue1509847065",
                            RequestedCompanyId = 37237186,
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
                new EmployeeCredential
                {
                    Id = 1117090509,
                    UserName = "TestValue1490337496",
                    Password = "TestValue804842770",
                    Status = (short)22264,
                    RequestedCompanyId = 1287401521,
                    Email = "TestValue1291632030",
                    DefaultPassword = false,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 1994433251,
                        Name = "TestValue1470121026",
                        PhoneNumber = "TestValue577044977",
                        DomainName = "TestValue1141122645",
                        Status = "TestValue1623864487",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue2075669273",
                        Department = new Department
                        {
                            Id = 1343743423,
                            Name = "TestValue1900869300",
                            RequestedCompanyId = 2028796083,
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
                new EmployeeCredential
                {
                    Id = 1600211764,
                    UserName = "TestValue927703742",
                    Password = "TestValue1754781232",
                    Status = (short)22419,
                    RequestedCompanyId = 999130975,
                    Email = "TestValue338191563",
                    DefaultPassword = false,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 140223516,
                        Name = "TestValue208300452",
                        PhoneNumber = "TestValue208152743",
                        DomainName = "TestValue927102362",
                        Status = "TestValue2052684954",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue957747381",
                        Department = new Department
                        {
                            Id = 1860667301,
                            Name = "TestValue1575558227",
                            RequestedCompanyId = 1414152294,
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
                }
            });

            // Act
            var result = _testClass.GetAll();

            // Assert
            _userService.Verify(mock => mock.GetAll());

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetById()
        {
            // Arrange
            var id = 633372595;

            _userService.Setup(mock => mock.GetById(It.IsAny<int>())).Returns(new EmployeeCredential
            {
                Id = 359061072,
                UserName = "TestValue1442101479",
                Password = "TestValue216147960",
                Status = (short)19117,
                RequestedCompanyId = 428703850,
                Email = "TestValue644744267",
                DefaultPassword = false,
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 1289453404,
                    Name = "TestValue832976128",
                    PhoneNumber = "TestValue54282258",
                    DomainName = "TestValue1240793301",
                    Status = "TestValue1330150266",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Email = "TestValue1717133753",
                    Department = new Department
                    {
                        Id = 749269947,
                        Name = "TestValue1447053816",
                        RequestedCompanyId = 506844821,
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
            });

            // Act
            var result = _testClass.GetById(id);

            // Assert
            _userService.Verify(mock => mock.GetById(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }
    }
}