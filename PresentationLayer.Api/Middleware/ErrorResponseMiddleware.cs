using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace PresentationLayer.Api.Middleware
{
    public class ErrorResponseMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorResponseMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, ILogger<ErrorResponseMiddleware> logger, IHostingEnvironment environment)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                logger.LogError(e, $"Произошла ошибка при обращении к методу '{context.Request.Path}'");

                var message = environment.IsDevelopment()
                    ? $"[trace: {context.TraceIdentifier}] {e.GetType().Name}: {e.Message}"
                    : "Произошла непредвиденная ошибка";

                var responseObject = new
                {
                    ErrorMessage = message,
                    TraceId = context.TraceIdentifier
                };

                context.Response.ContentType = "application/json; charset=utf-8";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                await context.Response.WriteAsync(JsonConvert.SerializeObject(responseObject, Formatting.Indented),
                    Encoding.UTF8);
            }
        }
    }
}