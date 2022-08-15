﻿using System;
using System.Collections.Generic;

#nullable disable

namespace EshopApi.Domains
{
    public partial class Product
    {
        public Product()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int? Size { get; set; }
        public string Varienty { get; set; }
        public double? Price { get; set; }
        public string Statust { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
