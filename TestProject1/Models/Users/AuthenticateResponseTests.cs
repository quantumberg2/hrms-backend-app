namespace TestProject1.Models.Users
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
                UserName = "TestValue386932648",
                UserId = 57190004,
                Roles = new List<string>()
            };
            _token = "TestValue191636921";
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
            var testValue = 1170470804;

            // Act
            _testClass.Id = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Id);
        }

        [Fact]
        public void CanSetAndGetName()
        {
            // Arrange
            var testValue = "TestValue776974616";

            // Act
            _testClass.Name = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Name);
        }

        [Fact]
        public void CanSetAndGetUsername()
        {
            // Arrange
            var testValue = "TestValue1588087946";

            // Act
            _testClass.Username = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Username);
        }

        [Fact]
        public void CanSetAndGetPassword()
        {
            // Arrange
            var testValue = "TestValue891413387";

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
            var testValue = "TestValue1914045253";

            // Act
            _testClass.Token = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Token);
        }
    }
}