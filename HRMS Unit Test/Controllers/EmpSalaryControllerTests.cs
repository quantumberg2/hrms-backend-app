namespace HRMS_Unit_Test.Controllers
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
        private readonly EmpSalaryController _testClass;
        private readonly Mock<IEmployeeSalary> _empsalry;
        private readonly Mock<ILogger<EmpSalaryController>> _logger;

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
                Id = 1464058878,
                EmployeeCredentialId = 1820768029,
                SalaryRange = "TestValue770548162",
                AnnualIncome = 682383529.08M,
                Loan = 1806499950.75M,
                Insurance = 209593667.25M,
                IsActive = (short)11111,
                EmployeeCredential = new EmployeeCredential
                {
                    Id = 402444804,
                    UserName = "TestValue1821503698",
                    Password = "TestValue1532765468",
                    Status = (short)27702,
                    RequestedCompanyId = 518924543,
                    Email = "TestValue1704141027",
                    DefaultPassword = false,
                    GenerateOtp = "TestValue831663690",
                    OtpExpiration = DateTime.UtcNow,
                    IsActive = (short)7290,
                    EmployeeLoginName = "TestValue1345805269",
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 227840373,
                        Name = "TestValue646711990",
                        PhoneNumber = "TestValue518084508",
                        DomainName = "TestValue86722438",
                        Status = "TestValue810371293",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue177937108",
                        IsActive = (short)1973,
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
                    //DeviceTables = new Mock<ICollection<DeviceTable>>().Object,
                    EmpPersonalInfos = new Mock<ICollection<EmpPersonalInfo>>().Object,
                    EmpSalaries = new Mock<ICollection<EmpSalary>>().Object,
                    EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object,
                    EmployeeLeaveAllocations = new Mock<ICollection<EmployeeLeaveAllocation>>().Object,
                    LeaveTrackings = new Mock<ICollection<LeaveTracking>>().Object,
                    UserRolesJs = new Mock<ICollection<UserRolesJ>>().Object
                }
            };

            _empsalry.Setup(mock => mock.InsertEmpSalary(It.IsAny<EmpSalary>())).ReturnsAsync("TestValue2063120281");

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
            var id = 1947112838;

            _empsalry.Setup(mock => mock.deleteEmpsalary(It.IsAny<int>())).ReturnsAsync(true);

            // Act
            var result = await _testClass.DeleteEmpsalary(id);

            // Assert
            _empsalry.Verify(mock => mock.deleteEmpsalary(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallSoftDelete()
        {
            // Arrange
            var id = 1716832033;
            var isActive = (short)28788;

            _empsalry.Setup(mock => mock.SoftDelete(It.IsAny<int>(), It.IsAny<short>())).Returns(false);

            // Act
            var result = _testClass.SoftDelete(id, isActive);

            // Assert
            _empsalry.Verify(mock => mock.SoftDelete(It.IsAny<int>(), It.IsAny<short>()));

            throw new NotImplementedException("Create or modify test");
        }
    }
}