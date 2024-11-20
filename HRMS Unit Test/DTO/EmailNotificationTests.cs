namespace HRMS_Unit_Test.DTO
{
    using System;
    using HRMS_Application.DTO;
    using HRMS_Application.Enums;
    using Xunit;

    public class EmailNotificationTests
    {
        private readonly EmailNotification _testClass;

        public EmailNotificationTests()
        {
            _testClass = new EmailNotification();
        }

        [Fact]
        public void CanSetAndGetappId()
        {
            // Arrange
            var testValue = AppId_s.Quantumberg;

            // Act
            _testClass.appId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.appId);
        }

        [Fact]
        public void CanSetAndGetEmail()
        {
            // Arrange
            var testValue = "TestValue1322987325";

            // Act
            _testClass.Email = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Email);
        }

        [Fact]
        public void CanSetAndGetName()
        {
            // Arrange
            var testValue = "TestValue2004955445";

            // Act
            _testClass.Name = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Name);
        }

        [Fact]
        public void CanSetAndGetPhoneNumber()
        {
            // Arrange
            var testValue = "TestValue1947847731";

            // Act
            _testClass.PhoneNumber = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.PhoneNumber);
        }

        [Fact]
        public void CanSetAndGetMessage()
        {
            // Arrange
            var testValue = "TestValue1709811386";

            // Act
            _testClass.Message = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Message);
        }
    }
}