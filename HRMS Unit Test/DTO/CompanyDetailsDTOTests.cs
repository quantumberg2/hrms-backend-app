namespace HRMS_Unit_Test.DTO
{
    using System;
    using HRMS_Application.DTO;
    using Microsoft.AspNetCore.Http;
    using Moq;
    using Xunit;

    public class CompanyDetailsDTOTests
    {
        private readonly CompanyDetailsDTO _testClass;

        public CompanyDetailsDTOTests()
        {
            _testClass = new CompanyDetailsDTO();
        }

        [Fact]
        public void CanSetAndGetName()
        {
            // Arrange
            var testValue = "TestValue954115636";

            // Act
            _testClass.Name = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Name);
        }

        [Fact]
        public void CanSetAndGetAddress()
        {
            // Arrange
            var testValue = "TestValue1514388996";

            // Act
            _testClass.Address = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Address);
        }

        [Fact]
        public void CanSetAndGetCountry()
        {
            // Arrange
            var testValue = "TestValue1982719657";

            // Act
            _testClass.Country = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Country);
        }

        [Fact]
        public void CanSetAndGetStates()
        {
            // Arrange
            var testValue = "TestValue1595694292";

            // Act
            _testClass.States = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.States);
        }

        [Fact]
        public void CanSetAndGetIndustry()
        {
            // Arrange
            var testValue = "TestValue414517636";

            // Act
            _testClass.Industry = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Industry);
        }

        [Fact]
        public void CanSetAndGetTimeZone()
        {
            // Arrange
            var testValue = "TestValue1658447579";

            // Act
            _testClass.TimeZone = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.TimeZone);
        }

        [Fact]
        public void CanSetAndGetCurrency()
        {
            // Arrange
            var testValue = "TestValue335900106";

            // Act
            _testClass.Currency = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Currency);
        }

        [Fact]
        public void CanSetAndGetPfNo()
        {
            // Arrange
            var testValue = "TestValue1047942916";

            // Act
            _testClass.PfNo = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.PfNo);
        }

        [Fact]
        public void CanSetAndGetTanNo()
        {
            // Arrange
            var testValue = "TestValue1644779741";

            // Act
            _testClass.TanNo = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.TanNo);
        }

        [Fact]
        public void CanSetAndGetEsiNo()
        {
            // Arrange
            var testValue = "TestValue397365771";

            // Act
            _testClass.EsiNo = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.EsiNo);
        }

        [Fact]
        public void CanSetAndGetPanNo()
        {
            // Arrange
            var testValue = "TestValue494921690";

            // Act
            _testClass.PanNo = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.PanNo);
        }

        [Fact]
        public void CanSetAndGetGstNo()
        {
            // Arrange
            var testValue = "TestValue1412867183";

            // Act
            _testClass.GstNo = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.GstNo);
        }

        [Fact]
        public void CanSetAndGetRegistrationNo()
        {
            // Arrange
            var testValue = "TestValue184915292";

            // Act
            _testClass.RegistrationNo = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.RegistrationNo);
        }

        [Fact]
        public void CanSetAndGetTwitter()
        {
            // Arrange
            var testValue = "TestValue1509917597";

            // Act
            _testClass.Twitter = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Twitter);
        }

        [Fact]
        public void CanSetAndGetFacebook()
        {
            // Arrange
            var testValue = "TestValue1868863902";

            // Act
            _testClass.Facebook = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Facebook);
        }

        [Fact]
        public void CanSetAndGetLinkedIn()
        {
            // Arrange
            var testValue = "TestValue901927633";

            // Act
            _testClass.LinkedIn = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.LinkedIn);
        }

        [Fact]
        public void CanSetAndGetCompanyLogo()
        {
            // Arrange
            var testValue = new Mock<IFormFile>().Object;

            // Act
            _testClass.CompanyLogo = testValue;

            // Assert
            Assert.Same(testValue, _testClass.CompanyLogo);
        }

        [Fact]
        public void CanSetAndGetIsActive()
        {
            // Arrange
            var testValue = (short)14195;

            // Act
            _testClass.IsActive = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.IsActive);
        }
    }
}