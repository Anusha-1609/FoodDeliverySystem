using AutoMapper;
using FoodDeliver.DTOs;
using FoodDelivery.DTOs;
using FoodDelivery.Models;
using YourNamespace.DTOs;

namespace FoodDelivery.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<Customer, CustomerDto>();
            CreateMap<CreateCustomerDto, Customer>();
            CreateMap<Restaurant, RestaurantDto>().ReverseMap();
            CreateMap<CreateRestaurantDto, Restaurant>();
            CreateMap<MenuItem, MenuItemDto>();
            CreateMap<CreateMenuItemDto, MenuItem>();
            CreateMap<Order, OrderDto>();
            CreateMap<CreateOrderDto, Order>();
            CreateMap<Delivery, DeliveryDto>();
            CreateMap<CreateDeliveryDto, Delivery>();
        }
    }
} 