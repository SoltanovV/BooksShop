namespace BooksShop.Models.Request;

public class CreateBookRequest
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
