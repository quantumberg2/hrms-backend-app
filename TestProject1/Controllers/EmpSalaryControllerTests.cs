namespace TestProject1.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using HRMS_Application.BusinessLogic.Interface;
    using HRMS_Application.Controllers;
    using HRMS_Application.Models;
    using Microsoft.Extensions.Logging;
    using Moq;
    using Xunit;

    public class EmpSalaryControllerTests
    {
        private EmpSalaryController _testClass;
        private Mock<IEmployeeSalary> _empsalry;
        private Mock<ILogger<EmpSalaryController>> _logger;

        public EmpSalaryControllerTests()
        {
            _empsalry = new Mock<IEmployeeSalary>();
            _logger = new Mock<ILogger<EmpSalaryController>>();
            _testClass = new EmpSalaryController(_empsalry.Object, _logger.Object);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new EmpSalaryController(_empsalry.Object, _logger.Object);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanCallGetAllEmpsalary()
        {
            // Arrange
            _empsalry.Setup(mock => mock.GetAllEmpSalary()).Returns(new List<EmpSalary>());

            // Act
            var result = _testClass.GetAllEmpsalary();

            // Assert
            _empsalry.Verify(mock => mock.GetAllEmpSalary());

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallInsertEmpsalary()
        {
            // Arrange
            var empSalary = new EmpSalary
            {
                Id = 1173968711,
                EmployeeCredentialId = 50096601,
                SalaryRange = "TestValue2021109936",
                AnnualIncome = 1109854655.91M,
                Loan = 885052015.65M,
                Insurance = 1045523809.44M,
                EmployeeCredential = new EmployeeCredential
                {
                    Id = 499121946,
                    UserName = "TestValue1491916157",
                    Password = "TestValue2083991258",
                    Status = (short)12752,
                    RequestedCompanyId = 2048122646,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 1246117316,
                        Name = "TestValue1640406621",
                        PhoneNumber = "TestValue2056852640",
                        DomainName = "TestValue344274713",
                        Status = "TestValue1711758078",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Department = new Department
                        {
                            Id = 1988170392,
                            Name = "TestValue797450087",
                            RequestedCompanyId = 893436312,
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
                }
            };

            _empsalry.Setup(mock => mock.InsertEmpSalary(It.IsAny<EmpSalary>())).ReturnsAsync("TestValue1144154194");

            // Act
            var result = await _testClass.InsertEmpsalary(empSalary);

            // Assert
            _empsalry.Verify(mock => mock.InsertEmpSalary(It.IsAny<EmpSalary>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallDeleteEmpsalary()
        {
            // Arrange
            var id = 152294843;

            _empsalry.Setup(mock => mock.deleteEmpsalary(It.IsAny<int>())).ReturnsAsync(true);

            // Act
            var result = await _testClass.DeleteEmpsalary(id);

            // Assert
            _empsalry.Verify(mock => mock.deleteEmpsalary(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }
    }
}