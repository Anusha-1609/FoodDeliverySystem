using FoodDelivery.DTOs;
using FoodDelivery.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodDelivery.Controllers
{
    [Authorize]
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

        [HttpGet("{itemId}/{restaurantId}")]
        [Authorize(Roles = "RestaurantOwner")]
        public async Task<IActionResult> Get(int itemId, int restaurantId)
        {
            var item = await _service.GetByItemAndRestaurantAsync(itemId, restaurantId);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        [Authorize(Roles = "RestaurantOwner")]
        public async Task<IActionResult> Create(CreateMenuItemDto dto)
        {
            var created = await _service.AddAsync(dto);
            return CreatedAtAction(nameof(Get), new { itemId = created.ItemID, restaurantId = created.RestaurantID }, created);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "RestaurantOwner")]
        public async Task<IActionResult> Update(int id, CreateMenuItemDto dto)
        {
            await _service.UpdateAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "RestaurantOwner")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }

}


//using FoodDelivery.DTOs;
//using FoodDelivery.Services.Interfaces;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;

//namespace FoodDelivery.Controllers
//{
//    [Authorize]
//    [ApiController]
//    [Route("api/[controller]")]
//    public class MenuItemController : ControllerBase
//    {
//        private readonly IMenuItemService _service;

//        public MenuItemController(IMenuItemService service)
//        {
//            _service = service;
//        }

//        [HttpGet]
//        public async Task<IActionResult> GetAll()
//        {
//            return Ok(await _service.GetAllAsync());
//        }

//        [HttpGet("{id}")]
//        [AllowAnonymous]
//        public async Task<IActionResult> Get(int id)
//        {
//            var item = await _service.GetByIdAsync(id);
//            if (item == null) return NotFound();
//            return Ok(item);
//        }

//        [HttpPost]
//        [Authorize(Roles = "RestaurantOwner")]
//        public async Task<IActionResult> Create(CreateMenuItemDto dto)
//        {
//            var created = await _service.AddAsync(dto);
//            return CreatedAtAction(nameof(Get), new { id = created.ItemID }, created);
//        }

//        [HttpPut("{id}")]
//        [Authorize(Roles = "RestaurantOwner")]
//        public async Task<IActionResult> Update(int id, CreateMenuItemDto dto)
//        {
//            await _service.UpdateAsync(id, dto);
//            return NoContent();
//        }

//        [HttpDelete("{id}")]
//        [Authorize(Roles = "RestaurantOwner")]
//        public async Task<IActionResult> Delete(int id)
//        {
//            await _service.DeleteAsync(id);
//            return NoContent();
//        }
//    }
//}