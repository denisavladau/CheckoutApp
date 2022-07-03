using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CheckoutApp.Data;
using CheckoutApp.Models;
using CheckoutApp.Repositories;

namespace CheckoutApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        readonly IBasketRepository _repository;
        private readonly CheckoutAppContext _context;

        public BasketController(IBasketRepository repository, CheckoutAppContext context)
        {
            _repository = repository;
            _context = context;
        }

        // GET: Baskets
        [HttpGet]
        public async Task<IEnumerable<BasketDto>> Get()
        {
            return await _repository.GetAll();
        }

        [HttpGet]
        [Route("baskets/{id}")]
        public async Task<BasketDto> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        [HttpPost]
        public async Task Create([FromBody] BasketCreateDto payload)
        {
            await _repository.Create(payload);
        }

        [HttpPut]
        [Route("baskets/{id}/{itemId}")]
        public async Task Update(int id, int itemId)
        {
            await _repository.AddItemsToBasket(id, itemId);
        }

        [HttpPatch]
        [Route("baskets/{id}")]
        public async Task UpdatePartial(int id, [FromBody] BasketUpdatePartialDto payload)
        {
            await _repository.CloseBasket(id, payload);
        }
    }
}
