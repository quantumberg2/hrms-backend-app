namespace TestProject1.Helpers
{
    using System;
    using HRMS_Application.Helpers;
    using Xunit;

    public class AppSettingsTests
    {
        private AppSettings _testClass;

        public AppSettingsTests()
        {
            _testClass = new AppSettings();
        }

        [Fact]
        public void CanSetAndGetSecret()
        {
            // Arrange
            var testValue = "TestValue1821986833";

            // Act
            _testClass.Secret = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Secret);
        }
    }
}