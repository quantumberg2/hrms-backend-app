namespace HRMS_Unit_Test.Entities
{
    using System;
    using HRMS_Application.Entities;
    using HRMS_Application.Enums;
    using Xunit;

    public class UserTests
    {
        private readonly User _testClass;

        public UserTests()
        {
            _testClass = new User();
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new User();

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanSetAndGetId()
        {
            // Arrange
            var testValue = 1273536563;

            // Act
            _testClass.Id = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Id);
        }

        [Fact]
        public void CanSetAndGetFirstName()
        {
            // Arrange
            var testValue = "TestValue1936168934";

            // Act
            _testClass.FirstName = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.FirstName);
        }

        [Fact]
        public void CanSetAndGetLastName()
        {
            // Arrange
            var testValue = "TestValue95810396";

            // Act
            _testClass.LastName = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.LastName);
        }

        [Fact]
        public void CanSetAndGetUsername()
        {
            // Arrange
            var testValue = "TestValue700090902";

            // Act
            _testClass.Username = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Username);
        }

        [Fact]
        public void CanSetAndGetRole()
        {
            // Arrange
            var testValue = Role.Faculty;

            // Act
            _testClass.Role = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Role);
        }

        [Fact]
        public void CanSetAndGetPasswordHash()
        {
            // Arrange
            var testValue = "TestValue535223701";

            // Act
            _testClass.PasswordHash = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.PasswordHash);
        }
    }
}