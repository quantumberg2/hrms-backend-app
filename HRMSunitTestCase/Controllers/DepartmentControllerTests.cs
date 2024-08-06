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

    public class DepartmentControllerTests
    {
        private DepartmentController _testClass;
        private Mock<IDepartment> _department;
        private Mock<ILogger<DepartmentController>> _logger;

        public DepartmentControllerTests()
        {
            _department = new Mock<IDepartment>();
            _logger = new Mock<ILogger<DepartmentController>>();
            _testClass = new DepartmentController(_department.Object, _logger.Object);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new DepartmentController(_department.Object, _logger.Object);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanCallGetAllDepartments()
        {
            // Arrange
            _department.Setup(mock => mock.GetAllDepartment()).Returns(new List<Department>());

            // Act
            var result = _testClass.GetAllDepartments();

            // Assert
            _department.Verify(mock => mock.GetAllDepartment());

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallInsertDepartments()
        {
            // Arrange
            var department = new Department
            {
                Id = 741987660,
                Name = "TestValue1896309557",
                RequestedCompanyId = 1815176146,
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 1689386188,
                    Name = "TestValue550320494",
                    PhoneNumber = "TestValue1274484374",
                    DomainName = "TestValue2082348147",
                    Status = "TestValue1765545582",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Email = "TestValue358315014",
                    Department = default(Department),
                    CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                    EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                    Positions = new Mock<ICollection<Position>>().Object
                },
                EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object
            };

            _department.Setup(mock => mock.InsertDepartment(It.IsAny<Department>())).ReturnsAsync("TestValue1418044533");

            // Act
            var result = await _testClass.InsertDepartments(department);

            // Assert
            _department.Verify(mock => mock.InsertDepartment(It.IsAny<Department>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallUpdateDepartment()
        {
            // Arrange
            var id = 1955012774;
            var name = "TestValue48501686";
            var requestedcompanyId = 1443374302;

            _department.Setup(mock => mock.UpdateDepartment(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<int?>())).ReturnsAsync(new Department
            {
                Id = 1399646938,
                Name = "TestValue1959110494",
                RequestedCompanyId = 323565946,
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 1518190496,
                    Name = "TestValue441498364",
                    PhoneNumber = "TestValue1146322766",
                    DomainName = "TestValue1756846823",
                    Status = "TestValue1155057114",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Email = "TestValue1725346674",
                    Department = default(Department),
                    CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                    EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                    Positions = new Mock<ICollection<Position>>().Object
                },
                EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object
            });

            // Act
            var result = await _testClass.UpdateDepartment(id, name, requestedcompanyId);

            // Assert
            _department.Verify(mock => mock.UpdateDepartment(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<int?>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallDeleteDepartment()
        {
            // Arrange
            var id = 1485943540;

            _department.Setup(mock => mock.deleteDepartment(It.IsAny<int>())).ReturnsAsync(false);

            // Act
            var result = await _testClass.DeleteDepartment(id);

            // Assert
            _department.Verify(mock => mock.deleteDepartment(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }
    }
}