namespace TestProject1.Entities
{
    using System;
    using HRMS_Application.Entities;
    using HRMS_Application.Enums;
    using Xunit;

    public class UserTests
    {
        private User _testClass;

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
            var testValue = 2146363031;

            // Act
            _testClass.Id = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Id);
        }

        [Fact]
        public void CanSetAndGetFirstName()
        {
            // Arrange
            var testValue = "TestValue1040158908";

            // Act
            _testClass.FirstName = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.FirstName);
        }

        [Fact]
        public void CanSetAndGetLastName()
        {
            // Arrange
            var testValue = "TestValue38698275";

            // Act
            _testClass.LastName = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.LastName);
        }

        [Fact]
        public void CanSetAndGetUsername()
        {
            // Arrange
            var testValue = "TestValue1956433658";

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
            var testValue = "TestValue1133243516";

            // Act
            _testClass.PasswordHash = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.PasswordHash);
        }
    }
}