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

    public class LeaveTrackingImpTests
    {
        private readonly LeaveTrackingImp _testClass;
        private HRMSContext _hrmscontext;
        private readonly Mock<IHttpContextAccessor> _httpContextAccessor;
        private readonly Mock<IJwtUtils> _jwtUtils;

        public LeaveTrackingImpTests()
        {
            _hrmscontext = new HRMSContext();
            _httpContextAccessor = new Mock<IHttpContextAccessor>();
            _jwtUtils = new Mock<IJwtUtils>();
          //  _testClass = new LeaveTrackingImp(_hrmscontext, _httpContextAccessor.Object, _jwtUtils.Object);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
        //    var instance = new LeaveTrackingImp(_hrmscontext, _httpContextAccessor.Object, _jwtUtils.Object);

            // Assert
       //     Assert.NotNull(instance);
        }

        [Fact]
        public async Task CanCallGetAllAsync()
        {
            // Act
            var result = await _testClass.GetAllAsync();

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallGetByIdAsync()
        {
            // Arrange
            var id = 460871789;

            // Act
            var result = await _testClass.GetByIdAsync(id);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallCreateAsync()
        {
            // Arrange
            var leaveTracking = new LeaveTracking
            {
                Id = 1836190213,
                EmpCredentialId = 1737289903,
                Startdate = DateTime.UtcNow,
                Enddate = DateTime.UtcNow,
                AppliedDate = DateTime.UtcNow,
                Status = "TestValue1132680216",
                Files = "TestValue26771073",
                LeaveTypeId = 323269955,
                Session = "TestValue1727297973",
                Contact = "TestValue239263398",
                ReasonForLeave = "TestValue1643112866",
                IsActive = (short)20257,
                EmpCredential = new EmployeeCredential
                {
                    Id = 294056385,
                    UserName = "TestValue1379062431",
                    Password = "TestValue1660546838",
                    Status = (short)8447,
                    RequestedCompanyId = 828215309,
                    Email = "TestValue489317242",
                    DefaultPassword = true,
                    GenerateOtp = "TestValue1252448871",
                    OtpExpiration = DateTime.UtcNow,
                    IsActive = (short)22902,
                    EmployeeLoginName = "TestValue1148799560",
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 535227455,
                        Name = "TestValue242569720",
                        PhoneNumber = "TestValue1589921783",
                        DomainName = "TestValue1212836918",
                        Status = "TestValue1004200172",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue1526884085",
                        IsActive = (short)16695,
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
                LeaveType = new LeaveType
                {
                    Id = 1351482201,
                    Type = "TestValue1503945572",
                    Days = 1829718348,
                    CompanyId = 2088636985,
                    Year = 744390965,
                    IsActive = (short)17711,
                    Company = new RequestedCompanyForm
                    {
                        Id = 297837433,
                        Name = "TestValue789530612",
                        PhoneNumber = "TestValue1209473182",
                        DomainName = "TestValue726530973",
                        Status = "TestValue595140609",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue697508477",
                        IsActive = (short)5155,
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
            var empCredentialId = 2078218248;

            _jwtUtils.Setup(mock => mock.ValidateJwtToken(It.IsAny<string>())).Returns(81400069);

            // Act
            var result = await _testClass.CreateAsync(leaveTracking, empCredentialId);

            // Assert
            _jwtUtils.Verify(mock => mock.ValidateJwtToken(It.IsAny<string>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallUpdateAsync()
        {
            // Arrange
            var leaveTracking = new LeaveTracking
            {
                Id = 1327029185,
                EmpCredentialId = 37640951,
                Startdate = DateTime.UtcNow,
                Enddate = DateTime.UtcNow,
                AppliedDate = DateTime.UtcNow,
                Status = "TestValue2086003513",
                Files = "TestValue1930424720",
                LeaveTypeId = 51822695,
                Session = "TestValue2133591983",
                Contact = "TestValue1080228280",
                ReasonForLeave = "TestValue1064533689",
                IsActive = (short)12378,
                EmpCredential = new EmployeeCredential
                {
                    Id = 349244779,
                    UserName = "TestValue809225206",
                    Password = "TestValue565847603",
                    Status = (short)31632,
                    RequestedCompanyId = 1986313996,
                    Email = "TestValue246268430",
                    DefaultPassword = true,
                    GenerateOtp = "TestValue128480044",
                    OtpExpiration = DateTime.UtcNow,
                    IsActive = (short)9877,
                    EmployeeLoginName = "TestValue1376587714",
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 375815772,
                        Name = "TestValue882801473",
                        PhoneNumber = "TestValue1960878165",
                        DomainName = "TestValue1386469050",
                        Status = "TestValue1697149067",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue218317572",
                        IsActive = (short)20792,
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
                LeaveType = new LeaveType
                {
                    Id = 1911577327,
                    Type = "TestValue1766225774",
                    Days = 1910269916,
                    CompanyId = 2147026481,
                    Year = 554940394,
                    IsActive = (short)17747,
                    Company = new RequestedCompanyForm
                    {
                        Id = 1218064959,
                        Name = "TestValue381179621",
                        PhoneNumber = "TestValue1063024182",
                        DomainName = "TestValue1552280831",
                        Status = "TestValue1274317052",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue1221259099",
                        IsActive = (short)22506,
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

            _jwtUtils.Setup(mock => mock.ValidateJwtToken(It.IsAny<string>())).Returns(154047835);

            // Act
            var result = await _testClass.UpdateAsync(leaveTracking);

            // Assert
            _jwtUtils.Verify(mock => mock.ValidateJwtToken(It.IsAny<string>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallUpdateLeaveAsync()
        {
            // Arrange
            var id = 1108057552;
            var newStatus = "TestValue271253921";

            // Act
            var result = await _testClass.UpdateLeaveAsync(id, newStatus);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallDeleteAsync()
        {
            // Arrange
            var id = 1018443763;

            _jwtUtils.Setup(mock => mock.ValidateJwtToken(It.IsAny<string>())).Returns(439411883);

            // Act
            var result = await _testClass.DeleteAsync(id);

            // Assert
            _jwtUtils.Verify(mock => mock.ValidateJwtToken(It.IsAny<string>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallGetLeavesByStatusAsync()
        {
            // Arrange
            var status = "TestValue1739392206";

            // Act
       //     var result = await _testClass.GetLeavesByStatusAsync(status);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

       /* [Fact]
        public async Task CanCallGetEmployeeLeaveSummaryAsync()
        {
            // Arrange
            var employeeCredentialId = 2082649406;

            // Act
            var result = await _testClass.GetEmployeeLeaveSummaryAsync(employeeCredentialId);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }
*/
        [Fact]
        public void CanCallSoftDelete()
        {
            // Arrange
            var id = 594897256;
            var isActive = (short)5679;

            // Act
            var result = _testClass.SoftDelete(id, isActive);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallApllyLeaveBehalf()
        {
            // Arrange
            var leaveTracking = new LeaveTracking
            {
                Id = 963204752,
                EmpCredentialId = 202077988,
                Startdate = DateTime.UtcNow,
                Enddate = DateTime.UtcNow,
                AppliedDate = DateTime.UtcNow,
                Status = "TestValue466660565",
                Files = "TestValue50137842",
                LeaveTypeId = 1108759515,
                Session = "TestValue1702402476",
                Contact = "TestValue1418730009",
                ReasonForLeave = "TestValue1513634667",
                IsActive = (short)12186,
                EmpCredential = new EmployeeCredential
                {
                    Id = 388854446,
                    UserName = "TestValue1712107148",
                    Password = "TestValue836596938",
                    Status = (short)3387,
                    RequestedCompanyId = 1461486153,
                    Email = "TestValue1301747420",
                    DefaultPassword = true,
                    GenerateOtp = "TestValue1941788032",
                    OtpExpiration = DateTime.UtcNow,
                    IsActive = (short)27366,
                    EmployeeLoginName = "TestValue1495266291",
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 1691948359,
                        Name = "TestValue923289814",
                        PhoneNumber = "TestValue841471245",
                        DomainName = "TestValue1397619580",
                        Status = "TestValue1054704592",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue1319792893",
                        IsActive = (short)4097,
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
                LeaveType = new LeaveType
                {
                    Id = 104561851,
                    Type = "TestValue443389590",
                    Days = 942434402,
                    CompanyId = 1794560491,
                    Year = 1761983308,
                    IsActive = (short)27021,
                    Company = new RequestedCompanyForm
                    {
                        Id = 990516305,
                        Name = "TestValue960877064",
                        PhoneNumber = "TestValue803021022",
                        DomainName = "TestValue1708191928",
                        Status = "TestValue1680365916",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue504802552",
                        IsActive = (short)829,
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
            var empCredentialId = 1663146130;

            _jwtUtils.Setup(mock => mock.ValidateJwtToken(It.IsAny<string>())).Returns(950700263);

            // Act
            var result = await _testClass.ApllyLeaveBehalf(leaveTracking, empCredentialId);

            // Assert
            _jwtUtils.Verify(mock => mock.ValidateJwtToken(It.IsAny<string>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetPendingLeaves()
        {
            // Arrange
            var employeeCredentialId = 1109933259;

            // Act
            var result = _testClass.GetPendingLeaves(employeeCredentialId);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetHistoryLeaves()
        {
            // Arrange
            var employeeCredentialId = 1696873162;

            // Act
            var result = _testClass.GetHistoryLeaves(employeeCredentialId);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallUpdateLeaveAsyncchanges()
        {
            // Arrange
            var employeeCredentialId = 753625284;
            var id = 885462606;
            var newStatus = "TestValue1656635598";

            // Act
            var result = await _testClass.UpdateLeaveAsyncchanges(employeeCredentialId, id, newStatus);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }
    }
}