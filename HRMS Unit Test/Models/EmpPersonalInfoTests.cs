namespace HRMS_Unit_Test.Models
{
    using System;
    using System.Collections.Generic;
    using HRMS_Application.Models;
    using Moq;
    using Xunit;

    public partial class EmpPersonalInfoTests
    {
        private readonly EmpPersonalInfo _testClass;

        public EmpPersonalInfoTests()
        {
            _testClass = new EmpPersonalInfo();
        }

        [Fact]
        public void CanSetAndGetId()
        {
            // Arrange
            var testValue = 1679091244;

            // Act
            _testClass.Id = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Id);
        }

        [Fact]
        public void CanSetAndGetEmployeeCredentialId()
        {
            // Arrange
            var testValue = 758966256;

            // Act
            _testClass.EmployeeCredentialId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.EmployeeCredentialId);
        }

        [Fact]
        public void CanSetAndGetDob()
        {
            // Arrange
            var testValue = DateTime.UtcNow;

            // Act
            _testClass.Dob = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Dob);
        }

        [Fact]
        public void CanSetAndGetDateOfJoining()
        {
            // Arrange
            var testValue = DateTime.UtcNow;

            // Act
            _testClass.DateOfJoining = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.DateOfJoining);
        }

        [Fact]
        public void CanSetAndGetConfirmDate()
        {
            // Arrange
            var testValue = DateTime.UtcNow;

            // Act
            _testClass.ConfirmDate = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.ConfirmDate);
        }

        [Fact]
        public void CanSetAndGetEmpStatus()
        {
            // Arrange
            var testValue = "TestValue1120099554";

            // Act
            _testClass.EmpStatus = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.EmpStatus);
        }

        [Fact]
        public void CanSetAndGetEmailId()
        {
            // Arrange
            var testValue = "TestValue359478284";

            // Act
            _testClass.EmailId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.EmailId);
        }

        [Fact]
        public void CanSetAndGetPersonalEmail()
        {
            // Arrange
            var testValue = "TestValue1194885375";

            // Act
            _testClass.PersonalEmail = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.PersonalEmail);
        }

        [Fact]
        public void CanSetAndGetMaritalStatus()
        {
            // Arrange
            var testValue = "TestValue620311092";

            // Act
            _testClass.MaritalStatus = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.MaritalStatus);
        }

        [Fact]
        public void CanSetAndGetBloodGroup()
        {
            // Arrange
            var testValue = "TestValue725955163";

            // Act
            _testClass.BloodGroup = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.BloodGroup);
        }

        [Fact]
        public void CanSetAndGetSpouseName()
        {
            // Arrange
            var testValue = "TestValue512946660";

            // Act
            _testClass.SpouseName = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.SpouseName);
        }

        [Fact]
        public void CanSetAndGetPhysicallyChallenged()
        {
            // Arrange
            var testValue = false;

            // Act
            _testClass.PhysicallyChallenged = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.PhysicallyChallenged);
        }

        [Fact]
        public void CanSetAndGetEmergencyContact()
        {
            // Arrange
            var testValue = "TestValue944174217";

            // Act
            _testClass.EmergencyContact = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.EmergencyContact);
        }

        [Fact]
        public void CanSetAndGetIsActive()
        {
            // Arrange
            var testValue = (short)11969;

            // Act
            _testClass.IsActive = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.IsActive);
        }

        [Fact]
        public void CanSetAndGetGender()
        {
            // Arrange
            var testValue = "TestValue1821134536";

            // Act
            _testClass.Gender = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Gender);
        }

        [Fact]
        public void CanSetAndGetPan()
        {
            // Arrange
            var testValue = "TestValue2122082830";

            // Act
            _testClass.Pan = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Pan);
        }

        [Fact]
        public void CanSetAndGetEmployeeCredential()
        {
            // Arrange
            var testValue = new EmployeeCredential
            {
                Id = 427820079,
                UserName = "TestValue1242378333",
                Password = "TestValue1458428249",
                Status = (short)27030,
                RequestedCompanyId = 901624680,
                Email = "TestValue292564948",
                DefaultPassword = true,
                GenerateOtp = "TestValue1968183456",
                OtpExpiration = DateTime.UtcNow,
                IsActive = (short)11923,
                EmployeeLoginName = "TestValue678841367",
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 1428526562,
                    Name = "TestValue1570302955",
                    PhoneNumber = "TestValue1997955094",
                    DomainName = "TestValue611273711",
                    Status = "TestValue1035258010",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Email = "TestValue1843793249",
                    IsActive = (short)23085,
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
    }
}