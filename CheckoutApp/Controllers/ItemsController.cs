using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CheckoutApp.Models;
using CheckoutApp.Repositories;

namespace CheckoutApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        readonly IItemRepository _repository;

        public ItemsController(IItemRepository repository)
        {
            _repository = repository;
        }

        // GET: Items
        [HttpGet]
        public async Task<IEnumerable<Item>> Get()
        {
            return await _repository.Get();
        }

        [HttpPost]
        public async Task Create([FromBody] Item payload)
        {
            await _repository.Create(payload);
        }
    }
}
