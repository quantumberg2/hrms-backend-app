namespace HRMS_Unit_Test.DTO
{
    using System;
    using HRMS_Application.DTO;
    using Xunit;

    public class GeneratepasswordTests
    {
        private readonly Generatepassword _testClass;

        public GeneratepasswordTests()
        {
            _testClass = new Generatepassword();
        }

        [Fact]
        public void CanSetAndGetEmailAddress()
        {
            // Arrange
            var testValue = "TestValue187785294";

            // Act
            _testClass.EmailAddress = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.EmailAddress);
        }

        [Fact]
        public void CanSetAndGetPassword()
        {
            // Arrange
            var testValue = "TestValue1556007964";

            // Act
            _testClass.Password = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Password);
        }

        [Fact]
        public void CanSetAndGetUserName()
        {
            // Arrange
            var testValue = "TestValue842276485";

            // Act
            _testClass.UserName = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.UserName);
        }
    }
}