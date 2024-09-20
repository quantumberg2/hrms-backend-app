namespace HRMS_Unit_Test.Models
{
    using System;
    using System.Collections.Generic;
    using HRMS_Application.Models;
    using Moq;
    using Xunit;

    public partial class AttendanceTests
    {
        private readonly Attendance _testClass;

        public AttendanceTests()
        {
            _testClass = new Attendance();
        }

        [Fact]
        public void CanSetAndGetId()
        {
            // Arrange
            var testValue = 1524846032;

            // Act
            _testClass.Id = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Id);
        }

        [Fact]
        public void CanSetAndGetEmpCredentialId()
        {
            // Arrange
            var testValue = 382993949;

            // Act
            _testClass.EmpCredentialId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.EmpCredentialId);
        }

        [Fact]
        public void CanSetAndGetNumberOfHours()
        {
            // Arrange
            var testValue = 634985594.1;

            // Act
            _testClass.NumberOfHours = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.NumberOfHours);
        }

        [Fact]
        public void CanSetAndGetStatus()
        {
            // Arrange
            var testValue = "TestValue2108326455";

            // Act
            _testClass.Status = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Status);
        }

        [Fact]
        public void CanSetAndGetEmpCredential()
        {
            // Arrange
            var testValue = new EmployeeCredential
            {
                Id = 1774369864,
                UserName = "TestValue1295613442",
                Password = "TestValue2085159118",
                Status = (short)24842,
                RequestedCompanyId = 1761509112,
                Email = "TestValue347862350",
                DefaultPassword = true,
                GenerateOtp = "TestValue1311987406",
                OtpExpiration = DateTime.UtcNow,
                IsActive = (short)17486,
                EmployeeLoginName = "TestValue914123556",
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 489616926,
                    Name = "TestValue1279269182",
                    PhoneNumber = "TestValue953189197",
                    DomainName = "TestValue952241398",
                    Status = "TestValue257971328",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Email = "TestValue1745733398",
                    IsActive = (short)2828,
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
            _testClass.EmpCredential = testValue;

            // Assert
            Assert.Same(testValue, _testClass.EmpCredential);
        }
    }
}