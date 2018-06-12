using System;
using System.Collections.Generic;

namespace MVCECommerceRemake.Models
{
    public partial class ProductsOrdersLink
    {
        public string OrderId { get; set; }
        public string ProductId { get; set; }
        public string QuantityOrdered { get; set; }
    }
}
