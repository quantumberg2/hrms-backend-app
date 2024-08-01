namespace TestProject1.BusinessLogic.Implements
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
            var id = 1460268847;

            // Act
            var result = _testClass.deleteAccountDetails(id);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetAccountDetailsById()
        {
            // Arrange
            var id = 668589866;

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
                Id = 1348193731,
                EmployeeCredentialId = 1490887494,
                AccountNumber = "TestValue1565696267",
                ConfirmAcNo = "TestValue1260830969",
                IfscCode = "TestValue1110537318",
                ConfirmIfsc = "TestValue1972166726",
                AccountType = "TestValue1116665423",
                BankName = "TestValue2110835005",
                BranchName = "TestValue241370792",
                AadharNumber = "TestValue331942071",
                PfNumber = "TestValue411359850",
                UanNumber = "TestValue1386172737",
                PfSchema = "TestValue821648148",
                PfJoiningDate = DateTime.UtcNow,
                EligibleForPf = true,
                EmployeeCredential = new EmployeeCredential
                {
                    Id = 1720637341,
                    UserName = "TestValue36367051",
                    Password = "TestValue552393178",
                    Status = (short)16760,
                    RequestedCompanyId = 1813522819,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 25413548,
                        Name = "TestValue1675518532",
                        PhoneNumber = "TestValue307982837",
                        DomainName = "TestValue1854530864",
                        Status = "TestValue1639870030",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Department = new Department
                        {
                            Id = 341702772,
                            Name = "TestValue1430420281",
                            RequestedCompanyId = 1495347401,
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