namespace HRMS_Unit_Test.Models
{
    using System;
    using System.Collections.Generic;
    using HRMS_Application.Models;
    using Moq;
    using Xunit;

    public partial class UserRolesJTests
    {
        private readonly UserRolesJ _testClass;

        public UserRolesJTests()
        {
            _testClass = new UserRolesJ();
        }

        [Fact]
        public void CanSetAndGetId()
        {
            // Arrange
            var testValue = 1517241596;

            // Act
            _testClass.Id = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Id);
        }

        [Fact]
        public void CanSetAndGetEmployeeCredentialId()
        {
            // Arrange
            var testValue = 732566250;

            // Act
            _testClass.EmployeeCredentialId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.EmployeeCredentialId);
        }

        [Fact]
        public void CanSetAndGetRolesId()
        {
            // Arrange
            var testValue = 46008713;

            // Act
            _testClass.RolesId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.RolesId);
        }

        [Fact]
        public void CanSetAndGetIsActive()
        {
            // Arrange
            var testValue = (short)17595;

            // Act
            _testClass.IsActive = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.IsActive);
        }

        [Fact]
        public void CanSetAndGetEmployeeCredential()
        {
            // Arrange
            var testValue = new EmployeeCredential
            {
                Id = 1987333651,
                UserName = "TestValue48712321",
                Password = "TestValue1417781993",
                Status = (short)27977,
                RequestedCompanyId = 1963925912,
                Email = "TestValue814023713",
                DefaultPassword = true,
                GenerateOtp = "TestValue1675981622",
                OtpExpiration = DateTime.UtcNow,
                IsActive = (short)15527,
                EmployeeLoginName = "TestValue915497678",
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 546244564,
                    Name = "TestValue160599157",
                    PhoneNumber = "TestValue1445558237",
                    DomainName = "TestValue593596436",
                    Status = "TestValue2020941697",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Email = "TestValue1414704869",
                    IsActive = (short)6630,
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
            };

            // Act
            _testClass.EmployeeCredential = testValue;

            // Assert
            Assert.Same(testValue, _testClass.EmployeeCredential);
        }

        [Fact]
        public void CanSetAndGetRoles()
        {
            // Arrange
            var testValue = new Role
            {
                Id = 706452843,
                Name = "TestValue725646520",
                IsActive = (short)14633,
                UserRolesJs = new Mock<ICollection<UserRolesJ>>().Object
            };

            // Act
            _testClass.Roles = testValue;

            // Assert
            Assert.Same(testValue, _testClass.Roles);
        }
    }
}