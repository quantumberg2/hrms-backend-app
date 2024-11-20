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

    public class UpdateEmployeeDetailControllerTests
    {
        private readonly UpdateEmployeeDetailController _testClass;
        private readonly Mock<IUpdateEmployeeDetails> _empDetails;
        private readonly Mock<ILogger<UpdateEmployeeDetailController>> _logger;

        public UpdateEmployeeDetailControllerTests()
        {
            _empDetails = new Mock<IUpdateEmployeeDetails>();
            _logger = new Mock<ILogger<UpdateEmployeeDetailController>>();
            _testClass = new UpdateEmployeeDetailController(_empDetails.Object, _logger.Object);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new UpdateEmployeeDetailController(_empDetails.Object, _logger.Object);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public async Task CanCallGetEmployeeInfo()
        {
            // Arrange
            _empDetails.Setup(mock => mock.GetEmployeeInfoAsync(It.IsAny<int>())).ReturnsAsync(new UpdateEmployeeInfoDTO
            {
                EmployeeCredentialId = 164221742,
                EmployeeName = "TestValue801400148",
                NickName = "TestValue306856779",
                EmailAddress = "TestValue914028143",
                EmpLoginName = "TestValue659209481",
                MobileNumber = "TestValue2009558715",
                Extension = "TestValue1401128144",
                gender = "TestValue12662671"
            });

            // Act
            var result = await _testClass.GetEmployeeInfo();

            // Assert
            _empDetails.Verify(mock => mock.GetEmployeeInfoAsync(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallGetEmployeePersonalInfo()
        {
            // Arrange
            _empDetails.Setup(mock => mock.GetEmployeePersonalInfoAsync(It.IsAny<int>())).ReturnsAsync(new EmpPersonalInfoDTO
            {
                FirstName = "TestValue1546766864",
                MiddleName = "TestValue1607875229",
                LastName = "TestValue1957538775",
                EmployeeCredentialId = 1669391033,
                Dob = DateTime.UtcNow,
                DateOfJoining = DateTime.UtcNow,
                ConfirmDate = DateTime.UtcNow,
                EmpStatus = "TestValue1012201032",
                EmailId = "TestValue1428109938",
                PersonalEmail = "TestValue238115836",
                MaritalStatus = "TestValue1709830882",
                BloodGroup = "TestValue1874506230",
                SpouseName = "TestValue104167101",
                PhysicallyChallenged = false,
                EmergencyContact = "TestValue1613842061",
                PAN = "TestValue1009835222",
                Gender = "TestValue1811224544",
                Contact = "TestValue786759856"
            });

            // Act
            var result = await _testClass.GetEmployeePersonalInfo();

            // Assert
            _empDetails.Verify(mock => mock.GetEmployeePersonalInfoAsync(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallGetEmployeeAddressInfo()
        {
            // Arrange
            _empDetails.Setup(mock => mock.GetEmployeeAddressInfoAsync(It.IsAny<int>())).ReturnsAsync(new AddressInfoDTO
            {
                EmployeeCredentialId = 2123655685,
                AddressLine1 = "TestValue733689252",
                AddressLine2 = "TestValue1124086430",
                City = "TestValue769647567",
                State = "TestValue518802488",
                Country = "TestValue1367881479",
                PinCode = "TestValue937564940",
                IsActive = (short)18563
            });

            // Act
            var result = await _testClass.GetEmployeeAddressInfo();

            // Assert
            _empDetails.Verify(mock => mock.GetEmployeeAddressInfoAsync(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallGetEmployeeAccountInfo()
        {
            // Arrange
            _empDetails.Setup(mock => mock.GetEmployeeAccountInfoAsync(It.IsAny<int>())).ReturnsAsync(new AccountDetail
            {
                Id = 1671729720,
                EmployeeCredentialId = 782012232,
                AccountNumber = "TestValue1112544539",
                IfscCode = "TestValue2114466851",
                AccountType = "TestValue527024341",
                BankName = "TestValue1904253047",
                BranchName = "TestValue832585557",
                AadharNumber = "TestValue2119242288",
                PfNumber = "TestValue846411166",
                UanNumber = "TestValue980909411",
                PfJoiningDate = DateTime.UtcNow,
                EligibleForPf = true,
                IsActive = (short)7300,
                Country = "TestValue1205665126",
                State = "TestValue1187919299",
                City = "TestValue79020057",
                Pin = 129641707,
                EmployeeCredential = new EmployeeCredential
                {
                    Id = 458428755,
                    UserName = "TestValue1074342867",
                    Password = "TestValue140544964",
                    Status = (short)17895,
                    RequestedCompanyId = 2033639263,
                    Email = "TestValue177104506",
                    DefaultPassword = false,
                    GenerateOtp = "TestValue227532933",
                    OtpExpiration = DateTime.UtcNow,
                    IsActive = (short)7636,
                    EmployeeLoginName = "TestValue14640292",
                    ResignedDate = DateTime.UtcNow,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 330684741,
                        Name = "TestValue180338891",
                        PhoneNumber = "TestValue1682606698",
                        DomainName = "TestValue1239911148",
                        Status = "TestValue882325656",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue792264839",
                        IsActive = (short)9295,
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
            });

            // Act
            var result = await _testClass.GetEmployeeAccountInfo();

            // Assert
            _empDetails.Verify(mock => mock.GetEmployeeAccountInfoAsync(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallUpdateEmployeeInfo()
        {
            // Arrange
            var updateEmployeeInfo = new UpdateEmployeeInfoDTO
            {
                EmployeeCredentialId = 285809055,
                EmployeeName = "TestValue887378801",
                NickName = "TestValue2047140140",
                EmailAddress = "TestValue1461126734",
                EmpLoginName = "TestValue1858575142",
                MobileNumber = "TestValue1953061482",
                Extension = "TestValue1041920673",
                gender = "TestValue132408460"
            };

            _empDetails.Setup(mock => mock.UpdateEmployeeInfoAsync(It.IsAny<UpdateEmployeeInfoDTO>())).ReturnsAsync(true);

            // Act
            var result = await _testClass.UpdateEmployeeInfo(updateEmployeeInfo);

            // Assert
            _empDetails.Verify(mock => mock.UpdateEmployeeInfoAsync(It.IsAny<UpdateEmployeeInfoDTO>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallUpdateEmployeePersonalInfo()
        {
            // Arrange
            var empPersonalInfoDTO = new EmpPersonalInfoDTO
            {
                FirstName = "TestValue632932650",
                MiddleName = "TestValue973589709",
                LastName = "TestValue1332795024",
                EmployeeCredentialId = 1728578377,
                Dob = DateTime.UtcNow,
                DateOfJoining = DateTime.UtcNow,
                ConfirmDate = DateTime.UtcNow,
                EmpStatus = "TestValue935736386",
                EmailId = "TestValue654669195",
                PersonalEmail = "TestValue994444723",
                MaritalStatus = "TestValue311218812",
                BloodGroup = "TestValue1591943268",
                SpouseName = "TestValue1227336515",
                PhysicallyChallenged = false,
                EmergencyContact = "TestValue1330441250",
                PAN = "TestValue1494625214",
                Gender = "TestValue1807143529",
                Contact = "TestValue885011606"
            };

            _empDetails.Setup(mock => mock.UpdateEmployeepersonalInfoAsync(It.IsAny<EmpPersonalInfoDTO>())).ReturnsAsync(false);

            // Act
            var result = await _testClass.UpdateEmployeePersonalInfo(empPersonalInfoDTO);

            // Assert
            _empDetails.Verify(mock => mock.UpdateEmployeepersonalInfoAsync(It.IsAny<EmpPersonalInfoDTO>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallUpdateEmployeeAddressInfo()
        {
            // Arrange
            var addressInfo = new AddressInfoDTO
            {
                EmployeeCredentialId = 512384049,
                AddressLine1 = "TestValue1573568306",
                AddressLine2 = "TestValue652246666",
                City = "TestValue436635590",
                State = "TestValue1753983665",
                Country = "TestValue98583755",
                PinCode = "TestValue1391464321",
                IsActive = (short)30771
            };

            _empDetails.Setup(mock => mock.UpdateEmployeeAddresslInfoAsync(It.IsAny<AddressInfoDTO>())).ReturnsAsync(false);

            // Act
            var result = await _testClass.UpdateEmployeeAddressInfo(addressInfo);

            // Assert
            _empDetails.Verify(mock => mock.UpdateEmployeeAddresslInfoAsync(It.IsAny<AddressInfoDTO>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallUpdateEmployeeAccountInfo()
        {
            // Arrange
            var accountDetail = new AccountDetail
            {
                Id = 902110244,
                EmployeeCredentialId = 1339124903,
                AccountNumber = "TestValue229985214",
                IfscCode = "TestValue1144785668",
                AccountType = "TestValue1363251372",
                BankName = "TestValue334967129",
                BranchName = "TestValue130894248",
                AadharNumber = "TestValue1901230803",
                PfNumber = "TestValue1627393481",
                UanNumber = "TestValue489419700",
                PfJoiningDate = DateTime.UtcNow,
                EligibleForPf = true,
                IsActive = (short)20067,
                Country = "TestValue433545562",
                State = "TestValue1542432002",
                City = "TestValue1673153343",
                Pin = 688161975,
                EmployeeCredential = new EmployeeCredential
                {
                    Id = 928692336,
                    UserName = "TestValue1437866035",
                    Password = "TestValue1712411971",
                    Status = (short)12884,
                    RequestedCompanyId = 1208320760,
                    Email = "TestValue938667488",
                    DefaultPassword = true,
                    GenerateOtp = "TestValue1162128534",
                    OtpExpiration = DateTime.UtcNow,
                    IsActive = (short)30434,
                    EmployeeLoginName = "TestValue1346191093",
                    ResignedDate = DateTime.UtcNow,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 379493176,
                        Name = "TestValue389674007",
                        PhoneNumber = "TestValue1843256517",
                        DomainName = "TestValue1090694654",
                        Status = "TestValue534348895",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue1729609035",
                        IsActive = (short)22331,
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

            _empDetails.Setup(mock => mock.UpdateEmployeeAccountInfoAsync(It.IsAny<AccountDetail>())).ReturnsAsync(true);

            // Act
            var result = await _testClass.UpdateEmployeeAccountInfo(accountDetail);

            // Assert
            _empDetails.Verify(mock => mock.UpdateEmployeeAccountInfoAsync(It.IsAny<AccountDetail>()));

            throw new NotImplementedException("Create or modify test");
        }
    }
}