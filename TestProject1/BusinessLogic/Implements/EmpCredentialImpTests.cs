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

    public class EmpCredentialImpTests
    {
        private EmpCredentialImp _testClass;
        private HRMSContext _context;
        private Mock<IHttpContextAccessor> _httpContextAccessor;
        private Mock<IJwtUtils> _jwtUtils;

        public EmpCredentialImpTests()
        {
            _context = new HRMSContext();
            _httpContextAccessor = new Mock<IHttpContextAccessor>();
            _jwtUtils = new Mock<IJwtUtils>();
            _testClass = new EmpCredentialImp(_context, _httpContextAccessor.Object, _jwtUtils.Object);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new EmpCredentialImp(_context, _httpContextAccessor.Object, _jwtUtils.Object);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public async Task CanCallDeleteEmployeeCredential()
        {
            // Arrange
            var id = 1809260954;

            // Act
            var result = await _testClass.DeleteEmployeeCredential(id);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetAllEmpCredential()
        {
            // Act
            var result = _testClass.GetAllEmpCredential();

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetById()
        {
            // Arrange
            var id = 1838686685;

            // Act
            var result = _testClass.GetById(id);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallInsertEmployeeCredential()
        {
            // Arrange
            var employeeCredential = new EmployeeCredential
            {
                Id = 341716232,
                UserName = "TestValue1121846342",
                Password = "TestValue187476695",
                Status = (short)22554,
                RequestedCompanyId = 1396803851,
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 779944739,
                    Name = "TestValue2062913484",
                    PhoneNumber = "TestValue1446541934",
                    DomainName = "TestValue1116124159",
                    Status = "TestValue7480586",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Department = new Department
                    {
                        Id = 228947452,
                        Name = "TestValue48815579",
                        RequestedCompanyId = 1600622146,
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
            };

            // Act
            var result = await _testClass.InsertEmployeeCredential(employeeCredential);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallUpdateEmployeeCredentials()
        {
            // Arrange
            var id = 950758163;
            var username = "TestValue2028494798";
            var password = "TestValue944298164";
            var status = (short)32334;
            var requestedCompanyId = 258685414;

            // Act
            var result = await _testClass.UpdateEmployeeCredentials(id, username, password, status, requestedCompanyId);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }
    }
}