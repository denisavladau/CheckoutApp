using CheckoutApp.Data;
using CheckoutApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CheckoutApp.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly CheckoutAppContext _context;

        public ItemRepository(CheckoutAppContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Item>> Get()
        {
            var items = await _context.Item.ToListAsync();

            return items;
        }

        public async Task Create(Item item)
        {
            var newItem = new Item
            {
                Name = item.Name,
                Price = item.Price
            };

            _context.Item.Add(newItem);

            await _context.SaveChangesAsync();
        }
    }
}
