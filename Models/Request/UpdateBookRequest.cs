namespace BooksShop.Models.Request
{
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
}
