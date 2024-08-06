namespace HRMSunitTestCase.Models.Users
{
    using System;
    using System.Collections.Generic;
    using HRMS_Application.DTOs;
    using HRMS_Application.Models.Users;
    using Xunit;

    public class AuthenticateResponseTests
    {
        private AuthenticateResponse _testClass;
        private UserDto _user;
        private string _token;
        private List<string> _roles;

        public AuthenticateResponseTests()
        {
            _user = new UserDto
            {
                UserName = "TestValue805048537",
                UserId = 734981827,
                Roles = new List<string>()
            };
            _token = "TestValue1448166469";
            _roles = new List<string>();
            _testClass = new AuthenticateResponse(_user, _token, _roles);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new AuthenticateResponse(_user, _token, _roles);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanSetAndGetId()
        {
            // Arrange
            var testValue = 429882114;

            // Act
            _testClass.Id = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Id);
        }

        [Fact]
        public void CanSetAndGetName()
        {
            // Arrange
            var testValue = "TestValue337069995";

            // Act
            _testClass.Name = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Name);
        }

        [Fact]
        public void CanSetAndGetUsername()
        {
            // Arrange
            var testValue = "TestValue521188053";

            // Act
            _testClass.Username = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Username);
        }

        [Fact]
        public void CanSetAndGetPassword()
        {
            // Arrange
            var testValue = "TestValue672125264";

            // Act
            _testClass.Password = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Password);
        }

        [Fact]
        public void CanSetAndGetRoles()
        {
            // Arrange
            var testValue = new List<string>();

            // Act
            _testClass.Roles = testValue;

            // Assert
            Assert.Same(testValue, _testClass.Roles);
        }

        [Fact]
        public void CanSetAndGetToken()
        {
            // Arrange
            var testValue = "TestValue291679415";

            // Act
            _testClass.Token = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Token);
        }
    }
}