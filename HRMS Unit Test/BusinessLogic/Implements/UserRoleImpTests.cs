namespace HRMS_Unit_Test.BusinessLogic.Implements
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
        private readonly UserRoleImp _testClass;
        private HRMSContext _context;
        private readonly Mock<IHttpContextAccessor> _httpContextAccessor;
        private readonly Mock<IJwtUtils> _jwtUtils;

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
            var id = 504181455;

            _jwtUtils.Setup(mock => mock.ValidateJwtToken(It.IsAny<string>())).Returns(447330976);

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
            var id = 1527702008;

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
                Id = 780123259,
                EmployeeCredentialId = 1148153626,
                RolesId = 432148440,
                IsActive = (short)20102,
                EmployeeCredential = new EmployeeCredential
                {
                    Id = 217877924,
                    UserName = "TestValue700520182",
                    Password = "TestValue1794918133",
                    Status = (short)11641,
                    RequestedCompanyId = 377949490,
                    Email = "TestValue390595610",
                    DefaultPassword = true,
                    GenerateOtp = "TestValue1109135803",
                    OtpExpiration = DateTime.UtcNow,
                    IsActive = (short)32384,
                    EmployeeLoginName = "TestValue1696819120",
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 1720433594,
                        Name = "TestValue2137906314",
                        PhoneNumber = "TestValue1551686700",
                        DomainName = "TestValue1602711102",
                        Status = "TestValue1985152945",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue1731947801",
                        IsActive = (short)1460,
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
                    Id = 1830051757,
                    Name = "TestValue1016333926",
                    IsActive = (short)13372,
                    UserRolesJs = new Mock<ICollection<UserRolesJ>>().Object
                }
            };

            _jwtUtils.Setup(mock => mock.ValidateJwtToken(It.IsAny<string>())).Returns(649877902);

            // Act
            var result = await _testClass.InsertuserRoles(userRolesJ);

            // Assert
            _jwtUtils.Verify(mock => mock.ValidateJwtToken(It.IsAny<string>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallSoftDelete()
        {
            // Arrange
            var id = 29759123;
            var isActive = (short)9297;

            // Act
            var result = _testClass.SoftDelete(id, isActive);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }
    }
}