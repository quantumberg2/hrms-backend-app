namespace HRMSunitTestCase.Models
{
    using System;
    using HRMS_Application.Models;
    using Xunit;

    public class ErrorResponseTests
    {
        private ErrorResponse _testClass;

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
            var testValue = 916978203;

            // Act
            _testClass.StatusCode = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.StatusCode);
        }

        [Fact]
        public void CanSetAndGetMessage()
        {
            // Arrange
            var testValue = "TestValue145244495";

            // Act
            _testClass.Message = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Message);
        }
    }
}