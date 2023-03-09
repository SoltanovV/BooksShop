namespace BooksShop.Models.Responce;

public class CreateOrderResponces
{
    /// <summary>
    /// 
    /// </summary>
    public Guid OrderId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public IEnumerable<Book> Books { get; set; } = Enumerable.Empty<Book>();
}
