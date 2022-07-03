using System.Collections.Generic;

namespace CheckoutApp.Models
{
    public class Basket
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public bool PaysVAT { get; set; }
        public bool Closed { get; set; }
        public bool Payed { get; set; }
    }
}
