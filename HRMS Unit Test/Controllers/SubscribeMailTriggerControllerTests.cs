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

    public class SubscribeMailTriggerControllerTests
    {
        private readonly SubscribeMailTriggerController _testClass;
        private readonly Mock<ILogger<SubscribeMailTriggerController>> _logger;

        public SubscribeMailTriggerControllerTests()
        {
            _logger = new Mock<ILogger<SubscribeMailTriggerController>>();
            _testClass = new SubscribeMailTriggerController(_logger.Object);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new SubscribeMailTriggerController(_logger.Object);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public async Task CanCallSendSubscriptionMail()
        {
            // Arrange
            var objMail = new SubscribeDTO
            {
                appId = AppId_s.Triguna,
                Email = "TestValue822857439"
            };

            // Act
            var result = await _testClass.SendSubscriptionMail(objMail);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }
    }
}