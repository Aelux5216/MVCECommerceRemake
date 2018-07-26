using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCECommerceRemake.Models
{
    public class BasketCompatabiltyModel
    {
        public BasketCompatabiltyModel()
        {
            this.basket = new Basket();
            this.Bvm = new BasketViewModel();
            this.Pvm = new ProductsCategoryViewModel();
        }
        public Basket basket { get; set; }
        public BasketViewModel Bvm { get; set; }
        public ProductsCategoryViewModel Pvm { get; set; }
        public string SelectedProduct { get; set; }
        public int CurrentQuantity { get; set; }
    }
}
