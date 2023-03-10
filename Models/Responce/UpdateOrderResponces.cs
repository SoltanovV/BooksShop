namespace BooksShop.Models.Responce;

/// <summary>
/// Responce для обновления заказа
/// </summary>
public class UpdateOrderResponces
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