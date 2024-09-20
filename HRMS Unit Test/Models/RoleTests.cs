namespace HRMS_Unit_Test.Models
{
    using System;
    using System.Collections.Generic;
    using HRMS_Application.Models;
    using Moq;
    using Xunit;

    public partial class RoleTests
    {
        private readonly Role _testClass;

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
            var testValue = 1122708971;

            // Act
            _testClass.Id = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Id);
        }

        [Fact]
        public void CanSetAndGetName()
        {
            // Arrange
            var testValue = "TestValue988961526";

            // Act
            _testClass.Name = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Name);
        }

        [Fact]
        public void CanSetAndGetIsActive()
        {
            // Arrange
            var testValue = (short)13381;

            // Act
            _testClass.IsActive = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.IsActive);
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