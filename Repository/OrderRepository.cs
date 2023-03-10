namespace BooksShop.Repository;

public class OrderRepository : IOrderRepository
{
    private readonly ApplicationContext _db;
    private bool disposed = false;

    public OrderRepository(ApplicationContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Order>> GetOrderAsync(Guid num)
    {
        try
        {
            var selectOrder = await _db.Orders
                .Where(o => o.OrderId == num)
                .Include(o => o.Books)
                .ToListAsync();

            if (selectOrder.Count != 0)
                return selectOrder;

            throw new Exception("Order not found");
        }
        catch
        {
            throw;
        }
    }

    public async Task<IEnumerable<Order>> GetOrdersAsync(DateTime date)
    {
        try
        {
            var selectOrder = await _db.Orders
                .Where(o => o.OrderDate.Date == date)
                .Include(o => o.Books)
                .AsNoTracking()
                .ToListAsync();

            if (selectOrder.Count != 0)
                return selectOrder;

            throw new Exception("Could not find orders");
        }
        catch
        {
            throw;
        }
    }

    public async Task<IEnumerable<Order>> GetOrdersAsync(Guid num, DateTime date)
    {
        try
        {
            var selectOrder = await _db.Orders
                .Where(o => o.OrderDate.Date == date
                            && o.OrderId == num)
                .Include(o => o.Books)
                .AsNoTracking()
                .ToListAsync();

            if (selectOrder.Count != 0)
                return selectOrder;

            throw new Exception("Could not find orders");
        }
        catch
        {
            throw;
        }
    }

    public async Task<Order> CreateOrderAsync(Order model, IEnumerable<Guid> booksIds)
    {
        try
        {
            var order = await _db.Orders.SingleOrDefaultAsync(o => o.OrderId == model.OrderId);

            if (order is null)
            {
                await _db.Orders.AddAsync(model);
                await _db.SaveChangesAsync();

                await UpdateOrderAsync(model, booksIds);

                return model;
            }
            else
            {
                await UpdateOrderAsync(order, booksIds);

                return model;
            }
        }
        catch
        {
            throw;
        }
    }

    public async Task<Order> UpdateOrderAsync(Order order, IEnumerable<Guid> ArrayBooksId)
    {
        try
        {
            var search = await _db.Orders.FirstOrDefaultAsync(o => o.OrderId == order.OrderId);

            if (search is null) throw new Exception("Order not found");

            foreach (var book in ArrayBooksId)
            {
                var foundBook = await _db.Books
                    .SingleOrDefaultAsync(b => b.BookId == book);

                if (foundBook is null)
                    continue;

                var orderBook = await _db.BooksOrders
                    .FirstOrDefaultAsync(bo => bo.OrderId == order.OrderId
                                               && bo.BookId == foundBook.BookId);

                if (orderBook is null)
                    await _db.BooksOrders
                        .AddAsync(new BookOrder()
                        {
                            OrderId = order.OrderId,
                            BookId = foundBook.BookId
                        });
            }

            await _db.SaveChangesAsync();
            return order;
        }
        catch
        {
            throw;
        }
    }

    public async Task<Order> RemoveOrderAsync(Guid orderId)
    {
        try
        {
            var search =
                await _db.Orders
                    .FirstOrDefaultAsync(o => o.OrderId == orderId);

            if (search is null) throw new Exception("Order not found");
            _db.Orders.Remove(search);
            await _db.SaveChangesAsync();
            return search;
        }
        catch
        {
            throw;
        }
    }

    public async Task<BookOrder> RemoveBookInOrderAsync(Guid orderId, Guid bookId)
    {
        try
        {
            var search =
                await _db.BooksOrders
                    .FirstOrDefaultAsync(bo => bo.OrderId == orderId
                                               && bo.BookId == bookId);

            if (search is null) throw new Exception("Could not find order or book");
            _db.BooksOrders.Remove(search);
            await _db.SaveChangesAsync();
            return search;
        }
        catch
        {
            throw;
        }
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
            if (disposing)
                _db.Dispose();
        disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}