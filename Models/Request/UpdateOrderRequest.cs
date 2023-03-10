namespace BooksShop.Models.Request;

/// <summary>
/// Request для обновления заказа
/// </summary>
public class UpdateOrderRequest
{
    /// <summary>
    /// Id заказа 
    /// </summary>
    public Guid OrderId { get; set; }

    /// <summary>
    /// Массив Id книг
    /// </summary>
    public Guid[] ArrayBooksId { get; set; }
}