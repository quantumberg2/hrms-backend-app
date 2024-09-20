namespace HRMS_Unit_Test
{
    using System;
    using System.Threading.Tasks;
    using HRMS_Application.DTO;
    using Xunit;

    public class EmailServiceTests
    {
        private readonly EmailService _testClass;

        public EmailServiceTests()
        {
            _testClass = new EmailService();
        }

        [Fact]
        public async Task CanCallSendOtpEmailAsync()
        {
            // Arrange
            var otpEmail = new OtpEmail
            {
                EmailAddress = "TestValue1018115002",
                Otp = "TestValue1878951860"
            };

            // Act
            await _testClass.SendOtpEmailAsync(otpEmail);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }
    }
}