namespace BooksShop.Models.Entity;

/// <summary>
/// 
/// </summary>
public class BookOrder
{
    /// <summary>
    /// 
    /// </summary>
    public int BookId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public Book Book { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public int OrderId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public Order Order { get; set; }

}
