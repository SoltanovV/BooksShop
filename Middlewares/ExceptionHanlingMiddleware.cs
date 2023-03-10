using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;
using Microsoft.SqlServer.Server;
using System.Reflection.Metadata;
//using Notes.Application.Common.Exceptions;

namespace BooksShop.Middlewares;

public class ExceptionHanlingMiddleware
{
    private readonly RequestDelegate _requestDelegate;
    private readonly ILogger<ExceptionHanlingMiddleware> _logger;

    public ExceptionHanlingMiddleware(RequestDelegate requestDelegate,
        ILogger<ExceptionHanlingMiddleware> logger)
    {
        _requestDelegate = requestDelegate;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext http)
    {
        try
        {
            await _requestDelegate(http);
        }
        catch (Exception ex)
        {
            await HadleExceptionAsync(http, ex.Message, HttpStatusCode.NotFound, ex.Message);
        }
    }

    private async Task HadleExceptionAsync(HttpContext context, string exMessage, HttpStatusCode statusCode,
        string message)
    {
        _logger.LogError(exMessage);
        var response = context.Response;

        response.ContentType = "application/json";
        response.StatusCode = (int)statusCode;

        ErrorDto errorDto = new()
        {
            StatusCode = (int)statusCode,
            Message = message
        };

        var result = JsonSerializer.Serialize(errorDto);

        await response.WriteAsJsonAsync(result);
    }
}