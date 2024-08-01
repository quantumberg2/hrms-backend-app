namespace TestProject1.Models
{
    using System;
    using System.Collections.Generic;
    using HRMS_Application.Models;
    using Moq;
    using Xunit;

    public partial class RoleTests
    {
        private Role _testClass;

        public RoleTests()
        {
            _testClass = new Role();
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new Role();

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanSetAndGetId()
        {
            // Arrange
            var testValue = 690003732;

            // Act
            _testClass.Id = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Id);
        }

        [Fact]
        public void CanSetAndGetName()
        {
            // Arrange
            var testValue = "TestValue131415977";

            // Act
            _testClass.Name = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Name);
        }

        [Fact]
        public void CanSetAndGetUserRolesJs()
        {
            // Arrange
            var testValue = new Mock<ICollection<UserRolesJ>>().Object;

            // Act
            _testClass.UserRolesJs = testValue;

            // Assert
            Assert.Same(testValue, _testClass.UserRolesJs);
        }
    }
}