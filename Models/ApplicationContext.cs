namespace BooksShop.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<BookOrder> BooksOrders { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var book1 = new Book()
            {
                BookId = Guid.NewGuid(),
                Name = "Test1",
                Release = DateTime.Now
            };

            var book2 = new Book()
            {
                BookId = Guid.NewGuid(),
                Name = "Test",
                Release = DateTime.Now
            };
            var book3 = new Book()
            {
                BookId = Guid.NewGuid(),
                Name = "Test",
                Release = DateTime.Now
            };

            //var book3 = new Book()
            //{
            //    Id = Guid.NewGuid(),
            //    Name = "dsdsdsds",
            //    Release = new DateTime(2018, 5, 1, 8, 30, 52)
            //};


            //var book4 = new Book()
            //{
            //    Id = Guid.NewGuid(),
            //    Name = "dsdsdsd111",
            //    Release = DateTime.Now
            //};


            //var book5 = new Book()
            //{
            //    Id = Guid.NewGuid(),
            //    Name = "Test",
            //    Release = DateTime.Now
            //};

            var books = new List<Book>() { book1, book2, book3};

            //var order1 = new Order()
            //{
            //    OrderId = Guid.NewGuid(),
            //    OrderDate = new DateTime(2018, 5, 1, 8, 30, 52)

            //};

            //var order2 = new Order()
            //{
            //    OrderId = Guid.NewGuid(),
            //    OrderDate = new DateTime(2014, 5, 1, 8, 30, 52)

            //};

            //var order3 = new Order()
            //{
            //    OrderId = Guid.NewGuid(),
            //    OrderDate = new DateTime(2022, 5, 1, 8, 30, 52)

            //};

            //var order4 = new Order()
            //{
            //    OrderId = Guid.NewGuid(),
            //    OrderDate = new DateTime(2019, 5, 1, 8, 30, 52)

            //};

            //var orders = new List<Order>() { order1, order2, order3, order4 };

            //var bookOrder1 = new BookOrder()
            //{
            //    BookId = 1,
            //    OrderId = Guid.Parse("D66BFE23-8CE9-45E1-A213-F30A5F5E3849")
            //};

            //var bookOrder2 = new BookOrder()
            //{
            //    BookId = 2,
            //    OrderId = Guid.Parse("E01941C8-D3C9-4AE5-A68F-5617FB9AFA24")
            //};

            //var bookOrder3 = new BookOrder()
            //{
            //    BookId = 3,
            //    OrderId = Guid.Parse("D66BFE23-8CE9-45E1-A213-F30A5F5E3849")
            //};

            //var bookOrder4 = new BookOrder()
            //{
            //    BookId = 2,
            //    OrderId = Guid.Parse("67E510F7-1ED1-4A7E-9A9F-18768CD2D4BA")
            //};

            //var bookOrder5 = new BookOrder()
            //{
            //    BookId = 4,
            //    OrderId = Guid.Parse("34C40F17-B533-4805-8BE2-7C14DD61E9A5")
            //};

            //var booksOrders = new List<BookOrder>() { bookOrder1, bookOrder2, bookOrder3, bookOrder4, bookOrder5 };

            modelBuilder.Entity<Book>().HasData(books);
            //modelBuilder.Entity<Order>().HasData(orders);
            //modelBuilder.Entity<BookOrder>().HasData(booksOrders);

            // relationships many-to-many
            modelBuilder.Entity<Book>()
                .HasMany(b => b.Orders)
                .WithMany(o => o.Books)
                .UsingEntity<BookOrder>(
                j => j
                    .HasOne(bo => bo.Order)
                    .WithMany(o => o.BookOrder)
                    .HasForeignKey(bo => bo.OrderId),
                j => j
                    .HasOne(bo => bo.Book)
                    .WithMany(b => b.BookOrder)
                    .HasForeignKey(bo => bo.BookId),
                j => j
                    .HasKey(bo => new { bo.OrderId, bo.BookId})
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
