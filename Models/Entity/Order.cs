namespace BooksShop.Models.Entity;

/// <summary>
/// 
/// </summary>
public class Order
{
    /// <summary>
    /// 
    /// </summary>
    public int Id { get; set; } 

    /// <summary>
    /// 
    /// </summary>
    public int NumberOrder { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public DateTime OrderDate { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public IEnumerable<Book>? Books { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public IEnumerable<BookOrder> BookOrder { get; set; }
}
