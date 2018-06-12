using System;
using System.Collections.Generic;

namespace MVCECommerceRemake.Models
{
    public partial class Customers
    {
        public double CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string HouseNameNo { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Postcode { get; set; }
        public string Email { get; set; }
    }
}
