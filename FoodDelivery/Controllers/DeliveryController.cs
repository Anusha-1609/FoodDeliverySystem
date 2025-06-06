using FoodDelivery.DTOs;
using Microsoft.AspNetCore.Mvc;
using FoodDelivery.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace FoodDelivery.Controllers
{
    [Authorize(Roles = "RestaurantOwner")]
    [ApiController]
    [Route("api/[controller]")]
    public class DeliveryController : ControllerBase
    {
        private readonly IDeliveryService _service;

        public DeliveryController(IDeliveryService service)
        {
            _service = service;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var delivery = await _service.GetByIdAsync(id);
            if (delivery == null) return NotFound();
            return Ok(delivery);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDeliveryDto dto)
        {
            var created = await _service.AddAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = created.DeliveryID }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CreateDeliveryDto dto)
        {
            await _service.UpdateAsync(id, dto);
            return NoContent();
        }

    }
}