namespace TestProject1.Middleware.Exceptions
{
    using System;
    using HRMS_Application.Middleware.Exceptions;
    using Xunit;

    public class NotFoundExceptionTests
    {
        private NotFoundException _testClass;
        private string _message;

        public NotFoundExceptionTests()
        {
            _message = "TestValue1997834670";
            _testClass = new NotFoundException(_message);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new NotFoundException(_message);

            // Assert
            Assert.NotNull(instance);
        }
    }

    public class BadRequestExceptionTests
    {
        private BadRequestException _testClass;
        private string _message;

        public BadRequestExceptionTests()
        {
            _message = "TestValue1952840562";
            _testClass = new BadRequestException(_message);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new BadRequestException(_message);

            // Assert
            Assert.NotNull(instance);
        }
    }

    public class ForbiddenExceptionTests
    {
        private ForbiddenException _testClass;
        private string _message;

        public ForbiddenExceptionTests()
        {
            _message = "TestValue1452135729";
            _testClass = new ForbiddenException(_message);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new ForbiddenException(_message);

            // Assert
            Assert.NotNull(instance);
        }
    }

    public class MethodNotAllowedExceptionTests
    {
        private MethodNotAllowedException _testClass;
        private string _message;

        public MethodNotAllowedExceptionTests()
        {
            _message = "TestValue209776305";
            _testClass = new MethodNotAllowedException(_message);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new MethodNotAllowedException(_message);

            // Assert
            Assert.NotNull(instance);
        }
    }

    public class NotAcceptableExceptionTests
    {
        private NotAcceptableException _testClass;
        private string _message;

        public NotAcceptableExceptionTests()
        {
            _message = "TestValue2008154197";
            _testClass = new NotAcceptableException(_message);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new NotAcceptableException(_message);

            // Assert
            Assert.NotNull(instance);
        }
    }

    public class UnauthorizedExceptionTests
    {
        private UnauthorizedException _testClass;
        private string _message;

        public UnauthorizedExceptionTests()
        {
            _message = "TestValue535140234";
            _testClass = new UnauthorizedException(_message);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new UnauthorizedException(_message);

            // Assert
            Assert.NotNull(instance);
        }
    }

    public class NotImplementedExceptionTests
    {
        private NotImplementedException _testClass;
        private string _message;

        public NotImplementedExceptionTests()
        {
            _message = "TestValue649851460";
            _testClass = new NotImplementedException(_message);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new NotImplementedException(_message);

            // Assert
            Assert.NotNull(instance);
        }
    }

    public class NotFoundResultExceptionTests
    {
        private NotFoundResultException _testClass;
        private string _message;

        public NotFoundResultExceptionTests()
        {
            _message = "TestValue1337843370";
            _testClass = new NotFoundResultException(_message);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new NotFoundResultException(_message);

            // Assert
            Assert.NotNull(instance);
        }
    }

    public class DatabaseOperationExceptionTests
    {
        private DatabaseOperationException _testClass;
        private string _message;

        public DatabaseOperationExceptionTests()
        {
            _message = "TestValue284016739";
            _testClass = new DatabaseOperationException(_message);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new DatabaseOperationException(_message);

            // Assert
            Assert.NotNull(instance);
        }
    }
}