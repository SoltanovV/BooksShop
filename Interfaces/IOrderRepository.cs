namespace BooksShop.Interfaces
{
    public interface IOrderRepository : IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Order> GetOrderNumberAsync(int num);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IEnumerable<Order>> GetListOrdersDateAsync(DateTime time);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<BookOrder> CreateOrdersAsync(BookOrder model);
    }
}
