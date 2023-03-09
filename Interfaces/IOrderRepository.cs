namespace BooksShop.Interfaces;

public interface IOrderRepository : IDisposable
{
    /// <summary>
    /// Получение информации о заказе по ID
    /// </summary>
    /// <param name="num">Id заказа</param>
    /// <returns>Информацию по заказу</returns>
    Task<IEnumerable<Order>> GetOrderAsync(Guid num);

    /// <summary>
    /// Получение списка заказов за определенное время 
    /// </summary>
    /// <param name="date"></param>
    /// <returns>Список заказов</returns>
    Task<IEnumerable<Order>> GetOrdersAsync(DateTime date);

    /// <summary>
    /// Получение заказа за определенное время 
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    Task<IEnumerable<Order>> GetOrdersAsync(Guid num, DateTime date);

    /// <summary>
    /// Создание заказа
    /// </summary>
    /// <param name="model">Модель для создания заказа</param>
    /// <param name="booksIds">Список книг</param>
    /// <returns>Созданный заказ</returns>
    Task<Order> CreateOrderAsync(Order model, IEnumerable<Guid> booksIds);

    /// <summary>
    /// Обновление заказа
    /// </summary>
    /// <param name="model">Модель для обновления заказа</param>
    /// <param name="booksIds">Список книг</param>
    /// <returns>Обновленный заказ</returns>
    Task<Order> UpdateOrderAsync(Order model, IEnumerable<Guid> booksIds);

    /// <summary>
    /// Удаление заказа
    /// </summary>
    /// <param name="orderId">ID заказа</param>
    /// <returns>Удаленный заказ</returns>
    Task<Order> RemoveOrderAsync(Guid orderId);

    /// <summary>
    /// Удаление книги из заказа
    /// </summary>
    /// <param name="orderId">ID заказа</param>
    /// <returns>Удаленный заказ</returns>
    Task<BookOrder> RemoveBookInOrderAsync(Guid orderId, Guid bookId);
}