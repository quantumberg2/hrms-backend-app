namespace TestProject1.Models.Users
{
    using System;
    using HRMS_Application.Models.Users;
    using Xunit;

    public class AuthenticateRequestTests
    {
        private AuthenticateRequest _testClass;

        public AuthenticateRequestTests()
        {
            _testClass = new AuthenticateRequest();
        }

        [Fact]
        public void CanSetAndGetUsername()
        {
            // Arrange
            var testValue = "TestValue719497056";

            // Act
            _testClass.Username = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Username);
        }

        [Fact]
        public void CanSetAndGetPassword()
        {
            // Arrange
            var testValue = "TestValue1029573270";

            // Act
            _testClass.Password = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Password);
        }
    }
}