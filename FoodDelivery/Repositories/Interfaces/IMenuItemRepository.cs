using FoodDelivery.Models;

namespace FoodDelivery.Repositories.Interfaces
{
    public interface IMenuItemRepository
    {
        Task<IEnumerable<MenuItem>> GetAllAsync();
        Task<MenuItem?> GetByIdAsync(int id);
        Task<MenuItem> AddAsync(MenuItem item);
        Task UpdateAsync(MenuItem item);
        Task DeleteAsync(int id);
    }
}