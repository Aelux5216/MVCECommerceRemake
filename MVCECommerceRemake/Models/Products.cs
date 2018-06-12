using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCECommerceRemake.Models
{
    public partial class Products
    {
        public uint ProductId { get; set; }
        [Display(Name="Name")]
        [DataType(DataType.Text)]
        public string ProductName { get; set; }
        public decimal? ProductPrice { get; set; }
        public string ProductQuantity { get; set; }
        public string ProductDescription { get; set; }
        public string ProductCategory { get; set; }
    }
}
