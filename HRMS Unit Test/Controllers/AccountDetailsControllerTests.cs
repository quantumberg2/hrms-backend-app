namespace HRMS_Unit_Test.Controllers
{
    using System;
    using System.Collections.Generic;
    using HRMS_Application.BusinessLogic.Interface;
    using HRMS_Application.Controllers;
    using HRMS_Application.Models;
    using Microsoft.Extensions.Logging;
    using Moq;
    using Xunit;

    public class AccountDetailsControllerTests
    {
        private readonly AccountDetailsController _testClass;
        private readonly Mock<IAccountDetails> _accountDetails;
        private readonly Mock<ILogger<AccountDetailsController>> _logger;

        public AccountDetailsControllerTests()
        {
            _accountDetails = new Mock<IAccountDetails>();
            _logger = new Mock<ILogger<AccountDetailsController>>();
            _testClass = new AccountDetailsController(_accountDetails.Object, _logger.Object);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new AccountDetailsController(_accountDetails.Object, _logger.Object);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanCallGetAllaccountDetails()
        {
            // Arrange
            _accountDetails.Setup(mock => mock.GetAllAccountdetails()).Returns(new List<AccountDetail>());

            // Act
            var result = _testClass.GetAllaccountDetails();

            // Assert
            _accountDetails.Verify(mock => mock.GetAllAccountdetails());

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetAccountDetailsById()
        {
            // Arrange
            var id = 2061239234;

            _accountDetails.Setup(mock => mock.GetAccountDetailsById(It.IsAny<int>())).Returns(new AccountDetail
            {
                Id = 1561663633,
                EmployeeCredentialId = 1439104167,
                AccountNumber = "TestValue276909008",
                IfscCode = "TestValue919001396",
                AccountType = "TestValue1606166836",
                BankName = "TestValue226301814",
                BranchName = "TestValue1660749485",
                AadharNumber = "TestValue1664400977",
                PfNumber = "TestValue1013425800",
                UanNumber = "TestValue1061404082",
                PfJoiningDate = DateTime.UtcNow,
                EligibleForPf = true,
                IsActive = (short)13681,
                Country = "TestValue1969082787",
                State = "TestValue107038221",
                City = "TestValue80497293",
                Pin = 2121766418,
                EmployeeCredential = new EmployeeCredential
                {
                    Id = 2073676991,
                    UserName = "TestValue2011933588",
                    Password = "TestValue490745565",
                    Status = (short)11864,
                    RequestedCompanyId = 48587640,
                    Email = "TestValue522380337",
                    DefaultPassword = false,
                    GenerateOtp = "TestValue330821725",
                    OtpExpiration = DateTime.UtcNow,
                    IsActive = (short)19884,
                    EmployeeLoginName = "TestValue1576096221",
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 133162964,
                        Name = "TestValue43817333",
                        PhoneNumber = "TestValue2026117312",
                        DomainName = "TestValue1231789419",
                        Status = "TestValue2039210828",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue453056164",
                        IsActive = (short)12449,
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
                }
            });

            // Act
            var result = _testClass.GetAccountDetailsById(id);

            // Assert
            _accountDetails.Verify(mock => mock.GetAccountDetailsById(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetAccountDetailsByAccNumber()
        {
            // Arrange
            var accountNumber = "TestValue2055327200";

            _accountDetails.Setup(mock => mock.GetAccountDetailsByAccNumber(It.IsAny<string>())).Returns(new AccountDetail
            {
                Id = 496804606,
                EmployeeCredentialId = 2083057826,
                AccountNumber = "TestValue1866530543",
                IfscCode = "TestValue1061533842",
                AccountType = "TestValue1179378859",
                BankName = "TestValue1311821191",
                BranchName = "TestValue620015627",
                AadharNumber = "TestValue1147710383",
                PfNumber = "TestValue1374000043",
                UanNumber = "TestValue2078712316",
                PfJoiningDate = DateTime.UtcNow,
                EligibleForPf = true,
                IsActive = (short)21049,
                Country = "TestValue704679260",
                State = "TestValue1359027869",
                City = "TestValue1597588729",
                Pin = 955541155,
                EmployeeCredential = new EmployeeCredential
                {
                    Id = 261507425,
                    UserName = "TestValue1075207066",
                    Password = "TestValue352894971",
                    Status = (short)26489,
                    RequestedCompanyId = 365407587,
                    Email = "TestValue1039283296",
                    DefaultPassword = true,
                    GenerateOtp = "TestValue2093570930",
                    OtpExpiration = DateTime.UtcNow,
                    IsActive = (short)26904,
                    EmployeeLoginName = "TestValue30070615",
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 93138850,
                        Name = "TestValue1616932152",
                        PhoneNumber = "TestValue1785767312",
                        DomainName = "TestValue1929120028",
                        Status = "TestValue1169676901",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue470297253",
                        IsActive = (short)1232,
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
                }
            });

            // Act
            var result = _testClass.GetAccountDetailsByAccNumber(accountNumber);

            // Assert
            _accountDetails.Verify(mock => mock.GetAccountDetailsByAccNumber(It.IsAny<string>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallInsertAccountDetails()
        {
            // Arrange
            var accountDetail = new AccountDetail
            {
                Id = 144923114,
                EmployeeCredentialId = 255235875,
                AccountNumber = "TestValue1012143149",
                IfscCode = "TestValue832554729",
                AccountType = "TestValue1326408021",
                BankName = "TestValue157555597",
                BranchName = "TestValue1048360904",
                AadharNumber = "TestValue1295863941",
                PfNumber = "TestValue94251243",
                UanNumber = "TestValue1161588297",
                PfJoiningDate = DateTime.UtcNow,
                EligibleForPf = true,
                IsActive = (short)13296,
                Country = "TestValue921618742",
                State = "TestValue593712251",
                City = "TestValue1070576157",
                Pin = 970281994,
                EmployeeCredential = new EmployeeCredential
                {
                    Id = 964003762,
                    UserName = "TestValue100161193",
                    Password = "TestValue1227353799",
                    Status = (short)25875,
                    RequestedCompanyId = 1605004957,
                    Email = "TestValue669433571",
                    DefaultPassword = false,
                    GenerateOtp = "TestValue1445719023",
                    OtpExpiration = DateTime.UtcNow,
                    IsActive = (short)17536,
                    EmployeeLoginName = "TestValue1218682341",
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 1150567122,
                        Name = "TestValue1509426718",
                        PhoneNumber = "TestValue1592363662",
                        DomainName = "TestValue909035415",
                        Status = "TestValue846419822",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue1298804296",
                        IsActive = (short)12158,
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
                }
            };

            _accountDetails.Setup(mock => mock.InsertAccountDetails(It.IsAny<AccountDetail>())).Returns("TestValue1757717262");

            // Act
            var result = _testClass.InsertAccountDetails(accountDetail);

            // Assert
            _accountDetails.Verify(mock => mock.InsertAccountDetails(It.IsAny<AccountDetail>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallDeleteAccountDetails()
        {
            // Arrange
            var id = 1452665615;

            _accountDetails.Setup(mock => mock.deleteAccountDetails(It.IsAny<int>())).Returns(false);

            // Act
            var result = _testClass.DeleteAccountDetails(id);

            // Assert
            _accountDetails.Verify(mock => mock.deleteAccountDetails(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallSoftDelete()
        {
            // Arrange
            var id = 1396847923;
            var isActive = (short)3702;

            _accountDetails.Setup(mock => mock.SoftDelete(It.IsAny<int>(), It.IsAny<short>())).Returns(false);

            // Act
            var result = _testClass.SoftDelete(id, isActive);

            // Assert
            _accountDetails.Verify(mock => mock.SoftDelete(It.IsAny<int>(), It.IsAny<short>()));

            throw new NotImplementedException("Create or modify test");
        }
    }
}