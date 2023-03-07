namespace BooksShop.Repository
{
    public class OrderRepository : IOrderRepository 
    {
        private readonly ApplicationContext _db;

        public OrderRepository(ApplicationContext db)
        {
            _db = db;
        }

        public async Task<Order> GetOrderNumberAsync(int orderNum)
        {
            try
            {
                var search = await _db.Orders.SingleOrDefaultAsync(b => b.Id == orderNum);
                if (search is not null)
                {
                    return search;
                }
                throw new Exception("Не удалось найти заказ");
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<Order>> GetListOrdersDateAsync(DateTime date)
        {
            try
            {
                var search = await _db.Orders.Where(o => o.OrderDate.Date == date.Date).ToListAsync();

                if (search is not null)
                {
                    return search;
                }
                throw new Exception("Не удалось найти заказы");
            }
            catch
            {
                throw;
            }
        }

        public async Task<BookOrder> CreateOrdersAsync(BookOrder model)
        {
            try
            {
                var book = await _db.Books.SingleOrDefaultAsync(b => b.Id == model.BookId);

                var order = await _db.Orders.SingleOrDefaultAsync(o => o.Id == model.OrderId);

                var bookOrder = _db.BooksOrders.Where(bo => bo.OrderId == order.Id).Where(bo => bo.BookId == book.Id);

                if (book is not null & book is not null)
                {
                    var result = await _db.AddAsync(model);

                    await _db.SaveChangesAsync();

                    return result.Entity;

                }
                throw new Exception("Не удалось добавить в заказ");
            }
            catch
            {
                throw;
            }
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
