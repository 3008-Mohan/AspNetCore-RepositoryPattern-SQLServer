using Microsoft.AspNetCore.Mvc;
using RepositoryPatternDemo.Models;
using RepositoryPatternDemo.Repositories;


namespace RepositoryPatternDemo.Controllers
{
    public class CustomersController: ControllerBase
    {
        private readonly ICustomerRepository _repository;
        public CustomersController(ICustomerRepository repository)
        {
            _repository = repository;
        }
        [HttpGet("api/[controller]")]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _repository.GetAllAsync();
            return Ok(customers);
        }
        [HttpGet("api/[controller]/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _repository.GetByIdAsync(id);
            if (customer == null) return NotFound();
            return Ok(customer);
        }
        [HttpPost("api/[controller]")]
        public async Task<IActionResult> Create(Customer customer)
        {
            await _repository.AddAsync(customer);
            await _repository.SaveAsync();
            return CreatedAtAction(nameof(GetById), new { id = customer.Id }, customer);
        }
    }
}
