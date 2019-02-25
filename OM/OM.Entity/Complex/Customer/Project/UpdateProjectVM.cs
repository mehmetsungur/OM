using System;

namespace OM.Entity.Complex.Customer.Project
{
    public class UpdateProjectVM
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Model { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime BillDate { get; set; }
        public string BillNumber { get; set; }
        public decimal Price { get; set; }
        public bool IsPay { get; set; }
        public string Description { get; set; }
    }
}