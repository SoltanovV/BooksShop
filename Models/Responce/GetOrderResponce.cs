namespace BooksShop.Models.Responce
{
    public class GetOrderResponce
    {
        /// <summary>
        /// 
        /// </summary>
        public Guid OrderId { get; set; }

        /// <summary>
        /// Дата создания заказа
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<Book> Books { get; set; } 
    }
}
