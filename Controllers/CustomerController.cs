
using Microsoft.AspNetCore.Mvc;
using CustomerMongoApi.Repositories;
using CustomerMongoApi.Models;
using System.Threading.Tasks;

namespace CustomerMongoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerRepository _repo;

        public CustomerController(CustomerRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _repo.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var customer = await _repo.GetAsync(id);
            return customer == null ? NotFound() : Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Customer customer)
        {
            await _repo.CreateAsync(customer);
            return CreatedAtAction(nameof(GetById), new { id = customer.Id }, customer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Customer customer)
        {
            var existing = await _repo.GetAsync(id);
            if (existing == null) return NotFound();
            customer.Id = id;
            await _repo.UpdateAsync(id, customer);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var existing = await _repo.GetAsync(id);
            if (existing == null) return NotFound();
            await _repo.DeleteAsync(id);
            return NoContent();
        }
    }
}
