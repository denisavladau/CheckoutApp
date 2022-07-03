using CheckoutApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckoutApp.Repositories
{
    public interface ICustomersRepository
    {
        Task<IEnumerable<Customer>> Get();
        Task Create(Customer customer);
    }
}
