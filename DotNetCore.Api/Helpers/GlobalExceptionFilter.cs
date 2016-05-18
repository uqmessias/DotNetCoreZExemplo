using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace DotNetCore.Api.Helpers
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly ILogger _logger;

        public GlobalExceptionFilter(ILoggerFactory loggerFactory )
        {
            _logger = loggerFactory.CreateLogger("Global Exception Filter");
        }

        public void OnException(ExceptionContext context)
        {
            context.Result = new BadRequestObjectResult("Ops aconteceu algo inesperado! Já estou entrando em contato com os macacos responsaveis!");
            _logger.LogError("GlobalExceptionFilter", context.Exception);
        }
    }
}