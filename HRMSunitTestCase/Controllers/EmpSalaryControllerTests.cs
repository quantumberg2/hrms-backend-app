namespace HRMSunitTestCase.Controllers
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
                Id = 2109145700,
                EmployeeCredentialId = 895452728,
                SalaryRange = "TestValue102697641",
                AnnualIncome = 659543281.65M,
                Loan = 793342292.49M,
                Insurance = 1857940247.79M,
                EmployeeCredential = new EmployeeCredential
                {
                    Id = 488369144,
                    UserName = "TestValue1475564069",
                    Password = "TestValue1621328679",
                    Status = (short)1632,
                    RequestedCompanyId = 1669594796,
                    Email = "TestValue475867180",
                    DefaultPassword = true,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 809414908,
                        Name = "TestValue1729129865",
                        PhoneNumber = "TestValue2099687030",
                        DomainName = "TestValue1077165028",
                        Status = "TestValue154234404",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue1530978005",
                        Department = new Department
                        {
                            Id = 59880247,
                            Name = "TestValue74451446",
                            RequestedCompanyId = 1495081874,
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
                }
            };

            _empsalry.Setup(mock => mock.InsertEmpSalary(It.IsAny<EmpSalary>())).ReturnsAsync("TestValue1703460260");

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
            var id = 126410131;

            _empsalry.Setup(mock => mock.deleteEmpsalary(It.IsAny<int>())).ReturnsAsync(false);

            // Act
            var result = await _testClass.DeleteEmpsalary(id);

            // Assert
            _empsalry.Verify(mock => mock.deleteEmpsalary(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }
    }
}