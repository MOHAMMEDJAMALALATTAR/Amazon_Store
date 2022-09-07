using System;
using System.Collections.Generic;

#nullable disable

namespace Amazon_Store.Models
{
    public partial class Subcategory
    {
        public Subcategory()
        {
            Items = new HashSet<Item>();
        }

        public int Id { get; set; }
        public string NameSubcategory { get; set; }
        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
