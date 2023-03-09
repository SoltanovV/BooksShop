namespace BooksShop.Models.Request;

/// <summary>
/// Request для создания заказа
/// </summary>
public class CreateOrderRequest
{
    /// <summary>
    /// Id заказа 
    /// </summary>
    public Guid OrderId { get; set; }

    /// <summary>
    /// Дата создания заказа
    /// </summary>
    public DateTime OrderDate { get; set; }

    /// <summary>
    /// Массив Id книг
    /// </summary>
    public Guid[] ArrayBooksId { get; set; }
}