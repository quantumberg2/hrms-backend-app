namespace HRMS_Unit_Test.Models
{
    using System;
    using System.Collections.Generic;
    using HRMS_Application.Models;
    using Moq;
    using Xunit;

    public partial class EmployeeDetailTests
    {
        private readonly EmployeeDetail _testClass;

        public EmployeeDetailTests()
        {
            _testClass = new EmployeeDetail();
        }

        [Fact]
        public void CanSetAndGetId()
        {
            // Arrange
            var testValue = 1141425080;

            // Act
            _testClass.Id = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Id);
        }

        [Fact]
        public void CanSetAndGetDeptId()
        {
            // Arrange
            var testValue = 1068033616;

            // Act
            _testClass.DeptId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.DeptId);
        }

        [Fact]
        public void CanSetAndGetFirstName()
        {
            // Arrange
            var testValue = "TestValue764380113";

            // Act
            _testClass.FirstName = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.FirstName);
        }

        [Fact]
        public void CanSetAndGetMiddleName()
        {
            // Arrange
            var testValue = "TestValue1316357759";

            // Act
            _testClass.MiddleName = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.MiddleName);
        }

        [Fact]
        public void CanSetAndGetLastName()
        {
            // Arrange
            var testValue = "TestValue1164219169";

            // Act
            _testClass.LastName = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.LastName);
        }

        [Fact]
        public void CanSetAndGetPositionId()
        {
            // Arrange
            var testValue = 117273196;

            // Act
            _testClass.PositionId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.PositionId);
        }

        [Fact]
        public void CanSetAndGetEmployeeCredentialId()
        {
            // Arrange
            var testValue = 1201093711;

            // Act
            _testClass.EmployeeCredentialId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.EmployeeCredentialId);
        }

        [Fact]
        public void CanSetAndGetEmployeeNumber()
        {
            // Arrange
            var testValue = "TestValue249889418";

            // Act
            _testClass.EmployeeNumber = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.EmployeeNumber);
        }

        [Fact]
        public void CanSetAndGetEmail()
        {
            // Arrange
            var testValue = "TestValue42047017";

            // Act
            _testClass.Email = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Email);
        }

        [Fact]
        public void CanSetAndGetRequestCompanyId()
        {
            // Arrange
            var testValue = 385580130;

            // Act
            _testClass.RequestCompanyId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.RequestCompanyId);
        }

        [Fact]
        public void CanSetAndGetIsActive()
        {
            // Arrange
            var testValue = (short)9942;

            // Act
            _testClass.IsActive = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.IsActive);
        }

        [Fact]
        public void CanSetAndGetManagerId()
        {
            // Arrange
            var testValue = 428570368;

            // Act
            _testClass.ManagerId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.ManagerId);
        }

        [Fact]
        public void CanSetAndGetNickName()
        {
            // Arrange
            var testValue = "TestValue413897858";

            // Act
            _testClass.NickName = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.NickName);
        }

        [Fact]
        public void CanSetAndGetExtension()
        {
            // Arrange
            var testValue = "TestValue2064072994";

            // Act
            _testClass.Extension = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Extension);
        }

        [Fact]
        public void CanSetAndGetMobileNumber()
        {
            // Arrange
            var testValue = "TestValue129193549";

            // Act
            _testClass.MobileNumber = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.MobileNumber);
        }

        [Fact]
        public void CanSetAndGetDept()
        {
            // Arrange
            var testValue = new Department
            {
                Id = 411541933,
                Name = "TestValue378872818",
                RequestedCompanyId = 653722128,
                IsActive = (short)18074,
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 84085699,
                    Name = "TestValue1284701832",
                    PhoneNumber = "TestValue76737200",
                    DomainName = "TestValue895975576",
                    Status = "TestValue150721197",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Email = "TestValue1059591390",
                    IsActive = (short)15552,
                    CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                    Departments = new Mock<ICollection<Department>>().Object,
                    EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                    Holidays = new Mock<ICollection<Holiday>>().Object,
                    LeaveTypes = new Mock<ICollection<LeaveType>>().Object,
                    Positions = new Mock<ICollection<Position>>().Object
                },
                EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object
            };

            // Act
            _testClass.Dept = testValue;

            // Assert
            Assert.Same(testValue, _testClass.Dept);
        }

        [Fact]
        public void CanSetAndGetEmployeeCredential()
        {
            // Arrange
            var testValue = new EmployeeCredential
            {
                Id = 1035060676,
                UserName = "TestValue1482813221",
                Password = "TestValue95415574",
                Status = (short)29988,
                RequestedCompanyId = 1484876688,
                Email = "TestValue43509338",
                DefaultPassword = false,
                GenerateOtp = "TestValue816416504",
                OtpExpiration = DateTime.UtcNow,
                IsActive = (short)26969,
                EmployeeLoginName = "TestValue1926143931",
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 612106193,
                    Name = "TestValue1181229582",
                    PhoneNumber = "TestValue2015132008",
                    DomainName = "TestValue259835193",
                    Status = "TestValue2120282236",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Email = "TestValue325613413",
                    IsActive = (short)31881,
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
                //DeviceTables = new Mock<ICollection<DeviceTable>>().Object,
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
        public void CanSetAndGetPosition()
        {
            // Arrange
            var testValue = new Position
            {
                Id = 368028288,
                Name = "TestValue413362462",
                RequestedCompanyId = 587667479,
                IsActive = (short)16846,
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 1086342732,
                    Name = "TestValue626071883",
                    PhoneNumber = "TestValue359390459",
                    DomainName = "TestValue738406460",
                    Status = "TestValue61402811",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Email = "TestValue1866739843",
                    IsActive = (short)8977,
                    CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                    Departments = new Mock<ICollection<Department>>().Object,
                    EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                    Holidays = new Mock<ICollection<Holiday>>().Object,
                    LeaveTypes = new Mock<ICollection<LeaveType>>().Object,
                    Positions = new Mock<ICollection<Position>>().Object
                },
                EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object
            };

            // Act
            _testClass.Position = testValue;

            // Assert
            Assert.Same(testValue, _testClass.Position);
        }

        [Fact]
        public void CanSetAndGetNumberOfYearsExperience()
        {
            // Arrange
            var testValue = "TestValue1982803014";

            // Act
            _testClass.NumberOfYearsExperience = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.NumberOfYearsExperience);
        }

        [Fact]
        public void CanSetAndGetImageUrl()
        {
            // Arrange
            var testValue = "TestValue213498013";

            // Act
            _testClass.ImageUrl = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.ImageUrl);
        }
    }
}