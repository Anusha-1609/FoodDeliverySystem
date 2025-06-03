using AutoMapper;
using FoodDelivery.DTOs;
using FoodDelivery.Models;
using FoodDelivery.Repositories.Interfaces;
using FoodDelivery.Services.Interfaces;

namespace YourNamespace.Services.Implementations
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _repository;
        private readonly IMapper _mapper;

        public PaymentService(IPaymentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PaymentDto>> GetAllAsync()
        {
            var payments = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<PaymentDto>>(payments);
        }

        public async Task<PaymentDto?> GetByIdAsync(int id)
        {
            var payment = await _repository.GetByIdAsync(id);
            return _mapper.Map<PaymentDto?>(payment);
        }

        public async Task<PaymentDto> AddAsync(CreatePaymentDto dto)
        {
            var entity = _mapper.Map<Payment>(dto);
            var created = await _repository.AddAsync(entity);
            return _mapper.Map<PaymentDto>(created);
        }

        public async Task UpdateAsync(int id, CreatePaymentDto dto)
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