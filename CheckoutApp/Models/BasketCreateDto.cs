using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckoutApp.Models
{
    public class BasketCreateDto
    {
        public string CustomerName { get; set; }
        public bool PaysVAT { get; set; }
    }
}
