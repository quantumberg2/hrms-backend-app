namespace HRMS_Unit_Test.BusinessLogic.Implements
{
    using System;
    using System.Collections.Generic;
    using HRMS_Application.BusinessLogic.Implements;
    using HRMS_Application.Models;
    using Moq;
    using Xunit;

    public class AccountDetailsImpTests
    {
        private readonly AccountDetailsImp _testClass;
        private HRMSContext _context;

        public AccountDetailsImpTests()
        {
            _context = new HRMSContext();
            _testClass = new AccountDetailsImp(_context);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new AccountDetailsImp(_context);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanCallGetAllAccountdetails()
        {
            // Act
            var result = _testClass.GetAllAccountdetails();

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetAccountDetailsById()
        {
            // Arrange
            var id = 1540153590;

            // Act
            var result = _testClass.GetAccountDetailsById(id);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetAccountDetailsByAccNumber()
        {
            // Arrange
            var accountNumber = "TestValue715214774";

            // Act
            var result = _testClass.GetAccountDetailsByAccNumber(accountNumber);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallInsertAccountDetails()
        {
            // Arrange
            var accountDetail = new AccountDetail
            {
                Id = 222532061,
                EmployeeCredentialId = 1948140358,
                AccountNumber = "TestValue1143391473",
                IfscCode = "TestValue325876005",
                AccountType = "TestValue1495806847",
                BankName = "TestValue800537314",
                BranchName = "TestValue810865388",
                AadharNumber = "TestValue774454845",
                PfNumber = "TestValue593840121",
                UanNumber = "TestValue31231027",
                PfJoiningDate = DateTime.UtcNow,
                EligibleForPf = true,
                IsActive = (short)1074,
                Country = "TestValue800619629",
                State = "TestValue1695381045",
                City = "TestValue721704779",
                Pin = 1719149899,
                EmployeeCredential = new EmployeeCredential
                {
                    Id = 1268541431,
                    UserName = "TestValue421598764",
                    Password = "TestValue559173542",
                    Status = (short)26457,
                    RequestedCompanyId = 77779009,
                    Email = "TestValue36261313",
                    DefaultPassword = true,
                    GenerateOtp = "TestValue367602858",
                    OtpExpiration = DateTime.UtcNow,
                    IsActive = (short)6660,
                    EmployeeLoginName = "TestValue1279962030",
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 319338864,
                        Name = "TestValue1766541887",
                        PhoneNumber = "TestValue1616773518",
                        DomainName = "TestValue1621855993",
                        Status = "TestValue125139454",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue2147288549",
                        IsActive = (short)11250,
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

            // Act
            var result = _testClass.InsertAccountDetails(accountDetail);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCalldeleteAccountDetails()
        {
            // Arrange
            var id = 1285323478;

            // Act
            var result = _testClass.deleteAccountDetails(id);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallSoftDelete()
        {
            // Arrange
            var id = 301368875;
            var isActive = (short)27944;

            // Act
            var result = _testClass.SoftDelete(id, isActive);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }
    }
}