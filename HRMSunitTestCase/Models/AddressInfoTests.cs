namespace HRMSunitTestCase.Models
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
            var testValue = 1062111088;

            // Act
            _testClass.Id = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Id);
        }

        [Fact]
        public void CanSetAndGetEmployeeCredentialId()
        {
            // Arrange
            var testValue = 1830491907;

            // Act
            _testClass.EmployeeCredentialId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.EmployeeCredentialId);
        }

        [Fact]
        public void CanSetAndGetAddressLine1()
        {
            // Arrange
            var testValue = "TestValue479194885";

            // Act
            _testClass.AddressLine1 = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.AddressLine1);
        }

        [Fact]
        public void CanSetAndGetAddressLine2()
        {
            // Arrange
            var testValue = "TestValue714813162";

            // Act
            _testClass.AddressLine2 = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.AddressLine2);
        }

        [Fact]
        public void CanSetAndGetCity()
        {
            // Arrange
            var testValue = "TestValue1862328992";

            // Act
            _testClass.City = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.City);
        }

        [Fact]
        public void CanSetAndGetState()
        {
            // Arrange
            var testValue = "TestValue1273719158";

            // Act
            _testClass.State = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.State);
        }

        [Fact]
        public void CanSetAndGetCountry()
        {
            // Arrange
            var testValue = "TestValue1489510107";

            // Act
            _testClass.Country = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Country);
        }

        [Fact]
        public void CanSetAndGetPinCode()
        {
            // Arrange
            var testValue = "TestValue1651421060";

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
                Id = 104700481,
                UserName = "TestValue1740299448",
                Password = "TestValue390775634",
                Status = (short)483,
                RequestedCompanyId = 271109439,
                Email = "TestValue101074686",
                DefaultPassword = true,
                RequestedCompany = new RequestedCompanyForm
                {
                    Id = 1829062719,
                    Name = "TestValue928108703",
                    PhoneNumber = "TestValue251474013",
                    DomainName = "TestValue1657760650",
                    Status = "TestValue227488427",
                    InsertedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Email = "TestValue774116249",
                    Department = new Department
                    {
                        Id = 2124833937,
                        Name = "TestValue1917397213",
                        RequestedCompanyId = 145510541,
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
                Holidays = new Mock<ICollection<Holiday>>().Object,
                LeaveTypes = new Mock<ICollection<LeaveType>>().Object,
                UserRolesJs = new Mock<ICollection<UserRolesJ>>().Object
            };

            // Act
            _testClass.EmployeeCredential = testValue;

            // Assert
            Assert.Same(testValue, _testClass.EmployeeCredential);
        }
    }
}