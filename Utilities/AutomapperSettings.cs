using AutoMapper;

namespace BooksShop.Utilities
{
    public class AutomapperSettings : Profile
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mapperConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<BooksOrdersRequest, Book>().ReverseMap();
                config.CreateMap<BooksOrdersResponces, Book>().ReverseMap();
            });
            return mapperConfig;
        }
    }
}
