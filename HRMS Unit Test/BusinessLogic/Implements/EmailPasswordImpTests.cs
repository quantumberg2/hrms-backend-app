namespace HRMS_Unit_Test.BusinessLogic.Implements
{
    using System;
    using System.Threading.Tasks;
    using HRMS_Application.BusinessLogic.Implements;
    using HRMS_Application.DTO;
    using Xunit;

    public class EmailPasswordImpTests
    {
        private readonly EmailPasswordImp _testClass;

        public EmailPasswordImpTests()
        {
            _testClass = new EmailPasswordImp();
        }

        [Fact]
        public async Task CanCallSendOtpEmailAsync()
        {
            // Arrange
            var generatepassword = new Generatepassword
            {
                EmailAddress = "TestValue699476624",
                Password = "TestValue1335216864",
                UserName = "TestValue442093805"
            };

            // Act
            await _testClass.SendOtpEmailAsync(generatepassword);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }
    }
}