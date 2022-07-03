using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CheckoutApp.Models;
using CheckoutApp.Repositories;

namespace CheckoutApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : Controller
    {
        readonly ICustomersRepository _repository;

        public CustomersController(ICustomersRepository repository)
        {
            _repository = repository;
        }

        // GET: Customers
        [HttpGet]
        public async Task<IEnumerable<Customer>> Get()
        {
            return await _repository.Get();
        }

        [HttpPost]
        public async Task Create([FromBody] Customer payload)
        {
            await _repository.Create(payload);
        }
    }
}
