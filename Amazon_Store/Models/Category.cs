using System;
using System.Collections.Generic;

#nullable disable

namespace Amazon_Store.Models
{
    public partial class Category
    {
        public Category()
        {
            Subcategories = new HashSet<Subcategory>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Subcategory> Subcategories { get; set; }
    }
}
