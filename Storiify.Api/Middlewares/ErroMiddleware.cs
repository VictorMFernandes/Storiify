using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Storiify.Api.Middlewares
{
    internal class ErroMiddleware
    {
        private readonly RequestDelegate _next;

        public ErroMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var resultado = JsonConvert.SerializeObject(new
            {
                sucesso = false,
                erros = new
                {
                    mensagem = exception.Message,
                    erroInterno = exception.InnerException?.Message,
                    stackTrace = exception.StackTrace
                }
            });

            return context.Response.WriteAsync(resultado);
        }
    }
}
