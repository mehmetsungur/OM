using OIT.Core.Model;
using System.Collections.Generic;

namespace OM.Entity.Domain
{
    public class Company : BaseDomain
    {
        public Company()
        {
            Works = new HashSet<Work>();
            Meets = new HashSet<Meet>();
            Customers = new HashSet<Customer>();
        }

        public string Logo { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string State { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Work> Works { get; set; }
        public virtual ICollection<Meet> Meets { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}