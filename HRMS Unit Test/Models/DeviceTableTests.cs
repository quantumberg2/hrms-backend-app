namespace HRMS_Unit_Test.Models
{
    using System;
    using System.Collections.Generic;
    using HRMS_Application.Models;
    using Moq;
    using Xunit;

    public partial class DeviceTableTests
    {
        private readonly DeviceTable _testClass;

        public DeviceTableTests()
        {
            _testClass = new DeviceTable();
        }

        [Fact]
        public void CanSetAndGetId()
        {
            // Arrange
            var testValue = 579909217;

            // Act
            _testClass.Id = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Id);
        }

        [Fact]
        public void CanSetAndGetEmpCredentialId()
        {
            // Arrange
            var testValue = 76663375;

            // Act
           // _testClass.EmpCredentialId = testValue;

            // Assert
           // Assert.Equal(testValue, _testClass.EmpCredentialId);
        }

        [Fact]
        public void CanSetAndGetTimeIn()
        {
            // Arrange
            var testValue = DateTime.UtcNow;

            // Act
            _testClass.TimeIn = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.TimeIn);
        }

        [Fact]
        public void CanSetAndGetTimeOut()
        {
            // Arrange
            var testValue = DateTime.UtcNow;

            // Act
            _testClass.TimeOut = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.TimeOut);
        }

        [Fact]
        public void CanSetAndGetInsertedDate()
        {
            // Arrange
            var testValue = DateTime.UtcNow;

            // Act
            _testClass.InsertedDate = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.InsertedDate);
        }

        [Fact]
        public void CanSetAndGetWorkTime()
        {
            // Arrange
            var testValue = DateTime.UtcNow;

            // Act
            _testClass.WorkTime = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.WorkTime);
        }

        [Fact]
        public void CanSetAndGetOverTime()
        {
            // Arrange
            var testValue = DateTime.UtcNow;

            // Act
            _testClass.OverTime = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.OverTime);
        }

        [Fact]
        public void CanSetAndGetRemark()
        {
            // Arrange
            var testValue = "TestValue1263940838";

            // Act
            _testClass.Remark = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Remark);
        }

        [Fact]
        public void CanSetAndGetErlOut()
        {
            // Arrange
            var testValue = DateTime.UtcNow;

            // Act
            _testClass.ErlOut = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.ErlOut);
        }

        [Fact]
        public void CanSetAndGetLateIn()
        {
            // Arrange
            var testValue = DateTime.UtcNow;

            // Act
            _testClass.LateIn = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.LateIn);
        }

        [Fact]
        public void CanSetAndGetName()
        {
            // Arrange
            var testValue = "TestValue1564838012";

            // Act
            _testClass.Name = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Name);
        }

        [Fact]
        public void CanSetAndGetStatus()
        {
            // Arrange
            var testValue = "TestValue307777304";

            // Act
            _testClass.Status = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Status);
        }

        [Fact]
        public void CanSetAndGetIsActive()
        {
            // Arrange
            var testValue = (short)30630;

            // Act
            _testClass.IsActive = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.IsActive);
        }

        [Fact]
        public void CanSetAndGetEmpCredential()
        {
            // Arrange
            var testValue = new EmployeeCredential
            {
                Id = 1579307084,
                UserName = "TestValue965952957",
                Password = "TestValue246578687",
                Status = (short)24583,
                RequestedCompanyId = 743847039,
                Email = "TestValue716862440",
                DefaultPassword = true,
                GenerateOtp = "TestValue147632792",
                OtpExpiration = DateTime.UtcNow,
                IsActive = (short)7541,
                EmployeeLoginName = "TestValue245231665",
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 849650052,
                    Name = "TestValue176299908",
                    PhoneNumber = "TestValue2124026164",
                    DomainName = "TestValue1946572845",
                    Status = "TestValue1576075369",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Email = "TestValue1404461231",
                    IsActive = (short)15593,
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
            //_testClass.EmpCredential = testValue;

           // Assert
          //  Assert.Same(testValue, _testClass.EmpCredential);
        }
    }
}