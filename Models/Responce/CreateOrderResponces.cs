namespace BooksShop.Models.Responce;

/// <summary>
/// Responces для создания заказа 
/// </summary>
public class CreateOrderResponces
{
    /// <summary>
    /// Id заказа 
    /// </summary>
    public Guid OrderId { get; set; }

    /// <summary>
    /// Список книг в заказе
    /// </summary>
    public IEnumerable<Book> Books { get; set; } = Enumerable.Empty<Book>();
}