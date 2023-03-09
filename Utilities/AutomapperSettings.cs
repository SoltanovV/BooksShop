using AutoMapper;

namespace BooksShop.Utilities;

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
}