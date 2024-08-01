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

    public class UserRoleControllerTests
    {
        private UserRoleController _testClass;
        private Mock<IUserRoles> _userRoles;
        private Mock<ILogger<UserRoleController>> _logger;

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
                Id = 1374639889,
                RoleId = 540091779,
                EmployeeCredentialId = 1128378809,
                RolesId = 256863577,
                EmployeeCredential = new EmployeeCredential
                {
                    Id = 1193111449,
                    UserName = "TestValue268141618",
                    Password = "TestValue2111972116",
                    Status = (short)17897,
                    RequestedCompanyId = 130231296,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 81130296,
                        Name = "TestValue1482216974",
                        PhoneNumber = "TestValue2115391910",
                        DomainName = "TestValue93759066",
                        Status = "TestValue169232677",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Department = new Department
                        {
                            Id = 115397772,
                            Name = "TestValue1299549484",
                            RequestedCompanyId = 65747726,
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
                Roles = new Role
                {
                    Id = 1981562926,
                    Name = "TestValue19348874",
                    UserRolesJs = new Mock<ICollection<UserRolesJ>>().Object
                }
            };

            _userRoles.Setup(mock => mock.InsertuserRoles(It.IsAny<UserRolesJ>())).ReturnsAsync("TestValue1292712867");

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
            var id = 1292610837;

            _userRoles.Setup(mock => mock.deleteUserRole(It.IsAny<int>())).ReturnsAsync(true);

            // Act
            var result = await _testClass.DeleteUserRole(id);

            // Assert
            _userRoles.Verify(mock => mock.deleteUserRole(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }
    }
}