namespace HRMS_Unit_Test.DTO
{
    using System;
    using HRMS_Application.DTO;
    using HRMS_Application.Enums;
    using Xunit;

    public class SubscribeDTOTests
    {
        private readonly SubscribeDTO _testClass;

        public SubscribeDTOTests()
        {
            _testClass = new SubscribeDTO();
        }

        [Fact]
        public void CanSetAndGetappId()
        {
            // Arrange
            var testValue = AppId_s.HRMS;

            // Act
            _testClass.appId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.appId);
        }

        [Fact]
        public void CanSetAndGetEmail()
        {
            // Arrange
            var testValue = "TestValue944361362";

            // Act
            _testClass.Email = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Email);
        }
    }
}