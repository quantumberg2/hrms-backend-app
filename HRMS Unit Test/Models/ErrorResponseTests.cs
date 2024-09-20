namespace HRMS_Unit_Test.Models
{
    using System;
    using HRMS_Application.Models;
    using Xunit;

    public class ErrorResponseTests
    {
        private readonly ErrorResponse _testClass;

        public ErrorResponseTests()
        {
            _testClass = new ErrorResponse();
        }

        [Fact]
        public void CanCallToString()
        {
            // Act
            var result = _testClass.ToString();

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public void CanSetAndGetStatusCode()
        {
            // Arrange
            var testValue = 2075909827;

            // Act
            _testClass.StatusCode = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.StatusCode);
        }

        [Fact]
        public void CanSetAndGetMessage()
        {
            // Arrange
            var testValue = "TestValue1793598490";

            // Act
            _testClass.Message = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Message);
        }
    }
}