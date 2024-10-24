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

    public class EmpLeaveAllocationControllerTests
    {
        private readonly EmpLeaveAllocationController _testClass;
        private readonly Mock<IEmpLeaveAllocation> _employeeLeaveService;
        private readonly Mock<ILogger<EmpLeaveAllocationController>> _logger;
        private HRMSContext _context;

        public EmpLeaveAllocationControllerTests()
        {
            _employeeLeaveService = new Mock<IEmpLeaveAllocation>();
            _logger = new Mock<ILogger<EmpLeaveAllocationController>>();
            _context = new HRMSContext();
            _testClass = new EmpLeaveAllocationController(_employeeLeaveService.Object, _logger.Object, _context);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new EmpLeaveAllocationController(_employeeLeaveService.Object, _logger.Object, _context);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanCallGetAllEmpleaves()
        {
            // Arrange
            _employeeLeaveService.Setup(mock => mock.GetAllEmpLeave()).Returns(new List<EmployeeLeaveAllocation>());

            // Act
            var result = _testClass.GetAllEmpleaves();

            // Assert
            _employeeLeaveService.Verify(mock => mock.GetAllEmpLeave());

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallCalculateLeaves()
        {
            // Arrange
            var empCredentialId = 1424432243;

            // Act
            var result = _testClass.CalculateLeaves(empCredentialId);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetById()
        {
            // Arrange
            var id = 1481677129;

            _employeeLeaveService.Setup(mock => mock.GetByEmpLeavebyId(It.IsAny<int>())).Returns(new EmployeeLeaveAllocation
            {
                Id = 1297042009,
                Year = 802385280,
                EmpCredentialId = 563508052,
                NumberOfLeaves = 840578567,
                RemainingLeave = 777451458,
                LeaveType = 2068619075,
                IsActive = (short)29593,
                EmpCredential = new EmployeeCredential
                {
                    Id = 997857508,
                    UserName = "TestValue123995464",
                    Password = "TestValue681152832",
                    Status = (short)13233,
                    RequestedCompanyId = 265427660,
                    Email = "TestValue1964640965",
                    DefaultPassword = false,
                    GenerateOtp = "TestValue823726511",
                    OtpExpiration = DateTime.UtcNow,
                    IsActive = (short)26478,
                    EmployeeLoginName = "TestValue545231576",
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 702232935,
                        Name = "TestValue899542071",
                        PhoneNumber = "TestValue782079848",
                        DomainName = "TestValue1251123021",
                        Status = "TestValue1857634008",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue1681646468",
                        IsActive = (short)8199,
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
                    Id = 1900581543,
                    Type = "TestValue229295605",
                    Days = 534422551,
                    CompanyId = 516681091,
                    Year = 1661041226,
                    IsActive = (short)18163,
                    Company = new RequestedCompanyForm
                    {
                        Id = 2080594366,
                        Name = "TestValue548674639",
                        PhoneNumber = "TestValue16109646",
                        DomainName = "TestValue1327868707",
                        Status = "TestValue706039053",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue1886364032",
                        IsActive = (short)307,
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
            });

            // Act
            var result = _testClass.GetById(id);

            // Assert
            _employeeLeaveService.Verify(mock => mock.GetByEmpLeavebyId(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallInsertEmpLeaves()
        {
            // Arrange
            var employeeLeave = new EmployeeLeaveAllocation
            {
                Id = 501881450,
                Year = 2063145606,
                EmpCredentialId = 689399302,
                NumberOfLeaves = 245337681,
                RemainingLeave = 742798137,
                LeaveType = 1060946917,
                IsActive = (short)6787,
                EmpCredential = new EmployeeCredential
                {
                    Id = 34621665,
                    UserName = "TestValue493053037",
                    Password = "TestValue1224835061",
                    Status = (short)31423,
                    RequestedCompanyId = 569672375,
                    Email = "TestValue1424971785",
                    DefaultPassword = true,
                    GenerateOtp = "TestValue1820790323",
                    OtpExpiration = DateTime.UtcNow,
                    IsActive = (short)2644,
                    EmployeeLoginName = "TestValue1586891648",
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 1268222459,
                        Name = "TestValue26121802",
                        PhoneNumber = "TestValue1087480671",
                        DomainName = "TestValue548155853",
                        Status = "TestValue1534196524",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue1422850462",
                        IsActive = (short)22647,
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
                    Id = 1081100271,
                    Type = "TestValue748042113",
                    Days = 318647910,
                    CompanyId = 249318014,
                    Year = 636772258,
                    IsActive = (short)18638,
                    Company = new RequestedCompanyForm
                    {
                        Id = 1084846126,
                        Name = "TestValue1715199645",
                        PhoneNumber = "TestValue1211038094",
                        DomainName = "TestValue633928363",
                        Status = "TestValue397660621",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue866417889",
                        IsActive = (short)8570,
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

            _employeeLeaveService.Setup(mock => mock.InsertEmployeeLeave(It.IsAny<EmployeeLeaveAllocation>())).ReturnsAsync("TestValue68304572");

            // Act
            var result = await _testClass.InsertEmpLeaves(employeeLeave);

            // Assert
            _employeeLeaveService.Verify(mock => mock.InsertEmployeeLeave(It.IsAny<EmployeeLeaveAllocation>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallDeleteEmpDetails()
        {
            // Arrange
            var id = 938848331;

            _employeeLeaveService.Setup(mock => mock.DeleteEmployeeLeave(It.IsAny<int>())).ReturnsAsync(true);

            // Act
            var result = await _testClass.DeleteEmpDetails(id);

            // Assert
            _employeeLeaveService.Verify(mock => mock.DeleteEmployeeLeave(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallSoftDelete()
        {
            // Arrange
            var id = 1455767768;
            var isActive = (short)2970;

            _employeeLeaveService.Setup(mock => mock.SoftDelete(It.IsAny<int>(), It.IsAny<short>())).Returns(false);

            // Act
            var result = _testClass.SoftDelete(id, isActive);

            // Assert
            _employeeLeaveService.Verify(mock => mock.SoftDelete(It.IsAny<int>(), It.IsAny<short>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallSaveEmployeeLeaveAllocation()
        {
            // Arrange
            var request = new EmployeeLeaveAllocationRequest
            {
                Year = 41369514,
                EmpCredentialId = 1439329677,
                NumberOfLeaves = 1749096387,
                RemainingLeave = 620706465,
                LeaveType = 655622581
            };

            // Act
            var result = _testClass.SaveEmployeeLeaveAllocation(request);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }
    }
}