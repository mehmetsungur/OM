using OIT.Core.Model;
using System;

namespace OM.Entity.Domain
{
    public class Task : BaseDomain
    {
        public string FromAss { get; set; }
        public string ToAss { get; set; }
        public string Name { get; set; }
        public bool State { get; set; }
        public string Description { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}