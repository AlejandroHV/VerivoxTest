using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using System.Text.Json;
using VerivoxTest.Application.Especifications.Responses;

namespace VerivoxTest.Application.API.Extensions.Middleware
{
    /// <summary>
    /// Filter to catch any exceptions and format them in the same way. 
    /// TO DO: Switch to handle specific exceptions. 
    /// </summary>
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly IHostEnvironment _hostEnvironment;
        private readonly ILogger<ExceptionFilter> _logger;

        public ExceptionFilter(IHostEnvironment hostEnvironment, ILogger<ExceptionFilter> logger)
        {
            _hostEnvironment = hostEnvironment; 
            _logger = logger;
        }


        public void OnException(ExceptionContext context)
        {
            
            _logger.LogError(context.Exception,context.Exception.Message);

            if (!_hostEnvironment.IsDevelopment())
            {
                context.Result = new ContentResult
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Content = "Internal Server Error"
                };
                return;
            }


            var error = new ExceptionResponse("Internal Server Error", context.Exception.StackTrace ?? string.Empty, context.Exception.Message );

            context.Result = new ContentResult
            {
                StatusCode = (int)HttpStatusCode.InternalServerError,
                Content = JsonSerializer.Serialize(error)
            };
        }
    }

}
