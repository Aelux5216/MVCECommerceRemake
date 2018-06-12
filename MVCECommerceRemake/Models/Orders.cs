using System;
using System.Collections.Generic;

namespace MVCECommerceRemake.Models
{
    public partial class Orders
    {
        public int OrderId { get; set; }
        public string OrderStatus { get; set; }
        public string OrderDate { get; set; }
    }
}
