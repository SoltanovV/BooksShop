using System.ComponentModel.DataAnnotations;

namespace BooksShop.Models.Entity;

/// <summary>
/// 
/// </summary>
public class Order
{
    /// <summary>
    /// Id заказа
    /// </summary>
    public Guid OrderId { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Дата создания заказа
    /// </summary>
    public DateTime OrderDate { get; set; }

    /// <summary>
    /// Навигационное свойство для Book
    /// </summary>
    public IEnumerable<Book> Books { get; set; }

    /// <summary>
    /// Навигационное свойство для BookOrder
    /// </summary>
    public IEnumerable<BookOrder> BookOrder { get; set; }
}