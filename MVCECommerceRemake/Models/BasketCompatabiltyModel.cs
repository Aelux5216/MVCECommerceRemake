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
            this.Bvm = new BasketViewModel();
            this.Pvm = new ProductsCategoryViewModel();
        }

        public BasketViewModel Bvm { get; set; }
        public ProductsCategoryViewModel Pvm { get; set; }
    }
}
