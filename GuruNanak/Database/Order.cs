using System;
using System.Collections.Generic;

#nullable disable

namespace GuruNanak.Database
{
    public partial class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public int ProductId { get; set; }
        public decimal TotalProductPrice { get; set; }
        public int Qty { get; set; }

        public virtual Product Product { get; set; }
    }
}
