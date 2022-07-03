using CheckoutApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckoutApp.Repositories
{
    public interface IItemRepository
    {
        Task<IEnumerable<Item>> Get();
        Task Create(Item item);
    }
}
