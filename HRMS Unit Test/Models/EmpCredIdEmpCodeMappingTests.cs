namespace HRMS_Unit_Test.Models
{
    using System;
    using System.Collections.Generic;
    using HRMS_Application.Models;
    using Moq;
    using Xunit;

    public partial class EmpCredIdEmpCodeMappingTests
    {
        private readonly EmpCredIdEmpCodeMapping _testClass;

        public EmpCredIdEmpCodeMappingTests()
        {
            _testClass = new EmpCredIdEmpCodeMapping();
        }

        [Fact]
        public void CanSetAndGetId()
        {
            // Arrange
            var testValue = 461210343;

            // Act
            _testClass.Id = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Id);
        }

        [Fact]
        public void CanSetAndGetEmpCredId()
        {
            // Arrange
            var testValue = 1601139431;

            // Act
            _testClass.EmpCredId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.EmpCredId);
        }

        [Fact]
        public void CanSetAndGetEmpCode()
        {
            // Arrange
            var testValue = 741061895;

            // Act
            _testClass.EmpCode = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.EmpCode);
        }

        [Fact]
        public void CanSetAndGetEmpCred()
        {
            // Arrange
            var testValue = new EmployeeCredential
            {
                Id = 1684748960,
                UserName = "TestValue1866000935",
                Password = "TestValue1199197079",
                Status = (short)24832,
                RequestedCompanyId = 466281447,
                Email = "TestValue1913292408",
                DefaultPassword = true,
                GenerateOtp = "TestValue1555137326",
                OtpExpiration = DateTime.UtcNow,
                IsActive = (short)2732,
                EmployeeLoginName = "TestValue233371932",
                ResignedDate = DateTime.UtcNow,
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 1233731063,
                    Name = "TestValue1872591324",
                    PhoneNumber = "TestValue1439286393",
                    DomainName = "TestValue1930050274",
                    Status = "TestValue79465566",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Email = "TestValue1283309963",
                    IsActive = (short)32389,
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
                EmpCredIdEmpCodeMappings = new Mock<ICollection<EmpCredIdEmpCodeMapping>>().Object,
                EmpPersonalInfos = new Mock<ICollection<EmpPersonalInfo>>().Object,
                EmpSalaries = new Mock<ICollection<EmpSalary>>().Object,
                EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object,
                EmployeeLeaveAllocations = new Mock<ICollection<EmployeeLeaveAllocation>>().Object,
                LeaveTrackings = new Mock<ICollection<LeaveTracking>>().Object,
                UserRolesJs = new Mock<ICollection<UserRolesJ>>().Object
            };

            // Act
            _testClass.EmpCred = testValue;

            // Assert
            Assert.Same(testValue, _testClass.EmpCred);
        }
    }
}