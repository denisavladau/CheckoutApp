using Microsoft.EntityFrameworkCore;
using CheckoutApp.Models;

namespace CheckoutApp.Data
{
    public class CheckoutAppContext : DbContext
    {
        public CheckoutAppContext(DbContextOptions<CheckoutAppContext> options)
            : base(options)
        {
        }

        public DbSet<Item> Item { get; set; }

        public DbSet<Basket> Basket { get; set; }

        public DbSet<Customer> Customer { get; set; }

        public DbSet<BasketItems> BasketItems {get;set;}
    }
}
