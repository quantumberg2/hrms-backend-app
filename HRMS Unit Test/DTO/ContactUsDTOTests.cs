namespace HRMS_Unit_Test.DTO
{
    using System;
    using HRMS_Application.DTO;
    using Xunit;

    public class ContactUsDTOTests
    {
        private readonly ContactUsDTO _testClass;

        public ContactUsDTOTests()
        {
            _testClass = new ContactUsDTO();
        }

        [Fact]
        public void CanSetAndGetEmail()
        {
            // Arrange
            var testValue = "TestValue1843568286";

            // Act
            _testClass.Email = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Email);
        }

        [Fact]
        public void CanSetAndGetName()
        {
            // Arrange
            var testValue = "TestValue1154709488";

            // Act
            _testClass.Name = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Name);
        }

        [Fact]
        public void CanSetAndGetPhoneNumber()
        {
            // Arrange
            var testValue = "TestValue1875602002";

            // Act
            _testClass.PhoneNumber = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.PhoneNumber);
        }

        [Fact]
        public void CanSetAndGetMessage()
        {
            // Arrange
            var testValue = "TestValue2054238651";

            // Act
            _testClass.Message = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Message);
        }
    }
}