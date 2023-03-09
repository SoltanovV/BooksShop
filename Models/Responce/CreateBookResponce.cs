namespace BooksShop.Models.Responce;

/// <summary>
/// 
/// </summary>
public class CreateBookResponce
{
    /// <summary>
    /// 
    /// </summary>
    public Guid BookId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public DateTime Release { get; set; }
}
