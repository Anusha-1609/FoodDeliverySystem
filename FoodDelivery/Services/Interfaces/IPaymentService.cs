using FoodDelivery.DTOs;

namespace FoodDelivery.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<IEnumerable<PaymentDto>> GetAllAsync();
        Task<PaymentDto?> GetByIdAsync(int id);
        Task<PaymentDto> AddAsync(CreatePaymentDto dto);
        Task UpdateAsync(int id, CreatePaymentDto dto);
        Task DeleteAsync(int id);
    }
}