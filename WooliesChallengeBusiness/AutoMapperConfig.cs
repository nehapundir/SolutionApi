using AutoMapper;
using WooliesChallenge.Business.Models;
using WooliesChallenge.Database.DataModels;

namespace WooliesChallenge.Business
{
    public class AutoMapperConfig
    {
        public static IMapper Mapper { private set; get; }
        public static void Intialize()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Product, ProductDto>();
                cfg.CreateMap<ShopperHistory, ShopperHistoryDto>();
            });
            Mapper = config.CreateMapper();
        }
    }
}
