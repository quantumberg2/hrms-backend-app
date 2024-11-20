namespace HRMS_Unit_Test.DTO
{
    using System;
    using System.Collections.Generic;
    using HRMS_Application.DTO;
    using Xunit;

    public class UserCompanyInfoTests
    {
        private readonly UserCompanyInfo _testClass;

        public UserCompanyInfoTests()
        {
            _testClass = new UserCompanyInfo();
        }

        [Fact]
        public void CanSetAndGetUserName()
        {
            // Arrange
            var testValue = "TestValue2001854311";

            // Act
            _testClass.UserName = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.UserName);
        }

        [Fact]
        public void CanSetAndGetUserId()
        {
            // Arrange
            var testValue = 1502776362;

            // Act
            _testClass.UserId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.UserId);
        }

        [Fact]
        public void CanSetAndGetEmail()
        {
            // Arrange
            var testValue = "TestValue1646098518";

            // Act
            _testClass.Email = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Email);
        }

        [Fact]
        public void CanSetAndGetRequestedCompanyId()
        {
            // Arrange
            var testValue = 857413488;

            // Act
            _testClass.RequestedCompanyId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.RequestedCompanyId);
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
        public void CanSetAndGetJwtToken()
        {
            // Arrange
            var testValue = "TestValue1673772230";

            // Act
            _testClass.JwtToken = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.JwtToken);
        }

        /*  [Fact]
          public void CanSetAndGetJwtToken()
          {
              // Arrange
              var testValue = "TestValue660878491";

              // Act
              _testClass.JwtToken = testValue;

              // Assert
              Assert.Equal(testValue, _testClass.JwtToken);
          }*/
    }
}