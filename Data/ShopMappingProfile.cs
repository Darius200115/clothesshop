using AutoMapper;
using test_proj_843823.Data.Entities;
using test_proj_843823.ViewModels;

namespace test_proj_843823.Data
{
    public class ShopMappingProfile : Profile
    {
        public ShopMappingProfile()
        {
            CreateMap<Order, OrderViewModel>()
                .ForMember(o=>o.OrderId , p=>p.MapFrom(o=>o.Id))
                .ReverseMap();

            CreateMap<OrderItem, OrderItemViewModel>()
                .ForMember(o => o.ClothesId, p => p.MapFrom(o => o.Clothes.ClothesId))
                .ForMember(o => o.Brand, p => p.MapFrom(o => o.Clothes.Brand))
                .ForMember(o => o.Category, p => p.MapFrom(o => o.Clothes.Category))
                .ForMember(o => o.Price, p => p.MapFrom(o => o.Clothes.Price))
                .ForMember(o => o.Count, p => p.MapFrom(o => o.Clothes.Count))
                .ReverseMap();
            



        }
    }
}
