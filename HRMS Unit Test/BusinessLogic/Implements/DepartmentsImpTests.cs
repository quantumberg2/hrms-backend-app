namespace HRMS_Unit_Test.BusinessLogic.Implements
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using HRMS_Application.Authorization;
    using HRMS_Application.BusinessLogic.Implements;
    using HRMS_Application.Models;
    using Microsoft.AspNetCore.Http;
    using Moq;
    using Xunit;

    public class DepartmentsImpTests
    {
        private readonly DepartmentsImp _testClass;
        private HRMSContext _hrmsContext;
        private readonly Mock<IHttpContextAccessor> _httpContextAccessor;
        private readonly Mock<IJwtUtils> _jwtUtils;

        public DepartmentsImpTests()
        {
            _hrmsContext = new HRMSContext();
            _httpContextAccessor = new Mock<IHttpContextAccessor>();
            _jwtUtils = new Mock<IJwtUtils>();
            _testClass = new DepartmentsImp(_hrmsContext, _httpContextAccessor.Object, _jwtUtils.Object);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new DepartmentsImp(_hrmsContext, _httpContextAccessor.Object, _jwtUtils.Object);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public async Task CanCalldeleteDepartment()
        {
            // Arrange
            var id = 1059945110;

            _jwtUtils.Setup(mock => mock.ValidateJwtToken(It.IsAny<string>())).Returns(1591286846);

            // Act
            var result = await _testClass.deleteDepartment(id);

            // Assert
            _jwtUtils.Verify(mock => mock.ValidateJwtToken(It.IsAny<string>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetAllDepartment()
        {
            // Act
            var result = _testClass.GetAllDepartment();

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetDepartmentById()
        {
            // Arrange
            var id = 713819668;

            // Act
            var result = _testClass.GetDepartmentById(id);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallInsertDepartment()
        {
            // Arrange
            var department = new Department
            {
                Id = 1551367165,
                Name = "TestValue1358591935",
                RequestedCompanyId = 556291736,
                IsActive = (short)16834,
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 630935733,
                    Name = "TestValue1673292904",
                    PhoneNumber = "TestValue1385211015",
                    DomainName = "TestValue1398364489",
                    Status = "TestValue170494215",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Email = "TestValue806617993",
                    IsActive = (short)29145,
                    CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                    Departments = new Mock<ICollection<Department>>().Object,
                    EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                    Holidays = new Mock<ICollection<Holiday>>().Object,
                    LeaveTypes = new Mock<ICollection<LeaveType>>().Object,
                    Positions = new Mock<ICollection<Position>>().Object
                },
                EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object
            };

            _jwtUtils.Setup(mock => mock.ValidateJwtToken(It.IsAny<string>())).Returns(53103466);

            // Act
            var result = await _testClass.InsertDepartment(department);

            // Assert
            _jwtUtils.Verify(mock => mock.ValidateJwtToken(It.IsAny<string>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallUpdateDepartment()
        {
            // Arrange
            var id = 847522756;
            var name = "TestValue794003813";
            var requestedcompanyId = 273902707;

            // Act
            var result = await _testClass.UpdateDepartment(id, name, requestedcompanyId);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallSoftDelete()
        {
            // Arrange
            var id = 330267794;
            var isActive = (short)28568;

            // Act
            var result = _testClass.SoftDelete(id, isActive);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetDepartmentsByName()
        {
            // Arrange
            var name = "TestValue1328167099";

            // Act
            var result = _testClass.GetDepartmentsByName(name);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }
    }
}