using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using HipodromoAPI.Exceptions;

namespace HipodromoAPI.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
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

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            var statusCode = exception switch
            {
                CategoriaInvalidaException => HttpStatusCode.BadRequest,
                ReservaDuplicadaException => HttpStatusCode.Conflict,
                _ => HttpStatusCode.InternalServerError
            };

            context.Response.StatusCode = (int)statusCode;

            var result = JsonConvert.SerializeObject(new { error = exception.Message });
            return context.Response.WriteAsync(result);
        }
    }
}
