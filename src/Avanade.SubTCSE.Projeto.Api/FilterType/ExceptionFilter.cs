using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Threading.Tasks;

namespace Avanade.SubTCSE.Projeto.Api.FilterType
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public readonly ILogger<ExceptionFilter> _logger;

        public ExceptionFilter(ILogger<ExceptionFilter> logger)
        {
            _logger = logger;
        }

        public override Task OnExceptionAsync(ExceptionContext context)
        {
            var ex = context.Exception;

            _logger.LogError(ex, ex.Message);

            context.Result = new ContentResult
            {
                Content = ex.Message,
                ContentType = "application/json",
                StatusCode = (int)HttpStatusCode.InternalServerError
            };

            context.ExceptionHandled = true;

            return base.OnExceptionAsync(context);
        }
    }
}