namespace BooksShop.Interfaces
{
    public interface IBookRepository : IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Book> GetIdAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IEnumerable<Book>> GetListBooksNameAsync(string name);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IEnumerable<Book>> GetListBooksDateAsync(DateTime time);
    }
}
