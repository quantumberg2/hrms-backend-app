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
                Id = 1206097725,
                Name = "TestValue602027981",
                RequestedCompanyId = 1877651010,
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 336803008,
                    Name = "TestValue671307346",
                    PhoneNumber = "TestValue1732397321",
                    DomainName = "TestValue373251167",
                    Status = "TestValue1599745305",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Department = default(Department),
                    CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                    EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                    Positions = new Mock<ICollection<Position>>().Object
                },
                EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object
            };

            _department.Setup(mock => mock.InsertDepartment(It.IsAny<Department>())).ReturnsAsync("TestValue2079288112");

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
            var id = 547600649;
            var name = "TestValue1394663963";
            var requestedcompanyId = 1776466192;

            _department.Setup(mock => mock.UpdateDepartment(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<int?>())).ReturnsAsync(new Department
            {
                Id = 1598174389,
                Name = "TestValue1424548705",
                RequestedCompanyId = 693015560,
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 1375931423,
                    Name = "TestValue1225311611",
                    PhoneNumber = "TestValue1371754991",
                    DomainName = "TestValue1184862297",
                    Status = "TestValue1874987661",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
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
            var id = 2040508746;

            _department.Setup(mock => mock.deleteDepartment(It.IsAny<int>())).ReturnsAsync(false);

            // Act
            var result = await _testClass.DeleteDepartment(id);

            // Assert
            _department.Verify(mock => mock.deleteDepartment(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }
    }
}