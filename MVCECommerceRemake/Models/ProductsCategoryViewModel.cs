using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCECommerceRemake.Models
{
    public class ProductsCategoryViewModel
    {
        public List<Products> products { get; set; }
        public SelectList categories;
        public string productCategory { get; set; } 
    }
}
