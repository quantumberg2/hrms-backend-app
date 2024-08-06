namespace HRMSunitTestCase.Models.Users
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
            var testValue = "TestValue371480443";

            // Act
            _testClass.Username = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Username);
        }

        [Fact]
        public void CanSetAndGetPassword()
        {
            // Arrange
            var testValue = "TestValue1153580749";

            // Act
            _testClass.Password = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Password);
        }
    }
}