namespace HRMSunitTestCase.BusinessLogic.Implements
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
        private DepartmentsImp _testClass;
        private HRMSContext _hrmsContext;
        private Mock<IHttpContextAccessor> _httpContextAccessor;
        private Mock<IJwtUtils> _jwtUtils;

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
            var id = 1905521914;

            _jwtUtils.Setup(mock => mock.ValidateJwtToken(It.IsAny<string>())).Returns(2127074600);

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
            var id = 885099899;

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
                Id = 2034028551,
                Name = "TestValue837033840",
                RequestedCompanyId = 967853394,
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 1971549031,
                    Name = "TestValue2024342909",
                    PhoneNumber = "TestValue36515433",
                    DomainName = "TestValue1732072598",
                    Status = "TestValue346464321",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Email = "TestValue1458700574",
                    Department = default(Department),
                    CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                    EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                    Positions = new Mock<ICollection<Position>>().Object
                },
                EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object
            };

            _jwtUtils.Setup(mock => mock.ValidateJwtToken(It.IsAny<string>())).Returns(1574453015);

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
            var id = 1228615077;
            var name = "TestValue472689858";
            var requestedcompanyId = 1194284367;

            // Act
            var result = await _testClass.UpdateDepartment(id, name, requestedcompanyId);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }
    }
}