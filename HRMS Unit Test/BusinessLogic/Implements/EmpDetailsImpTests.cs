namespace HRMS_Unit_Test.BusinessLogic.Implements
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using HRMS_Application.Authorization;
    using HRMS_Application.BusinessLogic.Implements;
    using HRMS_Application.BusinessLogic.Interface;
    using HRMS_Application.DTO;
    using HRMS_Application.GlobalSearch;
    using HRMS_Application.Models;
    using Microsoft.AspNetCore.Http;
    using Moq;
    using Xunit;

    public class EmpDetailsImpTests
    {
        private readonly EmpDetailsImp _testClass;
        private HRMSContext _hrmsContext;
        private readonly Mock<IHttpContextAccessor> _httpContextAccessor;
        private readonly Mock<IJwtUtils> _jwtUtils;
        private readonly Mock<IEmailPassword> _emailPasswordService;

        public EmpDetailsImpTests()
        {
            _hrmsContext = new HRMSContext();
            _httpContextAccessor = new Mock<IHttpContextAccessor>();
            _jwtUtils = new Mock<IJwtUtils>();
            _emailPasswordService = new Mock<IEmailPassword>();
         //   _testClass = new EmpDetailsImp(_hrmsContext, _httpContextAccessor.Object, _jwtUtils.Object, _emailPasswordService.Object);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
       //     var instance = new EmpDetailsImp(_hrmsContext, _httpContextAccessor.Object, _jwtUtils.Object, _emailPasswordService.Object);

            // Assert
          //  Assert.NotNull(instance);
        }

        [Fact]
        public async Task CanCallDeleteEmployeeDetail()
        {
            // Arrange
            var id = 1131361402;

            _jwtUtils.Setup(mock => mock.ValidateJwtToken(It.IsAny<string>())).Returns(343397826);

            // Act
            var result = await _testClass.DeleteEmployeeDetail(id);

            // Assert
            _jwtUtils.Verify(mock => mock.ValidateJwtToken(It.IsAny<string>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetAllUser()
        {
            // Act
            var result = _testClass.GetAllUser();

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetById()
        {
            // Arrange
            var id = 1805374430;

            // Act
            var result = _testClass.GetById(id);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallInsertEmployeeAsync()
        {
            // Arrange
            var employeeDetail = new EmployeeDetail
            {
                Id = 1574321451,
                DeptId = 1030957147,
                FirstName = "TestValue651282411",
                MiddleName = "TestValue1470129563",
                LastName = "TestValue2058146445",
                PositionId = 1283953631,
                EmployeeCredentialId = 285280672,
                EmployeeNumber = "TestValue1236913052",
                Email = "TestValue2068136735",
                RequestCompanyId = 302673087,
                IsActive = (short)2540,
                ManagerId = 1121002246,
                NickName = "TestValue1503927736",
                Extension = "TestValue1618823313",
                MobileNumber = "TestValue1220237132",
                Dept = new Department
                {
                    Id = 1060963121,
                    Name = "TestValue1382562523",
                    RequestedCompanyId = 1335232533,
                    IsActive = (short)11490,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 2082973764,
                        Name = "TestValue355228296",
                        PhoneNumber = "TestValue1603196413",
                        DomainName = "TestValue1574837780",
                        Status = "TestValue1391561918",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue1884990071",
                        IsActive = (short)5513,
                        CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                        Departments = new Mock<ICollection<Department>>().Object,
                        EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                        Holidays = new Mock<ICollection<Holiday>>().Object,
                        LeaveTypes = new Mock<ICollection<LeaveType>>().Object,
                        Positions = new Mock<ICollection<Position>>().Object
                    },
                    EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object
                },
                EmployeeCredential = new EmployeeCredential
                {
                    Id = 136062502,
                    UserName = "TestValue1342717614",
                    Password = "TestValue1763890213",
                    Status = (short)16948,
                    RequestedCompanyId = 483124954,
                    Email = "TestValue482983087",
                    DefaultPassword = true,
                    GenerateOtp = "TestValue1866137929",
                    OtpExpiration = DateTime.UtcNow,
                    IsActive = (short)12146,
                    EmployeeLoginName = "TestValue1262926212",
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 2141959309,
                        Name = "TestValue1353074768",
                        PhoneNumber = "TestValue311296293",
                        DomainName = "TestValue291101969",
                        Status = "TestValue1463017",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue1857487386",
                        IsActive = (short)27143,
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
                  //  DeviceTables = new Mock<ICollection<DeviceTable>>().Object,
                    EmpPersonalInfos = new Mock<ICollection<EmpPersonalInfo>>().Object,
                    EmpSalaries = new Mock<ICollection<EmpSalary>>().Object,
                    EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object,
                    EmployeeLeaveAllocations = new Mock<ICollection<EmployeeLeaveAllocation>>().Object,
                    LeaveTrackings = new Mock<ICollection<LeaveTracking>>().Object,
                    UserRolesJs = new Mock<ICollection<UserRolesJ>>().Object
                },
                Position = new Position
                {
                    Id = 1591289791,
                    Name = "TestValue1417512264",
                    RequestedCompanyId = 2115617069,
                    IsActive = (short)2260,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 304402987,
                        Name = "TestValue1376709453",
                        PhoneNumber = "TestValue940235963",
                        DomainName = "TestValue1353805747",
                        Status = "TestValue1155648940",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue378281364",
                        IsActive = (short)28531,
                        CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                        Departments = new Mock<ICollection<Department>>().Object,
                        EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                        Holidays = new Mock<ICollection<Holiday>>().Object,
                        LeaveTypes = new Mock<ICollection<LeaveType>>().Object,
                        Positions = new Mock<ICollection<Position>>().Object
                    },
                    EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object
                }
            };
            var companyId = 74628526;

            _jwtUtils.Setup(mock => mock.ValidateJwtToken(It.IsAny<string>())).Returns(429856822);
            _emailPasswordService.Setup(mock => mock.SendOtpEmailAsync(It.IsAny<Generatepassword>())).Verifiable();

            // Act
        //    var result = await _testClass.InsertEmployeeAsync(employeeDetail, companyId);

            // Assert
            _jwtUtils.Verify(mock => mock.ValidateJwtToken(It.IsAny<string>()));
            _emailPasswordService.Verify(mock => mock.SendOtpEmailAsync(It.IsAny<Generatepassword>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallUpdateEmployeeDetail()
        {
            // Arrange
            var id = 1603603014;
            var depId = 1407204140;
            var fname = "TestValue1732623139";
            var mname = "TestValue1696780460";
            var lname = "TestValue1147891129";
            var positionid = 1090046705;
            var Designation = "TestValue1620506486";
            var Email = "TestValue957336953";
            var employeecredentialId = 1967031780;
            var EmployeeNumber = "TestValue1831032493";
            var requsetCompanyId = 2023184664;

            _jwtUtils.Setup(mock => mock.ValidateJwtToken(It.IsAny<string>())).Returns(2118608685);

            // Act
     //       var result = await _testClass.UpdateEmployeeDetail(id, depId, fname, mname, lname, positionid, Designation, Email, employeecredentialId, EmployeeNumber, requsetCompanyId);

            // Assert
            _jwtUtils.Verify(mock => mock.ValidateJwtToken(It.IsAny<string>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallSoftDelete()
        {
            // Arrange
            var id = 1785273454;
            var isActive = (short)12553;

            // Act
            var result = _testClass.SoftDelete(id, isActive);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetAllEmployees()
        {
            // Act
            var result = _testClass.GetAllEmployees();

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallGetEmployeeInfoAsync()
        {
            // Arrange
            var employeeCredentialId = 2104794567;

            // Act
            var result = await _testClass.GetEmployeeInfoAsync(employeeCredentialId);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallGetEmployeePersonalInfoAsync()
        {
            // Arrange
            var employeeCredentialId = 1066487459;

            // Act
            var result = await _testClass.GetEmployeePersonalInfoAsync(employeeCredentialId);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallGetEmployeeAddressInfoAsync()
        {
            // Arrange
            var employeeCredentialId = 29487755;

            // Act
            var result = await _testClass.GetEmployeeAddressInfoAsync(employeeCredentialId);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallGetEmployeeAccountInfoAsync()
        {
            // Arrange
            var employeeCredentialId = 1023936240;

            // Act
            var result = await _testClass.GetEmployeeAccountInfoAsync(employeeCredentialId);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        /*[Fact]
        public void CanCallGetFilters()
        {
            // Arrange
            var globalSearch = new GlobalsearchEmp { FilterBy = "TestValue461978069" };

            // Act
            var result = _testClass.GetFilters(globalSearch);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }*/

        [Fact]
        public async Task CanCallUpdateEmployeeInfoAsync()
        {
            // Arrange
            var updateEmployeeInfo = new UpdateEmployeeInfoDTO
            {
                EmployeeCredentialId = 2081510747,
                EmployeeName = "TestValue645224557",
                NickName = "TestValue1971758950",
                EmailAddress = "TestValue2131031636",
                EmpLoginName = "TestValue2121533301",
                MobileNumber = "TestValue1916856649",
                Extension = "TestValue213245416",
                gender = "TestValue1979143162"
            };

            // Act
           // var result = await _testClass.UpdateEmployeeInfoAsync(updateEmployeeInfo);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallUpdateEmployeepersonalInfoAsync()
        {
            // Arrange
            var empPersonalInfo = new EmpPersonalInfoDTO
            {
                FirstName = "TestValue2113491808",
                MiddleName = "TestValue823654250",
                LastName = "TestValue1904477682",
                EmployeeCredentialId = 1474959661,
                Dob = DateTime.UtcNow,
                DateOfJoining = DateTime.UtcNow,
                ConfirmDate = DateTime.UtcNow,
                EmpStatus = "TestValue104701723",
                EmailId = "TestValue1522900563",
                PersonalEmail = "TestValue1791509403",
                MaritalStatus = "TestValue824942016",
                BloodGroup = "TestValue1806806845",
                SpouseName = "TestValue734755169",
                PhysicallyChallenged = false,
                EmergencyContact = "TestValue761999480",
                PAN = "TestValue1290694487",
                Gender = "TestValue1058899959",
                Contact = "TestValue236980900"
            };

            // Act
            var result = await _testClass.UpdateEmployeepersonalInfoAsync(empPersonalInfo);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallUpdateEmployeeAddresslInfoAsync()
        {
            // Arrange
            var addressInfo = new AddressInfoDTO
            {
                EmployeeCredentialId = 821584157,
                AddressLine1 = "TestValue1771741658",
                AddressLine2 = "TestValue1733963418",
                City = "TestValue92432405",
                State = "TestValue510330762",
                Country = "TestValue1629130375",
                PinCode = "TestValue1419398533",
                IsActive = (short)30840
            };

            // Act
            var result = await _testClass.UpdateEmployeeAddresslInfoAsync(addressInfo);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallUpdateEmployeeAccountInfoAsync()
        {
            // Arrange
            var accountDetail = new AccountDetail
            {
                Id = 1324317992,
                EmployeeCredentialId = 131712700,
                AccountNumber = "TestValue2063786942",
                IfscCode = "TestValue1935857213",
                AccountType = "TestValue1576887616",
                BankName = "TestValue146849735",
                BranchName = "TestValue1620055025",
                AadharNumber = "TestValue1433154486",
                PfNumber = "TestValue1963250137",
                UanNumber = "TestValue1483535044",
                PfJoiningDate = DateTime.UtcNow,
                EligibleForPf = false,
                IsActive = (short)17150,
                Country = "TestValue796852236",
                State = "TestValue1200342918",
                City = "TestValue492072119",
                Pin = 1726330770,
                EmployeeCredential = new EmployeeCredential
                {
                    Id = 500284101,
                    UserName = "TestValue2141247698",
                    Password = "TestValue2145297890",
                    Status = (short)4546,
                    RequestedCompanyId = 331732290,
                    Email = "TestValue409036126",
                    DefaultPassword = false,
                    GenerateOtp = "TestValue1318767229",
                    OtpExpiration = DateTime.UtcNow,
                    IsActive = (short)15603,
                    EmployeeLoginName = "TestValue408243657",
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 1150174793,
                        Name = "TestValue359289978",
                        PhoneNumber = "TestValue387569883",
                        DomainName = "TestValue1824424244",
                        Status = "TestValue1850398301",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue350012787",
                        IsActive = (short)10590,
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

            // Act
           // var result = await _testClass.UpdateEmployeeAccountInfoAsync(accountDetail);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetEmployeeShiftAndLeaveStats()
        {
            // Arrange
            var empCredentialId = 949905746;

            // Act
            var result = _testClass.GetEmployeeShiftAndLeaveStats(empCredentialId);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }
    }
}