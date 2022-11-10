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
                .ReverseMap(); 
        }
    }
}
