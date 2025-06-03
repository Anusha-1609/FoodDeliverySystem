using FoodDelivery.DTOs;

namespace FoodDelivery.Services.Interfaces
{
    public interface IDeliveryService
    {
        Task<IEnumerable<DeliveryDto>> GetAllAsync();
        Task<DeliveryDto?> GetByIdAsync(int id);
        Task<DeliveryDto> AddAsync(CreateDeliveryDto dto);
        Task UpdateAsync(int id, CreateDeliveryDto dto);
        Task DeleteAsync(int id);
    }
}