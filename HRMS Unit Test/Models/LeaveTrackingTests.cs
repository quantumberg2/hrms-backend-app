namespace HRMS_Unit_Test.Models
{
    using System;
    using System.Collections.Generic;
    using HRMS_Application.Models;
    using Moq;
    using Xunit;

    public partial class LeaveTrackingTests
    {
        private readonly LeaveTracking _testClass;

        public LeaveTrackingTests()
        {
            _testClass = new LeaveTracking();
        }

        [Fact]
        public void CanSetAndGetId()
        {
            // Arrange
            var testValue = 942084573;

            // Act
            _testClass.Id = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Id);
        }

        [Fact]
        public void CanSetAndGetEmpCredentialId()
        {
            // Arrange
            var testValue = 957345286;

            // Act
            _testClass.EmpCredentialId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.EmpCredentialId);
        }

        [Fact]
        public void CanSetAndGetStartdate()
        {
            // Arrange
            var testValue = DateTime.UtcNow;

            // Act
            _testClass.Startdate = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Startdate);
        }

        [Fact]
        public void CanSetAndGetEnddate()
        {
            // Arrange
            var testValue = DateTime.UtcNow;

            // Act
            _testClass.Enddate = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Enddate);
        }

        [Fact]
        public void CanSetAndGetAppliedDate()
        {
            // Arrange
            var testValue = DateTime.UtcNow;

            // Act
            _testClass.AppliedDate = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.AppliedDate);
        }

        [Fact]
        public void CanSetAndGetStatus()
        {
            // Arrange
            var testValue = "TestValue771585967";

            // Act
            _testClass.Status = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Status);
        }

        [Fact]
        public void CanSetAndGetFiles()
        {
            // Arrange
            var testValue = "TestValue1072759273";

            // Act
            _testClass.Files = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Files);
        }

        [Fact]
        public void CanSetAndGetLeaveTypeId()
        {
            // Arrange
            var testValue = 1368760069;

            // Act
            _testClass.LeaveTypeId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.LeaveTypeId);
        }

        [Fact]
        public void CanSetAndGetSession()
        {
            // Arrange
            var testValue = "TestValue844940802";

            // Act
            _testClass.Session = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Session);
        }

        [Fact]
        public void CanSetAndGetContact()
        {
            // Arrange
            var testValue = "TestValue548755642";

            // Act
            _testClass.Contact = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Contact);
        }

        [Fact]
        public void CanSetAndGetReasonForLeave()
        {
            // Arrange
            var testValue = "TestValue1312890905";

            // Act
            _testClass.ReasonForLeave = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.ReasonForLeave);
        }

        [Fact]
        public void CanSetAndGetIsActive()
        {
            // Arrange
            var testValue = (short)24816;

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
                Id = 31514093,
                UserName = "TestValue1545219390",
                Password = "TestValue156257960",
                Status = (short)16223,
                RequestedCompanyId = 613350012,
                Email = "TestValue569880057",
                DefaultPassword = false,
                GenerateOtp = "TestValue1389115651",
                OtpExpiration = DateTime.UtcNow,
                IsActive = (short)23629,
                EmployeeLoginName = "TestValue1062191777",
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 717037155,
                    Name = "TestValue1583088445",
                    PhoneNumber = "TestValue1613953089",
                    DomainName = "TestValue1759557856",
                    Status = "TestValue1854406220",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Email = "TestValue1793533876",
                    IsActive = (short)29350,
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
            _testClass.EmpCredential = testValue;

            // Assert
            Assert.Same(testValue, _testClass.EmpCredential);
        }

        [Fact]
        public void CanSetAndGetLeaveType()
        {
            // Arrange
            var testValue = new LeaveType
            {
                Id = 1909016380,
                Type = "TestValue561542113",
                Days = 1659130661,
                CompanyId = 344710577,
                Year = 42168123,
                IsActive = (short)14384,
                Company = new RequestedCompanyForm
                {
                    Id = 2140979508,
                    Name = "TestValue610778288",
                    PhoneNumber = "TestValue974601501",
                    DomainName = "TestValue396350018",
                    Status = "TestValue819011584",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Email = "TestValue677680572",
                    IsActive = (short)8655,
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
            _testClass.LeaveType = testValue;

            // Assert
            Assert.Same(testValue, _testClass.LeaveType);
        }
    }
}