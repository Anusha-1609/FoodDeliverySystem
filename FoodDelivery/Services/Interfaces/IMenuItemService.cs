﻿using FoodDelivery.DTOs;

namespace FoodDelivery.Services.Interfaces
{
    public interface IMenuItemService
    {
        Task<IEnumerable<MenuItemDto>> GetAllAsync();
        Task<MenuItemDto?> GetByItemAndRestaurantAsync(int itemId, int restaurantId); // 🔄 Replaced GetByIdAsync
        Task<MenuItemDto> AddAsync(CreateMenuItemDto dto);
        Task UpdateAsync(int id, CreateMenuItemDto dto);
        Task DeleteAsync(int id);
    }
}



//using FoodDelivery.DTOs;

//namespace FoodDelivery.Services.Interfaces
//{
//    public interface IMenuItemService
//    {
//        Task<IEnumerable<MenuItemDto>> GetAllAsync();
//        Task<MenuItemDto?> GetByIdAsync(int id);
//        Task<MenuItemDto> AddAsync(CreateMenuItemDto dto);
//        Task UpdateAsync(int id, CreateMenuItemDto dto);
//        Task DeleteAsync(int id);
//    }
//}