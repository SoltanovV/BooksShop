using AutoMapper;

namespace BooksShop.Utilities
{
    public class AutomapperSettings : Profile
    {
        public AutomapperSettings()
        {
            CreateMap<CreateBookRequest, Book>();
            CreateMap<Book, CreateBookResponce>();

            CreateMap<UpdateBookRequest, Book>();
            CreateMap<Book, UpdateBookResponce>();

            CreateMap<Book, GerBookResponce>();


            CreateMap<CreateOrderRequest, Order>();
            CreateMap<Order, CreateOrderResponces>();

            CreateMap<UpdateOrderRequest, Order>();
            CreateMap<Order, UpdateOrderResponces>();

            CreateMap<Order, GetOrderResponce>();

        }
        //public static MapperConfiguration RegisterMaps()
        //{
            
        //    //var mapperConfig = new MapperConfiguration(config =>
        //    //{
        //    //    //config.CreateMap<Book, BookResponce>();

        //    //    //config.CreateMap<CreateOrdersRequest, BookOrder>();
        //    //    //config.CreateMap<BookOrder, CreateOrdersResponces>();

        //    //    config.CreateMap<CreateOrdersRequest, Order>();
        //    //    config.CreateMap<Order, CreateOrdersResponces>();


        //    //});
        //   //return mapperConfig;
        //}
    }
}
