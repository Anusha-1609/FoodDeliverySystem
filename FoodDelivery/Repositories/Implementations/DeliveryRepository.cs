using FoodDelivery.Models;
using Microsoft.EntityFrameworkCore;
using FoodDelivery.Repositories.Interfaces;

namespace FoodDelivery.Repositories.Implementations
{
    public class DeliveryRepository : IDeliveryRepository
    {
        private readonly FoodDeliverySystemContext _context;

        public DeliveryRepository(FoodDeliverySystemContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Delivery>> GetAllAsync()
        {
            return await _context.Deliveries.ToListAsync();
        }

        public async Task<Delivery?> GetByIdAsync(int id)
        {
            return await _context.Deliveries.FindAsync(id);
        }

        public async Task<Delivery> AddAsync(Delivery delivery)
        {
            _context.Deliveries.Add(delivery);
            await _context.SaveChangesAsync();
            return delivery;
        }

        public async Task UpdateAsync(Delivery delivery)
        {
            _context.Entry(delivery).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var delivery = await _context.Deliveries.FindAsync(id);
            if (delivery != null)
            {
                _context.Deliveries.Remove(delivery);
                await _context.SaveChangesAsync();
            }
        }
    }
}