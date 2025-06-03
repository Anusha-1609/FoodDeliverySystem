using FoodDeliver.DTOs;

namespace YourNamespace.Services.Interfaces
{
    public interface IRestaurantService
    {
        Task<IEnumerable<RestaurantDto>> GetAllAsync();
        Task<RestaurantDto?> GetByIdAsync(int id);
        Task<RestaurantDto> AddAsync(CreateRestaurantDto dto);
        Task UpdateAsync(int id, CreateRestaurantDto dto);
        Task DeleteAsync(int id);
    }
}
