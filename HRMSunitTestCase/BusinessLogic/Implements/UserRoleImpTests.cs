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
            var id = 59435022;

            _jwtUtils.Setup(mock => mock.ValidateJwtToken(It.IsAny<string>())).Returns(1107527517);

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
            var id = 1450680798;

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
                Id = 1525276884,
                EmployeeCredentialId = 59648210,
                RolesId = 1205749109,
                EmployeeCredential = new EmployeeCredential
                {
                    Id = 1851149361,
                    UserName = "TestValue190201610",
                    Password = "TestValue1518573416",
                    Status = (short)18299,
                    RequestedCompanyId = 1119548454,
                    Email = "TestValue115026379",
                    DefaultPassword = false,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 859166875,
                        Name = "TestValue719136806",
                        PhoneNumber = "TestValue1909111320",
                        DomainName = "TestValue366397818",
                        Status = "TestValue1775623914",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue414124806",
                        Department = new Department
                        {
                            Id = 946466358,
                            Name = "TestValue1242497528",
                            RequestedCompanyId = 1499478313,
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
                    Id = 742488441,
                    Name = "TestValue344272954",
                    UserRolesJs = new Mock<ICollection<UserRolesJ>>().Object
                }
            };

            _jwtUtils.Setup(mock => mock.ValidateJwtToken(It.IsAny<string>())).Returns(225102350);

            // Act
            var result = await _testClass.InsertuserRoles(userRolesJ);

            // Assert
            _jwtUtils.Verify(mock => mock.ValidateJwtToken(It.IsAny<string>()));

            throw new NotImplementedException("Create or modify test");
        }
    }
}