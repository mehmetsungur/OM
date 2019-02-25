using OIT.Core.Model;
using System.Collections.Generic;

namespace OM.Entity.Domain
{
    public class Role : BaseDomain
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}