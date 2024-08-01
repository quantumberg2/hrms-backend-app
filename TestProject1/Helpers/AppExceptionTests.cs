namespace TestProject1.Helpers
{
    using System;
    using HRMS_Application.Helpers;
    using Xunit;

    public class AppExceptionTests
    {
        private AppException _testClass;
        private string _message;
        private object[] _args;

        public AppExceptionTests()
        {
            _message = "TestValue306113342";
            _args = new[] { new object(), new object(), new object() };
            _testClass = new AppException(_message, _args);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new AppException();

            // Assert
            Assert.NotNull(instance);

            // Act
            instance = new AppException(_message);

            // Assert
            Assert.NotNull(instance);

            // Act
            instance = new AppException(_message, _args);

            // Assert
            Assert.NotNull(instance);
        }
    }
}