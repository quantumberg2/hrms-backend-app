namespace TestProject1.Models
{
    using System;
    using System.Collections.Generic;
    using HRMS_Application.Models;
    using Moq;
    using Xunit;

    public partial class AddressInfoTests
    {
        private AddressInfo _testClass;

        public AddressInfoTests()
        {
            _testClass = new AddressInfo();
        }

        [Fact]
        public void CanSetAndGetId()
        {
            // Arrange
            var testValue = 1344640293;

            // Act
            _testClass.Id = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Id);
        }

        [Fact]
        public void CanSetAndGetEmployeeCredentialId()
        {
            // Arrange
            var testValue = 714518307;

            // Act
            _testClass.EmployeeCredentialId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.EmployeeCredentialId);
        }

        [Fact]
        public void CanSetAndGetAddressLine1()
        {
            // Arrange
            var testValue = "TestValue67549699";

            // Act
            _testClass.AddressLine1 = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.AddressLine1);
        }

        [Fact]
        public void CanSetAndGetAddressLine2()
        {
            // Arrange
            var testValue = "TestValue1648693182";

            // Act
            _testClass.AddressLine2 = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.AddressLine2);
        }

        [Fact]
        public void CanSetAndGetCity()
        {
            // Arrange
            var testValue = "TestValue687794286";

            // Act
            _testClass.City = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.City);
        }

        [Fact]
        public void CanSetAndGetState()
        {
            // Arrange
            var testValue = "TestValue1944065334";

            // Act
            _testClass.State = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.State);
        }

        [Fact]
        public void CanSetAndGetCountry()
        {
            // Arrange
            var testValue = "TestValue1464126092";

            // Act
            _testClass.Country = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Country);
        }

        [Fact]
        public void CanSetAndGetPinCode()
        {
            // Arrange
            var testValue = "TestValue1113874544";

            // Act
            _testClass.PinCode = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.PinCode);
        }

        [Fact]
        public void CanSetAndGetEmployeeCredential()
        {
            // Arrange
            var testValue = new EmployeeCredential
            {
                Id = 163300661,
                UserName = "TestValue1289417035",
                Password = "TestValue2059853586",
                Status = (short)22291,
                RequestedCompanyId = 1913481100,
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 1444337099,
                    Name = "TestValue1902562885",
                    PhoneNumber = "TestValue2132837561",
                    DomainName = "TestValue885561590",
                    Status = "TestValue1616971844",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Department = new Department
                    {
                        Id = 1728523995,
                        Name = "TestValue469167709",
                        RequestedCompanyId = 1476790408,
                        RequestedCompany = default(RequestedCompanyForm),
                        EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object
                    },
                    CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                    EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                    Positions = new Mock<ICollection<Position>>().Object
                },
                AccountDetails = new Mock<ICollection<AccountDetail>>().Object,
                AddressInfos = new Mock<ICollection<AddressInfo>>().Object,
                EmpPersonalInfos = new Mock<ICollection<EmpPersonalInfo>>().Object,
                EmpSalaries = new Mock<ICollection<EmpSalary>>().Object,
                EmployeeAttendances = new Mock<ICollection<EmployeeAttendance>>().Object,
                EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object,
                EmployeeLeaves = new Mock<ICollection<EmployeeLeave>>().Object,
                UserRolesJs = new Mock<ICollection<UserRolesJ>>().Object
            };

            // Act
            _testClass.EmployeeCredential = testValue;

            // Assert
            Assert.Same(testValue, _testClass.EmployeeCredential);
        }
    }
}