using FoodDelivery.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodDelivery.Services.Interfaces { public interface ICartService { Task<IEnumerable<CartDto>> GetByCustomerIdAsync(int customerId); Task<CartDto?> GetByIdAsync(int cartId, int customerId); Task<CartDto> AddAsync(CreateCartDto dto); Task UpdateAsync(int cartId, int customerId, CreateCartDto dto); Task DeleteAsync(int cartId, int customerId); } }