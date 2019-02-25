using System;
using OIT.Core.Model;
using System.Collections.Generic;

namespace OM.Entity.Domain
{
    public class Category : BaseDomain
    {
        public Category()
        {
            SubCategories = new HashSet<Category>();
            Products = new HashSet<Product>();
        }


        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<int> TopCategoryId { get; set; }

        public virtual Category TopCategory { get; set; }
        public virtual ICollection<Category> SubCategories { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}