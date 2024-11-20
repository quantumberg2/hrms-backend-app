namespace HRMS_Unit_Test.Controllers
{
    using System;
    using System.Threading.Tasks;
    using HRMS_Application.Controllers;
    using HRMS_Application.DTO;
    using HRMS_Application.Enums;
    using Microsoft.Extensions.Logging;
    using Moq;
    using Xunit;

    public class MailNotificationControllerTests
    {
        private readonly MailNotificationController _testClass;
        private readonly Mock<ILogger<MailNotificationController>> _logger;

        public MailNotificationControllerTests()
        {
            _logger = new Mock<ILogger<MailNotificationController>>();
            _testClass = new MailNotificationController(_logger.Object);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new MailNotificationController(_logger.Object);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public async Task CanCallSendMail()
        {
            // Arrange
            var objEmail = new EmailNotification
            {
                appId = AppId_s.DeviWebsite,
                Email = "TestValue1841414896",
                Name = "TestValue637563228",
                PhoneNumber = "TestValue1249946475",
                Message = "TestValue1801219509"
            };

            // Act
            var result = await _testClass.SendMail(objEmail);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }
    }
}