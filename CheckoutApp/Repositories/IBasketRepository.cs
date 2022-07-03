using CheckoutApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CheckoutApp.Repositories
{
    public interface IBasketRepository
    {
        Task<IEnumerable<BasketDto>> GetAll();
        Task<BasketDto> GetById(int id);
        Task Create(BasketCreateDto basket);
        Task AddItemsToBasket(int id, int itemId);
        Task CloseBasket(int id, BasketUpdatePartialDto basket);
    }
}
