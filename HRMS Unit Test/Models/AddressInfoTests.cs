namespace HRMS_Unit_Test.Models
{
    using System;
    using System.Collections.Generic;
    using HRMS_Application.Models;
    using Moq;
    using Xunit;

    public partial class AddressInfoTests
    {
        private readonly AddressInfo _testClass;

        public AddressInfoTests()
        {
            _testClass = new AddressInfo();
        }

        [Fact]
        public void CanSetAndGetId()
        {
            // Arrange
            var testValue = 1538036410;

            // Act
            _testClass.Id = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Id);
        }

        [Fact]
        public void CanSetAndGetEmployeeCredentialId()
        {
            // Arrange
            var testValue = 1558356017;

            // Act
            _testClass.EmployeeCredentialId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.EmployeeCredentialId);
        }

        [Fact]
        public void CanSetAndGetAddressLine1()
        {
            // Arrange
            var testValue = "TestValue1306421510";

            // Act
            _testClass.AddressLine1 = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.AddressLine1);
        }

        [Fact]
        public void CanSetAndGetAddressLine2()
        {
            // Arrange
            var testValue = "TestValue1570478153";

            // Act
            _testClass.AddressLine2 = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.AddressLine2);
        }

        [Fact]
        public void CanSetAndGetCity()
        {
            // Arrange
            var testValue = "TestValue1892282903";

            // Act
            _testClass.City = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.City);
        }

        [Fact]
        public void CanSetAndGetState()
        {
            // Arrange
            var testValue = "TestValue1543386764";

            // Act
            _testClass.State = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.State);
        }

        [Fact]
        public void CanSetAndGetCountry()
        {
            // Arrange
            var testValue = "TestValue2093289614";

            // Act
            _testClass.Country = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Country);
        }

        [Fact]
        public void CanSetAndGetPinCode()
        {
            // Arrange
            var testValue = "TestValue920835266";

            // Act
            _testClass.PinCode = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.PinCode);
        }

        [Fact]
        public void CanSetAndGetIsActive()
        {
            // Arrange
            var testValue = (short)15339;

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
                Id = 1236879816,
                UserName = "TestValue988590014",
                Password = "TestValue433801945",
                Status = (short)3749,
                RequestedCompanyId = 1133961361,
                Email = "TestValue1321986000",
                DefaultPassword = true,
                GenerateOtp = "TestValue336784196",
                OtpExpiration = DateTime.UtcNow,
                IsActive = (short)4216,
                EmployeeLoginName = "TestValue996166839",
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 216600795,
                    Name = "TestValue1559474673",
                    PhoneNumber = "TestValue1924010945",
                    DomainName = "TestValue1210493667",
                    Status = "TestValue811031529",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Email = "TestValue258490747",
                    IsActive = (short)11386,
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
    }
}