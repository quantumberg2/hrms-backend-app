namespace HRMSunitTestCase.BusinessLogic.Implements
{
    using System;
    using System.Collections.Generic;
    using HRMS_Application.BusinessLogic.Implements;
    using HRMS_Application.Models;
    using Moq;
    using Xunit;

    public class AccountDetailsImpTests
    {
        private AccountDetailsImp _testClass;
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
        public void CanCalldeleteAccountDetails()
        {
            // Arrange
            var id = 1813711308;

            // Act
            var result = _testClass.deleteAccountDetails(id);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetAccountDetailsById()
        {
            // Arrange
            var id = 735964836;

            // Act
            var result = _testClass.GetAccountDetailsById(id);

            // Assert
            throw new NotImplementedException("Create or modify test");
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
        public void CanCallInsertAccountDetails()
        {
            // Arrange
            var accountDetail = new AccountDetail
            {
                Id = 545065848,
                EmployeeCredentialId = 1881374611,
                AccountNumber = "TestValue324363480",
                ConfirmAcNo = "TestValue593331517",
                IfscCode = "TestValue1669379251",
                ConfirmIfsc = "TestValue89524322",
                AccountType = "TestValue1626658646",
                BankName = "TestValue1220510568",
                BranchName = "TestValue404969330",
                AadharNumber = "TestValue1093493507",
                PfNumber = "TestValue1337961564",
                UanNumber = "TestValue1692167641",
                PfSchema = "TestValue209239436",
                PfJoiningDate = DateTime.UtcNow,
                EligibleForPf = false,
                EmployeeCredential = new EmployeeCredential
                {
                    Id = 1949994434,
                    UserName = "TestValue997087227",
                    Password = "TestValue55446845",
                    Status = (short)21406,
                    RequestedCompanyId = 2083594668,
                    Email = "TestValue1884722922",
                    DefaultPassword = false,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 466012889,
                        Name = "TestValue1078628886",
                        PhoneNumber = "TestValue1679567952",
                        DomainName = "TestValue638629830",
                        Status = "TestValue1421717803",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue267691164",
                        Department = new Department
                        {
                            Id = 191895759,
                            Name = "TestValue673310687",
                            RequestedCompanyId = 1620220858,
                            RequestedCompany = default(RequestedCompanyForm),
                            EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object
                        },
                        CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                        EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                        Positions = new Mock<ICollection<Position>>().Object
                    },
                    AccountDetails = new Mock<ICollection<AccountDetail>>().Object,
                    AddressInfos = new Mock<ICollection<AddressInfo>>().Object,
                    EmpPersonalInfos = new Mock<ICollection<EmpPersonalInfo>>().Object,
                    EmpSalaries = new Mock<ICollection<EmpSalary>>().Object,
                    EmployeeAttendances = new Mock<ICollection<EmployeeAttendance>>().Object,
                    EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object,
                    EmployeeLeaves = new Mock<ICollection<EmployeeLeave>>().Object,
                    Holidays = new Mock<ICollection<Holiday>>().Object,
                    LeaveTypes = new Mock<ICollection<LeaveType>>().Object,
                    UserRolesJs = new Mock<ICollection<UserRolesJ>>().Object
                },
                EmpPersonalInfos = new Mock<ICollection<EmpPersonalInfo>>().Object
            };

            // Act
            var result = _testClass.InsertAccountDetails(accountDetail);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }
    }
}