using AutoMapper;
using FoodDelivery.DTOs;
using FoodDelivery.Models;
using YourNamespace.Repositories.Interfaces;
using YourNamespace.Services.Interfaces;

namespace YourNamespace.Services.Implementations
{
    public class MenuItemService : IMenuItemService
    {
        private readonly IMenuItemRepository _repository;
        private readonly IMapper _mapper;

        public MenuItemService(IMenuItemRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MenuItemDto>> GetAllAsync()
        {
            var items = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<MenuItemDto>>(items);
        }

        public async Task<MenuItemDto?> GetByIdAsync(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            return _mapper.Map<MenuItemDto?>(item);
        }

        public async Task<MenuItemDto> AddAsync(CreateMenuItemDto dto)
        {
            var entity = _mapper.Map<MenuItem>(dto);
            var created = await _repository.AddAsync(entity);
            return _mapper.Map<MenuItemDto>(created);
        }

        public async Task UpdateAsync(int id, CreateMenuItemDto dto)
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