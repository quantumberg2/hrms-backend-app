namespace TestProject1.Models
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
            var testValue = 762714000;

            // Act
            _testClass.Id = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Id);
        }

        [Fact]
        public void CanSetAndGetName()
        {
            // Arrange
            var testValue = "TestValue1559443806";

            // Act
            _testClass.Name = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Name);
        }

        [Fact]
        public void CanSetAndGetAddress()
        {
            // Arrange
            var testValue = "TestValue554831856";

            // Act
            _testClass.Address = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Address);
        }

        [Fact]
        public void CanSetAndGetCountry()
        {
            // Arrange
            var testValue = "TestValue1232488779";

            // Act
            _testClass.Country = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Country);
        }

        [Fact]
        public void CanSetAndGetStates()
        {
            // Arrange
            var testValue = "TestValue1679800554";

            // Act
            _testClass.States = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.States);
        }

        [Fact]
        public void CanSetAndGetIndustry()
        {
            // Arrange
            var testValue = "TestValue1359905164";

            // Act
            _testClass.Industry = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Industry);
        }

        [Fact]
        public void CanSetAndGetTimeZone()
        {
            // Arrange
            var testValue = "TestValue681302349";

            // Act
            _testClass.TimeZone = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.TimeZone);
        }

        [Fact]
        public void CanSetAndGetCurrency()
        {
            // Arrange
            var testValue = "TestValue2117866716";

            // Act
            _testClass.Currency = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Currency);
        }

        [Fact]
        public void CanSetAndGetPfNo()
        {
            // Arrange
            var testValue = "TestValue1667229549";

            // Act
            _testClass.PfNo = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.PfNo);
        }

        [Fact]
        public void CanSetAndGetTanNo()
        {
            // Arrange
            var testValue = "TestValue2023251461";

            // Act
            _testClass.TanNo = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.TanNo);
        }

        [Fact]
        public void CanSetAndGetEsiNo()
        {
            // Arrange
            var testValue = "TestValue1321200201";

            // Act
            _testClass.EsiNo = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.EsiNo);
        }

        [Fact]
        public void CanSetAndGetPanNo()
        {
            // Arrange
            var testValue = "TestValue1897868996";

            // Act
            _testClass.PanNo = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.PanNo);
        }

        [Fact]
        public void CanSetAndGetGstNo()
        {
            // Arrange
            var testValue = "TestValue1688019412";

            // Act
            _testClass.GstNo = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.GstNo);
        }

        [Fact]
        public void CanSetAndGetRegistrationNo()
        {
            // Arrange
            var testValue = "TestValue456384073";

            // Act
            _testClass.RegistrationNo = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.RegistrationNo);
        }

        [Fact]
        public void CanSetAndGetTwitter()
        {
            // Arrange
            var testValue = "TestValue34246025";

            // Act
            _testClass.Twitter = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Twitter);
        }

        [Fact]
        public void CanSetAndGetFacebook()
        {
            // Arrange
            var testValue = "TestValue328715671";

            // Act
            _testClass.Facebook = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Facebook);
        }

        [Fact]
        public void CanSetAndGetLinkedIn()
        {
            // Arrange
            var testValue = "TestValue1564893639";

            // Act
            _testClass.LinkedIn = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.LinkedIn);
        }

        [Fact]
        public void CanSetAndGetCompanyLogo()
        {
            // Arrange
            var testValue = "TestValue390104996";

            // Act
            _testClass.CompanyLogo = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.CompanyLogo);
        }

        [Fact]
        public void CanSetAndGetRequestedCompanyId()
        {
            // Arrange
            var testValue = 1618676774;

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
                Id = 400534131,
                Name = "TestValue1165443218",
                PhoneNumber = "TestValue2114546154",
                DomainName = "TestValue680533789",
                Status = "TestValue1612863577",
                InsertedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                Department = new Department
                {
                    Id = 2079076703,
                    Name = "TestValue1814205745",
                    RequestedCompanyId = 293407514,
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