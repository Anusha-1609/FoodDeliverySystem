using AutoMapper;
using FoodDelivery.DTOs;
using FoodDelivery.Models;
using FoodDelivery.Repositories.Interfaces;
using FoodDelivery.Services.Interfaces;

namespace FoodDelivery.Services.Implementations
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _repository; private readonly IMapper _mapper;

        public CartService(ICartRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CartDto>> GetByCustomerIdAsync(int customerId)
        {
            var carts = await _repository.GetByCustomerIdAsync(customerId);
            return _mapper.Map<IEnumerable<CartDto>>(carts);
        }

        public async Task<CartDto?> GetByIdAsync(int cartId, int customerId)
        {
            var cart = await _repository.GetByIdAndCustomerAsync(cartId, customerId);
            return _mapper.Map<CartDto?>(cart);
        }

        public async Task<CartDto> AddAsync(CreateCartDto dto)
        {
            var entity = _mapper.Map<Cart>(dto);
            var created = await _repository.AddAsync(entity);
            return _mapper.Map<CartDto>(created);
        }

        public async Task UpdateAsync(int cartId, int customerId, CreateCartDto dto)
        {
            var existing = await _repository.GetByIdAndCustomerAsync(cartId, customerId);
            if (existing == null) return;

            _mapper.Map(dto, existing);
            await _repository.UpdateAsync(existing);
        }

        public async Task DeleteAsync(int cartId, int customerId)
        {
            var existing = await _repository.GetByIdAndCustomerAsync(cartId, customerId);
            if (existing == null) return;

            await _repository.DeleteAsync(existing);
        }
    }

}