using System;
using OIT.Core.Model;
using System.Collections.Generic;

namespace OM.Entity.Domain
{
    public class Product : BaseDomain
    {
        public string Serial { get; set; }
        public string BrandName { get; set; }
        public string Model { get; set; }
        public string State { get; set; }
        public string Periodic { get; set; }
        public string WorkHeight { get; set; }
        public string WorkCapacity { get; set; }
        public string Description { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public Nullable<int> WorkId { get; set; }
        public Nullable<int> BrandId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Work Work { get; set; }
    }
}