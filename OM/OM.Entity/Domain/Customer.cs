using System;
using OIT.Core.Model;

namespace OM.Entity.Domain
{
    public class Customer : BaseDomain
    {
        public string CompanyName { get; set; }
        public string Contact { get; set; }
        public string Caption { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public Nullable<int> CompanyId { get; set; }

        public virtual Company Company { get; set; }
    }
}