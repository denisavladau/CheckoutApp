using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckoutApp.Models
{
    public class BasketItems
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public int BasketId { get; set; }
        public Basket Basket { get; set; }
    }
}
