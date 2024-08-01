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
            var id = 1183110908;

            _jwtUtils.Setup(mock => mock.ValidateJwtToken(It.IsAny<string>())).Returns(1762073041);

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
            var id = 1047147786;

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
                Id = 551762959,
                EmployeeCredentialId = 144638683,
                SalaryRange = "TestValue955951481",
                AnnualIncome = 1333291695.12M,
                Loan = 256129526.07M,
                Insurance = 1107962861.94M,
                EmployeeCredential = new EmployeeCredential
                {
                    Id = 1662546910,
                    UserName = "TestValue1964545983",
                    Password = "TestValue1368210909",
                    Status = (short)13828,
                    RequestedCompanyId = 639361250,
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 1549369813,
                        Name = "TestValue460152316",
                        PhoneNumber = "TestValue1814721427",
                        DomainName = "TestValue1842007689",
                        Status = "TestValue1898192113",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Department = new Department
                        {
                            Id = 1038746013,
                            Name = "TestValue44357848",
                            RequestedCompanyId = 1095404016,
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
                }
            };

            // Act
            var result = await _testClass.InsertEmpSalary(empSalary);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }
    }
}