namespace HRMSunitTestCase.Models
{
    using System;
    using System.Collections.Generic;
    using HRMS_Application.Models;
    using Moq;
    using Xunit;

    public partial class CompanyDetailTests
    {
        private CompanyDetail _testClass;

        public CompanyDetailTests()
        {
            _testClass = new CompanyDetail();
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new CompanyDetail();

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanSetAndGetId()
        {
            // Arrange
            var testValue = 2031895750;

            // Act
            _testClass.Id = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Id);
        }

        [Fact]
        public void CanSetAndGetName()
        {
            // Arrange
            var testValue = "TestValue1124675250";

            // Act
            _testClass.Name = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Name);
        }

        [Fact]
        public void CanSetAndGetAddress()
        {
            // Arrange
            var testValue = "TestValue991701296";

            // Act
            _testClass.Address = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Address);
        }

        [Fact]
        public void CanSetAndGetCountry()
        {
            // Arrange
            var testValue = "TestValue1478177587";

            // Act
            _testClass.Country = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Country);
        }

        [Fact]
        public void CanSetAndGetStates()
        {
            // Arrange
            var testValue = "TestValue1811879112";

            // Act
            _testClass.States = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.States);
        }

        [Fact]
        public void CanSetAndGetIndustry()
        {
            // Arrange
            var testValue = "TestValue1894977498";

            // Act
            _testClass.Industry = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Industry);
        }

        [Fact]
        public void CanSetAndGetTimeZone()
        {
            // Arrange
            var testValue = "TestValue1565387464";

            // Act
            _testClass.TimeZone = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.TimeZone);
        }

        [Fact]
        public void CanSetAndGetCurrency()
        {
            // Arrange
            var testValue = "TestValue208288575";

            // Act
            _testClass.Currency = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Currency);
        }

        [Fact]
        public void CanSetAndGetPfNo()
        {
            // Arrange
            var testValue = "TestValue795545793";

            // Act
            _testClass.PfNo = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.PfNo);
        }

        [Fact]
        public void CanSetAndGetTanNo()
        {
            // Arrange
            var testValue = "TestValue1835234784";

            // Act
            _testClass.TanNo = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.TanNo);
        }

        [Fact]
        public void CanSetAndGetEsiNo()
        {
            // Arrange
            var testValue = "TestValue1489087674";

            // Act
            _testClass.EsiNo = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.EsiNo);
        }

        [Fact]
        public void CanSetAndGetPanNo()
        {
            // Arrange
            var testValue = "TestValue819302915";

            // Act
            _testClass.PanNo = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.PanNo);
        }

        [Fact]
        public void CanSetAndGetGstNo()
        {
            // Arrange
            var testValue = "TestValue1651340830";

            // Act
            _testClass.GstNo = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.GstNo);
        }

        [Fact]
        public void CanSetAndGetRegistrationNo()
        {
            // Arrange
            var testValue = "TestValue1582929051";

            // Act
            _testClass.RegistrationNo = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.RegistrationNo);
        }

        [Fact]
        public void CanSetAndGetTwitter()
        {
            // Arrange
            var testValue = "TestValue64800667";

            // Act
            _testClass.Twitter = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Twitter);
        }

        [Fact]
        public void CanSetAndGetFacebook()
        {
            // Arrange
            var testValue = "TestValue170269628";

            // Act
            _testClass.Facebook = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Facebook);
        }

        [Fact]
        public void CanSetAndGetLinkedIn()
        {
            // Arrange
            var testValue = "TestValue1841930969";

            // Act
            _testClass.LinkedIn = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.LinkedIn);
        }

        [Fact]
        public void CanSetAndGetCompanyLogo()
        {
            // Arrange
            var testValue = "TestValue1168821473";

            // Act
            _testClass.CompanyLogo = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.CompanyLogo);
        }

        [Fact]
        public void CanSetAndGetRequestedCompanyId()
        {
            // Arrange
            var testValue = 1749695674;

            // Act
            _testClass.RequestedCompanyId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.RequestedCompanyId);
        }

        [Fact]
        public void CanSetAndGetRequestedCompany()
        {
            // Arrange
            var testValue = new RequestedCompanyForm
            {
                Id = 981802555,
                Name = "TestValue737920287",
                PhoneNumber = "TestValue1918513400",
                DomainName = "TestValue1580267610",
                Status = "TestValue245004195",
                InsertedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                Email = "TestValue1585453163",
                Department = new Department
                {
                    Id = 1355173408,
                    Name = "TestValue566724578",
                    RequestedCompanyId = 722893307,
                    RequestedCompany = default(RequestedCompanyForm),
                    EmployeeDetails = new Mock<ICollection<EmployeeDetail>>().Object
                },
                CompanyDetails = new Mock<ICollection<CompanyDetail>>().Object,
                EmployeeCredentials = new Mock<ICollection<EmployeeCredential>>().Object,
                Positions = new Mock<ICollection<Position>>().Object
            };

            // Act
            _testClass.RequestedCompany = testValue;

            // Assert
            Assert.Same(testValue, _testClass.RequestedCompany);
        }

        [Fact]
        public void CanSetAndGetHolidays()
        {
            // Arrange
            var testValue = new Mock<ICollection<Holiday>>().Object;

            // Act
            _testClass.Holidays = testValue;

            // Assert
            Assert.Same(testValue, _testClass.Holidays);
        }

        [Fact]
        public void CanSetAndGetLeaveTypes()
        {
            // Arrange
            var testValue = new Mock<ICollection<LeaveType>>().Object;

            // Act
            _testClass.LeaveTypes = testValue;

            // Assert
            Assert.Same(testValue, _testClass.LeaveTypes);
        }
    }
}