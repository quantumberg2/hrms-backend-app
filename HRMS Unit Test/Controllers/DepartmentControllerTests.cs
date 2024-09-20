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

    public class DepartmentControllerTests
    {
        private readonly DepartmentController _testClass;
        private readonly Mock<IDepartment> _department;
        private readonly Mock<ILogger<DepartmentController>> _logger;

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
        public void CanCallGetDepartmentsByName()
        {
            // Arrange
            var name = "TestValue333713848";

            _department.Setup(mock => mock.GetDepartmentsByName(It.IsAny<string>())).Returns(new List<Department>());

            // Act
            var result = _testClass.GetDepartmentsByName(name);

            // Assert
            _department.Verify(mock => mock.GetDepartmentsByName(It.IsAny<string>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallInsertDepartments()
        {
            // Arrange
            var department = new Department
            {
                Id = 1267420575,
                Name = "TestValue1722159908",
                RequestedCompanyId = 2018066746,
                IsActive = (short)3734,
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 404316770,
                    Name = "TestValue1226933723",
                    PhoneNumber = "TestValue285923838",
                    DomainName = "TestValue1055626069",
                    Status = "TestValue797089338",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Email = "TestValue1424781438",
                    IsActive = (short)21155,
                    CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                    Departments = new Mock<ICollection<Department>>().Object,
                    EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                    Holidays = new Mock<ICollection<Holiday>>().Object,
                    LeaveTypes = new Mock<ICollection<LeaveType>>().Object,
                    Positions = new Mock<ICollection<Position>>().Object
                },
                EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object
            };

            _department.Setup(mock => mock.InsertDepartment(It.IsAny<Department>())).ReturnsAsync("TestValue2073592075");

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
            var id = 870145925;
            var name = "TestValue614268264";
            var requestedcompanyId = 1512067543;

            _department.Setup(mock => mock.UpdateDepartment(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<int?>())).ReturnsAsync(new Department
            {
                Id = 151375346,
                Name = "TestValue791182037",
                RequestedCompanyId = 1607447361,
                IsActive = (short)31668,
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 1541703180,
                    Name = "TestValue1233881016",
                    PhoneNumber = "TestValue1426002413",
                    DomainName = "TestValue209074708",
                    Status = "TestValue696980295",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Email = "TestValue2053601795",
                    IsActive = (short)4572,
                    CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                    Departments = new Mock<ICollection<Department>>().Object,
                    EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                    Holidays = new Mock<ICollection<Holiday>>().Object,
                    LeaveTypes = new Mock<ICollection<LeaveType>>().Object,
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
            var id = 1347448562;

            _department.Setup(mock => mock.deleteDepartment(It.IsAny<int>())).ReturnsAsync(false);

            // Act
            var result = await _testClass.DeleteDepartment(id);

            // Assert
            _department.Verify(mock => mock.deleteDepartment(It.IsAny<int>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallSoftDelete()
        {
            // Arrange
            var id = 1459735789;
            var isActive = (short)24421;

            _department.Setup(mock => mock.SoftDelete(It.IsAny<int>(), It.IsAny<short>())).Returns(false);

            // Act
            var result = _testClass.SoftDelete(id, isActive);

            // Assert
            _department.Verify(mock => mock.SoftDelete(It.IsAny<int>(), It.IsAny<short>()));

            throw new NotImplementedException("Create or modify test");
        }
    }
}