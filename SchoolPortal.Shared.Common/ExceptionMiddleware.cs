using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Http;

namespace SchoolPortal.Shared.Common
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context); // İstek işleme devam et
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            //_logger.AddLog(new GenericLogModel { Object = exception, Type = Type.Error, Message = exception.Message});

            var response = new BaseResponseModel<object>
            {
                Success = true,
                Message = "Bir hata oluştu: " + exception.Message,
                Data = null,
                StatusCode = HttpStatusCode.InternalServerError
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)response.StatusCode;

            var json = System.Text.Json.JsonSerializer.Serialize(response);
            return context.Response.WriteAsync(json);
        }
    }
}
