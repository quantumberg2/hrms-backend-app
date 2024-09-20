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

    public class UserRoleControllerTests
    {
        private readonly UserRoleController _testClass;
        private readonly Mock<IUserRoles> _userRoles;
        private readonly Mock<ILogger<UserRoleController>> _logger;

        public UserRoleControllerTests()
        {
            _userRoles = new Mock<IUserRoles>();
            _logger = new Mock<ILogger<UserRoleController>>();
            _testClass = new UserRoleController(_userRoles.Object, _logger.Object);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new UserRoleController(_userRoles.Object, _logger.Object);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanCallGetAllUserRoles()
        {
            // Arrange
            _userRoles.Setup(mock => mock.GetAlluserRole()).Returns(new List<UserRolesJ>());

            // Act
            var result = _testClass.GetAllUserRoles();

            // Assert
            _userRoles.Verify(mock => mock.GetAlluserRole());

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallInsertUserRole()
        {
            // Arrange
            var userRole = new UserRolesJ
            {
                Id = 1717387350,
                EmployeeCredentialId = 2068217624,
                RolesId = 215061807,
                IsActive = (short)28181,
                EmployeeCredential = new EmployeeCredential
                {
                    Id = 1152777078,
                    UserName = "TestValue2011436398",
                    Password = "TestValue1579455334",
                    Status = (short)3282,
                    RequestedCompanyId = 1866909996,
                    Email = "TestValue1118022",
                    DefaultPassword = true,
                    GenerateOtp = "TestValue1954957396",
                    OtpExpiration = DateTime.UtcNow,
                    IsActive = (short)30530,
                    EmployeeLoginName = "TestValue1204421932",
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 1278769751,
                        Name = "TestValue1207121996",
                        PhoneNumber = "TestValue99967951",
                        DomainName = "TestValue1811192089",
                        Status = "TestValue587004249",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue1164283290",
                        IsActive = (short)3601,
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
                Roles = new Role
                {
                    Id = 1202974099,
                    Name = "TestValue1487245325",
                    IsActive = (short)9370,
                    UserRolesJs = new Mock<ICollection<UserRolesJ>>().Object
                }
            };

            _userRoles.Setup(mock => mock.InsertuserRoles(It.IsAny<UserRolesJ>())).ReturnsAsync("TestValue292804029");

            // Act
            var result = await _testClass.InsertUserRole(userRole);

            // Assert
            _userRoles.Verify(mock => mock.InsertuserRoles(It.IsAny<UserRolesJ>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallDeleteUserRole()
        {
            // Arrange
            var id = 1221833119;

            _userRoles.Setup(mock => mock.deleteUserRole(It.IsAny<int>())).ReturnsAsync(true);

            // Act
            var result = await _testClass.DeleteUserRole(id);

            // Assert
            _userRoles.Verify(mock => mock.deleteUserRole(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallSoftDelete()
        {
            // Arrange
            var id = 1441223403;
            var isActive = (short)12505;

            _userRoles.Setup(mock => mock.SoftDelete(It.IsAny<int>(), It.IsAny<short>())).Returns(false);

            // Act
            var result = _testClass.SoftDelete(id, isActive);

            // Assert
            _userRoles.Verify(mock => mock.SoftDelete(It.IsAny<int>(), It.IsAny<short>()));

            throw new NotImplementedException("Create or modify test");
        }
    }
}