using FoodDelivery.DTOs;

namespace FoodDelivery.Services.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDto>> GetAllAsync();
        Task<OrderDto?> GetByIdAsync(int id);
        Task<OrderDto> AddAsync(CreateOrderDto dto);
        Task UpdateAsync(int id, CreateOrderDto dto);
        Task DeleteAsync(int id);
    }
}
