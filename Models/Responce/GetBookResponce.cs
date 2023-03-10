namespace BooksShop.Models.Responce;

/// <summary>
/// Responce для получения списка книг
/// </summary>
public class GetBookResponce
{
    /// <summary>
    /// Название книги
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Дата выхода книги 
    /// </summary>
    public DateTime Release { get; set; }
}