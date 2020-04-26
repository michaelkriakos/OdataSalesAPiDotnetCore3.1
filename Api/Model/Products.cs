using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Model
{
    public partial class Products
    {
        public Products()
        {
            Sales = new HashSet<Sales>();
        }
[Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }

        public virtual ICollection<Sales> Sales { get; set; }
    }
}
