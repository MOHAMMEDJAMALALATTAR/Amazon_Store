using System;
using System.Collections.Generic;

#nullable disable

namespace Amazon_Store.Models
{
    public partial class Item
    {
        public int Id { get; set; }
        public string NameItem { get; set; }
        public int? SubcategoryId { get; set; }

        public virtual Subcategory Subcategory { get; set; }
    }
}
