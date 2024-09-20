namespace HRMS_Unit_Test.Middleware.Exceptions
{
    using System;
    using HRMS_Application.Middleware.Exceptions;
    using Xunit;


    public class NotFoundExceptionTests
    {
        private readonly NotFoundException _testClass;
        private string _message;

        public NotFoundExceptionTests()
        {
            _message = "TestValue771701337";
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
        private readonly BadRequestException _testClass;
        private string _message;

        public BadRequestExceptionTests()
        {
            _message = "TestValue1203128805";
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
        private readonly ForbiddenException _testClass;
        private string _message;

        public ForbiddenExceptionTests()
        {
            _message = "TestValue1849670846";
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
        private readonly MethodNotAllowedException _testClass;
        private string _message;

        public MethodNotAllowedExceptionTests()
        {
            _message = "TestValue1798794892";
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
        private readonly NotAcceptableException _testClass;
        private string _message;

        public NotAcceptableExceptionTests()
        {
            _message = "TestValue500176205";
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
        private readonly UnauthorizedException _testClass;
        private string _message;

        public UnauthorizedExceptionTests()
        {
            _message = "TestValue1662278324";
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
        private readonly System.NotImplementedException _testClass;
        private string _message;

        public NotImplementedExceptionTests()
        {
            _message = "TestValue1671936441";
            _testClass = new System.NotImplementedException(_message);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new System.NotImplementedException(_message);

            // Assert
            Assert.NotNull(instance);
        }
    }

    public class NotFoundResultExceptionTests
    {
        private readonly NotFoundResultException _testClass;
        private string _message;

        public NotFoundResultExceptionTests()
        {
            _message = "TestValue1083768300";
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
        private readonly DatabaseOperationException _testClass;
        private string _message;

        public DatabaseOperationExceptionTests()
        {
            _message = "TestValue1714012612";
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