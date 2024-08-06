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
            var id = 499775799;

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
            var id = 29901646;

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
                Id = 150379638,
                UserName = "TestValue79140285",
                Password = "TestValue102053794",
                Status = (short)1343,
                RequestedCompanyId = 1034381191,
                Email = "TestValue543505186",
                DefaultPassword = false,
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 1024228528,
                    Name = "TestValue1891671124",
                    PhoneNumber = "TestValue1813418964",
                    DomainName = "TestValue1190847523",
                    Status = "TestValue1096119119",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Email = "TestValue1296847060",
                    Department = new Department
                    {
                        Id = 313268578,
                        Name = "TestValue1855780341",
                        RequestedCompanyId = 1282187259,
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
            var id = 1867998601;
            var username = "TestValue2062803850";
            var password = "TestValue807117145";
            var status = (short)12856;
            var requestedCompanyId = 646000542;

            // Act
            var result = await _testClass.UpdateEmployeeCredentials(id, username, password, status, requestedCompanyId);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }
    }
}