using AutoMapper;
using FoodDelivery.DTOs;
using FoodDelivery.Models;
using FoodDelivery.Services.Interfaces;
using FoodDelivery.Repositories.Interfaces;

namespace FoodDelivery.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderDto>> GetAllAsync()
        {
            var orders = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<OrderDto>>(orders);
        }

        public async Task<OrderDto?> GetByIdAsync(int id)
        {
            var order = await _repository.GetByIdAsync(id);
            return _mapper.Map<OrderDto?>(order);
        }

        public async Task<OrderDto> AddAsync(CreateOrderDto dto)
        {
            var entity = _mapper.Map<Order>(dto);
            var created = await _repository.AddAsync(entity);
            return _mapper.Map<OrderDto>(created);
        }

        public async Task UpdateAsync(int id, CreateOrderDto dto)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return;
            _mapper.Map(dto, existing);
            await _repository.UpdateAsync(existing);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}