namespace BooksShop.Interfaces;

public interface IBookRepository : IDisposable
{
    /// <summary>
    /// Получение информации книги по ID
    /// </summary>
    /// <param name="id">Id книги</param>
    /// <returns>Найденную книгу</returns>
    Task<Book> GetBookAsync(Guid id);

    /// <summary>
    /// Получение списка книг по названию
    /// </summary>
    /// <param name="name">Название кинги</param>
    /// <returns>Список книг по названию</returns>
    Task<IEnumerable<Book>> GetBooksAsync(string name);

    /// <summary>
    /// Получение списка книг по дате выхода
    /// </summary>
    /// <param name="date">Дата выхода книги</param>
    /// <returns>Список книг по дате выхода</returns>
    Task<IEnumerable<Book>> GetBooksAsync(DateTime date);

    /// <summary>
    /// Получение списка книг по названию и дате выхода
    /// </summary>
    /// <param name="name">Название книги</param>
    /// <param name="date">Дата выхода</param>
    /// <returns>Список книг по названию и дате выхода</returns>
    Task<IEnumerable<Book>> GetBooksAsync(string name, DateTime date);

    /// <summary>
    /// Создает кингу
    /// </summary>
    /// <param name="book">Сущность для создания</param>
    /// <returns>Созданную книгу</returns>
    Task<Book> CreateBookAsync(Book book);

    /// <summary>
    /// Обновление информации по книги
    /// </summary>
    /// <param name="book">Модель для обновления</param>
    /// <returns>Обновленную информацию по книге</returns>
    Task<Book> UpdateBookAsync(Book book);

    /// <summary>
    /// Удаляет книгу
    /// </summary>
    /// <param name="id">Id книги</param>
    /// <returns>Удаленную книгу</returns>
    Task<Book> RemoveBookAsync(Guid id);
}