using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCECommerceRemake.Models
{
    public partial class Products
    {
        //[Display(Name = "")]
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal? ProductPrice { get; set; }
        public int ProductQuantity { get; set; }
        public string ProductDescription { get; set; }
        public string ProductCategory { get; set; }
    }
}
