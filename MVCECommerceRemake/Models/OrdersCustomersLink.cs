﻿using System;
using System.Collections.Generic;

namespace MVCECommerceRemake.Models
{
    public partial class OrdersCustomersLink
    {
        public int CustomerId { get; set; }
        public int OrderId { get; set; }
    }
}
