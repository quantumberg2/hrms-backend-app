namespace HRMS_Unit_Test.DTO
{
    using System;
    using HRMS_Application.DTO;
    using Xunit;

    public class ForgotpasswordRequestTests
    {
        private readonly ForgotpasswordRequest _testClass;

        public ForgotpasswordRequestTests()
        {
            _testClass = new ForgotpasswordRequest();
        }

        [Fact]
        public void CanSetAndGetEmail()
        {
            // Arrange
            var testValue = "TestValue1844221008";

            // Act
            _testClass.Email = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Email);
        }

        [Fact]
        public void CanSetAndGetOtp()
        {
            // Arrange
            var testValue = "TestValue220064790";

            // Act
            _testClass.Otp = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Otp);
        }

        [Fact]
        public void CanSetAndGetNewPassword()
        {
            // Arrange
            var testValue = "TestValue219654027";

            // Act
            _testClass.NewPassword = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.NewPassword);
        }

        [Fact]
        public void CanSetAndGetConfirmPassword()
        {
            // Arrange
            var testValue = "TestValue1862952017";

            // Act
            _testClass.ConfirmPassword = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.ConfirmPassword);
        }
    }
}