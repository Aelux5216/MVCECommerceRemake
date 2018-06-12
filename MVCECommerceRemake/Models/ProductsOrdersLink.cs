using System;
using System.Collections.Generic;

namespace MVCECommerceRemake.Models
{
    public partial class ProductsOrdersLink
    {
        public int OrderId { get; set; }
        public string ProductId { get; set; }
        public int QuantityOrdered { get; set; }
    }
}
