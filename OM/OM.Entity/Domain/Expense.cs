using System;
using OIT.Core.Model;

namespace OM.Entity.Domain
{
    public class Expense : BaseDomain
    {
        public string Type { get; set; }
        public DateTime ProcessDate { get; set; }
        public string Process { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public DateTime PayDate { get; set; }
        public decimal Price { get; set; }
    }
}