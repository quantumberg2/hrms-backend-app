namespace HRMSunitTestCase.Controllers
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
                Id = 1246636271,
                EmployeeCredentialId = 1300775509,
                RolesId = 1490817881,
                EmployeeCredential = new EmployeeCredential
                {
                    Id = 1724946438,
                    UserName = "TestValue95298370",
                    Password = "TestValue1345970023",
                    Status = (short)5209,
                    RequestedCompanyId = 1750513768,
                    Email = "TestValue794498683",
                    DefaultPassword = true,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 419547811,
                        Name = "TestValue420467615",
                        PhoneNumber = "TestValue1622701818",
                        DomainName = "TestValue807383081",
                        Status = "TestValue600934572",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue1831106224",
                        Department = new Department
                        {
                            Id = 1676979332,
                            Name = "TestValue1733965819",
                            RequestedCompanyId = 434614088,
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
                Roles = new Role
                {
                    Id = 1856761066,
                    Name = "TestValue1258666115",
                    UserRolesJs = new Mock<ICollection<UserRolesJ>>().Object
                }
            };

            _userRoles.Setup(mock => mock.InsertuserRoles(It.IsAny<UserRolesJ>())).ReturnsAsync("TestValue391005334");

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
            var id = 248856501;

            _userRoles.Setup(mock => mock.deleteUserRole(It.IsAny<int>())).ReturnsAsync(false);

            // Act
            var result = await _testClass.DeleteUserRole(id);

            // Assert
            _userRoles.Verify(mock => mock.deleteUserRole(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }
    }
}