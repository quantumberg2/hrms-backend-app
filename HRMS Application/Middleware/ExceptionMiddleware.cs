
using HRMS_Application.Middleware.Exceptions;
using HRMS_Application.Models;
using System.Net;

namespace HRMS_Application.Middleware
{
    public class ExceptionMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionMiddleware> _log;
        public ExceptionMiddleware(ILogger<ExceptionMiddleware> log)
        {
            _log = log;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                _log.LogError("Exception", ex.Message + ex.StackTrace + ex.InnerException);
                await HandleException(context, ex);
            }
        }
        private static Task HandleException(HttpContext context, Exception ex)
        {
            int statusCode = StatusCodes.Status500InternalServerError;
            switch (ex)
            {
                case NotFoundException:
                    statusCode = StatusCodes.Status404NotFound;
                    break;

                case BadRequestException:
                    statusCode = StatusCodes.Status400BadRequest;
                    break;

                case ForbiddenException:
                    statusCode = StatusCodes.Status403Forbidden;
                    break;

                case MethodNotAllowedException:
                    statusCode = StatusCodes.Status405MethodNotAllowed;
                    break;
                case NotAcceptableException:
                    statusCode = StatusCodes.Status406NotAcceptable;
                    break;

                case UnauthorizedException:
                    statusCode = StatusCodes.Status401Unauthorized;
                    break;

                case Exceptions.NotImplementedException:
                    statusCode = StatusCodes.Status501NotImplemented;
                    break;

                case NotFoundResultException:
                    statusCode = StatusCodes.Status404NotFound;
                    break;

                case ArgumentException:
                    statusCode = StatusCodes.Status500InternalServerError;
                    break;

                case DatabaseOperationException:
                    statusCode = StatusCodes.Status501NotImplemented;
                    break;
            }
            var errorResponse = new ErrorResponse
            {
                StatusCode = statusCode,
                Message = ex.Message
            };
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;
            return context.Response.WriteAsync(errorResponse.ToString());
        }
    }

    //Extension Method For this Middleware
    public static class ExceptionMiddlewareExtension
    {
        public static void ConfigureExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
