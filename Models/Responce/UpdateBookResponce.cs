namespace BooksShop.Models.Responce;

/// <summary>
/// Responce для обновления книги
/// </summary>
public class UpdateBookResponce
{
    /// <summary>
    /// Id книги 
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