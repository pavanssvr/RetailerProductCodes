using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace IRIProductCodes.Filters
{
    /// <summary>
    /// Global exception filter
    /// </summary>
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            HttpResponse response = context.HttpContext.Response;
            response.StatusCode = 500;
            response.WriteAsync(context.Exception.Message);

            context.ExceptionHandled = true;
        }
    }
}
