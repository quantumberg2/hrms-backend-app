namespace HRMS_Unit_Test.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using HRMS_Application.BusinessLogic.Interface;
    using HRMS_Application.Controllers;
    using HRMS_Application.DTO;
    using HRMS_Application.Models;
    using Microsoft.Extensions.Logging;
    using Moq;
    using Xunit;

    public class EmployeeAttendenceControllerTests
    {
        private readonly EmployeeAttendenceController _testClass;
        private readonly Mock<IEmployeeAttendance> _employeeAttendence;
        private readonly Mock<ILogger<EmployeeAttendenceController>> _logger;

        public EmployeeAttendenceControllerTests()
        {
            _employeeAttendence = new Mock<IEmployeeAttendance>();
            _logger = new Mock<ILogger<EmployeeAttendenceController>>();
            _testClass = new EmployeeAttendenceController(_employeeAttendence.Object, _logger.Object);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new EmployeeAttendenceController(_employeeAttendence.Object, _logger.Object);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanCallGetAllEmpDetails()
        {
            // Arrange
            _employeeAttendence.Setup(mock => mock.GetAllEmpAttendence()).Returns(new List<Attendance>());

            // Act
            var result = _testClass.GetAllEmpDetails();

            // Assert
            _employeeAttendence.Verify(mock => mock.GetAllEmpAttendence());

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetAttendanceByCredId()
        {
            // Arrange
            _employeeAttendence.Setup(mock => mock.GetAttendanceByCredId(It.IsAny<int>())).Returns(new List<AttendanceDTO>());

            // Act
            var result = _testClass.GetAttendanceByCredId();

            // Assert
            _employeeAttendence.Verify(mock => mock.GetAttendanceByCredId(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetById()
        {
            // Arrange
            var id = 2140455270;

            _employeeAttendence.Setup(mock => mock.GetById(It.IsAny<int>())).Returns(new Attendance
            {
                Id = 836420102,
                EmpCredentialId = 1858358255,
                NumberOfHours = 1794472437.78,
                Status = "TestValue818851199",
                EmpCredential = new EmployeeCredential
                {
                    Id = 627784087,
                    UserName = "TestValue29562312",
                    Password = "TestValue2059606237",
                    Status = (short)32273,
                    RequestedCompanyId = 1995302298,
                    Email = "TestValue449355071",
                    DefaultPassword = true,
                    GenerateOtp = "TestValue776243509",
                    OtpExpiration = DateTime.UtcNow,
                    IsActive = (short)1082,
                    EmployeeLoginName = "TestValue736357079",
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 1508756693,
                        Name = "TestValue586060489",
                        PhoneNumber = "TestValue1366061846",
                        DomainName = "TestValue1216298804",
                        Status = "TestValue1723218500",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue1493155847",
                        IsActive = (short)2658,
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
            });

            // Act
            var result = _testClass.GetById(id);

            // Assert
            _employeeAttendence.Verify(mock => mock.GetById(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallInsertEmpAttendence()
        {
            // Arrange
            var employeeAttendance = new Attendance
            {
                Id = 1925555615,
                EmpCredentialId = 1599854819,
                NumberOfHours = 615454782.03,
                Status = "TestValue1082409255",
                EmpCredential = new EmployeeCredential
                {
                    Id = 1191776057,
                    UserName = "TestValue595862247",
                    Password = "TestValue358418712",
                    Status = (short)6075,
                    RequestedCompanyId = 770152667,
                    Email = "TestValue449430478",
                    DefaultPassword = false,
                    GenerateOtp = "TestValue394454687",
                    OtpExpiration = DateTime.UtcNow,
                    IsActive = (short)11873,
                    EmployeeLoginName = "TestValue1904978400",
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 1207184902,
                        Name = "TestValue1453277855",
                        PhoneNumber = "TestValue1368390308",
                        DomainName = "TestValue776700302",
                        Status = "TestValue637859718",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue1308239836",
                        IsActive = (short)28778,
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

            _employeeAttendence.Setup(mock => mock.InsertEmployeeAttendence(It.IsAny<Attendance>())).ReturnsAsync("TestValue1731340574");

            // Act
            var result = await _testClass.InsertEmpAttendence(employeeAttendance);

            // Assert
            _employeeAttendence.Verify(mock => mock.InsertEmployeeAttendence(It.IsAny<Attendance>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallUpdateEmpDetails()
        {
            // Arrange
            var id = 1104787394;
            var Timein = DateTime.UtcNow;
            var Timeout = DateTime.UtcNow;
            var Remark = "TestValue326813031";
            var empcredentialId = 407306500;

            _employeeAttendence.Setup(mock => mock.UpdateEmployeeAttendence(It.IsAny<int>(), It.IsAny<DateTime?>(), It.IsAny<DateTime?>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(new Attendance
            {
                Id = 485013785,
                EmpCredentialId = 293293848,
                NumberOfHours = 1338957909.6299999,
                Status = "TestValue409747172",
                EmpCredential = new EmployeeCredential
                {
                    Id = 2107136774,
                    UserName = "TestValue441581159",
                    Password = "TestValue1040557065",
                    Status = (short)16279,
                    RequestedCompanyId = 1213354238,
                    Email = "TestValue1445176396",
                    DefaultPassword = true,
                    GenerateOtp = "TestValue843448479",
                    OtpExpiration = DateTime.UtcNow,
                    IsActive = (short)1938,
                    EmployeeLoginName = "TestValue2034526454",
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 1366480027,
                        Name = "TestValue6112590",
                        PhoneNumber = "TestValue1094636704",
                        DomainName = "TestValue867830180",
                        Status = "TestValue1519273264",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue1636883586",
                        IsActive = (short)781,
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
            });

            // Act
            var result = await _testClass.UpdateEmpDetails(id, Timein, Timeout, Remark, empcredentialId);

            // Assert
            _employeeAttendence.Verify(mock => mock.UpdateEmployeeAttendence(It.IsAny<int>(), It.IsAny<DateTime?>(), It.IsAny<DateTime?>(), It.IsAny<string>(), It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallDeleteEmpAttendence()
        {
            // Arrange
            var id = 730611259;

            _employeeAttendence.Setup(mock => mock.DeleteEmployeeAttendance(It.IsAny<int>())).ReturnsAsync(false);

            // Act
            var result = await _testClass.DeleteEmpAttendence(id);

            // Assert
            _employeeAttendence.Verify(mock => mock.DeleteEmployeeAttendance(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetAttendanceByCredIdWithNoParameters()
        {
            // Arrange
            _employeeAttendence.Setup(mock => mock.GetAttendanceByCredId(It.IsAny<int>())).Returns(new List<AttendanceDTO>());

            // Act
            var result = _testClass.GetAttendanceByCredId();

            // Assert
            _employeeAttendence.Verify(mock => mock.GetAttendanceByCredId(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetAttendanceByCredIdWithEmpCredId()
        {
            // Arrange
            var empCredId = 209288718;

            _employeeAttendence.Setup(mock => mock.GetAttendanceByCredId(It.IsAny<int>())).Returns(new List<AttendanceDTO>());

            // Act
            var result = _testClass.GetAttendanceByCredId(empCredId);

            // Assert
            _employeeAttendence.Verify(mock => mock.GetAttendanceByCredId(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }
    }
}