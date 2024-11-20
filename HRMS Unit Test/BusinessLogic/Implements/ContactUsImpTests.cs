namespace HRMS_Unit_Test.BusinessLogic.Implements
{
    using System;
    using System.Threading.Tasks;
    using HRMS_Application.BusinessLogic.Implements;
    using HRMS_Application.DTO;
    using Xunit;

    public class ContactUsImpTests
    {
        private readonly ContactUsImp _testClass;

        public ContactUsImpTests()
        {
            _testClass = new ContactUsImp();
        }

        [Fact]
        public async Task CanCallSendMessageAsync()
        {
            // Arrange
            var contact = new ContactUsDTO
            {
                Email = "TestValue216717142",
                Name = "TestValue1413441697",
                PhoneNumber = "TestValue850703779",
                Message = "TestValue1448194713"
            };

            // Act
            await _testClass.SendMessageAsync(contact);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }
    }
}