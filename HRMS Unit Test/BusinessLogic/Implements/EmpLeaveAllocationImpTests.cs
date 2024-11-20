namespace HRMS_Unit_Test.BusinessLogic.Implements
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using HRMS_Application.Authorization;
    using HRMS_Application.BusinessLogic.Implements;
    using HRMS_Application.DTO;
    using HRMS_Application.Models;
    using Microsoft.AspNetCore.Http;
    using Moq;
    using Xunit;

    public class EmpLeaveAllocationImpTests
    {
        private readonly EmpLeaveAllocationImp _testClass;
        private HRMSContext _hrmscontext;
        private readonly Mock<IHttpContextAccessor> _httpContextAccessor;
        private readonly Mock<IJwtUtils> _jwtUtils;

        public EmpLeaveAllocationImpTests()
        {
            _hrmscontext = new HRMSContext();
            _httpContextAccessor = new Mock<IHttpContextAccessor>();
            _jwtUtils = new Mock<IJwtUtils>();
            _testClass = new EmpLeaveAllocationImp(_hrmscontext, _httpContextAccessor.Object, _jwtUtils.Object);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new EmpLeaveAllocationImp(_hrmscontext, _httpContextAccessor.Object, _jwtUtils.Object);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public async Task CanCallDeleteEmployeeLeave()
        {
            // Arrange
            var id = 983472324;

            _jwtUtils.Setup(mock => mock.ValidateJwtToken(It.IsAny<string>())).Returns(604350987);

            // Act
            var result = await _testClass.DeleteEmployeeLeave(id);

            // Assert
            _jwtUtils.Verify(mock => mock.ValidateJwtToken(It.IsAny<string>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetAllEmpLeave()
        {
            // Act
            var result = _testClass.GetAllEmpLeave();

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetByEmpLeavebyId()
        {
            // Arrange
            var id = 1344304356;

            // Act
            var result = _testClass.GetByEmpLeavebyId(id);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallInsertEmployeeLeave()
        {
            // Arrange
            var employeeLeave = new EmployeeLeaveAllocation
            {
                Id = 1087749373,
                Year = 968114993,
                EmpCredentialId = 1528933554,
                NumberOfLeaves = 1227104086,
                RemainingLeave = 379937235,
                LeaveType = 84792293,
                IsActive = (short)20352,
                EmpCredential = new EmployeeCredential
                {
                    Id = 866180302,
                    UserName = "TestValue1720166111",
                    Password = "TestValue1407889532",
                    Status = (short)27653,
                    RequestedCompanyId = 1473471021,
                    Email = "TestValue1590862362",
                    DefaultPassword = false,
                    GenerateOtp = "TestValue1193461475",
                    OtpExpiration = DateTime.UtcNow,
                    IsActive = (short)25655,
                    EmployeeLoginName = "TestValue1073470420",
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 403499727,
                        Name = "TestValue1813342893",
                        PhoneNumber = "TestValue1792811340",
                        DomainName = "TestValue1155727693",
                        Status = "TestValue1652399793",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue1740665821",
                        IsActive = (short)17524,
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
                    //DeviceTables = new Mock<ICollection<DeviceTable>>().Object,
                    EmpPersonalInfos = new Mock<ICollection<EmpPersonalInfo>>().Object,
                    EmpSalaries = new Mock<ICollection<EmpSalary>>().Object,
                    EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object,
                    EmployeeLeaveAllocations = new Mock<ICollection<EmployeeLeaveAllocation>>().Object,
                    LeaveTrackings = new Mock<ICollection<LeaveTracking>>().Object,
                    UserRolesJs = new Mock<ICollection<UserRolesJ>>().Object
                },
                LeaveTypeNavigation = new LeaveType
                {
                    Id = 2130844381,
                    Type = "TestValue617183953",
                    Days = 826391200,
                    CompanyId = 737424447,
                    Year = 164110523,
                    IsActive = (short)15413,
                    Company = new RequestedCompanyForm
                    {
                        Id = 659368254,
                        Name = "TestValue310930879",
                        PhoneNumber = "TestValue1033787263",
                        DomainName = "TestValue1548199004",
                        Status = "TestValue1972980699",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue200528966",
                        IsActive = (short)26895,
                        CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                        Departments = new Mock<ICollection<Department>>().Object,
                        EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                        Holidays = new Mock<ICollection<Holiday>>().Object,
                        LeaveTypes = new Mock<ICollection<LeaveType>>().Object,
                        Positions = new Mock<ICollection<Position>>().Object
                    },
                    EmployeeLeaveAllocations = new Mock<ICollection<EmployeeLeaveAllocation>>().Object,
                    LeaveTrackings = new Mock<ICollection<LeaveTracking>>().Object
                }
            };

            // Act
            var result = await _testClass.InsertEmployeeLeave(employeeLeave);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallSoftDelete()
        {
            // Arrange
            var id = 33660961;
            var isActive = (short)10156;

            // Act
            var result = _testClass.SoftDelete(id, isActive);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallGrantLeaveAllocationAsync()
        {
            // Arrange
            var request = new EmployeeLeaveAllocationRequest
            {
                Year = 167172263,
                EmpCredentialId = 636728005,
                NumberOfLeaves = 1335543387,
                RemainingLeave = 521562267,
                LeaveType = 1336067234
            };

            // Act
            await _testClass.GrantLeaveAllocationAsync(request);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }
    }
}