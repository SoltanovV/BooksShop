using System.ComponentModel.DataAnnotations;

namespace BooksShop.Models.Entity;

/// <summary>
/// Книги Заказы
/// </summary>
public class BookOrder
{
    /// <summary>
    /// Id заказа
    /// </summary>
    [Key]
    public Guid OrderId { get; set; }

    /// <summary>
    /// Навигационное свойство для Order
    /// </summary>
    public Order? Order { get; set; }

    /// <summary>
    /// Id книги
    /// </summary>
    public Guid BookId { get; set; }

    /// <summary>
    /// Навигационное свойство для Book
    /// </summary>
    public Book? Book { get; set; }
}