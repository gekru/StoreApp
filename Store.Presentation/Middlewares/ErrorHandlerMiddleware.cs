using Microsoft.AspNetCore.Http;
using Store.BusinessLogic.Common.Interfaces;
using System.Threading.Tasks;

namespace Store.Presentation.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ErrorHandlerMiddleware(RequestDelegate next, ILogger logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (System.Exception exeption)
            {
                _logger.LogFile(exeption.ToString());
            }
        }
    }
}
