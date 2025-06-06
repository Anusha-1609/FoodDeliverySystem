using FoodDelivery.DTOs;
using Microsoft.AspNetCore.Mvc;
using FoodDelivery.Services.Interfaces;

namespace FoodDelivery.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _service;

        public RestaurantController(IRestaurantService service)
        {
            _service = service;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CreateRestaurantDto dto)
        {
            await _service.UpdateAsync(id, dto);
            return NoContent();
        }
    }
}