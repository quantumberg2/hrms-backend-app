namespace HRMS_Unit_Test.DTO
{
    using System;
    using HRMS_Application.DTO;
    using Xunit;

    public class ComanyLogoDTOTests
    {
        private readonly ComanyLogoDTO _testClass;

        public ComanyLogoDTOTests()
        {
            _testClass = new ComanyLogoDTO();
        }

        [Fact]
        public void CanSetAndGetCompanyName()
        {
            // Arrange
            var testValue = "TestValue1656921225";

            // Act
            _testClass.CompanyName = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.CompanyName);
        }

        [Fact]
        public void CanSetAndGetCompanyLogo()
        {
            // Arrange
            var testValue = "TestValue522861429";

            // Act
            _testClass.CompanyLogo = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.CompanyLogo);
        }
    }
}