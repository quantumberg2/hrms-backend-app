namespace HRMS_Unit_Test.Controllers
{
    using System;
    using System.Collections.Generic;
    using HRMS_Application.BusinessLogics.Implements;
    using HRMS_Application.Controllers;
    using HRMS_Application.DTO;
    using HRMS_Application.Models;
    using HRMS_Application.Models.Users;
    using Microsoft.Extensions.Logging;
    using Moq;
    using Xunit;

    public class UserServiceControllerTests
    {
        private readonly UserServiceController _testClass;
        private readonly Mock<IUserService> _userService;
        private readonly Mock<ILogger<UserServiceController>> _logger;

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
                Username = "TestValue1557752249",
                Password = "TestValue352806491"
            };

            _userService.Setup(mock => mock.Authenticate(It.IsAny<AuthenticateRequest>())).Returns(new AuthenticateResponse(new List<int>()));

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
                    Id = 898248066,
                    UserName = "TestValue1093164700",
                    Password = "TestValue451670583",
                    Status = (short)10048,
                    RequestedCompanyId = 1737248941,
                    Email = "TestValue1518929478",
                    DefaultPassword = true,
                    GenerateOtp = "TestValue95568287",
                    OtpExpiration = DateTime.UtcNow,
                    IsActive = (short)982,
                    EmployeeLoginName = "TestValue362457879",
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 1894469132,
                        Name = "TestValue1766382015",
                        PhoneNumber = "TestValue641238623",
                        DomainName = "TestValue1130506550",
                        Status = "TestValue1409900107",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue410838639",
                        IsActive = (short)30867,
                        CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                        Departments = new Mock<ICollection<Department>>().Object,
                        EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                        Holidays = new Mock<ICollection<Holiday>>().Object,
                        LeaveTypes = new Mock<ICollection<LeaveType>>().Object,
                        Positions = new Mock<ICollection<Position>>().Object
                    },
                    AccountDetails = new Mock<ICollection<AccountDetail>>().Object,
                    AddressInfos = new Mock<ICollection<AddressInfo>>().Object,
                    Attendances = new Mock<ICollection<Attendance>>().Object,
                    DeviceTables = new Mock<ICollection<DeviceTable>>().Object,
                    EmpPersonalInfos = new Mock<ICollection<EmpPersonalInfo>>().Object,
                    EmpSalaries = new Mock<ICollection<EmpSalary>>().Object,
                    EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object,
                    EmployeeLeaveAllocations = new Mock<ICollection<EmployeeLeaveAllocation>>().Object,
                    LeaveTrackings = new Mock<ICollection<LeaveTracking>>().Object,
                    UserRolesJs = new Mock<ICollection<UserRolesJ>>().Object
                },
                new EmployeeCredential
                {
                    Id = 1877134348,
                    UserName = "TestValue1813324006",
                    Password = "TestValue1054883556",
                    Status = (short)20254,
                    RequestedCompanyId = 225218813,
                    Email = "TestValue1875255385",
                    DefaultPassword = false,
                    GenerateOtp = "TestValue1473915447",
                    OtpExpiration = DateTime.UtcNow,
                    IsActive = (short)30550,
                    EmployeeLoginName = "TestValue1147367676",
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 527687915,
                        Name = "TestValue799408381",
                        PhoneNumber = "TestValue2074572192",
                        DomainName = "TestValue1613926351",
                        Status = "TestValue1496860751",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue901776989",
                        IsActive = (short)27449,
                        CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                        Departments = new Mock<ICollection<Department>>().Object,
                        EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                        Holidays = new Mock<ICollection<Holiday>>().Object,
                        LeaveTypes = new Mock<ICollection<LeaveType>>().Object,
                        Positions = new Mock<ICollection<Position>>().Object
                    },
                    AccountDetails = new Mock<ICollection<AccountDetail>>().Object,
                    AddressInfos = new Mock<ICollection<AddressInfo>>().Object,
                    Attendances = new Mock<ICollection<Attendance>>().Object,
                    DeviceTables = new Mock<ICollection<DeviceTable>>().Object,
                    EmpPersonalInfos = new Mock<ICollection<EmpPersonalInfo>>().Object,
                    EmpSalaries = new Mock<ICollection<EmpSalary>>().Object,
                    EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object,
                    EmployeeLeaveAllocations = new Mock<ICollection<EmployeeLeaveAllocation>>().Object,
                    LeaveTrackings = new Mock<ICollection<LeaveTracking>>().Object,
                    UserRolesJs = new Mock<ICollection<UserRolesJ>>().Object
                },
                new EmployeeCredential
                {
                    Id = 256960962,
                    UserName = "TestValue1187488350",
                    Password = "TestValue302183330",
                    Status = (short)30432,
                    RequestedCompanyId = 136693916,
                    Email = "TestValue2080905925",
                    DefaultPassword = false,
                    GenerateOtp = "TestValue1733211755",
                    OtpExpiration = DateTime.UtcNow,
                    IsActive = (short)19006,
                    EmployeeLoginName = "TestValue1650487955",
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 1714737010,
                        Name = "TestValue1658009797",
                        PhoneNumber = "TestValue1549605988",
                        DomainName = "TestValue2030060762",
                        Status = "TestValue1967712139",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue1356081591",
                        IsActive = (short)10894,
                        CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                        Departments = new Mock<ICollection<Department>>().Object,
                        EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                        Holidays = new Mock<ICollection<Holiday>>().Object,
                        LeaveTypes = new Mock<ICollection<LeaveType>>().Object,
                        Positions = new Mock<ICollection<Position>>().Object
                    },
                    AccountDetails = new Mock<ICollection<AccountDetail>>().Object,
                    AddressInfos = new Mock<ICollection<AddressInfo>>().Object,
                    Attendances = new Mock<ICollection<Attendance>>().Object,
                    DeviceTables = new Mock<ICollection<DeviceTable>>().Object,
                    EmpPersonalInfos = new Mock<ICollection<EmpPersonalInfo>>().Object,
                    EmpSalaries = new Mock<ICollection<EmpSalary>>().Object,
                    EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object,
                    EmployeeLeaveAllocations = new Mock<ICollection<EmployeeLeaveAllocation>>().Object,
                    LeaveTrackings = new Mock<ICollection<LeaveTracking>>().Object,
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
            var id = 873545588;

            _userService.Setup(mock => mock.GetById(It.IsAny<int>())).Returns(new EmployeeCredential
            {
                Id = 42390953,
                UserName = "TestValue379349561",
                Password = "TestValue502868693",
                Status = (short)17896,
                RequestedCompanyId = 673029253,
                Email = "TestValue1365392962",
                DefaultPassword = true,
                GenerateOtp = "TestValue1332142656",
                OtpExpiration = DateTime.UtcNow,
                IsActive = (short)28724,
                EmployeeLoginName = "TestValue371561802",
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 2066219565,
                    Name = "TestValue1443643553",
                    PhoneNumber = "TestValue137270358",
                    DomainName = "TestValue896015175",
                    Status = "TestValue397608381",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Email = "TestValue864605026",
                    IsActive = (short)15101,
                    CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                    Departments = new Mock<ICollection<Department>>().Object,
                    EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                    Holidays = new Mock<ICollection<Holiday>>().Object,
                    LeaveTypes = new Mock<ICollection<LeaveType>>().Object,
                    Positions = new Mock<ICollection<Position>>().Object
                },
                AccountDetails = new Mock<ICollection<AccountDetail>>().Object,
                AddressInfos = new Mock<ICollection<AddressInfo>>().Object,
                Attendances = new Mock<ICollection<Attendance>>().Object,
                DeviceTables = new Mock<ICollection<DeviceTable>>().Object,
                EmpPersonalInfos = new Mock<ICollection<EmpPersonalInfo>>().Object,
                EmpSalaries = new Mock<ICollection<EmpSalary>>().Object,
                EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object,
                EmployeeLeaveAllocations = new Mock<ICollection<EmployeeLeaveAllocation>>().Object,
                LeaveTrackings = new Mock<ICollection<LeaveTracking>>().Object,
                UserRolesJs = new Mock<ICollection<UserRolesJ>>().Object
            });

            // Act
            var result = _testClass.GetById(id);

            // Assert
            _userService.Verify(mock => mock.GetById(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallSelectCompany()
        {
            // Arrange
            var model = new SelectCompanyRequest { CompanyId = 222411757 };

            _userService.Setup(mock => mock.SelectCompany(It.IsAny<SelectCompanyRequest>(), It.IsAny<int>())).Returns(new AuthenticateResponse(new List<int>()));

            // Act
            var result = _testClass.SelectCompany(model);

            // Assert
            _userService.Verify(mock => mock.SelectCompany(It.IsAny<SelectCompanyRequest>(), It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }
    }
}