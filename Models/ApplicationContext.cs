namespace BooksShop.Models
{
    public class  ApplicationContext : DbContext
    {
        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<BookOrder> BooksOrders { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options) 
            : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var book1 = new Book()
            {
                Id = 1,
                Name = "Test1",
                Release = DateTime.Now
            };

            var book2 = new Book()
            {
                Id = 2,
                Name = "Test",
                Release = DateTime.Now
            };

            var book3 = new Book()
            {
                Id = 3,
                Name = "dsdsdsds",
                Release = new DateTime(2018, 5, 1, 8, 30, 52)
            };


            var book4 = new Book()
            {

                Id = 4,
                Name = "dsdsdsd111",
                Release = DateTime.Now
            };


            var book5 = new Book()
            {
                Id = 5,
                Name = "Test",
                Release = DateTime.Now
            };

            var books = new List<Book>() { book1, book2, book3, book4, book5 };

            var order1 = new Order()
            {
                Id = 1,
                NumberOrder = 1,
                OrderDate = new DateTime(2018, 5, 1, 8, 30, 52)

            };

            var order2 = new Order()
            {
                Id = 2,
                NumberOrder = 2,
                OrderDate = new DateTime(2014, 5, 1, 8, 30, 52)

            };

            var order3 = new Order()
            {
                Id = 3,
                NumberOrder = 3,
                OrderDate = new DateTime(2022, 5, 1, 8, 30, 52) 

            };

            var order4 = new Order()
            {
                Id = 4,
                NumberOrder = 4,
                OrderDate = new DateTime(2019, 5, 1, 8, 30, 52)

            };

            var orders = new List<Order>() { order1, order2, order3, order4 };

            var bookOrder1 = new BookOrder()
            {
                BookId = 1,
                OrderId = 1
            };

            var bookOrder2 = new BookOrder()
            {
                BookId = 2,
                OrderId = 1
            };

            var bookOrder3 = new BookOrder()
            {
                BookId = 3,
                OrderId = 1
            };

            var bookOrder4 = new BookOrder()
            {
                BookId = 1,
                OrderId = 3
            };

            var bookOrder5 = new BookOrder()
            {
                BookId = 4,
                OrderId = 2
            };

            var booksOrders = new List<BookOrder>() { bookOrder1, bookOrder2, bookOrder3, bookOrder4, bookOrder5 };

            modelBuilder.Entity<Book>().HasData(books);
            modelBuilder.Entity<Order>().HasData(orders);
            modelBuilder.Entity<BookOrder>().HasData(booksOrders);

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
                    .HasKey(bo => new { bo.BookId, bo.OrderId})
                );
        }
    }
}
