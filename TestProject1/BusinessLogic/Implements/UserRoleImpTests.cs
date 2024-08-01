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

    public class UserRoleImpTests
    {
        private UserRoleImp _testClass;
        private HRMSContext _context;
        private Mock<IHttpContextAccessor> _httpContextAccessor;
        private Mock<IJwtUtils> _jwtUtils;

        public UserRoleImpTests()
        {
            _context = new HRMSContext();
            _httpContextAccessor = new Mock<IHttpContextAccessor>();
            _jwtUtils = new Mock<IJwtUtils>();
            _testClass = new UserRoleImp(_context, _httpContextAccessor.Object, _jwtUtils.Object);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new UserRoleImp(_context, _httpContextAccessor.Object, _jwtUtils.Object);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public async Task CanCalldeleteUserRole()
        {
            // Arrange
            var id = 876489963;

            _jwtUtils.Setup(mock => mock.ValidateJwtToken(It.IsAny<string>())).Returns(16956499);

            // Act
            var result = await _testClass.deleteUserRole(id);

            // Assert
            _jwtUtils.Verify(mock => mock.ValidateJwtToken(It.IsAny<string>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetAlluserRole()
        {
            // Act
            var result = _testClass.GetAlluserRole();

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetuserRoleById()
        {
            // Arrange
            var id = 1024924178;

            // Act
            var result = _testClass.GetuserRoleById(id);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallInsertuserRoles()
        {
            // Arrange
            var userRolesJ = new UserRolesJ
            {
                Id = 248109514,
                RoleId = 201332296,
                EmployeeCredentialId = 1178974909,
                RolesId = 1216689982,
                EmployeeCredential = new EmployeeCredential
                {
                    Id = 1937625576,
                    UserName = "TestValue14314887",
                    Password = "TestValue1001709706",
                    Status = (short)17202,
                    RequestedCompanyId = 921893390,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 1703644326,
                        Name = "TestValue1495916687",
                        PhoneNumber = "TestValue763918078",
                        DomainName = "TestValue499705123",
                        Status = "TestValue814129286",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Department = new Department
                        {
                            Id = 1682714546,
                            Name = "TestValue1614049880",
                            RequestedCompanyId = 510282167,
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
                    Id = 1898320239,
                    Name = "TestValue1389613681",
                    UserRolesJs = new Mock<ICollection<UserRolesJ>>().Object
                }
            };

            _jwtUtils.Setup(mock => mock.ValidateJwtToken(It.IsAny<string>())).Returns(1795241240);

            // Act
            var result = await _testClass.InsertuserRoles(userRolesJ);

            // Assert
            _jwtUtils.Verify(mock => mock.ValidateJwtToken(It.IsAny<string>()));

            throw new NotImplementedException("Create or modify test");
        }
    }
}