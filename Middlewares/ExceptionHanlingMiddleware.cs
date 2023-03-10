using System.Net;
using System.Text.Json;

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
            await HadleExceptionAsync(http, ex.Message, HttpStatusCode.NotFound);
        }
    }


    /// <summary>
    /// Метод для обработки исключений
    /// </summary>
    /// <param name="context">Тип передачи данных</param>
    /// <param name="exMessage">Текс исключения</param>
    /// <param name="statusCode">Код статуса кода</param>
    /// <returns>Сущность ошибки</returns>
    private async Task HadleExceptionAsync(HttpContext context, string exMessage, HttpStatusCode statusCode)
    {
        _logger.LogError(exMessage);
        var response = context.Response;

        response.ContentType = "application/json";
        response.StatusCode = (int)statusCode;

        ErrorDto errorDto = new()
        {
            StatusCode = (int)statusCode,
            Message = exMessage
        };

        var result = JsonSerializer.Serialize(errorDto);

        await response.WriteAsJsonAsync(result);
    }
}