using System;
using OIT.Core.Model;
using System.Collections.Generic;

namespace OM.Entity.Domain
{
    public class Work : BaseDomain
    {
        public Work()
        {
            Products = new HashSet<Product>();
        }

        public string CompanyName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime BillDate { get; set; }
        public string BillNumber { get; set; }
        public decimal Price { get; set; }
        public bool IsPay { get; set; }
        public string Personnel { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public Nullable<int> WorkTypeId { get; set; }
        public Nullable<int> CompanyId { get; set; }

        public virtual Company Company { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}