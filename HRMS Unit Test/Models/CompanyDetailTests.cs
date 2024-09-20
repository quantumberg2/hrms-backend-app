namespace HRMS_Unit_Test.Models
{
    using System;
    using System.Collections.Generic;
    using HRMS_Application.Models;
    using Moq;
    using Xunit;

    public partial class CompanyDetailTests
    {
        private readonly CompanyDetail _testClass;

        public CompanyDetailTests()
        {
            _testClass = new CompanyDetail();
        }

        [Fact]
        public void CanSetAndGetId()
        {
            // Arrange
            var testValue = 294489197;

            // Act
            _testClass.Id = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Id);
        }

        [Fact]
        public void CanSetAndGetName()
        {
            // Arrange
            var testValue = "TestValue822966084";

            // Act
            _testClass.Name = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Name);
        }

        [Fact]
        public void CanSetAndGetAddress()
        {
            // Arrange
            var testValue = "TestValue847856675";

            // Act
            _testClass.Address = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Address);
        }

        [Fact]
        public void CanSetAndGetCountry()
        {
            // Arrange
            var testValue = "TestValue1753168423";

            // Act
            _testClass.Country = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Country);
        }

        [Fact]
        public void CanSetAndGetStates()
        {
            // Arrange
            var testValue = "TestValue428882281";

            // Act
            _testClass.States = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.States);
        }

        [Fact]
        public void CanSetAndGetIndustry()
        {
            // Arrange
            var testValue = "TestValue397666266";

            // Act
            _testClass.Industry = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Industry);
        }

        [Fact]
        public void CanSetAndGetTimeZone()
        {
            // Arrange
            var testValue = "TestValue1067439358";

            // Act
            _testClass.TimeZone = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.TimeZone);
        }

        [Fact]
        public void CanSetAndGetCurrency()
        {
            // Arrange
            var testValue = "TestValue1185222826";

            // Act
            _testClass.Currency = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Currency);
        }

        [Fact]
        public void CanSetAndGetPfNo()
        {
            // Arrange
            var testValue = "TestValue2034236158";

            // Act
            _testClass.PfNo = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.PfNo);
        }

        [Fact]
        public void CanSetAndGetTanNo()
        {
            // Arrange
            var testValue = "TestValue393330879";

            // Act
            _testClass.TanNo = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.TanNo);
        }

        [Fact]
        public void CanSetAndGetEsiNo()
        {
            // Arrange
            var testValue = "TestValue414898717";

            // Act
            _testClass.EsiNo = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.EsiNo);
        }

        [Fact]
        public void CanSetAndGetPanNo()
        {
            // Arrange
            var testValue = "TestValue607417618";

            // Act
            _testClass.PanNo = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.PanNo);
        }

        [Fact]
        public void CanSetAndGetGstNo()
        {
            // Arrange
            var testValue = "TestValue589753266";

            // Act
            _testClass.GstNo = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.GstNo);
        }

        [Fact]
        public void CanSetAndGetRegistrationNo()
        {
            // Arrange
            var testValue = "TestValue1953956306";

            // Act
            _testClass.RegistrationNo = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.RegistrationNo);
        }

        [Fact]
        public void CanSetAndGetTwitter()
        {
            // Arrange
            var testValue = "TestValue504719538";

            // Act
            _testClass.Twitter = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Twitter);
        }

        [Fact]
        public void CanSetAndGetFacebook()
        {
            // Arrange
            var testValue = "TestValue1880404637";

            // Act
            _testClass.Facebook = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Facebook);
        }

        [Fact]
        public void CanSetAndGetLinkedIn()
        {
            // Arrange
            var testValue = "TestValue2071664682";

            // Act
            _testClass.LinkedIn = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.LinkedIn);
        }

        [Fact]
        public void CanSetAndGetCompanyLogo()
        {
            // Arrange
            var testValue = "TestValue1775205703";

            // Act
            _testClass.CompanyLogo = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.CompanyLogo);
        }

        [Fact]
        public void CanSetAndGetRequestedCompanyId()
        {
            // Arrange
            var testValue = 1523579748;

            // Act
            _testClass.RequestedCompanyId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.RequestedCompanyId);
        }

        [Fact]
        public void CanSetAndGetIsActive()
        {
            // Arrange
            var testValue = (short)26638;

            // Act
            _testClass.IsActive = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.IsActive);
        }

        [Fact]
        public void CanSetAndGetRequestedCompany()
        {
            // Arrange
            var testValue = new RequestedCompanyForm
            {
                Id = 235448186,
                Name = "TestValue539388497",
                PhoneNumber = "TestValue524562530",
                DomainName = "TestValue1031142545",
                Status = "TestValue469118096",
                InsertedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                Email = "TestValue638047026",
                IsActive = (short)32350,
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
    }
}