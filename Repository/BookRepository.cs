namespace BooksShop.Repository
{
    public class BookRepository : IBookRepository, IDisposable
    {
        private readonly ApplicationContext _db;
        private bool disposed = false;

        public BookRepository(ApplicationContext db)
        {
            _db = db;
        }

        public async Task<Book> GetBookAsync(Guid id)
        {
            try
            {
                var search = await _db.Books.SingleOrDefaultAsync(b => b.BookId == id);
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

        public async Task<IEnumerable<Book>> GetBooksAsync(string name)
        {
            try
            {
                var search = await _db.Books.Where(b => b.Name == name).AsNoTracking().ToListAsync();
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

        public async Task<IEnumerable<Book>> GetBooksAsync(DateTime date)
        {
            try
            {
                var search = await _db.Books.Where(b => b.Release.Date == date).AsNoTracking().ToListAsync();

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

        public async Task<IEnumerable<Book>> GetBooksAsync(string name, DateTime date)
        {
            try
            {
                var search = await _db.Books.Where(b => b.Name == name && b.Release.Date == date).AsNoTracking().ToListAsync();
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

        public async Task<Book> CreateBookAsync(Book book)
        {
            try
            {
                var search = await _db.Books.FirstOrDefaultAsync(b => b.BookId == book.BookId);
                if (search is null)
                {
                    var result = await _db.Books.AddAsync(book);
                    await _db.SaveChangesAsync();
                    return result.Entity;
                }
                throw new Exception("Не удалось создать книгу книгу");
            }
            catch
            {
                throw;
            }
        }

        public async Task<Book> UpdateBookAsync(Book book)
        {
            try
            {
                var result = _db.Books.Update(book);
                await _db.SaveChangesAsync();
                return result.Entity;
            }
            catch
            {
                throw new Exception("Не удалось удалить");
            }

        }

        public async Task<Book> RemoveBookAsync(Guid id)
        {
            try
            {
                var search = await _db.Books.FirstOrDefaultAsync(b => b.BookId == id);
                if (search is not null)
                {
                    var result = _db.Books.Remove(search);
                    await _db.SaveChangesAsync();
                    return result.Entity;
                }
                throw new Exception("Не удалось создать книгу книгу");
            }
            catch
            {
                throw;
            }

        }


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
