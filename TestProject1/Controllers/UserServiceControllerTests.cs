namespace TestProject1.Controllers
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
                Username = "TestValue140090420",
                Password = "TestValue223705373"
            };

            _userService.Setup(mock => mock.Authenticate(It.IsAny<AuthenticateRequest>())).Returns(new AuthenticateResponse(new UserDto
            {
                UserName = "TestValue860498135",
                UserId = 1465365985,
                Roles = new List<string>()
            }, "TestValue255232328", new List<string>()));

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
                    Id = 506982311,
                    UserName = "TestValue906636824",
                    Password = "TestValue660135663",
                    Status = (short)10477,
                    RequestedCompanyId = 650806407,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 1136324809,
                        Name = "TestValue1159464287",
                        PhoneNumber = "TestValue1923333264",
                        DomainName = "TestValue1960379642",
                        Status = "TestValue1217292513",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Department = new Department
                        {
                            Id = 179097420,
                            Name = "TestValue577248459",
                            RequestedCompanyId = 668103732,
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
                new EmployeeCredential
                {
                    Id = 1045061665,
                    UserName = "TestValue1012580623",
                    Password = "TestValue1935296016",
                    Status = (short)31677,
                    RequestedCompanyId = 789878892,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 216896785,
                        Name = "TestValue678082135",
                        PhoneNumber = "TestValue1012251023",
                        DomainName = "TestValue1773595187",
                        Status = "TestValue587102191",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Department = new Department
                        {
                            Id = 2062857668,
                            Name = "TestValue624264195",
                            RequestedCompanyId = 881749342,
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
                new EmployeeCredential
                {
                    Id = 1501759555,
                    UserName = "TestValue1374122180",
                    Password = "TestValue2012271933",
                    Status = (short)29929,
                    RequestedCompanyId = 177133605,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 140399145,
                        Name = "TestValue768298448",
                        PhoneNumber = "TestValue1282449044",
                        DomainName = "TestValue2059301796",
                        Status = "TestValue706467281",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Department = new Department
                        {
                            Id = 801951646,
                            Name = "TestValue254067961",
                            RequestedCompanyId = 939527869,
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
            var id = 38335543;

            _userService.Setup(mock => mock.GetById(It.IsAny<int>())).Returns(new EmployeeCredential
            {
                Id = 411539870,
                UserName = "TestValue1373430053",
                Password = "TestValue802474718",
                Status = (short)29188,
                RequestedCompanyId = 51961957,
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 1413006208,
                    Name = "TestValue1433904472",
                    PhoneNumber = "TestValue597732603",
                    DomainName = "TestValue1380672910",
                    Status = "TestValue478787283",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Department = new Department
                    {
                        Id = 1292774877,
                        Name = "TestValue931926988",
                        RequestedCompanyId = 675487093,
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
            });

            // Act
            var result = _testClass.GetById(id);

            // Assert
            _userService.Verify(mock => mock.GetById(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }
    }
}