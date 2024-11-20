namespace HRMS_Unit_Test.DTO
{
    using System;
    using HRMS_Application.DTO;
    using Xunit;

    public class UserDetailsDTOTests
    {
        private readonly UserDetailsDTO _testClass;

        public UserDetailsDTOTests()
        {
            _testClass = new UserDetailsDTO();
        }

        [Fact]
        public void CanSetAndGetName()
        {
            // Arrange
            var testValue = "TestValue577386476";

            // Act
            _testClass.Name = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Name);
        }

        [Fact]
        public void CanSetAndGetEmail()
        {
            // Arrange
            var testValue = "TestValue393807093";

            // Act
            _testClass.Email = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Email);
        }

        [Fact]
        public void CanSetAndGetImageUrl()
        {
            // Arrange
            var testValue = "TestValue1316089879";

            // Act
            _testClass.ImageUrl = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.ImageUrl);
        }

        [Fact]
        public void CanSetAndGetCompanyLogo()
        {
            // Arrange
            var testValue = "TestValue1941916273";

            // Act
            _testClass.CompanyLogo = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.CompanyLogo);
        }
    }
}