using System.Net;
using System.Net.Mime;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace ETicaretAPI.API.Extentions;

public static class ConfigureExceptionHandlerExtension
{
    public static void ConfigureExceptionHandler<T>(this WebApplication application, ILogger<T> logger)
    {
        application.UseExceptionHandler(builder =>
        {
            builder.Run(async context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = MediaTypeNames.Application.Json;

               var contextFeatures  = context.Features.Get<IExceptionHandlerFeature>();
               if (contextFeatures != null)
               {
                   logger.LogError(contextFeatures.Error.Message);

                   await context.Response.WriteAsync(JsonSerializer.Serialize(new
                   {
                        statusCode = context.Response.StatusCode,
                        message = contextFeatures.Error.Message,
                        Title = "Hata alındı !"
                   }));
               }
            });
        });
        
    }
}