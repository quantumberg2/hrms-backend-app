namespace TestProject1.DTOs
{
    using System;
    using System.Collections.Generic;
    using HRMS_Application.DTOs;
    using Xunit;

    public class UserDtoTests
    {
        private UserDto _testClass;

        public UserDtoTests()
        {
            _testClass = new UserDto();
        }

        [Fact]
        public void CanSetAndGetUserName()
        {
            // Arrange
            var testValue = "TestValue880870771";

            // Act
            _testClass.UserName = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.UserName);
        }

        [Fact]
        public void CanSetAndGetUserId()
        {
            // Arrange
            var testValue = 319534633;

            // Act
            _testClass.UserId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.UserId);
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
    }
}