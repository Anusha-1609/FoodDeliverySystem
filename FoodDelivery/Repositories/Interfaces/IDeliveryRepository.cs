using FoodDelivery.Models;

namespace FoodDelivery.Repositories.Interfaces
{
    public interface IDeliveryRepository
    {
        Task<IEnumerable<Delivery>> GetAllAsync();
        Task<Delivery?> GetByIdAsync(int id);
        Task<Delivery> AddAsync(Delivery delivery);
        Task UpdateAsync(Delivery delivery);
        Task DeleteAsync(int id);
    }
}
