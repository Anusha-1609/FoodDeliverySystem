using Microsoft.AspNetCore.Mvc;
using FoodDelivery.DTOs;
using FoodDelivery.Services.Interfaces;

namespace FoodDelivery.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;

        public CustomerController(ICustomerService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var customer = await _service.GetByIdAsync(id);
            return customer == null ? NotFound() : Ok(customer);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(CreateCustomerDto dto)
        {
            var result = await _service.RegisterAsync(dto);
            return result ? Ok("Registered") : Conflict("Email already exists");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var user = await _service.LoginAsync(dto);
            return user == null ? Unauthorized() : Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CreateCustomerDto dto)
        {
            var result = await _service.UpdateAsync(id, dto);
            return result ? Ok() : NotFound();
        }
    }
}