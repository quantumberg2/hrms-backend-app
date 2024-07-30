namespace HRMS_Application.Middleware.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {

        }
    }

    public class BadRequestException : Exception
    {
        public BadRequestException(string message) :base(message)
        {

        }
    }

    public class ForbiddenException : Exception
    {
        public ForbiddenException(string message): base(message)
        {

        }
    }

    public class MethodNotAllowedException : Exception
    {
        public MethodNotAllowedException(string message) : base(message)
        {

        }
    }

    public class NotAcceptableException : Exception
    {
        public NotAcceptableException(string message) : base(message)
        {

        }
    }

    public class UnauthorizedException : Exception
    {
        public UnauthorizedException(string message) : base(message)
        {

        }
    }

    public class NotImplementedException : Exception
    {
        public NotImplementedException(string message) : base(message)
        {

        }
    }

    public class NotFoundResultException:Exception
    {
        public NotFoundResultException(string message) : base(message)
        {

        }
    }

    public class DatabaseOperationException:Exception
    {
        public DatabaseOperationException(string message) : base(message)
        {

        }
    }



}
