using System.Text.Json;

namespace BooksShop.Models;

/// <summary>
/// Сущность для получения данных из ошибки
/// </summary>
public class ErrorDto
{
    /// <summary>
    /// Статус код
    /// </summary>
    public int StatusCode { get; set; }

    /// <summary>
    /// Сообщение ошибки
    /// </summary>
    public string Message { get; set; }

    /// <summary>
    /// Переопределение метода ToString
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}