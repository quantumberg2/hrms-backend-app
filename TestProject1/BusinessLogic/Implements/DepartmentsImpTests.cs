namespace TestProject1.BusinessLogic.Implements
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
            var id = 877081814;

            _jwtUtils.Setup(mock => mock.ValidateJwtToken(It.IsAny<string>())).Returns(148471798);

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
            var id = 25322137;

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
                Id = 1058365880,
                Name = "TestValue1143109428",
                RequestedCompanyId = 192376482,
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 2073493485,
                    Name = "TestValue856775948",
                    PhoneNumber = "TestValue1524944822",
                    DomainName = "TestValue436475629",
                    Status = "TestValue1799379398",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Department = default(Department),
                    CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                    EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                    Positions = new Mock<ICollection<Position>>().Object
                },
                EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object
            };

            _jwtUtils.Setup(mock => mock.ValidateJwtToken(It.IsAny<string>())).Returns(2093059790);

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
            var id = 219695830;
            var name = "TestValue2147367616";
            var requestedcompanyId = 1177101819;

            // Act
            var result = await _testClass.UpdateDepartment(id, name, requestedcompanyId);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }
    }
}