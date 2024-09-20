namespace HRMS_Unit_Test.Helpers
{
    using System;
    using HRMS_Application.Helpers;
    using Xunit;

    public class AppSettingsTests
    {
        private readonly AppSettings _testClass;

        public AppSettingsTests()
        {
            _testClass = new AppSettings();
        }

        [Fact]
        public void CanSetAndGetSecret()
        {
            // Arrange
            var testValue = "TestValue958653664";

            // Act
            _testClass.Secret = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Secret);
        }
    }
}