namespace HRMSunitTestCase.Controllers
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
                Id = 787885911,
                EmployeeCredentialId = 1190059177,
                AccountNumber = "TestValue1541684067",
                ConfirmAcNo = "TestValue516338179",
                IfscCode = "TestValue1211220563",
                ConfirmIfsc = "TestValue1723618123",
                AccountType = "TestValue564110231",
                BankName = "TestValue1658655153",
                BranchName = "TestValue1595847639",
                AadharNumber = "TestValue90080951",
                PfNumber = "TestValue1981112389",
                UanNumber = "TestValue1487395658",
                PfSchema = "TestValue1924929895",
                PfJoiningDate = DateTime.UtcNow,
                EligibleForPf = true,
                EmployeeCredential = new EmployeeCredential
                {
                    Id = 587579403,
                    UserName = "TestValue874721199",
                    Password = "TestValue471501178",
                    Status = (short)20415,
                    RequestedCompanyId = 1992577681,
                    Email = "TestValue1759346963",
                    DefaultPassword = false,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 675390118,
                        Name = "TestValue987913922",
                        PhoneNumber = "TestValue757526099",
                        DomainName = "TestValue1642089917",
                        Status = "TestValue817061361",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue979376741",
                        Department = new Department
                        {
                            Id = 2101226194,
                            Name = "TestValue1682719787",
                            RequestedCompanyId = 434332931,
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

            _accountDetails.Setup(mock => mock.InsertAccountDetails(It.IsAny<AccountDetail>())).Returns("TestValue1072122803");

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
            var id = 1224879060;

            _accountDetails.Setup(mock => mock.deleteAccountDetails(It.IsAny<int>())).Returns(true);

            // Act
            var result = _testClass.DeleteAccountDetails(id);

            // Assert
            _accountDetails.Verify(mock => mock.deleteAccountDetails(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }
    }
}