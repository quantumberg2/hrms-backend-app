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

    public class EmployeeSalaryImpTests
    {
        private EmployeeSalaryImp _testClass;
        private HRMSContext _context;
        private Mock<IHttpContextAccessor> _httpContextAccessor;
        private Mock<IJwtUtils> _jwtUtils;

        public EmployeeSalaryImpTests()
        {
            _context = new HRMSContext();
            _httpContextAccessor = new Mock<IHttpContextAccessor>();
            _jwtUtils = new Mock<IJwtUtils>();
            _testClass = new EmployeeSalaryImp(_context, _httpContextAccessor.Object, _jwtUtils.Object);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new EmployeeSalaryImp(_context, _httpContextAccessor.Object, _jwtUtils.Object);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public async Task CanCalldeleteEmpsalary()
        {
            // Arrange
            var id = 1227365757;

            _jwtUtils.Setup(mock => mock.ValidateJwtToken(It.IsAny<string>())).Returns(789104917);

            // Act
            var result = await _testClass.deleteEmpsalary(id);

            // Assert
            _jwtUtils.Verify(mock => mock.ValidateJwtToken(It.IsAny<string>()));

            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetAllEmpSalary()
        {
            // Act
            var result = _testClass.GetAllEmpSalary();

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallGetEmpSalaryById()
        {
            // Arrange
            var id = 1460462980;

            // Act
            var result = _testClass.GetEmpSalaryById(id);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CanCallInsertEmpSalary()
        {
            // Arrange
            var empSalary = new EmpSalary
            {
                Id = 384241348,
                EmployeeCredentialId = 1724429817,
                SalaryRange = "TestValue1751609305",
                AnnualIncome = 961703047.8M,
                Loan = 1718771125.5M,
                Insurance = 1367298356.49M,
                EmployeeCredential = new EmployeeCredential
                {
                    Id = 1873036894,
                    UserName = "TestValue1592670059",
                    Password = "TestValue1434055887",
                    Status = (short)31066,
                    RequestedCompanyId = 1630253441,
                    Email = "TestValue1097080997",
                    DefaultPassword = false,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 141084505,
                        Name = "TestValue1753434393",
                        PhoneNumber = "TestValue1007693895",
                        DomainName = "TestValue1977688377",
                        Status = "TestValue505264439",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue439521200",
                        Department = new Department
                        {
                            Id = 79295525,
                            Name = "TestValue1014658042",
                            RequestedCompanyId = 1574133596,
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

            // Act
            var result = await _testClass.InsertEmpSalary(empSalary);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }
    }
}