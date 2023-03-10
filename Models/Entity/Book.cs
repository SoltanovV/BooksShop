namespace BooksShop.Models.Entity;

/// <summary>
/// Книга
/// </summary>
public class Book
{
    /// <summary>
    /// Id книги
    /// </summary>
    public Guid BookId { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Название книги
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Дата выхода книги
    /// </summary>
    public DateTime Release { get; set; } = DateTime.Now;

    /// <summary>
    /// Навигационное свойство для Order
    /// </summary>
    public IEnumerable<Order>? Orders { get; set; }

    /// <summary>
    /// Навигационное свойство для BookOrder
    /// </summary>
    public IEnumerable<BookOrder>? BookOrder { get; set; }
}