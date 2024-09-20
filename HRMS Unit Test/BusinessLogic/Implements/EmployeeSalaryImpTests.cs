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

    public class EmployeeSalaryImpTests
    {
        private readonly EmployeeSalaryImp _testClass;
        private HRMSContext _context;
        private readonly Mock<IHttpContextAccessor> _httpContextAccessor;
        private readonly Mock<IJwtUtils> _jwtUtils;

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
            var id = 1495640883;

            _jwtUtils.Setup(mock => mock.ValidateJwtToken(It.IsAny<string>())).Returns(963676786);

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
            var id = 1657720422;

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
                Id = 647865385,
                EmployeeCredentialId = 1316105889,
                SalaryRange = "TestValue739361442",
                AnnualIncome = 769595234.76M,
                Loan = 758050277.49M,
                Insurance = 1621871818.38M,
                IsActive = (short)4028,
                EmployeeCredential = new EmployeeCredential
                {
                    Id = 511242640,
                    UserName = "TestValue1826969757",
                    Password = "TestValue1291440500",
                    Status = (short)2948,
                    RequestedCompanyId = 1851004188,
                    Email = "TestValue79251199",
                    DefaultPassword = false,
                    GenerateOtp = "TestValue752272191",
                    OtpExpiration = DateTime.UtcNow,
                    IsActive = (short)18236,
                    EmployeeLoginName = "TestValue2001664501",
                    RequestedCompany = new RequestedCompanyForm
                    {
                        Id = 1810254777,
                        Name = "TestValue124178788",
                        PhoneNumber = "TestValue1405718172",
                        DomainName = "TestValue1221704867",
                        Status = "TestValue1409689828",
                        InsertedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Email = "TestValue1269718070",
                        IsActive = (short)24716,
                        CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                        Departments = new Mock<ICollection<Department>>().Object,
                        EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                        Holidays = new Mock<ICollection<Holiday>>().Object,
                        LeaveTypes = new Mock<ICollection<LeaveType>>().Object,
                        Positions = new Mock<ICollection<Position>>().Object
                    },
                    AccountDetails = new Mock<ICollection<AccountDetail>>().Object,
                    AddressInfos = new Mock<ICollection<AddressInfo>>().Object,
                    Attendances = new Mock<ICollection<Attendance>>().Object,
                    DeviceTables = new Mock<ICollection<DeviceTable>>().Object,
                    EmpPersonalInfos = new Mock<ICollection<EmpPersonalInfo>>().Object,
                    EmpSalaries = new Mock<ICollection<EmpSalary>>().Object,
                    EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object,
                    EmployeeLeaveAllocations = new Mock<ICollection<EmployeeLeaveAllocation>>().Object,
                    LeaveTrackings = new Mock<ICollection<LeaveTracking>>().Object,
                    UserRolesJs = new Mock<ICollection<UserRolesJ>>().Object
                }
            };

            // Act
            var result = await _testClass.InsertEmpSalary(empSalary);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanCallSoftDelete()
        {
            // Arrange
            var id = 786596547;
            var isActive = (short)18635;

            // Act
            var result = _testClass.SoftDelete(id, isActive);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }
    }
}