using AutoMapper;
using FoodDelivery.DTOs;
using FoodDelivery.Models;
using YourNamespace.Services.Interfaces;
using YourNamespace.Repositories.Interfaces;

namespace YourNamespace.Services.Implementations
{
    public class DeliveryService : IDeliveryService
    {
        private readonly IDeliveryRepository _repository;
        private readonly IMapper _mapper;

        public DeliveryService(IDeliveryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DeliveryDto>> GetAllAsync()
        {
            var deliveries = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<DeliveryDto>>(deliveries);
        }

        public async Task<DeliveryDto?> GetByIdAsync(int id)
        {
            var delivery = await _repository.GetByIdAsync(id);
            return _mapper.Map<DeliveryDto?>(delivery);
        }

        public async Task<DeliveryDto> AddAsync(CreateDeliveryDto dto)
        {
            var entity = _mapper.Map<Delivery>(dto);
            var created = await _repository.AddAsync(entity);
            return _mapper.Map<DeliveryDto>(created);
        }

        public async Task UpdateAsync(int id, CreateDeliveryDto dto)
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