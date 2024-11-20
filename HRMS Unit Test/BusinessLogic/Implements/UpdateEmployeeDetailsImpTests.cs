namespace HRMS_Unit_Test.BusinessLogic.Implements
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using HRMS_Application.Authorization;
    using HRMS_Application.BusinessLogic.Implements;
    using HRMS_Application.BusinessLogic.Interface;
    using HRMS_Application.DTO;
    using HRMS_Application.Models;
    using Microsoft.AspNetCore.Http;
    using Moq;
    using Xunit;

    public class UpdateEmployeeDetailsImpTests
    {
        private readonly UpdateEmployeeDetailsImp _testClass;
        private HRMSContext _hrmsContext;
        private readonly Mock<IHttpContextAccessor> _httpContextAccessor;
        private readonly Mock<IJwtUtils> _jwtUtils;
        private readonly Mock<IEmailPassword> _emailPasswordService;
        private readonly Mock<IAzureOperations> _azureOperations;

        public UpdateEmployeeDetailsImpTests()
        {
            _hrmsContext = new HRMSContext();
            _httpContextAccessor = new Mock<IHttpContextAccessor>();
            _jwtUtils = new Mock<IJwtUtils>();
            _emailPasswordService = new Mock<IEmailPassword>();
            _azureOperations = new Mock<IAzureOperations>();
            _testClass = new UpdateEmployeeDetailsImp(_hrmsContext, _httpContextAccessor.Object, _jwtUtils.Object, _emailPasswordService.Object, _azureOperations.Object);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new UpdateEmployeeDetailsImp(_hrmsContext, _httpContextAccessor.Object, _jwtUtils.Object, _emailPasswordService.Object, _azureOperations.Object);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public async Task CanCallGetEmployeeAccountInfoAsync()
        {
            // Arrange
            var employeeCredentialId = 868450807;

            // Act
            var result = await _testClass.GetEmployeeAccountInfoAsync(employeeCredentialId);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallGetEmployeeAddressInfoAsync()
        {
            // Arrange
            var employeeCredentialId = 592517259;

            // Act
            var result = await _testClass.GetEmployeeAddressInfoAsync(employeeCredentialId);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallGetEmployeeInfoAsync()
        {
            // Arrange
            var employeeCredentialId = 1731196584;

            // Act
            var result = await _testClass.GetEmployeeInfoAsync(employeeCredentialId);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallGetEmployeePersonalInfoAsync()
        {
            // Arrange
            var employeeCredentialId = 105383563;

            // Act
            var result = await _testClass.GetEmployeePersonalInfoAsync(employeeCredentialId);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallUpdateEmployeeAccountInfoAsync()
        {
            // Arrange
            var accountDetail = new AccountDetail
            {
                Id = 1374626493,
                EmployeeCredentialId = 293720264,
                AccountNumber = "TestValue225967635",
                IfscCode = "TestValue848966083",
                AccountType = "TestValue1090574159",
                BankName = "TestValue832854710",
                BranchName = "TestValue445509298",
                AadharNumber = "TestValue1840822801",
                PfNumber = "TestValue809090889",
                UanNumber = "TestValue1239212942",
                PfJoiningDate = DateTime.UtcNow,
                EligibleForPf = false,
                IsActive = (short)24582,
                Country = "TestValue447476442",
                State = "TestValue911952704",
                City = "TestValue1281456235",
                Pin = 1078823500,
                EmployeeCredential = new EmployeeCredential
                {
                    Id = 86300897,
                    UserName = "TestValue1012028737",
                    Password = "TestValue317512114",
                    Status = (short)24611,
                    RequestedCompanyId = 1623008228,
                    Email = "TestValue1658155571",
                    DefaultPassword = true,
                    GenerateOtp = "TestValue1513426596",
                    OtpExpiration = DateTime.UtcNow,
                    IsActive = (short)13062,
                    EmployeeLoginName = "TestValue1675903519",
                    ResignedDate = DateTime.UtcNow,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 1296763081,
                        Name = "TestValue157153344",
                        PhoneNumber = "TestValue1129492714",
                        DomainName = "TestValue1944062929",
                        Status = "TestValue1327328936",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue1189003968",
                        IsActive = (short)17890,
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
                    EmpCredIdEmpCodeMappings = new Mock<ICollection<EmpCredIdEmpCodeMapping>>().Object,
                    EmpPersonalInfos = new Mock<ICollection<EmpPersonalInfo>>().Object,
                    EmpSalaries = new Mock<ICollection<EmpSalary>>().Object,
                    EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object,
                    EmployeeLeaveAllocations = new Mock<ICollection<EmployeeLeaveAllocation>>().Object,
                    LeaveTrackings = new Mock<ICollection<LeaveTracking>>().Object,
                    UserRolesJs = new Mock<ICollection<UserRolesJ>>().Object
                }
            };

            // Act
            var result = await _testClass.UpdateEmployeeAccountInfoAsync(accountDetail);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallUpdateEmployeeAddresslInfoAsync()
        {
            // Arrange
            var addressInfo = new AddressInfoDTO
            {
                EmployeeCredentialId = 895695059,
                AddressLine1 = "TestValue523456257",
                AddressLine2 = "TestValue1785724304",
                City = "TestValue2049051249",
                State = "TestValue1665603554",
                Country = "TestValue988528015",
                PinCode = "TestValue321443662",
                IsActive = (short)29543
            };

            // Act
            var result = await _testClass.UpdateEmployeeAddresslInfoAsync(addressInfo);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallUpdateEmployeeInfoAsync()
        {
            // Arrange
            var updateEmployeeInfo = new UpdateEmployeeInfoDTO
            {
                EmployeeCredentialId = 508265241,
                EmployeeName = "TestValue1101277793",
                NickName = "TestValue980844883",
                EmailAddress = "TestValue850170429",
                EmpLoginName = "TestValue1424213380",
                MobileNumber = "TestValue599680042",
                Extension = "TestValue2025588449",
                gender = "TestValue607867761"
            };

            // Act
            var result = await _testClass.UpdateEmployeeInfoAsync(updateEmployeeInfo);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallUpdateEmployeepersonalInfoAsync()
        {
            // Arrange
            var empPersonalInfo = new EmpPersonalInfoDTO
            {
                FirstName = "TestValue1113975126",
                MiddleName = "TestValue1769552756",
                LastName = "TestValue2003905717",
                EmployeeCredentialId = 275005145,
                Dob = DateTime.UtcNow,
                DateOfJoining = DateTime.UtcNow,
                ConfirmDate = DateTime.UtcNow,
                EmpStatus = "TestValue118204197",
                EmailId = "TestValue629858982",
                PersonalEmail = "TestValue1863954569",
                MaritalStatus = "TestValue379172086",
                BloodGroup = "TestValue860024686",
                SpouseName = "TestValue2140348314",
                PhysicallyChallenged = true,
                EmergencyContact = "TestValue1683575276",
                PAN = "TestValue288355954",
                Gender = "TestValue711330087",
                Contact = "TestValue1012511607"
            };

            // Act
            var result = await _testClass.UpdateEmployeepersonalInfoAsync(empPersonalInfo);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }
    }
}