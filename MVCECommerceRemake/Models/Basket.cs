using System;
using System.Collections.Generic;

namespace MVCECommerceRemake.Models
{
    public partial class Basket
    {
        public decimal CustomerId { get; set; }
        public string ProductId { get; set; }
        public double Quantity { get; set; }
    }
}
