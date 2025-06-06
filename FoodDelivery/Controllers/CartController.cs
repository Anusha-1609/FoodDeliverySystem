using FoodDelivery.DTOs;
using FoodDelivery.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodDelivery.Controllers
{
    [Authorize(Roles = "Customer")]
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _service;

        public CartController(ICartService service)
        {
            _service = service;
        }

        [HttpGet("{cartId}/{customerId}")]
        public async Task<IActionResult> GetById(int cartId, int customerId)
        {
            var result = await _service.GetByIdAsync(cartId, customerId);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetByCustomerId(int customerId)
        {
            return Ok(await _service.GetByCustomerIdAsync(customerId));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCartDto dto)
        {
            var created = await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetByCustomerId), new { customerId = created.CustomerID }, created);
        }

        [HttpPut("{cartId}/{customerId}")]
        public async Task<IActionResult> Update(int cartId, int customerId, CreateCartDto dto)
        {
            await _service.UpdateAsync(cartId, customerId, dto);
            return NoContent();
        }

        [HttpDelete("{cartId}/{customerId}")]
        public async Task<IActionResult> Delete(int cartId, int customerId)
        {
            await _service.DeleteAsync(cartId, customerId);
            return NoContent();
        }
    }

}



//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Authorization;
//using FoodDelivery.DTOs;
//using FoodDelivery.Services.Interfaces;

//namespace FoodDelivery.Controllers
//{
//    [Authorize(Roles = "Customer")]
//    [ApiController]
//    [Route("api/[controller]")]
//    public class CartController : ControllerBase
//    {
//        private readonly ICartService _service;

//        public CartController(ICartService service)
//        {
//            _service = service;
//        }

//        [HttpGet("customer/{customerId}")]
//        public async Task<IActionResult> GetByCustomerId(int customerId)
//        {
//            return Ok(await _service.GetByCustomerIdAsync(customerId));
//        }

//        [HttpPost]
//        public async Task<IActionResult> Create(CreateCartDto dto)
//        {
//            var created = await _service.AddAsync(dto);
//            return CreatedAtAction(nameof(GetByCustomerId), new { customerId = created.CustomerID }, created);
//        }

//        [HttpPut("{id}")]
//        public async Task<IActionResult> Update(int id, CreateCartDto dto)
//        {
//            await _service.UpdateAsync(id, dto);
//            return NoContent();
//        }

//        [HttpDelete("{id}")]
//        public async Task<IActionResult> Delete(int id)
//        {
//            await _service.DeleteAsync(id);
//            return NoContent();
//        }
//    }
//}





