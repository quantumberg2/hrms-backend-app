namespace HRMS_Unit_Test.DTOs
{
    using System;
    using System.Collections.Generic;
    using HRMS_Application.DTOs;
    using Xunit;

    public class UserDtoTests
    {
        private readonly UserDto _testClass;

        public UserDtoTests()
        {
            _testClass = new UserDto();
        }

        [Fact]
        public void CanSetAndGetUserName()
        {
            // Arrange
            var testValue = "TestValue925123920";

            // Act
            _testClass.UserName = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.UserName);
        }

        [Fact]
        public void CanSetAndGetUserId()
        {
            // Arrange
            var testValue = 190342609;

            // Act
            _testClass.UserId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.UserId);
        }

        [Fact]
        public void CanSetAndGetEmail()
        {
            // Arrange
            var testValue = "TestValue725011518";

            // Act
            _testClass.Email = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Email);
        }

        [Fact]
        public void CanSetAndGetRequestedCompanyId()
        {
            // Arrange
            var testValue = 572344161;

            // Act
            _testClass.RequestedCompanyId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.RequestedCompanyId);
        }

        [Fact]
        public void CanSetAndGetCompanyIds()
        {
            // Arrange
            var testValue = new List<int>();

            // Act
            _testClass.CompanyIds = testValue;

            // Assert
            Assert.Same(testValue, _testClass.CompanyIds);
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