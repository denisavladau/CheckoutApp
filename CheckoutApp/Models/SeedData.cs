using CheckoutApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace CheckoutApp.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CheckoutAppContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<CheckoutAppContext>>()))
            {
                if (context.Item.Any())
                {
                    return;
                }

                context.Item.AddRange(
                    new Item
                    {
                        Name = "Tomato",
                        Price = 20
                    },
                    new Item
                    {
                        Name = "Juice",
                        Price = 10
                    },
                    new Item
                    {
                        Name = "Potato",
                        Price = 15
                    },
                    new Item
                    {
                        Name = "Bread",
                        Price = 5
                    },
                    new Item
                    {
                        Name = "Egg",
                        Price = 5
                    }
                );

                context.Customer.AddRange(
                    new Customer
                    {
                        Name = "Andrei"
                    },
                    new Customer
                    {
                        Name = "Denisa"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
