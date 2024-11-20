namespace HRMS_Unit_Test.BusinessLogic.Implements
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using HRMS_Application.BusinessLogic.Implements;
    using Xunit;

    public class AlertMailOperationsImpTests
    {
        private readonly AlertMailOperationsImp _testClass;

        public AlertMailOperationsImpTests()
        {
            _testClass = new AlertMailOperationsImp();
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new AlertMailOperationsImp();

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public async Task CanCallSendEmailAsync()
        {
            // Arrange
            var emailTemplate = "TestValue1421929478";
            var parameters = new Dictionary<string, string>();

            // Act
            await _testClass.SendEmailAsync(emailTemplate, parameters);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }
    }
}