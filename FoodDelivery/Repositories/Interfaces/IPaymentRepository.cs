﻿using FoodDelivery.Models;

namespace FoodDelivery.Repositories.Interfaces
{
    public interface IPaymentRepository
    {
        Task<IEnumerable<Payment>> GetAllAsync();
        Task<Payment?> GetByIdAsync(int id);
        Task<Payment> AddAsync(Payment payment);
        Task UpdateAsync(Payment payment);
        Task DeleteAsync(int id);
    }
}
