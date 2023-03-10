namespace BooksShop.Models.Responce;

/// <summary>
/// Responce для получения заказа
/// </summary>
public class GetOrderResponce
{
    /// <summary>
    /// ID заказа
    /// </summary>
    public Guid OrderId { get; set; }

    /// <summary>
    /// Дата создания заказа
    /// </summary>
    public DateTime OrderDate { get; set; }

    /// <summary>
    /// Список книг
    /// </summary>
    public IEnumerable<Book> Books { get; set; } = Enumerable.Empty<Book>();
}