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

    public class EmployeeAttendanceImpTests
    {
        private readonly EmployeeAttendanceImp _testClass;
        private HRMSContext _hrmscontext;
        private readonly Mock<IHttpContextAccessor> _httpContextAccessor;
        private readonly Mock<IJwtUtils> _jwtUtils;

        public EmployeeAttendanceImpTests()
        {
            _hrmscontext = new HRMSContext();
            _httpContextAccessor = new Mock<IHttpContextAccessor>();
            _jwtUtils = new Mock<IJwtUtils>();
            _testClass = new EmployeeAttendanceImp(_hrmscontext, _httpContextAccessor.Object, _jwtUtils.Object);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new EmployeeAttendanceImp(_hrmscontext, _httpContextAccessor.Object, _jwtUtils.Object);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public async Task CanCallDeleteEmployeeAttendance()
        {
            // Arrange
            var id = 992932509;

            _jwtUtils.Setup(mock => mock.ValidateJwtToken(It.IsAny<string>())).Returns(995783520);

            // Act
            var result = await _testClass.DeleteEmployeeAttendance(id);

            // Assert
            _jwtUtils.Verify(mock => mock.ValidateJwtToken(It.IsAny<string>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetAllEmpAttendence()
        {
            // Act
            var result = _testClass.GetAllEmpAttendence();

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetAttendanceByCredId()
        {
            // Arrange
            var empCredId = 2066192304;

            // Act
            var result = _testClass.GetAttendanceByCredId(empCredId);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetById()
        {
            // Arrange
            var id = 1039809459;

            // Act
            var result = _testClass.GetById(id);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallInsertEmployeeAttendence()
        {
            // Arrange
            var employeeAttendence = new Attendance
            {
                Id = 1759309293,
                EmpCredentialId = 1346022540,
                NumberOfHours = 1045132276.3199999,
                Status = "TestValue795136988",
                EmpCredential = new EmployeeCredential
                {
                    Id = 1154125216,
                    UserName = "TestValue193236254",
                    Password = "TestValue160522950",
                    Status = (short)10224,
                    RequestedCompanyId = 734431021,
                    Email = "TestValue4260011",
                    DefaultPassword = true,
                    GenerateOtp = "TestValue1972409427",
                    OtpExpiration = DateTime.UtcNow,
                    IsActive = (short)499,
                    EmployeeLoginName = "TestValue1519922785",
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 1843126279,
                        Name = "TestValue1359622341",
                        PhoneNumber = "TestValue390147472",
                        DomainName = "TestValue973079794",
                        Status = "TestValue1382316786",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue937401256",
                        IsActive = (short)13776,
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
                }
            };

            _jwtUtils.Setup(mock => mock.ValidateJwtToken(It.IsAny<string>())).Returns(1885336006);

            // Act
            var result = await _testClass.InsertEmployeeAttendence(employeeAttendence);

            // Assert
            _jwtUtils.Verify(mock => mock.ValidateJwtToken(It.IsAny<string>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallUpdateEmployeeAttendence()
        {
            // Arrange
            var id = 795632507;
            var Timein = DateTime.UtcNow;
            var Timeout = DateTime.UtcNow;
            var Remark = "TestValue1997865304";
            var empcredentialId = 1545452393;

            // Act
            var result = await _testClass.UpdateEmployeeAttendence(id, Timein, Timeout, Remark, empcredentialId);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }
    }
}