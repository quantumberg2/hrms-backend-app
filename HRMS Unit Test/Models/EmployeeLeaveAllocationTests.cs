namespace HRMS_Unit_Test.Models
{
    using System;
    using System.Collections.Generic;
    using HRMS_Application.Models;
    using Moq;
    using Xunit;

    public partial class EmployeeLeaveAllocationTests
    {
        private readonly EmployeeLeaveAllocation _testClass;

        public EmployeeLeaveAllocationTests()
        {
            _testClass = new EmployeeLeaveAllocation();
        }

        [Fact]
        public void CanSetAndGetId()
        {
            // Arrange
            var testValue = 2145930924;

            // Act
            _testClass.Id = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Id);
        }

        [Fact]
        public void CanSetAndGetYear()
        {
            // Arrange
            var testValue = 924463213;

            // Act
            _testClass.Year = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Year);
        }

        [Fact]
        public void CanSetAndGetEmpCredentialId()
        {
            // Arrange
            var testValue = 1870223007;

            // Act
            _testClass.EmpCredentialId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.EmpCredentialId);
        }

        [Fact]
        public void CanSetAndGetNumberOfLeaves()
        {
            // Arrange
            var testValue = 1177622673;

            // Act
            _testClass.NumberOfLeaves = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.NumberOfLeaves);
        }

        [Fact]
        public void CanSetAndGetRemainingLeave()
        {
            // Arrange
            var testValue = 254518099;

            // Act
            _testClass.RemainingLeave = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.RemainingLeave);
        }

        [Fact]
        public void CanSetAndGetLeaveType()
        {
            // Arrange
            var testValue = 171139569;

            // Act
            _testClass.LeaveType = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.LeaveType);
        }

        [Fact]
        public void CanSetAndGetIsActive()
        {
            // Arrange
            var testValue = (short)28461;

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
                Id = 1467324846,
                UserName = "TestValue1952716418",
                Password = "TestValue1471531643",
                Status = (short)22988,
                RequestedCompanyId = 789822551,
                Email = "TestValue275538618",
                DefaultPassword = true,
                GenerateOtp = "TestValue1540763224",
                OtpExpiration = DateTime.UtcNow,
                IsActive = (short)21709,
                EmployeeLoginName = "TestValue942001273",
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 477080103,
                    Name = "TestValue1513904013",
                    PhoneNumber = "TestValue929909494",
                    DomainName = "TestValue1791594399",
                    Status = "TestValue876300181",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Email = "TestValue1932326105",
                    IsActive = (short)3504,
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

        [Fact]
        public void CanSetAndGetLeaveTypeNavigation()
        {
            // Arrange
            var testValue = new LeaveType
            {
                Id = 1280978223,
                Type = "TestValue1009022799",
                Days = 418448729,
                CompanyId = 1144645967,
                Year = 1772196859,
                IsActive = (short)4331,
                Company = new RequestedCompanyForm
                {
                    Id = 539552164,
                    Name = "TestValue1254057282",
                    PhoneNumber = "TestValue1741138895",
                    DomainName = "TestValue743931021",
                    Status = "TestValue1948472110",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Email = "TestValue420663670",
                    IsActive = (short)16224,
                    CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                    Departments = new Mock<ICollection<Department>>().Object,
                    EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                    Holidays = new Mock<ICollection<Holiday>>().Object,
                    LeaveTypes = new Mock<ICollection<LeaveType>>().Object,
                    Positions = new Mock<ICollection<Position>>().Object
                },
                EmployeeLeaveAllocations = new Mock<ICollection<EmployeeLeaveAllocation>>().Object,
                LeaveTrackings = new Mock<ICollection<LeaveTracking>>().Object
            };

            // Act
            _testClass.LeaveTypeNavigation = testValue;

            // Assert
            Assert.Same(testValue, _testClass.LeaveTypeNavigation);
        }
    }
}