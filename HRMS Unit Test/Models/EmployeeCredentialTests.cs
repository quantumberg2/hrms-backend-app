namespace HRMS_Unit_Test.Models
{
    using System;
    using System.Collections.Generic;
    using HRMS_Application.Models;
    using Moq;
    using Xunit;

    public partial class EmployeeCredentialTests
    {
        private readonly EmployeeCredential _testClass;

        public EmployeeCredentialTests()
        {
            _testClass = new EmployeeCredential();
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new EmployeeCredential();

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanSetAndGetId()
        {
            // Arrange
            var testValue = 384890693;

            // Act
            _testClass.Id = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Id);
        }

        [Fact]
        public void CanSetAndGetUserName()
        {
            // Arrange
            var testValue = "TestValue318097370";

            // Act
            _testClass.UserName = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.UserName);
        }

        [Fact]
        public void CanSetAndGetPassword()
        {
            // Arrange
            var testValue = "TestValue1691740215";

            // Act
            _testClass.Password = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Password);
        }

        [Fact]
        public void CanSetAndGetStatus()
        {
            // Arrange
            var testValue = (short)14666;

            // Act
            _testClass.Status = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Status);
        }

        [Fact]
        public void CanSetAndGetRequestedCompanyId()
        {
            // Arrange
            var testValue = 1191706528;

            // Act
            _testClass.RequestedCompanyId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.RequestedCompanyId);
        }

        [Fact]
        public void CanSetAndGetEmail()
        {
            // Arrange
            var testValue = "TestValue516496170";

            // Act
            _testClass.Email = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Email);
        }

        [Fact]
        public void CanSetAndGetDefaultPassword()
        {
            // Arrange
            var testValue = false;

            // Act
            _testClass.DefaultPassword = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.DefaultPassword);
        }

        [Fact]
        public void CanSetAndGetGenerateOtp()
        {
            // Arrange
            var testValue = "TestValue63564618";

            // Act
            _testClass.GenerateOtp = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.GenerateOtp);
        }

        [Fact]
        public void CanSetAndGetOtpExpiration()
        {
            // Arrange
            var testValue = DateTime.UtcNow;

            // Act
            _testClass.OtpExpiration = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.OtpExpiration);
        }

        [Fact]
        public void CanSetAndGetIsActive()
        {
            // Arrange
            var testValue = (short)25649;

            // Act
            _testClass.IsActive = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.IsActive);
        }

        [Fact]
        public void CanSetAndGetEmployeeLoginName()
        {
            // Arrange
            var testValue = "TestValue1731152881";

            // Act
            _testClass.EmployeeLoginName = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.EmployeeLoginName);
        }

        [Fact]
        public void CanSetAndGetRequestedCompany()
        {
            // Arrange
            var testValue = new RequestedCompanyForm
            {
                Id = 411476984,
                Name = "TestValue1846255790",
                PhoneNumber = "TestValue253230950",
                DomainName = "TestValue318028464",
                Status = "TestValue1930430911",
                InsertedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                Email = "TestValue1322931633",
                IsActive = (short)18343,
                CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                Departments = new Mock<ICollection<Department>>().Object,
                EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                Holidays = new Mock<ICollection<Holiday>>().Object,
                LeaveTypes = new Mock<ICollection<LeaveType>>().Object,
                Positions = new Mock<ICollection<Position>>().Object
            };

            // Act
            _testClass.RequestedCompany = testValue;

            // Assert
            Assert.Same(testValue, _testClass.RequestedCompany);
        }

        [Fact]
        public void CanSetAndGetAccountDetails()
        {
            // Arrange
            var testValue = new Mock<ICollection<AccountDetail>>().Object;

            // Act
            _testClass.AccountDetails = testValue;

            // Assert
            Assert.Same(testValue, _testClass.AccountDetails);
        }

        [Fact]
        public void CanSetAndGetAddressInfos()
        {
            // Arrange
            var testValue = new Mock<ICollection<AddressInfo>>().Object;

            // Act
            _testClass.AddressInfos = testValue;

            // Assert
            Assert.Same(testValue, _testClass.AddressInfos);
        }

        [Fact]
        public void CanSetAndGetAttendances()
        {
            // Arrange
            var testValue = new Mock<ICollection<Attendance>>().Object;

            // Act
            _testClass.Attendances = testValue;

            // Assert
            Assert.Same(testValue, _testClass.Attendances);
        }

        [Fact]
        public void CanSetAndGetDeviceTables()
        {
            // Arrange
            var testValue = new Mock<ICollection<DeviceTable>>().Object;

            // Act
            //_testClass.DeviceTables = testValue;

            // Assert
            //Assert.Same(testValue, _testClass.DeviceTables);
        }

        [Fact]
        public void CanSetAndGetEmpPersonalInfos()
        {
            // Arrange
            var testValue = new Mock<ICollection<EmpPersonalInfo>>().Object;

            // Act
            _testClass.EmpPersonalInfos = testValue;

            // Assert
            Assert.Same(testValue, _testClass.EmpPersonalInfos);
        }

        [Fact]
        public void CanSetAndGetEmpSalaries()
        {
            // Arrange
            var testValue = new Mock<ICollection<EmpSalary>>().Object;

            // Act
            _testClass.EmpSalaries = testValue;

            // Assert
            Assert.Same(testValue, _testClass.EmpSalaries);
        }

        [Fact]
        public void CanSetAndGetEmployeeDetails()
        {
            // Arrange
            var testValue = new Mock<ICollection<EmployeeDetail>>().Object;

            // Act
            _testClass.EmployeeDetails = testValue;

            // Assert
            Assert.Same(testValue, _testClass.EmployeeDetails);
        }

        [Fact]
        public void CanSetAndGetEmployeeLeaveAllocations()
        {
            // Arrange
            var testValue = new Mock<ICollection<EmployeeLeaveAllocation>>().Object;

            // Act
            _testClass.EmployeeLeaveAllocations = testValue;

            // Assert
            Assert.Same(testValue, _testClass.EmployeeLeaveAllocations);
        }

        [Fact]
        public void CanSetAndGetLeaveTrackings()
        {
            // Arrange
            var testValue = new Mock<ICollection<LeaveTracking>>().Object;

            // Act
            _testClass.LeaveTrackings = testValue;

            // Assert
            Assert.Same(testValue, _testClass.LeaveTrackings);
        }

        [Fact]
        public void CanSetAndGetUserRolesJs()
        {
            // Arrange
            var testValue = new Mock<ICollection<UserRolesJ>>().Object;

            // Act
            _testClass.UserRolesJs = testValue;

            // Assert
            Assert.Same(testValue, _testClass.UserRolesJs);
        }

        [Fact]
        public void CanSetAndGetResignedDate()
        {
            // Arrange
            var testValue = DateTime.UtcNow;

            // Act
            _testClass.ResignedDate = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.ResignedDate);
        }

        [Fact]
        public void CanSetAndGetEmpCredIdEmpCodeMappings()
        {
            // Arrange
            var testValue = new Mock<ICollection<EmpCredIdEmpCodeMapping>>().Object;

            // Act
            _testClass.EmpCredIdEmpCodeMappings = testValue;

            // Assert
            Assert.Same(testValue, _testClass.EmpCredIdEmpCodeMappings);
        }
    }
}