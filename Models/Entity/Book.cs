namespace BooksShop.Models.Entity;

/// <summary>
/// 
/// </summary>
public class Book
{
    /// <summary>
    /// 
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string Name { get; set; } = string.Empty; 

    /// <summary>
    /// 
    /// </summary>
    public DateTime Release { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public IEnumerable<Order> Orders { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public IEnumerable<BookOrder> BookOrder { get; set; }

}
