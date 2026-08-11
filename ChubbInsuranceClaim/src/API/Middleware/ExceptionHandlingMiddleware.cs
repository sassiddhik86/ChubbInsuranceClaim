using System.Net;
using System.Text.Json;

namespace ChubbInsuranceClaim.src.API.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(
            RequestDelegate next,
            ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;

            _logger = logger;
        }

        public async Task InvokeAsync(
            HttpContext context)
        {

            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {

                _logger.LogError(
                    ex,
                    "Unhandled exception occurred.");



                await HandleExceptionAsync(
                    context,
                    ex);
            }
        }

        private static async Task HandleExceptionAsync(
            HttpContext context,
            Exception exception)
        {

            context.Response.ContentType =
                "application/json";



            int statusCode;



            string message;



            switch (exception)
            {

                case ArgumentException:
                    statusCode =
                        (int)HttpStatusCode.BadRequest;

                    message =
                        exception.Message;

                    break;



                case UnauthorizedAccessException:

                    statusCode =
                        (int)HttpStatusCode.Unauthorized;

                    message =
                        "Unauthorized access.";

                    break;



                case KeyNotFoundException:

                    statusCode =
                        (int)HttpStatusCode.NotFound;

                    message =
                        exception.Message;

                    break;



                default:

                    statusCode =
                        (int)HttpStatusCode.InternalServerError;

                    message =
                        "An unexpected error occurred.";

                    break;
            }



            context.Response.StatusCode =
                statusCode;



            var response =
                new
                {
                    success = false,

                    statusCode,

                    message,

                    timestamp =
                        DateTime.UtcNow
                };



            await context.Response
                .WriteAsync(
                    JsonSerializer.Serialize(response));
        }
    }
}
