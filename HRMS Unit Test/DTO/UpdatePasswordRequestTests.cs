namespace HRMS_Unit_Test.DTO
{
    using System;
    using HRMS_Application.DTO;
    using Xunit;

    public class UpdatePasswordRequestTests
    {
        private readonly UpdatePasswordRequest _testClass;

        public UpdatePasswordRequestTests()
        {
            _testClass = new UpdatePasswordRequest();
        }

        [Fact]
        public void CanSetAndGetEmail()
        {
            // Arrange
            var testValue = "TestValue1729494963";

            // Act
            _testClass.Email = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Email);
        }

        [Fact]
        public void CanSetAndGetOldPassword()
        {
            // Arrange
            var testValue = "TestValue1495499998";

            // Act
            _testClass.OldPassword = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.OldPassword);
        }

        [Fact]
        public void CanSetAndGetNewPassword()
        {
            // Arrange
            var testValue = "TestValue437929764";

            // Act
            _testClass.NewPassword = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.NewPassword);
        }
    }
}