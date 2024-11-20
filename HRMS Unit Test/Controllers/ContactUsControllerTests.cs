namespace HRMS_Unit_Test.Controllers
{
    using System;
    using System.Threading.Tasks;
    using HRMS_Application.BusinessLogic.Interface;
    using HRMS_Application.Controllers;
    using HRMS_Application.DTO;
    using Microsoft.Extensions.Logging;
    using Moq;
    using Xunit;

    public class ContactUsControllerTests
    {
        private readonly ContactUsController _testClass;
        private readonly Mock<IContactUs> _contact;
        private readonly Mock<ILogger<ContactUsController>> _logger;

        public ContactUsControllerTests()
        {
            _contact = new Mock<IContactUs>();
            _logger = new Mock<ILogger<ContactUsController>>();
            _testClass = new ContactUsController(_contact.Object, _logger.Object);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new ContactUsController(_contact.Object, _logger.Object);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public async Task CanCallSendMessageAsync()
        {
            // Arrange
            var contact = new ContactUsDTO
            {
                Email = "TestValue1905681282",
                Name = "TestValue2037127090",
                PhoneNumber = "TestValue1239160651",
                Message = "TestValue1730154534"
            };

            _contact.Setup(mock => mock.SendMessageAsync(It.IsAny<ContactUsDTO>())).Verifiable();

            // Act
            var result = await _testClass.SendMessageAsync(contact);

            // Assert
            _contact.Verify(mock => mock.SendMessageAsync(It.IsAny<ContactUsDTO>()));

            throw new NotImplementedException("Create or modify test");
        }
    }
}