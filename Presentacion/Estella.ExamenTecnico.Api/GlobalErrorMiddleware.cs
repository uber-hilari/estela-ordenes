using Estela.ExamenTecnico.Dominio;
using Microsoft.AspNetCore.Http.Features;
using System.Net;
using System.Text.Json;

namespace Estella.ExamenTecnico.Api
{
    public class GlobalErrorMiddleware(RequestDelegate next)
    {
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandlerError(context, ex);
            }
        }

        private Task HandlerError(HttpContext context, Exception error)
        {
            context.Response.ContentType = "application/json";

            object data;
            if (error is BaseException ex)
            {
                context.Response.StatusCode = ex.Codigo / 100;
                var responseFeature = context.Response.HttpContext.Features.Get<IHttpResponseFeature>();
                if (responseFeature != null)
                    responseFeature.ReasonPhrase = ex.Message;
                data = ex.GetErrors();
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var responseFeature = context.Response.HttpContext.Features.Get<IHttpResponseFeature>();
                if (responseFeature != null)
                    responseFeature.ReasonPhrase = "Error del Servidor";
                data = "Error del Servidor";
            }
            return context.Response.WriteAsync(JsonSerializer.Serialize(data));
        }
    }
}
