namespace BooksShop.Models.Request;

/// <summary>
/// Request для создания книги
/// </summary>
public class UpdateBookRequest
{
    /// <summary>
    /// Название книги
    /// </summary>
    public Guid BookId { get; set; }

    /// <summary>
    /// Название книги
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Дата выхода книги
    /// </summary>
    public DateTime Release { get; set; }
}