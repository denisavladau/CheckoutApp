using System.Collections.Generic;

namespace CheckoutApp.Models
{
    public class BasketDto
    {
        public int Id { get; set; }
        public IEnumerable<Item> Items { get; set; }
        public Customer Customer { get; set; }
        public bool PaysVAT { get; set; }
        public bool Closed { get; set; }
        public bool Payed { get; set; }
        public double TotalNet { get; set; }
        public double TotalGross { get; set; }
    }
}
