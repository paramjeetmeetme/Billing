using System;
using System.Collections.Generic;

namespace GuruNanak.Database
{
    public partial class ProductCategory
    {
        public ProductCategory()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Type { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; }
    }
}
