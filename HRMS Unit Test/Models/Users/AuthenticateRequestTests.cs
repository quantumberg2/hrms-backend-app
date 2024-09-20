namespace HRMS_Unit_Test.Models.Users
{
    using System;
    using HRMS_Application.Models.Users;
    using Xunit;

    public class AuthenticateRequestTests
    {
        private readonly AuthenticateRequest _testClass;

        public AuthenticateRequestTests()
        {
            _testClass = new AuthenticateRequest();
        }

        [Fact]
        public void CanSetAndGetUsername()
        {
            // Arrange
            var testValue = "TestValue988785361";

            // Act
            _testClass.Username = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Username);
        }

        [Fact]
        public void CanSetAndGetPassword()
        {
            // Arrange
            var testValue = "TestValue1968849220";

            // Act
            _testClass.Password = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Password);
        }
    }
}