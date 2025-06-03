using FoodDelivery.DTOs;

namespace YourNamespace.Services.Interfaces
{
    public interface IMenuItemService
    {
        Task<IEnumerable<MenuItemDto>> GetAllAsync();
        Task<MenuItemDto?> GetByIdAsync(int id);
        Task<MenuItemDto> AddAsync(CreateMenuItemDto dto);
        Task UpdateAsync(int id, CreateMenuItemDto dto);
        Task DeleteAsync(int id);
    }
}