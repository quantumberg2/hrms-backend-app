namespace HRMS_Unit_Test.DTO
{
    using System;
    using HRMS_Application.DTO;
    using Xunit;

    public class OtpEmailTests
    {
        private readonly OtpEmail _testClass;

        public OtpEmailTests()
        {
            _testClass = new OtpEmail();
        }

        [Fact]
        public void CanSetAndGetEmailAddress()
        {
            // Arrange
            var testValue = "TestValue1189336501";

            // Act
            _testClass.EmailAddress = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.EmailAddress);
        }

        [Fact]
        public void CanSetAndGetOtp()
        {
            // Arrange
            var testValue = "TestValue594259641";

            // Act
            _testClass.Otp = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Otp);
        }
    }
}