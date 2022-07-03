using CheckoutApp.Data;
using CheckoutApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CheckoutApp.Repositories
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly CheckoutAppContext _context;

        public CustomersRepository(CheckoutAppContext context)
        {
            _context = context;
        }
        public async  Task<IEnumerable<Customer>> Get()
        {
            return await _context.Customer.ToListAsync();
        }

        public async Task Create(Customer customer)
        {
            var newCustomer = new Customer
            {
                Name = customer.Name,
            };

            _context.Customer.Add(newCustomer);

            await _context.SaveChangesAsync();
        }
    }
}
