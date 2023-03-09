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
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

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

        }
    }
}
