﻿using System;
using System.Collections.Generic;

#nullable disable

namespace EshopApi.Domains
{
    public partial class SalesPerson
    {
        public SalesPerson()
        {
            Orders = new HashSet<Order>();
        }

        public int SalesPersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Ciry { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
