using FoodDelivery.DTOs;
using FoodDelivery.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoodDelivery.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuItemController : ControllerBase
    {
        private readonly IMenuItemService _service;

        public MenuItemController(IMenuItemService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMenuItemDto dto)
        {
            var created = await _service.AddAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = created.ItemID }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CreateMenuItemDto dto)
        {
            await _service.UpdateAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}