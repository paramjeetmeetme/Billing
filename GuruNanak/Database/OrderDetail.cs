using System;
using System.Collections.Generic;

#nullable disable

namespace GuruNanak.Database
{
    public partial class OrderDetail
    {
        public int Id { get; set; }
        public string ProductDetails { get; set; }
        public decimal? Discount { get; set; }
        public decimal? TotalPrice { get; set; }
    }
}
