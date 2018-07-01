using System;
using System.Collections.Generic;

namespace MVCECommerceRemake.Models
{
    public partial class Basket
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int? Quantity { get; set; }
    }
}
