namespace BooksShop.Models.Request;

public class CreateOrderRequest
{
    /// <summary>
    /// 
    /// </summary>
    public Guid OrderId { get; set; }

    /// <summary>
    /// Дата создания заказа
    /// </summary>
    public DateTime OrderDate { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public Guid[] ArrayBooksId { get; set; }
}
