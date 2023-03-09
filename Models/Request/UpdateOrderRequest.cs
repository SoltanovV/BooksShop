namespace BooksShop.Models.Request;

public class UpdateOrderRequest
{
    /// <summary>
    /// 
    /// </summary>
    public Guid OrderId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public Guid[] ArrayBooksId { get; set; }
}
