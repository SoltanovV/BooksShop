using BooksShop.Interfaces;

namespace BooksShop.Repository
{
    public class BookRepository : IBookRepository, IDisposable
    {
        private readonly ApplicationContext _db;

        public BookRepository(ApplicationContext db)
        {
            _db = db;
        }

        public async Task<Book> GetIdAsync(int id)
        {
            try
            {
                var search = await _db.Books.SingleOrDefaultAsync(b => b.Id == id);
                if (search is not null)
                {
                    return search;
                }
                throw new Exception("Не удалось найти книгу");
            }
            catch 
            {
                throw;
            }
        }

        public async Task<IEnumerable<Book>> GetListBooksNameAsync(string name)
        {
            try
            {
                var search = await _db.Books.Where(b => b.Name == name).ToListAsync();
                if (search is not null)
                {
                    return search;
                }
                throw new Exception("Не удалось найти книгу");
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<Book>> GetListBooksDateAsync(DateTime date)
        {
            try
            {
                var search = await _db.Books.Where(b => b.Release.Date == date.Date).ToListAsync();
                                                    
                if (search is not null)
                {
                    return search;
                }
                throw new Exception("Не удалось найти книгу");
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
