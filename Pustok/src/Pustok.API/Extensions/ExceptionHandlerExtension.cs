using Microsoft.AspNetCore.Diagnostics;
using Pustok.Business.DTOs.Common;
using Pustok.Business.Exceptions;
using System.Net;

namespace Pustok.API.Extensions;

public static class ExceptionHandlerExtension
{
    public static IApplicationBuilder AddExceptionHandlerService(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(error =>
        {
            error.Run(async context =>
            {
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                int statusCode = (int)HttpStatusCode.InternalServerError;
                string message = "Internal Server Error";

                if (contextFeature != null)
                {
                    //if(contextFeature.Error is ProductNotFoundException)
                    //{
                    //    statusCode = (int)HttpStatusCode.NotFound;
                    //    message = contextFeature.Error.Message;
                    //}
                    //else if(contextFeature.Error is ProductAlreadyExistException)
                    //{
                    //    statusCode = (int)HttpStatusCode.Conflict;
                    //    message = contextFeature.Error.Message;
                    //}

                    if (contextFeature.Error is IBaseException)
                    {
                        var exception = (IBaseException)contextFeature.Error;
                        statusCode = exception.StatusCode;
                        message = exception.Message;
                    }
                }

                context.Response.StatusCode = statusCode;
                await context.Response.WriteAsJsonAsync(new ResponseDto(statusCode, message));
                await context.Response.CompleteAsync();
            });
        });

        return app;
    }
}