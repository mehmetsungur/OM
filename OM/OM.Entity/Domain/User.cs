using System;
using System.Collections.Generic;
using OIT.Core.Model;

namespace OM.Entity.Domain
{
    public class User : BaseDomain
    {

        public User()
        {
            Tasks = new HashSet<Task>();
        }

        public string FName { get; set; }
        public string LName { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Photo { get; set; }
        public Nullable<int> RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}