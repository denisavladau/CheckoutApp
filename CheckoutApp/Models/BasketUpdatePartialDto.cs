using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckoutApp.Models
{
    public class BasketUpdatePartialDto
    {
        public bool Close { get; set; }
        public bool Payed { get; set; }
    }
}
