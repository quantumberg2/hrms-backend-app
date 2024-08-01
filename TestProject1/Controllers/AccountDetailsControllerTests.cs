namespace TestProject1.Controllers
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
        private AccountDetailsController _testClass;
        private Mock<IAccountDetails> _accountDetails;
        private Mock<ILogger<AccountDetailsController>> _logger;

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
        public void CanCallInsertDepartments()
        {
            // Arrange
            var accountDetail = new AccountDetail
            {
                Id = 1756909908,
                EmployeeCredentialId = 359374937,
                AccountNumber = "TestValue1398675230",
                ConfirmAcNo = "TestValue877696316",
                IfscCode = "TestValue868307502",
                ConfirmIfsc = "TestValue979267273",
                AccountType = "TestValue1816664298",
                BankName = "TestValue79856424",
                BranchName = "TestValue890695686",
                AadharNumber = "TestValue968506966",
                PfNumber = "TestValue860036525",
                UanNumber = "TestValue791726744",
                PfSchema = "TestValue366784070",
                PfJoiningDate = DateTime.UtcNow,
                EligibleForPf = false,
                EmployeeCredential = new EmployeeCredential
                {
                    Id = 1730935742,
                    UserName = "TestValue75998401",
                    Password = "TestValue1029202571",
                    Status = (short)16770,
                    RequestedCompanyId = 550803609,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 926440422,
                        Name = "TestValue425073925",
                        PhoneNumber = "TestValue1502875327",
                        DomainName = "TestValue1657736525",
                        Status = "TestValue51023312",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Department = new Department
                        {
                            Id = 794114170,
                            Name = "TestValue416137287",
                            RequestedCompanyId = 954950226,
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

            _accountDetails.Setup(mock => mock.InsertAccountDetails(It.IsAny<AccountDetail>())).Returns("TestValue273482402");

            // Act
            var result = _testClass.InsertDepartments(accountDetail);

            // Assert
            _accountDetails.Verify(mock => mock.InsertAccountDetails(It.IsAny<AccountDetail>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallDeleteAccountDetails()
        {
            // Arrange
            var id = 1929183981;

            _accountDetails.Setup(mock => mock.deleteAccountDetails(It.IsAny<int>())).Returns(false);

            // Act
            var result = _testClass.DeleteAccountDetails(id);

            // Assert
            _accountDetails.Verify(mock => mock.deleteAccountDetails(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }
    }
}