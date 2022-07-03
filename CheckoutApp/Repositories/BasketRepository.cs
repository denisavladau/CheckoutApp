using CheckoutApp.Data;
using CheckoutApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckoutApp.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly CheckoutAppContext _context;

        public BasketRepository(CheckoutAppContext context)
        {
            _context = context;
        }

        public async Task Create(BasketCreateDto basket)
        {
            var customer = _context.Customer.FirstOrDefault(x => x.Name == basket.CustomerName);
            if (customer == null)
            {
                throw new InvalidOperationException("The customer doesn't exist!");
            }

            var newBasket = new Basket
            {
                Customer = customer,
                PaysVAT = basket.PaysVAT,
                Payed = false
            };

            _context.Basket.Add(newBasket);

            await _context.SaveChangesAsync();

        }

        public async Task<BasketDto> GetById(int id)
        {
            var basket = await _context.Basket.Where(x => x.Id == id).Select(x => new BasketDto
            {
                Id = x.Id,
                Closed = x.Closed,
                Customer = x.Customer,
                Payed = x.Payed,
                PaysVAT = x.PaysVAT,
                TotalGross = 0,
                TotalNet = 0
            }).FirstOrDefaultAsync();

            var basketItemsItemIds = _context.BasketItems.Where(x => x.BasketId == basket.Id).Select(x => x.ItemId);
            if (basketItemsItemIds.Any())
            {
                basket.Items = _context.Item.Where(x => basketItemsItemIds.Contains(x.Id));
                basket.TotalNet = basket.Items.Any() ? basket.Items.Select(x => x.Price).Sum() : 0;
                basket.TotalGross = basket.TotalNet != 0 ? CalulateTotalGross(basket.TotalNet, basket.PaysVAT) : 0;
            }

            return basket;
        }

        public async Task AddItemsToBasket(int id, int itemId)
        {
            var basket = _context.Find<Basket>(id);

            if (basket == null)
            {
                throw new InvalidOperationException("Basket doesn't exist!");
            }

            if (basket.Closed)
            {
                throw new InvalidOperationException("Basket is closed, you can not add any items!");
            }

            await _context.BasketItems.AddAsync(new BasketItems
            {
                BasketId = id,
                ItemId = itemId
            });
            await _context.SaveChangesAsync();
        }

        public async Task CloseBasket(int id, BasketUpdatePartialDto basket)
        {
            var basketToUpdate = _context.Find<Basket>(id);

            if (basketToUpdate != null)
            {
                basketToUpdate.Closed = basket.Close;
                basketToUpdate.Payed = basket.Payed;
                await _context.SaveChangesAsync();
            }
        }

        async Task<IEnumerable<BasketDto>> IBasketRepository.GetAll()
        {
            var baskets = await _context.Basket.Select(x => new BasketDto
            {
                Id = x.Id,
                Closed = x.Closed,
                Customer = x.Customer,
                Payed = x.Payed,
                PaysVAT = x.PaysVAT,
                TotalGross = 0,
                TotalNet = 0
            }).ToListAsync();



            foreach (var basket in baskets)
            {
                var basketItemsItemIds = _context.BasketItems.Where(x => x.BasketId == basket.Id).Select(x => x.ItemId);
                if (basketItemsItemIds.Any())
                {
                    basket.Items = _context.Item.Where(x => basketItemsItemIds.Contains(x.Id));
                    basket.TotalNet = basket.Items.Any() ? basket.Items.Select(x => x.Price).Sum() : 0;
                    basket.TotalGross = basket.TotalNet != 0 ? CalulateTotalGross(basket.TotalNet, basket.PaysVAT) : 0;
                }

            }

            return baskets;
        }

        double CalulateTotalGross(double totalNet, bool paysVAT)
        {
            return paysVAT ? 0.1 * totalNet + totalNet : totalNet;
        }
    }
}
